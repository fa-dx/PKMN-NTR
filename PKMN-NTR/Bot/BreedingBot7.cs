using System;
using System.Threading.Tasks;

namespace ntrbase.Bot
{
    class BreedingBot7
    {
        public enum breedbotstates { botstart, quickegg, triggerdialog, testdialog1, continuedialog, fixdialog, checknoegg, exitdialog, testdialog2, walkleft1, checkmap1, walkup1, checkmap2, enterdoor, checkmap3, walkup2, checkmap4, walkright1, checkmap5, startcomputer, testcomputer, readslot, testboxchange, touchboxview, testboxview, touchnewbox, selectnewbox, testviewout, touchegg, moveegg, releaseegg, exitcomputer, filter, testspassed, testexit, walkleft2, checkmap6, walkdown1, checkmap7, walkdown2, checkmap8, walkright2, checkmap9, readegg, errorhandle, botexit };

        public bool botstop = false;
        public string finishmessage;
        private int botState = 0;
        private int botresult = 0;
        private int attempts = 0;
        private bool boxchange = true;
        private int[,] egglocations = new int[5, 2];
        private int eggsinbatch = 0;
        private int eggsinparty = 0;
        private int currentesv = 0;
        private float currentpos = 0;
        long dataready;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;
        private int maxreconnect = 10;

        private int mode;
        private int currentbox;
        private int currentslot;
        private int quantity;
        private bool readesv;
        private int filterbox;
        private int filterslot;

        private uint eggOff = 0x3313EDD8;
        private uint posXOff = 0x33199260;
        private uint posYOff = 0x3319E2C4;
        private uint dialogOff = 0x63DD68;
        private uint dialogIn = 0x09;
        private uint dialogOut = 0x08;
        private uint boxesOff = 0x10F1A0;
        private uint boxesIN = 0x6F0000;
        private uint boxesOUT = 0x520000;
        private uint boxesviewOff = 0x672D04;
        private uint boxesviewIN = 0x00000000;
        private uint boxesviewOUT = 0x40000000;

        //private uint posZOff = 0x330D6744;

        public BreedingBot7(int selectedmode, int startbox, int startslot, int amount, bool readesvafterdep)
        {
            mode = selectedmode;
            currentbox = startbox - 1;
            currentslot = startslot - 1;
            quantity = amount;
            readesv = readesvafterdep;
        }

