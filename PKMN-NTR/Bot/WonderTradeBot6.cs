using System;
using System.Threading.Tasks;

namespace ntrbase.Bot
{
    class WonderTradeBot6
    {
        // Class variables
        private enum botstates { testpssmenu, readpoke, pressWTbutton, testsavescrn, confirmsave, testwtscrn, confirmwt, testboxes, gotoboxchange, touchboxview, testboxview, touchnewbox, selectnewbox, testboxviewout, touchpoke, selectrade, confirmsend, testboxesout, waitfortrade, testbackpssmenu, notradepartner, endbot };

        public bool botstop;
        private int botresult;
        private int currentbox;
        private int currentslot;
        private int quantity;
        private int botstate;
        private int waittimeout;
        private int attempts;
        private int tradewait;
        private uint currentPID;

        private bool boxchange = true;

        private bool taskresultbool;
        private int taskresultint;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        private uint psssmenu1Off;
        private uint psssmenu1IN;
        private uint psssmenu1OUT;
        public uint savescrnOff;
        public uint savescrnIN;
        public uint savescrnOUT;
        public uint wtconfirmationOff;
        public uint wtconfirmationIN;
        public uint wtconfirmationOUT;
        public uint wtboxesOff;
        public uint wtboxesIN;
        public uint wtboxesOUT;
        public uint wtboxviewOff;
        public uint wtboxviewIN;
        public uint wtboxviewOUT;
        public uint wtboxviewRange;

        // Button values for remote controls
        public static readonly uint keyA = 0xFFE;

        // Position of boxes and pokémon in the lower screen
        public static readonly uint[] pokeposX = { 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180 };
        public static readonly uint[] pokeposY = { 60, 60, 60, 60, 60, 60, 90, 90, 90, 90, 90, 90, 120, 120, 120, 120, 120, 120, 150, 150, 150, 150, 150, 150, 180, 180, 180, 180, 180, 180 };
        public static readonly uint[] boxposX = { 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260 };
        public static readonly uint[] boxposY = { 24, 24, 24, 24, 24, 24, 24, 24, 72, 72, 72, 72, 72, 72, 72, 72, 120, 120, 120, 120, 120, 120, 120, 120, 168, 168, 168, 168, 168, 168, 168 };

        public WonderTradeBot6(int StartBox, int StartSlot, int Amount, bool oras)
        {
            currentbox = StartBox - 1;
            currentslot = StartSlot - 1;
            quantity = Amount;
            botstop = false;
            boxchange = true;
            botstate = 0;
            botresult = 0;
            attempts = 0;
            if (!oras)
            { // Offsets for XY
                psssmenu1Off = 0x19ABC0;
                psssmenu1IN = 0x7E0000;
                psssmenu1OUT = 0x4D0000;
                savescrnOff = 0x19AB78;
                savescrnIN = 0x7E0000;
                savescrnOUT = 0x4D0000;
                wtconfirmationOff = 0x19A918;
                wtconfirmationIN = 0x4D0000;
                wtconfirmationOUT = 0x780000;
                wtboxesOff = 0x19A988;
                wtboxesIN = 0x6C0000;
                wtboxesOUT = 0x4D0000;
                wtboxviewOff = 0x627437;
                wtboxviewIN = 0x00000000;
                wtboxviewOUT = 0x20000000;
                wtboxviewRange = 0x1000000;
            }
            else
            { // Offsets for ORAS
                psssmenu1Off = 0x19C21C;
                psssmenu1IN = 0x830000;
                psssmenu1OUT = 0x500000;
                savescrnOff = 0x19C1CC;
                savescrnIN = 0x830000;
                savescrnOUT = 0x500000;
                wtconfirmationOff = 0x19C024;
                wtconfirmationIN = 0x500000;
                wtconfirmationOUT = 0x700000;
                wtboxesOff = 0x19BFCC;
                wtboxesIN = 0x710000;
                wtboxesOUT = 0x500000;
                wtboxviewOff = 0x66F5F2;
                wtboxviewIN = 0xC000;
                wtboxviewOUT = 0x4000;
                wtboxviewRange = 0x1000;
            }
        }

