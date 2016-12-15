using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    class BreedingBot7
    {
        public enum breedbotstates { botstart, selectbox, readslot, quickegg, triggerdialog, testdialog1, continuedialog, fixdialog, checknoegg, exitdialog, testdialog2, filter, testspassed, botexit };

        // Bot variables
        public int botresult;
        public bool botstop;
        public string finishmessage;

        // Class variables
        private int botState;
        private int attempts;
        private int maxreconnect;
        private int currentesv;
        private long dataready;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        // Input variables
        private int mode;
        private int currentbox;
        private int currentslot;
        private int quantity;
        private bool readesv;

        // Data offsets
        private uint eggOff = 0x3313EDD8;
        private uint dialogOff = 0x63DD68;
        private uint dialogIn = 0x09;
        private uint dialogOut = 0x08;
        private uint currentboxOff = 0x330D982F;

        //private uint boxesOff = 0x10F1A0;
        //private uint boxesIN = 0x6F0000;
        //private uint boxesOUT = 0x520000;
        //private uint boxesviewOff = 0x672D04;
        //private uint boxesviewIN = 0x00000000;
        //private uint boxesviewOUT = 0x40000000;
        //private uint posXOff = 0x33199260;
        //private uint posYOff = 0x3319E2C4;
        //private uint posZOff = 0x330D6744;

        public BreedingBot7(int selectedmode, int startbox, int amount, bool readesvafterdep)
        {
            botresult = 0;
            botstop = false;
            finishmessage = "";

            botState = (int)breedbotstates.botstart;
            attempts = 0;
            maxreconnect = 10;
            currentesv = 0;
            dataready = 0;

            mode = selectedmode;
            currentbox = startbox - 1;
            currentslot = 0;
            quantity = amount;
            readesv = readesvafterdep;
        }

        public async Task<int> RunBot()
        {
            while (!botstop)
            {
                switch (botState)
                {
                    case (int)breedbotstates.botstart:
                        Report("Bot start");
                        if (mode >= 0)
                            botState = (int)breedbotstates.selectbox;
                        else
                            botState = (int)breedbotstates.botexit;
                        break;

                    case (int)breedbotstates.selectbox:
                        Report("Set start box");
                        waitTaskbool = Program.helper.waitNTRwrite(currentboxOff, Convert.ToUInt32(currentbox), Program.gCmdWindow.pid);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.readslot;
                        }
                        else
                        {
                            attempts++;
                            botresult = 1;
                            botState = (int)breedbotstates.selectbox;
                        }
                        break;

                    case (int)breedbotstates.readslot:
                        Report("Read pokémon from box " + (currentbox + 1) + ", slot " + (currentslot + 1));
                        waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                        dataready = await waitTaskint;
                        switch (dataready)
                        {
                            case -2: // Read error
                                botresult = 2;
                                Report("Error detected");
                                attempts = 11;
                                break;
                            case -1: // Empty slot
                                botState = (int)breedbotstates.quickegg;
                                break;
                            default: // Not empty slot
                                Report("Space is not empty");
                                getNextSlot();
                                botState = (int)breedbotstates.readslot;
                                break;
                        }
                        break;

                    case (int)breedbotstates.quickegg:
                        Report("Produce Egg in Nursery");
                        waitTaskbool = Program.helper.waitNTRwrite(eggOff, 0x01, Program.gCmdWindow.pid);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        else
                        {
                            attempts++;
                            botresult = 1;
                            botState = (int)breedbotstates.quickegg;
                        }
                        break;

                    case (int)breedbotstates.triggerdialog:
                        Report("Start dialog");
                        waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.testdialog1;
                        else
                        {
                            attempts++;
                            botresult = 7;
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        break;

                    case (int)breedbotstates.testdialog1:
                        Report("Test if dialog has started");
                        waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogIn, 0x01);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.continuedialog;
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        break;

                    case (int)breedbotstates.continuedialog:
                        Report("Continue dialog");
                        int i;
                        for (i = 0; i < 6; i++)
                        {
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (!(await waitTaskbool))
                                break;
                        }
                        if (i == 6)
                            botState = (int)breedbotstates.checknoegg;
                        else
                            botState = (int)breedbotstates.fixdialog;
                        break;

                    case (int)breedbotstates.fixdialog:
                        waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.checknoegg;
                        else
                        {
                            attempts++;
                            botresult = 7;
                            botState = (int)breedbotstates.fixdialog;
                        }
                        break;

                    case (int)breedbotstates.checknoegg:
                        waitTaskbool = Program.helper.memoryinrange(eggOff, 0x00, 0x01);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            Report("Egg received");
                            botState = (int)breedbotstates.exitdialog;
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.fixdialog;
                        }
                        break;

                    case (int)breedbotstates.exitdialog:
                        Report("Exit dialog");
                        await Task.Delay(1000);
                        waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                        if (await waitTaskbool)
                        {
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                            if (await waitTaskbool)
                                botState = (int)breedbotstates.testdialog2;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)breedbotstates.exitdialog;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = 7;
                            botState = (int)breedbotstates.exitdialog;
                        }
                        break;

                    case (int)breedbotstates.testdialog2:
                        waitTaskbool = Program.helper.memoryinrange(dialogOff, dialogOut, 0x01);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            Report("Dialog finished");
                            botState = (int)breedbotstates.filter;
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.exitdialog;
                        }
                        break;

                    case (int)breedbotstates.filter:
                        bool testsok = false;
                        Report("Reading egg located at box " + (currentbox + 1) + " slot  " + (currentslot + 1));
                        waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                        dataready = await waitTaskint;
                        if (dataready >= 0)
                        {
                            quantity--;
                            Program.gCmdWindow.updateBreedingslots(currentbox, currentslot, quantity);
                            uint PID = Convert.ToUInt32(dataready);
                            if (readesv || mode == 2)
                            {
                                int esv = (int)((PID >> 16 ^ PID & 0xFFFF) >> 4);
                                Program.gCmdWindow.AddESVrow(currentbox, currentslot, esv);
                                if (mode == 2)
                                {
                                    currentesv = esv;
                                    testsok = Program.gCmdWindow.ESV_TSV_check(esv);
                                }
                            }
                            if (mode == 1)
                                testsok = Program.gCmdWindow.CheckBreedingFilters();
                        }
                        else
                        {
                            botresult = 2;
                            Report("Error detected");
                            attempts = 11;
                        }
                        if (testsok)
                            botState = (int)breedbotstates.testspassed;
                        else if (quantity > 0)
                        {
                            getNextSlot();
                            botState = (int)breedbotstates.readslot;
                        }
                        else
                        {
                            if (mode == 1 || mode == 2)
                            {
                                Report("No match found");
                                botresult = 3;
                            }
                            else
                                botresult = 0;
                            botState = (int)breedbotstates.botexit;
                        }
                        break;

                    case (int)breedbotstates.testspassed:
                        if (mode == 1)
                        {
                            Report("All tests passed");
                            botresult = 4;
                            finishmessage = "Finished. A match was found at box " + (currentbox + 1) + ", slot " + (currentslot + 1) + ", using filter #";
                        }
                        else if (mode == 2)
                        {
                            Report("ESV/TSV match found");
                            botresult = 5;
                            finishmessage = "Finished. A match was found at box " + (currentbox + 1) + ", slot " + (currentslot + 1) + ", the ESV/TSV value is: " + currentesv;
                        }
                        botState = (int)breedbotstates.botexit;
                        break;

                    case (int)breedbotstates.botexit:
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

        private void getNextSlot()
        {
            currentslot++;
            if (currentslot >= 30)
            {
                currentbox++;
                currentslot = 0;
                if (currentbox >= 32)
                    currentbox = 0;
            }
            Program.gCmdWindow.updateBreedingslots(currentbox, currentslot, quantity);
        }



    }
}