        public async Task<int> RunBot()
        {
            while (!botstop)
            {
                botresult = 0;
                switch (botState)
                {
                    case (int)breedbotstates.botstart:
                        Report("Bot start");
                        if (mode >= 0)
                            botState = (int)breedbotstates.quickegg;
                        else
                            botState = (int)breedbotstates.botexit;
                        break;

                    case (int)breedbotstates.quickegg:
                        waitTaskbool = Program.helper.waitNTRwrite(eggOff, 0x01, Program.gCmdWindow.pid);
                        if (await waitTaskbool)
                        {
                            botresult = 0;
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        else
                        {
                            botresult = 1;
                            Report("Error detected");
                            attempts = 11;
                        }
                        break;

                    case (int)breedbotstates.triggerdialog:
                        Report("Start dialog");
                        waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyA);
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
                            waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyA);
                            if (!(await waitTaskbool))
                                break;
                        }
                        if (i == 6)
                            botState = (int)breedbotstates.checknoegg;
                        else
                            botState = (int)breedbotstates.fixdialog;
                        break;

                    case (int)breedbotstates.fixdialog:
                        waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyA);
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
                        waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyB);
                        if (await waitTaskbool)
                        {
                            waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyB);
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
                            addEggtoParty();
                            if (eggsinparty >= 5 || quantity == 0)
                                botState = (int)breedbotstates.walkleft1;
                            else
                                botState = (int)breedbotstates.quickegg;
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.exitdialog;
                        }
                        break;

                    case (int)breedbotstates.walkleft1:
                        Report("Walk to Nursery");
                        Program.helper.quickstick(-100, 0, 500);
                        await Task.Delay(1000);
                        botState = (int)breedbotstates.checkmap1;
                        break;

                    case (int)breedbotstates.checkmap1:
                        waitTaskbool = Program.helper.waitNTRread(posXOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position X: " + currentpos); // Expected 5850
                            if (currentpos > 5910)
                            {
                                await fixleft();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap1;
                            }
                            else if (currentpos < 5790)
                            {
                                await fixright();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap1;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.walkup1;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.checkmap1;
                        }
                        break;

                    case (int)breedbotstates.walkup1:
                        Report("Walk to door");
                        Program.helper.quickstick(0, 100, 1000);
                        await Task.Delay(1500);
                        botState = (int)breedbotstates.checkmap2;
                        break;

                    case (int)breedbotstates.checkmap2:
                        waitTaskbool = Program.helper.waitNTRread(posYOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position Y: " + currentpos); // Expected 3160
                            if (currentpos > 3240)
                            {
                                await fixup();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap2;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.enterdoor;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.checkmap2;
                        }
                        break;

                    case (int)breedbotstates.enterdoor:
                        waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyA);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.checkmap3;
                        else
                        {
                            attempts++;
                            botresult = 7;
                            botState = (int)breedbotstates.enterdoor;
                        }
                        break;

                    case (int)breedbotstates.checkmap3:
                        waitTaskbool = Program.helper.waitNTRread(posYOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position Y: " + currentpos); // Expected 2275
                            if (currentpos != 2275)
                            {
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.enterdoor;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.walkup2;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.enterdoor;
                        }
                        break;

                    case (int)breedbotstates.walkup2:
                        Report("Walk to desk");
                        Program.helper.quickstick(0, 100, 1250);
                        await Task.Delay(1750);
                        botState = (int)breedbotstates.checkmap4;
                        break;

                    case (int)breedbotstates.checkmap4:
                        waitTaskbool = Program.helper.waitNTRread(posYOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position Y: " + currentpos); // Expected 2037
                            if (currentpos > 2100)
                            {
                                await fixup();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap4;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.walkright1;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.checkmap4;
                        }
                        break;

                    case (int)breedbotstates.walkright1:
                        Report("Walk to computer");
                        Program.helper.quickstick(100, 0, 200);
                        await Task.Delay(700);
                        botState = (int)breedbotstates.checkmap5;
                        break;

                    case (int)breedbotstates.checkmap5:
                        waitTaskbool = Program.helper.waitNTRread(posXOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position X: " + currentpos); // Expected 2200
                            if (currentpos > 2240)
                            {
                                await fixleft();
                                await fixup();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap5;
                            }
                            else if (currentpos < 2180)
                            {
                                await fixright();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap5;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.startcomputer;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.checkmap5;
                        }
                        break;

                    case (int)breedbotstates.startcomputer:
                        Report("Turn on computer");
                        waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyA);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.testcomputer;
                        else
                        {
                            attempts++;
                            botresult = 7;
                            botState = (int)breedbotstates.startcomputer;
                        }
                        break;

                    case (int)breedbotstates.testcomputer:
                        Report("Test if computer is on");
                        waitTaskbool = Program.helper.timememoryinrange(boxesOff, boxesIN, 0x10000, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.readslot;
                        }
                        else
                        {
                            await fixup();
                            attempts++;
                            botresult = 2;
                            botState = (int)breedbotstates.startcomputer;
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
                                botState = (int)breedbotstates.testboxchange;
                                break;
                            default: // Not empty slot
                                Report("Space is not empty");
                                getNextSlot();
                                botState = (int)breedbotstates.readslot;
                                break;
                        }
                        break;

                    case (int)breedbotstates.testboxchange:
                        if (boxchange)
                        {
                            botState = (int)breedbotstates.touchboxview;
                            boxchange = false;
                        }
                        else
                            botState = (int)breedbotstates.touchegg;
                        break;

                    case (int)breedbotstates.touchboxview:
                        Report("Touch Box View");
                        waitTaskbool = Program.helper.waittouch(140, 230);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.testboxview;
                        else
                        {
                            attempts++;
                            botresult = 6;
                            botState = (int)breedbotstates.touchboxview;
                        }
                        break;

                    case (int)breedbotstates.testboxview:
                        Report("Test if box view is shown");
                        await Task.Delay(1000);
                        waitTaskbool = Program.helper.timememoryinrange(boxesviewOff, boxesviewIN, 0x1000000, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.touchnewbox;
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.touchboxview;
                        }
                        break;

                    case (int)breedbotstates.touchnewbox:
                        Report("Touch New Box");
                        waitTaskbool = Program.helper.waittouch(Program.PKTable.boxposX7[currentbox], Program.PKTable.boxposY7[currentbox]);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.selectnewbox;
                        }
                        else
                        {
                            attempts++;
                            botresult = 6;
                            botState = (int)breedbotstates.touchnewbox;
                        }
                        break;

                    case (int)breedbotstates.selectnewbox:
                        Report("Select New Box");
                        waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyA);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.testviewout;
                        else
                        {
                            attempts++;
                            botresult = 7;
                            botState = (int)breedbotstates.selectnewbox;
                        }
                        break;

                    case (int)breedbotstates.testviewout:
                        Report("Test if box view is not shown");
                        waitTaskbool = Program.helper.timememoryinrange(boxesviewOff, boxesviewOUT, 0x2000000, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.touchegg;
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.selectnewbox;
                        }
                        break;

                    case (int)breedbotstates.touchegg:
                        Report("Select Egg");
                        waitTaskbool = Program.helper.waitholdtouch(280, 100);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.moveegg;
                        else
                        {
                            botresult = 6;
                            Report("Error detected");
                            attempts = 11;
                        }
                        break;

                    case (int)breedbotstates.moveegg:
                        Report("Move Egg");
                        waitTaskbool = Program.helper.waitholdtouch(Program.PKTable.pokeposX7[currentslot], Program.PKTable.pokeposY7[currentslot]);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.releaseegg;
                        else
                        {
                            botresult = 6;
                            Report("Error detected");
                            attempts = 11;
                        }
                        break;

                    case (int)breedbotstates.releaseegg:
                        Report("Release Egg");
                        waitTaskbool = Program.helper.waitfreetouch();
                        if (await waitTaskbool)
                        {
                            egglocations[eggsinbatch, 0] = currentbox;
                            egglocations[eggsinbatch, 1] = currentslot;
                            eggsinbatch++;
                            getNextSlot();
                            eggsinparty--;
                            if (eggsinparty > 0)
                                botState = (int)breedbotstates.readslot;
                            else
                                botState = (int)breedbotstates.exitcomputer;
                        }
                        else
                        {
                            botresult = 6;
                            Report("Error detected");
                            attempts = 11;
                        }
                        break;

                    case (int)breedbotstates.exitcomputer:
                        Report("Exit from PC");
                        waitTaskbool = Program.helper.waitbutton(Program.PKTable.keyB);
                        if (await waitTaskbool)
                            botState = (int)breedbotstates.testexit;
                        else
                        {
                            attempts++;
                            botresult = 7;
                            botState = (int)breedbotstates.exitcomputer;
                        }
                        break;

                    case (int)breedbotstates.testexit:
                        Report("Test if out from PC");
                        waitTaskbool = Program.helper.timememoryinrange(boxesOff, boxesOUT, 0x10000, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            if (mode == 1 || mode == 2 || readesv)
                                botState = (int)breedbotstates.filter;
                            else if (quantity > 0)
                                botState = (int)breedbotstates.walkleft2;
                            else
                            {
                                Report("Error detected");
                                attempts = 11;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.exitcomputer;
                        }
                        break;

                    case (int)breedbotstates.filter:
                        for (i = 0; i < eggsinbatch; i++)
                        {
                            filterbox = egglocations[i, 0];
                            filterslot = egglocations[i, 1];
                            bool testsok = false;
                            Report("Reading egg located at box " + (filterbox + 1) + " slot  " + (filterslot + 1));
                            waitTaskint = Program.helper.waitPokeRead(filterbox, filterslot);
                            dataready = await waitTaskint;
                            if (dataready >= 0)
                            {
                                uint PID = Convert.ToUInt32(dataready);
                                if (readesv || mode == 2)
                                {
                                    int esv = (int)((PID >> 16 ^ PID & 0xFFFF) >> 4);
                                    Program.gCmdWindow.AddESVrow(filterbox, filterslot, esv);
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
                                break;
                            }
                            if (testsok)
                            {
                                botState = (int)breedbotstates.testspassed;
                                break;
                            }
                            else if (quantity > 0)
                                botState = (int)breedbotstates.walkleft2;
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
                                break;
                            }
                        }
                        break;

                    case (int)breedbotstates.testspassed:
                        if (mode == 1)
                        {
                            Report("All tests passed");
                            botresult = 4;
                            finishmessage = "Finished. A match was found at box " + (filterbox + 1) + ", slot " + (filterslot + 1) + ", using filter #";
                        }
                        else if (mode == 2)
                        {
                            Report("ESV/TSV match found");
                            botresult = 5;
                            finishmessage = "Finished. A match was found at box " + (filterbox + 1) + ", slot " + (filterslot + 1) + ", the ESV/TSV value is: " + currentesv;
                        }
                        botState = (int)breedbotstates.botexit;
                        break;

                    case (int)breedbotstates.walkleft2:
                        Report("Retire from computer");
                        eggsinbatch = 0;
                        Program.helper.quickstick(-100, 0, 400);
                        await Task.Delay(900);
                        botState = (int)breedbotstates.checkmap6;
                        break;

                    case (int)breedbotstates.checkmap6:
                        waitTaskbool = Program.helper.waitNTRread(posXOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position X: " + currentpos); // Expected 2100
                            if (currentpos > 2150)
                            {
                                await fixleft();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap6;
                            }
                            else if (currentpos < 2050)
                            {
                                await fixright();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap6;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.walkdown1;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.checkmap6;
                        }
                        break;

                    case (int)breedbotstates.walkdown1:
                        Report("Retire from desk");
                        Program.helper.quickstick(0, -100, 1000);
                        await Task.Delay(3000);
                        botState = (int)breedbotstates.checkmap7;
                        break;

                    case (int)breedbotstates.checkmap7:
                        waitTaskbool = Program.helper.waitNTRread(posXOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position X: " + currentpos); // Expected 2275
                            if ((int)currentpos != 5841)
                            {
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.walkdown1;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.walkdown2;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.walkdown1;
                        }
                        break;

                    case (int)breedbotstates.walkdown2:
                        Report("Retire from Nursery");
                        Program.helper.quickstick(0, -100, 600);
                        await Task.Delay(1100);
                        botState = (int)breedbotstates.checkmap8;
                        break;

                    case (int)breedbotstates.checkmap8:
                        waitTaskbool = Program.helper.waitNTRread(posYOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position Y: " + currentpos); // Expected 3410
                            if (currentpos > 3470)
                            {
                                await fixup();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap8;
                            }
                            else if (currentpos < 3300)
                            {
                                await fixdown();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap8;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.walkright2;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.checkmap8;
                        }
                        break;

                    case (int)breedbotstates.walkright2:
                        Report("Walk to Nursery Lady");
                        Program.helper.quickstick(100, 0, 500);
                        await Task.Delay(1000);
                        botState = (int)breedbotstates.checkmap9;
                        break;

                    case (int)breedbotstates.checkmap9:
                        waitTaskbool = Program.helper.waitNTRread(posXOff);
                        if (await waitTaskbool)
                        {
                            currentpos = BitConverter.ToSingle(BitConverter.GetBytes(Program.helper.lastRead), 0);
                            Report("Current position X: " + currentpos); // Expected 6010
                            if (currentpos > 6060)
                            {
                                await fixleft();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap9;
                            }
                            else if (currentpos < 5990)
                            {
                                await fixright();
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.checkmap9;
                            }
                            else
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.quickegg;
                            }
                        }
                        else
                        {
                            attempts++;
                            botresult = -1;
                            botState = (int)breedbotstates.checkmap9;
                        }
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
                boxchange = true;
                if (currentbox >= 32)
                    currentbox = 0;
            }
            Program.gCmdWindow.updateBreedingslots(currentbox, currentslot, quantity);
        }

        private void addEggtoParty()
        {
            eggsinparty++;
            quantity--;
            Program.gCmdWindow.updateBreedingslots(currentbox, currentslot, quantity);
        }

        private async Task fixright()
        {
            Report("Move right");
            Program.helper.quickstick(100, 0, 200);
            await Task.Delay(500);
        }

        private async Task fixleft()
        {
            Report("Move left");
            Program.helper.quickstick(-100, 0, 200);
            await Task.Delay(500);
        }

        private async Task fixup()
        {
            Report("Move up");
            Program.helper.quickstick(0, 100, 200);
            await Task.Delay(500);
        }

        private async Task fixdown()
        {
            Report("Move down");
            Program.helper.quickstick(0, -100, 200);
            await Task.Delay(500);
        }

    }
}