        public async Task<int> RunBot()
        {
            while (!botstop)
            {
                switch (botstate)
                {
                    case (int)botstates.testpssmenu:
                        Report("Test if the PSS menu is shown");
                        waitTaskbool = Program.helper.memoryinrange(psssmenu1Off, psssmenu1IN, 0x10000);
                        if (await waitTaskbool)
                            botstate = (int)botstates.readpoke;
                        else
                        {
                            botresult = 1;
                            botstate = (int)botstates.endbot;
                        }
                        break;

                    case (int)botstates.readpoke:
                        Report("Read pokémon from box " + (currentbox + 1) + ", slot " + (currentslot + 1));
                        waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                        long dataready = await waitTaskint;
                        switch (dataready)
                        {
                            case -2:
                                botresult = 2;
                                botstate = (int)botstates.endbot;
                                break;
                            case -1:
                                Report("Slot is empty");
                                getNextSlot();
                                if (quantity > 0) // Test if there are more trades
                                    botstate = (int)botstates.readpoke;
                                else
                                { // Stop if no more trades
                                    botresult = 0;
                                    botstate = (int)botstates.endbot;
                                }
                                break;
                            default:
                                {
                                    currentPID = Convert.ToUInt32(dataready);
                                    Report("Pokémon found, PID: 0x" + currentPID.ToString("X8"));
                                    botstate = (int)botstates.pressWTbutton;
                                }
                                break;
                        }
                        break;

                    case (int)botstates.pressWTbutton:
                        Report("Touch Wonder Trade button");
                        Program.helper.quicktouch(240, 120, 200);
                        await Task.Delay(250);
                        botstate = (int)botstates.testsavescrn;
                        break;

                    case (int)botstates.testsavescrn:
                        Report("Test if the save screen is shown");
                        waitTaskbool = Program.helper.timememoryinrange(savescrnOff, savescrnIN, 0x10000, 100, 5000);
                        taskresultbool = await waitTaskbool;
                        if (taskresultbool)
                        {
                            attempts = 0;
                            botstate = (int)botstates.confirmsave;
                        }
                        else
                        { // If not in save screen, try again
                            attempts++;
                            botstate = (int)botstates.pressWTbutton;
                        }
                        break;

                    case (int)botstates.confirmsave:
                        Report("Press Yes");
                        Program.helper.quickbuton(keyA, 200);
                        await Task.Delay(250);
                        botstate = (int)botstates.testwtscrn;
                        break;

                    case (int)botstates.testwtscrn:
                        Report("Test if Wonder Trade screen is shown");
                        waitTaskbool = Program.helper.timememoryinrange(wtconfirmationOff, wtconfirmationIN, 0x10000, 100, 5000);
                        taskresultbool = await waitTaskbool;
                        if (taskresultbool)
                        {
                            attempts = 0;
                            botstate = (int)botstates.confirmwt;
                        }
                        else
                        {
                            attempts++;
                            botstate = (int)botstates.confirmsave;
                        }
                        break;

                    case (int)botstates.confirmwt:
                        Report("Touch Yes");
                        Program.helper.quicktouch(160, 100, 200);
                        await Task.Delay(250);
                        botstate = (int)botstates.testboxes;
                        break;

                    case (int)botstates.testboxes:
                        Report("Test if the boxes are shown");
                        waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, wtboxesIN, 0x10000, 100, 5000);
                        taskresultbool = await waitTaskbool;
                        if (taskresultbool)
                        {
                            attempts = 0;
                            botstate = (int)botstates.gotoboxchange;
                        }
                        else
                        {
                            attempts++;
                            botstate = (int)botstates.confirmwt;
                        }
                        break;

                    case (int)botstates.gotoboxchange:
                        await Task.Delay(2000);
                        if (boxchange)
                        {
                            botstate = (int)botstates.touchboxview;
                            boxchange = false;
                        }
                        else
                            botstate = (int)botstates.touchpoke;
                        break;

                    case (int)botstates.touchboxview:
                        Report("Touch Box View");
                        Program.helper.quicktouch(30, 220, 200);
                        await Task.Delay(250);
                        botstate = (int)botstates.testboxview;
                        break;

                    case (int)botstates.testboxview:
                        Report("Test if box view is shown");
                        waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewIN, wtboxviewRange, 100, 5000);
                        taskresultbool = await waitTaskbool;
                        if (taskresultbool)
                        {
                            attempts = 0;
                            botstate = (int)botstates.touchnewbox;
                        }
                        else
                        {
                            attempts++;
                            botstate = (int)botstates.touchboxview;
                        }
                        break;

                    case (int)botstates.touchnewbox:
                        await Task.Delay(500);
                        Report("Touch New Box");
                        Program.helper.quicktouch(boxposX[currentbox], boxposY[currentbox], 200);
                        await Task.Delay(500);
                        botstate = (int)botstates.selectnewbox;
                        break;

                    case (int)botstates.selectnewbox:
                        Report("Touch New Box");
                        Program.helper.quickbuton(keyA, 200);
                        await Task.Delay(500);
                        botstate = (int)botstates.testboxviewout;
                        break;

                    case (int)botstates.testboxviewout:
                        Report("Test if box view is not shown");
                        waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewOUT, wtboxviewRange, 100, 5000);
                        taskresultbool = await waitTaskbool;
                        if (taskresultbool)
                        {
                            attempts = 0;
                            botstate = (int)botstates.touchpoke;
                        }
                        else
                        {
                            attempts++;
                            botstate = (int)botstates.touchnewbox;
                        }
                        break;

