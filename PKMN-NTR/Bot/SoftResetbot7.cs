using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    class SoftResetbot7
    {
        public enum srbotStates { botstart, selectmode, startdialog, testdialog1, readparty, continuedialog, testdialog2, exitdialog, filter, testspassed, softreset, reconnect, connpatch, nickname, triggerbattle, testdialog3, continuedialog2, readopp, botexit };

        // Bot variables
        public int botresult;
        public int resetNo;
        public bool botstop;

        // Class variables
        private int botState;
        private int attempts;
        private int maxreconnect;
        private long dataready;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        // Input variables
        private int mode;

        // DataoOffsets
        private uint dialogOff = 0x63DD68;
        private uint dialogIn = 0x09;
        private uint dialogOut = 0x08;
        private uint partyOff = 0x34195E10;
        private uint opponentOff = 0x3254F4AC;

        public SoftResetbot7(int selectedmode)
        {
            botresult = 0;
            resetNo = 0;
            botstop = false;

            botState = (int)srbotStates.botstart;
            attempts = 0;
            maxreconnect = 10;

            mode = selectedmode;
        }

        public async Task<int> RunBot()
        {
            try
            {
                while (!botstop)
                {
                    switch (botState)
                    {
                        case (int)srbotStates.botstart:
                            Report("Bot: START Gen 7 Soft-reset bot");
                            botState = (int)srbotStates.selectmode;
                            break;

                        case (int)srbotStates.selectmode:
                            if (mode == 0 || mode == 1)
                                botState = (int)srbotStates.startdialog;
                            else if (mode == 2)
                                botState = (int)srbotStates.triggerbattle;
                            else
                                botState = (int)srbotStates.botexit;
                            break;

                        case (int)srbotStates.startdialog:
                            Report("Bot: Start dialog");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.testdialog1;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.startdialog;
                            }
                            break;

                        case (int)srbotStates.testdialog1:
                            Report("Bot: Test if dialog has started");
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogIn, 0x01);
                            if (await waitTaskbool)
                            {
                                if (mode == 1)
                                    attempts = -15; // Type:Null dialog is longer
                                else
                                    attempts = 0;
                                botState = (int)srbotStates.continuedialog;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.startdialog;
                            }
                            break;

                        case (int)srbotStates.continuedialog:
                            Report("Bot: Continue dialog");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.testdialog2;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.continuedialog;
                            }
                            break;

                        case (int)srbotStates.testdialog2:
                            Report("Bot: Test if dialog has finished");
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogOut, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.readparty;
                            }
                            else if (Program.helper.lastRead == 0x0F || Program.helper.lastRead == 0x03)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.exitdialog;
                            }
                            else if (Program.helper.lastRead == 0x11)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.nickname;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.continuedialog;
                            }
                            break;

                        case (int)srbotStates.exitdialog:
                            Report("Bot: Exit dialog");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.readparty;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.exitdialog;
                            }
                            break;

                        case (int)srbotStates.readparty:
                            Report("Bot: Try to read party");
                            waitTaskint = Program.helper.waitPartyRead(partyOff, 1);
                            dataready = await waitTaskint;
                            if (dataready >= 0)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.filter;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.exitdialog;
                            }
                            break;

                        case (int)srbotStates.filter:
                            bool testsok = Program.gCmdWindow.CheckSoftResetFilters();
                            if (testsok)
                                botState = (int)srbotStates.testspassed;
                            else
                                botState = (int)srbotStates.softreset;
                            break;

                        case (int)srbotStates.testspassed:
                            Report("Bot: All tests passed!");
                            botresult = 4;
                            botState = (int)srbotStates.botexit;
                            break;

                        case (int)srbotStates.softreset:
                            resetNo++;
                            Report("Bot: Sof-reset #" + resetNo.ToString());
                            waitTaskbool = Program.helper.waitSoftReset();
                            if (await waitTaskbool)
                            {
                                botState = (int)srbotStates.reconnect;
                            }
                            else
                            {
                                botresult = 2;
                                botState = (int)srbotStates.botexit;
                            }
                            break;

                        case (int)srbotStates.reconnect:
                            await Task.Delay(6000);
                            Report("Bot: Try reconnect");
                            waitTaskbool = Program.gCmdWindow.Reconnect();
                            if (await waitTaskbool)
                            {
                                botState = (int)srbotStates.connpatch;
                            }
                            else
                            {
                                botresult = -1;
                                botState = (int)srbotStates.botexit;
                            }
                            break;

                        case (int)srbotStates.connpatch:
                            Report("Bot: Apply NFC patch");
                            waitTaskbool = Program.helper.waitNTRwrite(0x3DFFD0, 0xE3A01000, Program.gCmdWindow.pid);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.selectmode;
                            }
                            else
                            {
                                attempts++;
                                botresult = 1;
                                botState = (int)srbotStates.connpatch;
                            }
                            break;

                        case (int)srbotStates.nickname:
                            Report("Bot: Nickname screen");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keySTART);
                            await Task.Delay(250);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.testdialog2;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.nickname;
                            }
                            break;

                        case (int)srbotStates.triggerbattle:
                            Report("Bot: Try to trigger battle");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.testdialog3;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.triggerbattle;
                            }
                            break;

                        case (int)srbotStates.testdialog3:
                            Report("Bot: Test if dialog has started");
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogIn, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.continuedialog2;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.triggerbattle;
                            }
                            break;

                        case (int)srbotStates.continuedialog2:
                            Report("Bot: Continue dialog");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.readopp;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.continuedialog2;
                            }
                            break;

                        case (int)srbotStates.readopp:
                            Report("Bot: Try to read opponent");
                            waitTaskint = Program.helper.waitPokeRead(opponentOff);
                            dataready = await waitTaskint;
                            if (dataready >= 0)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.filter;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.continuedialog2;
                            }
                            break;

                        case (int)srbotStates.botexit:
                            Report("Bot: STOP Gen 7 Soft-reset bot");
                            botstop = true;
                            break;

                        default:
                            Report("Bot: STOP Gen 7 Soft-reset bot");
                            botresult = -1;
                            botstop = true;
                            break;

                    }
                    if (attempts > 10)
                    { // Too many attempts
                        if (maxreconnect > 0)
                        {
                            Report("Bot: Try reconnection to fix error");
                            waitTaskbool = Program.gCmdWindow.Reconnect();
                            maxreconnect--;
                            if (await waitTaskbool)
                            {
                                await Task.Delay(5000);
                                attempts = 0;
                            }
                            else
                            {
                                botresult = -1;
                                botstop = true;
                            }
                        }
                        else
                        {
                            Report("Bot: STOP Gen 7 Soft-reset bot");
                            botstop = true;
                        }
                    }
                }
                return botresult;
            }
            catch (Exception ex)
            {
                Report("Bot: Exception detected:");
                Report(ex.Source);
                Report(ex.Message);
                Report(ex.StackTrace);
                Report("Bot: STOP Gen 6 Soft-reset bot");
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void Report(string log)
        {
            Program.gCmdWindow.addtoLog(log);
        }
    }
}
