using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    class SoftResetbot7
    {
        public enum srbotStates { botstart, selectmode, startdialog, testdialog1, readparty, continuedialog, testdialog2, exitdialog, filter, testspassed, softreset, skiptitle, reconnect, connpatch, startgame, nickname, triggerbattle, testdialog3, continuedialog2, readopp, soluna1, soluna2, soluna3, soluna4, soluna5, runbattle1, runbattle2, runbattle3, writehoney, openmenu, testmenu, openbag, testbag, selecthoney, activatehoney, testwild, waitwild, readwild, dismissmsg, botexit };

        // Bot variables
        public int botresult;
        public int resetNo;
        public bool botstop;

        // Class variables
        private int botState;
        private int attempts;
        private int honeynum;
        private int maxreconnect;
        private long dataready;
        private bool isub;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        // Input variables
        private int mode;
        private int species;

        // DataoOffsets
        private uint dialogOff = 0x67499C; // 1.0: 0x63DD68;
        private uint dialogIn = 0x80000000; // 1.0: 0x0C;
        private uint dialogOut = 0x00000000; // 1.0: 0x0B;
        private uint battleOff = 0x6747D8;// 1.0: 0x6731A4;
        private uint battleIn = 0x40400000; // 1.0: 0x00000000;
        private uint battleOut = 0x00000000; // 1.0: 0x00FFFFFF;
        private uint partyOff = 0x34195E10;
        private uint opponentOff = 0x3254F4AC;
        private uint itemOff = 0x330D5934;
        private uint honey = 0x000F9C5E;
        private uint menuOff = 0x67496C; // 1.0: 0x672920;
        private uint menuIn = 0x80000000;
        private uint menuOut = 0x00000000;
        private uint bagOff = 0x6747F8; // 1.0: 0x67DF74;
        private uint bagIn = 0x41280000; // 1.0: 0x01;
        private uint bagOut = 0x00000000; // 1.0: 0x03;

        public SoftResetbot7(int selectedmode, int selectedspecies)
        {
            botresult = 0;
            resetNo = 0;
            botstop = false;
            honeynum = 0;
            isub = false;

            botState = (int)srbotStates.botstart;
            attempts = 0;
            maxreconnect = 10;

            mode = selectedmode;
            species = selectedspecies + 1;
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
                            switch (mode)
                            {
                                case 0:
                                case 1:
                                    botState = (int)srbotStates.startdialog;
                                    break;
                                case 2:
                                    botState = (int)srbotStates.triggerbattle;
                                    break;
                                case 3:
                                    resetNo = 1;
                                    botState = (int)srbotStates.soluna1;
                                    break;
                                case 4:
                                case 5:
                                    resetNo = 1;
                                    botState = (int)srbotStates.writehoney;
                                    break;
                                default:
                                    botState = (int)srbotStates.botexit;
                                    break;
                            }
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
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogIn, 0x10000000);
                            if (await waitTaskbool)
                            {
                                if (mode == 1)
                                    attempts = -40; // Type:Null dialog is longer
                                else
                                    attempts = -15;
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
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogOut, 0x10000000);
                            if (await waitTaskbool)
                            {
                                attempts = -10;
                                botState = (int)srbotStates.readparty;
                            }
                            else if (Program.helper.lastRead >= 0x3F000000 && Program.helper.lastRead < 0x40000000)
                            {
                                attempts = -10;
                                botState = (int)srbotStates.exitdialog;
                            }
                            else if (Program.helper.lastRead >= 0x3D000000 && Program.helper.lastRead < 0x3E000000)
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
                            else if (mode == 3)
                            {
                                botState = (int)srbotStates.runbattle1;
                            }
                            else if (mode == 4)
                            {
                                botState = (int)srbotStates.runbattle1;
                            }
                            else if (mode == 5)
                            {
                                botState = (int)srbotStates.runbattle1;
                            }
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
                                botState = (int)srbotStates.skiptitle;
                            }
                            else
                            {
                                botresult = 2;
                                botState = (int)srbotStates.botexit;
                            }
                            break;

                        case (int)srbotStates.skiptitle:
                            await Task.Delay(7000);
                            Report("Bot: Open Menu");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.reconnect;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.skiptitle;
                            }
                            break;

                        case (int)srbotStates.reconnect:
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
                            waitTaskbool = Program.helper.waitNTRwrite(LookupTable.nfcOff, LookupTable.nfcVal, Program.gCmdWindow.pid);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.startgame;
                            }
                            else
                            {
                                attempts++;
                                botresult = 1;
                                botState = (int)srbotStates.connpatch;
                            }
                            break;

                        case (int)srbotStates.startgame:
                            Report("Bot: Start the game");
                            await Task.Delay(1000);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                await Task.Delay(3000);
                                attempts = 0;
                                botState = (int)srbotStates.selectmode;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.startgame;
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
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogIn, 0x10000000);
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

                        case (int)srbotStates.soluna1:
                            Report("Bot: Walk to legendary pokemon");
                            waitTaskbool = Program.helper.waitsitck(0, 100);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.soluna2;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.soluna1;
                            }
                            break;

                        case (int)srbotStates.soluna2:
                            Report("Bot: Trigger battle #" + resetNo);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.soluna3;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.soluna2;
                            }
                            break;

                        case (int)srbotStates.soluna3:
                            Report("Bot: Test if dialog has started");
                            waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogIn, 0x10000000);
                            if (await waitTaskbool)
                            {
                                attempts = -0;
                                botState = (int)srbotStates.soluna4;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.soluna2;
                            }
                            break;

                        case (int)srbotStates.soluna4:
                            Report("Bot: Test if data is available");
                            waitTaskbool = Program.helper.timememoryinrange(battleOff, battleIn, 0x10000, 1000, 20000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.soluna5;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.soluna1;
                            }
                            break;

                        case (int)srbotStates.soluna5:
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
                                botState = (int)srbotStates.soluna2;
                            }
                            break;

                        case (int)srbotStates.runbattle1:
                            Report("Bot: Run from battle");
                            await Task.Delay(1500);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.DpadDOWN);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.runbattle2;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.runbattle1;
                            }
                            break;

                        case (int)srbotStates.runbattle2:
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.runbattle3;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.runbattle2;
                            }
                            break;

                        case (int)srbotStates.runbattle3:
                            Report("Bot: Test out from battle");
                            waitTaskbool = Program.helper.timememoryinrange(battleOff, battleOut, 0x10000, 1000, 10000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                resetNo++;
                                if (mode == 3)
                                {
                                    botState = (int)srbotStates.soluna1;
                                    await Task.Delay(5000);
                                }
                                else if (isub)
                                {
                                    botState = (int)srbotStates.dismissmsg;
                                    await Task.Delay(5000);
                                }
                                else
                                {
                                    botState = (int)srbotStates.writehoney;
                                    await Task.Delay(4000);
                                }

                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.runbattle1;
                            }
                            break;

                        case (int)srbotStates.writehoney:
                            if (honeynum >= 10)
                            {
                                botState = (int)srbotStates.openmenu;
                            }
                            else
                            {
                                Report("Bot: Give 999 honey");
                                waitTaskbool = Program.helper.waitNTRwrite(itemOff, honey, Program.gCmdWindow.pid);
                                if (await waitTaskbool)
                                {
                                    attempts = 0;
                                    honeynum = 999;
                                    botState = (int)srbotStates.openmenu;
                                }
                                else
                                {
                                    attempts++;
                                    botresult = 1;
                                    botState = (int)srbotStates.writehoney;
                                }
                            }
                            break;

                        case (int)srbotStates.openmenu:
                            Report("Bot: Open Menu");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyX);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.testmenu;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.openmenu;
                            }
                            break;

                        case (int)srbotStates.testmenu:
                            Report("Bot: Test if the menu is open");
                            waitTaskbool = Program.helper.timememoryinrange(menuOff, menuIn, 0x10000000, 1000, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.openbag;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.openmenu;
                            }
                            break;

                        case (int)srbotStates.openbag:
                            Report("Bot: Open Bag");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.testbag;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.openbag;
                            }
                            break;

                        case (int)srbotStates.testbag:
                            Report("Bot: Test if the bag is open");
                            waitTaskbool = Program.helper.timememoryinrange(bagOff, bagIn, 0x10000, 1000, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.selecthoney;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.openbag;
                            }
                            break;

                        case (int)srbotStates.selecthoney:
                            Report("Bot: Select Honey");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.activatehoney;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.selecthoney;
                            }
                            break;

                        case (int)srbotStates.activatehoney:
                            Report("Bot: Trigger battle #" + resetNo);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotStates.testwild;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.openbag;
                            }
                            break;

                        case (int)srbotStates.testwild:
                            Report("Bot: Test if battle is triggered");
                            waitTaskbool = Program.helper.timememoryinrange(bagOff, bagOut, 0x10000, 1000, 10000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                honeynum--;
                                botState = (int)srbotStates.waitwild;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.activatehoney;
                            }
                            break;

                        case (int)srbotStates.waitwild:
                            Report("Bot: Test if data is available");
                            waitTaskbool = Program.helper.timememoryinrange(battleOff, battleIn, 0x10000, 1000, 20000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.readwild;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.activatehoney;
                            }
                            break;

                        case (int)srbotStates.readwild:
                            Report("Bot: Try to read opponent");
                            waitTaskint = Program.helper.waitPokeRead(opponentOff);
                            dataready = await waitTaskint;
                            if (dataready >= 0)
                            {
                                attempts = 0;
                                if (Program.helper.lastRead == species)
                                {
                                    if (mode == 5)
                                    {
                                        isub = true;
                                    }
                                    botState = (int)srbotStates.filter;
                                }
                                else
                                {
                                    isub = false;
                                    botState = (int)srbotStates.runbattle1;
                                }
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotStates.readwild;
                            }
                            break;

                        case (int)srbotStates.dismissmsg:
                            Report("Bot: Dismiss message");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotStates.writehoney;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotStates.dismissmsg;
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
                Report("Bot: STOP Gen 7 Soft-reset bot");
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
