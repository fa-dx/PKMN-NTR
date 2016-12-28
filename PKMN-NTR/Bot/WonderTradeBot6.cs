using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    class WonderTradeBot6
    {
        private enum botstates { botstart, testpssmenu, readpoke, pressWTbutton, testsavescrn, confirmsave, testwtscrn, confirmwt, testboxes, gotoboxchange, touchboxview, testboxview, touchnewbox, selectnewbox, testboxviewout, touchpoke, selectrade, confirmsend, testboxesout, waitfortrade, testbackpssmenu, notradepartner, endbot };

        // Bot variables
        public int botresult;
        public bool botstop;

        // Class variables
        private int botstate;
        private int attempts;
        private int tradewait;
        private int maxreconnect;
        private bool boxchange;
        private bool taskresultbool;
        private uint currentPID;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        // Input variables
        private int currentbox;
        private int currentslot;
        private int quantity;

        // Class constants
        private readonly int commandtime = 250;
        private readonly int delaytime = 150;

        // Data offsets
        private uint psssmenu1Off;
        private uint psssmenu1IN;
        //private uint psssmenu1OUT;
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

        public WonderTradeBot6(int StartBox, int StartSlot, int Amount, bool oras)
        {
            botresult = 0;
            botstop = false;

            botstate = (int)botstates.botstart;
            attempts = 0;
            tradewait = 0;
            maxreconnect = 10;
            boxchange = true;
            taskresultbool = false;
            currentPID = 0;

            currentbox = StartBox - 1;
            currentslot = StartSlot - 1;
            quantity = Amount;

            if (!oras)
            { // XY
                psssmenu1Off = 0x19ABC0;
                psssmenu1IN = 0x7E0000;
                //psssmenu1OUT = 0x4D0000;
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
            { // ORAS
                psssmenu1Off = 0x19C21C;
                psssmenu1IN = 0x830000;
                //psssmenu1OUT = 0x500000;
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
            try
            {
                while (!botstop)
                {
                    switch (botstate)
                    {
                        case (int)botstates.botstart:
                            Report("Bot: START Gen 6 Wonder Trade bot");
                            botstate = (int)botstates.testpssmenu;
                            break;

                        case (int)botstates.testpssmenu:
                            Report("Bot: Test if the PSS menu is shown");
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
                            Report("Bot: Look for pokemon to trade");
                            waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                            long dataready = await waitTaskint;
                            switch (dataready)
                            {
                                case -2:
                                    botresult = 2;
                                    botstate = (int)botstates.endbot;
                                    break;
                                case -1:
                                    Report("Bot: Slot is empty");
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
                                        Report("Bot: Pokémon found");
                                        botstate = (int)botstates.pressWTbutton;
                                    }
                                    break;
                            }
                            break;

                        case (int)botstates.pressWTbutton:
                            Report("Bot: Touch Wonder Trade button");
                            Program.helper.quicktouch(240, 120, commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.testsavescrn;
                            break;

                        case (int)botstates.testsavescrn:
                            Report("Bot: Test if the save screen is shown");
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
                                botresult = 2;
                                botstate = (int)botstates.pressWTbutton;
                            }
                            break;

                        case (int)botstates.confirmsave:
                            Report("Bot: Press Yes");
                            await Task.Delay(500);
                            Program.helper.quickbuton(LookupTable.keyA, commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.testwtscrn;
                            break;

                        case (int)botstates.testwtscrn:
                            Report("Bot: Test if Wonder Trade screen is shown");
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
                                botresult = 2;
                                botstate = (int)botstates.confirmsave;
                            }
                            break;

                        case (int)botstates.confirmwt:
                            Report("Bot: Touch Yes");
                            await Task.Delay(500);
                            Program.helper.quicktouch(160, 100, commandtime);
                            await Task.Delay(delaytime);
                            botstate = (int)botstates.testboxes;
                            break;

                        case (int)botstates.testboxes:
                            Report("Bot: Test if the boxes are shown");
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
                                botresult = 2;
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
                            Report("Bot: Touch Box View");
                            Program.helper.quicktouch(30, 220, commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.testboxview;
                            break;

                        case (int)botstates.testboxview:
                            Report("Bot: Test if box view is shown");
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
                                botresult = 2;
                                botstate = (int)botstates.touchboxview;
                            }
                            break;

                        case (int)botstates.touchnewbox:
                            await Task.Delay(500);
                            Report("Bot: Touch New Box");
                            Program.helper.quicktouch(LookupTable.boxposX6[currentbox], LookupTable.boxposY6[currentbox], commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.selectnewbox;
                            break;

                        case (int)botstates.selectnewbox:
                            Report("Bot: Select New Box");
                            await Task.Delay(500);
                            Program.helper.quickbuton(LookupTable.keyA, commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.testboxviewout;
                            break;

                        case (int)botstates.testboxviewout:
                            Report("Bot: Test if box view is not shown");
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
                                botresult = 2;
                                botstate = (int)botstates.touchnewbox;
                            }
                            break;

                        case (int)botstates.touchpoke:
                            Report("Bot: Touch Pokémon");
                            await Task.Delay(500);
                            Program.helper.quicktouch(LookupTable.pokeposX6[currentslot], LookupTable.pokeposY6[currentslot], commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.selectrade;
                            break;

                        case (int)botstates.selectrade:
                            Report("Bot: Select Trade");
                            await Task.Delay(750);
                            Program.helper.quickbuton(LookupTable.keyA, commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.confirmsend;
                            break;

                        case (int)botstates.confirmsend:
                            Report("Bot: Select Yes");
                            await Task.Delay(750);
                            Program.helper.quickbuton(LookupTable.keyA, commandtime);
                            await Task.Delay(commandtime + delaytime);
                            botstate = (int)botstates.testboxesout;
                            break;

                        case (int)botstates.testboxesout:
                            Report("Bot: Test if the boxes are not shown");
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
                                botresult = 2;
                                botstate = (int)botstates.touchpoke;
                            }
                            break;

                        case (int)botstates.waitfortrade:
                            Report("Bot: Wait for trade");
                            waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                            uint newPID = Convert.ToUInt32(await waitTaskint);
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
                                Report("Bot: Wait 30 seconds");
                                await Task.Delay(30000);
                                botstate = (int)botstates.testbackpssmenu;
                            }
                            break;

                        case (int)botstates.testbackpssmenu:
                            Report("Bot: Test if back to the PSS menu");
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
                                botresult = -1;
                                botstate = (int)botstates.testbackpssmenu;
                            }
                            break;

                        case (int)botstates.notradepartner:
                            Report("Bot: Test if back to the PSS menu");
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
                                botresult = -1;
                                Report("Bot: Select Yes");
                                Program.helper.quickbuton(LookupTable.keyA, commandtime);
                                await Task.Delay(commandtime + delaytime);
                                botstate = (int)botstates.notradepartner;
                            }
                            break;

                        case (int)botstates.endbot:
                            Report("Bot: STOP Gen 6 Wonder Trade bot");
                            botstop = true;
                            break;

                        default:
                            Report("Bot: STOP Gen 6 Wonder Trade bot");
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
                            Report("Bot: STOP Gen 6 Wonder Trade bot");
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
                Report("Bot: STOP Gen 6 Wonder Trade bot");
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void Report(string log)
        {
            Program.gCmdWindow.addtoLog(log);
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
