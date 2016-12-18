using System.Threading.Tasks;

namespace ntrbase.Bot
{
    class SoftResetbot7
    {
        public enum srbotStates { botstart, startdialog, testdialog1, readparty, continuedialog, testdialog2, exitdialog, filter, testspassed, softreset, reconnect, connpatch, nickname, botexit };

        // Bot variables
        public int botresult;
        public int resetNo;
        public bool botstop;

        // Class variables
        private int botState;
        private int attempts;
        private int maxreconnect;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        // Input variables
        private int mode;

        // DataoOffsets
        private uint dialogOff = 0x63DD68;
        private uint dialogIn = 0x09;
        private uint dialogOut = 0x08;
        private uint partyOff = 0x34195E10;

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
            while (!botstop)
            {
                switch (botState)
                {
                    case (int)srbotStates.botstart:
                        Report("Bot start");
                        if (mode == 0 || mode == 1)
                            botState = (int)srbotStates.startdialog;
                        else
                            botState = (int)srbotStates.botexit;
                        break;

                    case (int)srbotStates.startdialog:
                        Report("Start dialog");
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
                        Report("Test if dialog has started");
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
                        Report("Continue dialog");
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
                        Report("Test if dialog has finished");
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
                        Report("Exit dialog");
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
                        Report("Try to read party");
                        waitTaskint = Program.helper.waitPartyRead(partyOff, 1);
                        long dataready = await waitTaskint;
                        if (dataready >= 0)
                        {
                            attempts = 0;
                            Report("PID: 0x" + dataready.ToString("X8"));
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
                        Report("All tests passed!");
                        botresult = 4;
                        botState = (int)srbotStates.botexit;
                        break;

                    case (int)srbotStates.softreset:
                        resetNo++;
                        Report("Sof-reset #" + resetNo.ToString());
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
                        Report("Try reconnect");
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
                        Report("Apply NFC patch");
                        waitTaskbool = Program.helper.waitNTRwrite(0x3DFFD0, 0xE3A01000, Program.gCmdWindow.pid);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)srbotStates.startdialog;
                        }
                        else
                        {
                            attempts++;
                            botresult = 1;
                            botState = (int)srbotStates.connpatch;
                        }
                        break;

                    case (int)srbotStates.nickname:
                        Report("Nickname screen");
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

                    case (int)srbotStates.botexit:
                        Report("Bot stop");
                        botstop = true;
                        break;

                    default:
                        Report("Bot stop");
                        botresult = -1;
                        botstop = true;
                        break;

                }
                if (attempts > 10)
                { // Too many attempts
                    if (maxreconnect > 0)
                    {
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
                        Report("Bot stop");
                        botstop = true;
                    }
                }
            }
            return botresult;
        }

        private void Report(string log)
        {
            Program.gCmdWindow.Addlog(log);
        }
    }
}