                    case (int)botstates.touchpoke:
                        Report("Touch Pokémon");
                        Program.helper.quicktouch(pokeposX[currentslot], pokeposY[currentslot], 200);
                        await Task.Delay(1000);
                        botstate = (int)botstates.selectrade;
                        break;

                    case (int)botstates.selectrade:
                        Report("Select Trade");
                        Program.helper.quickbuton(keyA, 200);
                        await Task.Delay(1000);
                        botstate = (int)botstates.confirmsend;
                        break;

                    case (int)botstates.confirmsend:
                        Report("Select Yes");
                        Program.helper.quickbuton(keyA, 200);
                        await Task.Delay(250);
                        botstate = (int)botstates.testboxesout;
                        break;

                    case (int)botstates.testboxesout:
                        Report("Test if the boxes are not shown");
                        waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, wtboxesOUT, 0x10000, 100, 5000);
                        taskresultbool = await waitTaskbool;
                        if (taskresultbool)
                        {
                            attempts = 0;
                            tradewait = 0;
                            botstate = (int)botstates.waitfortrade;
                        }
                        else
                        {
                            attempts++;
                            botstate = (int)botstates.touchpoke;
                        }
                        break;

                    case (int)botstates.waitfortrade:
                        Report("Wait for trade");
                        waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                        uint newPID = Convert.ToUInt32(await waitTaskint);
                        Report("PID: 0x" + newPID.ToString("X8"));
                        if (currentPID == newPID)
                        {
                            await Task.Delay(2000);
                            tradewait++;
                            if (tradewait > 30) // Too much time passed
                            {
                                attempts = 0;
                                botstate = (int)botstates.notradepartner;
                            }
                        }
                        else
                        {
                            Report("Wait 30 seconds");
                            await Task.Delay(30000);
                            botstate = (int)botstates.testbackpssmenu;
                        }
                        break;

                    case (int)botstates.testbackpssmenu:
                        Report("Test if back to the PSS menu");
                        waitTaskbool = Program.helper.timememoryinrange(psssmenu1Off, psssmenu1IN, 0x10000, 2000, 10000);
                        taskresultbool = await waitTaskbool;
                        if (taskresultbool)
                        { // Trade sucessfull
                            attempts = 0;
                            getNextSlot();
                            if (quantity > 0) // Test if there are more trades
                                botstate = (int)botstates.readpoke;
                            else
                            { // Stop if no more trades
                                botresult = 0;
                                botstate = (int)botstates.endbot;
                            }
                        }
                        else
                        { // Still waiting
                            attempts++;
                            botstate = (int)botstates.testbackpssmenu;
                        }
                        break;

                    case (int)botstates.notradepartner:
                        Report("Test if back to the PSS menu");
                        waitTaskbool = Program.helper.timememoryinrange(psssmenu1Off, psssmenu1IN, 0x10000, 500, 3000);
                        taskresultbool = await waitTaskbool;
                        if (taskresultbool)
                        { // Back in menu
                            attempts = 0;
                            botstate = (int)botstates.pressWTbutton;
                        }
                        else
                        { // Still waiting
                            attempts++;
                            Report("Select Yes");
                            Program.helper.quickbuton(keyA, 200);
                            await Task.Delay(250);
                            botstate = (int)botstates.notradepartner;
                        }
                        break;

                    default:
                        botstop = true;
                        break;
                }
                if (attempts > 10)
                { // Too many attempts
                    botstop = true;
                    botresult = -1;
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
                boxchange = true;
                if (currentbox >= 31)
                    currentbox = 0;
            }
            quantity--;
            Program.gCmdWindow.updateWTslots(currentbox, currentslot, quantity);
        }

    }
}
