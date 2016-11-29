using System;
using System.Threading.Tasks;

namespace ntrbase.Bot
{
    class BreedingBot6
    {
        public enum breedbotstates { botstart, facedaycareman, quickegg, walk1, walk2, checkegg, walk3, checkmap1, triggerdialog, checknoegg, exitdialog, testparty, walktodaycare, checkmap2, fix1, entertodaycare, checkmap3, walktodesk, checkmap4, walktocomputer, checkmap5, fix2, facecomputer, startcomputer, testcomputer, computerdialog, pressPCstorage, touchOrganize, testboxes, readslot, testboxchange, touchboxview, testboxview, touchnewbox, selectnewbox, testviewout, touchegg, moveegg, releaseegg, exitcomputer, testexit, readegg, retirefromcomputer, checkmap6, fix3, retirefromdesk, checkmap7, retirefromdoor, checkmap8, fix5, walktodaycareman, checkmap9, fix4, filter, testspassed, botexit };

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
        private int walktime = 50;
        private int commandtime = 250;
        private int commanddelay = 250;
        private int longcommandtime = 750;
        private uint lastposition = 0;
        long dataready;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        private int mode;
        private int currentbox;
        private int currentslot;
        private int quantity;
        private bool organizeboxes;
        private bool mauvdaycare;
        private bool readesv;
        private bool quickbreed;
        private bool oras;
        private int runtime;
        private int filterbox;
        private int filterslot;

        private uint wtboxesOff;
        private uint organizeBoxIN;
        private uint organizeBoxOUT;
        private uint wtboxviewOff;
        private uint wtboxviewIN;
        private uint wtboxviewOUT;
        private uint wtboxviewRange;
        public uint computerOff;
        public uint computerIN;
        //private uint computerOUT;
        private uint mapidoff;
        private uint mapxoff;
        private uint mapyoff;
        //private uint mapzoff;
        private uint routemapid;
        private uint daycaremapid;
        private uint daycaremanx;
        private uint daycaremany;
        private uint daycaredoorx;
        //uint daycaredoory;
        private uint daycareexitx;
        //uint daycareexity;
        private uint computerx;
        private uint computery;
        private uint eggoff;

        // Position of boxes and pokémon in the lower screen
        public static readonly uint[] pokeposX = { 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180, 30, 60, 90, 120, 150, 180 };
        public static readonly uint[] pokeposY = { 60, 60, 60, 60, 60, 60, 90, 90, 90, 90, 90, 90, 120, 120, 120, 120, 120, 120, 150, 150, 150, 150, 150, 150, 180, 180, 180, 180, 180, 180 };
        public static readonly uint[] boxposX = { 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260, 300, 20, 60, 100, 140, 180, 220, 260 };
        public static readonly uint[] boxposY = { 24, 24, 24, 24, 24, 24, 24, 24, 72, 72, 72, 72, 72, 72, 72, 72, 120, 120, 120, 120, 120, 120, 120, 120, 168, 168, 168, 168, 168, 168, 168 };

        // Button values for remote controls
        public static readonly uint nokey = 0xFFF;
        public static readonly uint keyA = 0xFFE;
        public static readonly uint keyB = 0xFFD;
        public static readonly uint keyX = 0xBFF;
        public static readonly uint keyY = 0x7FF;
        public static readonly uint keyR = 0xEFF;
        public static readonly uint keyL = 0xDFF;
        public static readonly uint keySTART = 0xFF7;
        public static readonly uint keySELECT = 0xFFB;
        public static readonly uint DpadUP = 0xFBF;
        public static readonly uint DpadDOWN = 0xF7F;
        public static readonly uint DpadLEFT = 0xFDF;
        public static readonly uint DpadRIGHT = 0xFEF;
        public static readonly uint runUP = 0xFBD;
        public static readonly uint runDOWN = 0xF7D;
        public static readonly uint runLEFT = 0xFDD;
        public static readonly uint runRIGHT = 0xFED;
        public static readonly uint softReset = 0xCF7;
        public static readonly uint notouch = 0x02000000;

        public BreedingBot6(int selectedmode, int startbox, int startlsot, int amount, bool organizeboxesposition, bool mauvilledaycare, bool readesvafterdep, bool quickbreedflag, bool orasgame)
        {
            mode = selectedmode;
            currentbox = startbox - 1;
            currentslot = startlsot - 1;
            quantity = amount;
            organizeboxes = organizeboxesposition;
            mauvdaycare = mauvilledaycare;
            readesv = readesvafterdep;
            quickbreed = quickbreedflag;
            oras = orasgame;

            if (!oras)
            {
                computerOff = 0x19A918;
                computerIN = 0x4D0000;
                wtboxesOff = 0x19A988;
                organizeBoxIN = 0x6C0000;
                organizeBoxOUT = 0x4D0000;
                wtboxviewOff = 0x627437;
                wtboxviewIN = 0x00000000;
                wtboxviewOUT = 0x20000000;
                mapidoff = 0x81828EC;
                mapxoff = 0x818290C;
                mapyoff = 0x8182914;
                //mapzoff = 0x8182910;
                routemapid = 0x108;
                daycaremapid = 0x109;
                daycaremanx = 0x46219400;
                daycaremany = 0x460F9400;
                daycaredoorx = 0x4622FC00;
                //daycaredoory = 0x460F4C00;
                daycareexitx = 0x43610000;
                //daycareexity = 0x43AF8000;
                computerx = 0x43828000;
                computery = 0x43730000;
                runtime = 1000;
            }
            else
            {
                if (mauvdaycare)
                { // Mauvile Day Care
                    computerOff = 0x19BF5C;
                    computerIN = 0x500000;
                    wtboxesOff = 0x19BFCC;
                    organizeBoxIN = 0x710000;
                    organizeBoxOUT = 0x500000;
                    wtboxviewOff = 0x66F5F2;
                    wtboxviewIN = 0xC000;
                    wtboxviewOUT = 0x4000;
                    wtboxviewRange = 0x1000;
                    mapidoff = 0x8187BD4;
                    mapxoff = 0x8187BF4;
                    mapyoff = 0x8187BFC;
                    //mapzoff = 0x8187BF8;
                    routemapid = 0x2C;
                    daycaremapid = 0x187;
                    daycaremanx = 0x45553000;
                    daycaremany = 0x44D92000;
                    daycaredoorx = 0x455AD000;
                    //daycaredoory = 0x44D6E000;
                    daycareexitx = 0x43610000;
                    //daycareexity = 0x43A68000;
                    computerx = 0x43828000;
                    computery = 0x43730000;
                    eggoff = 0x8C88358;
                    runtime = 1000;
                }
                else
                { // Battle Resort Day Care
                    computerOff = 0x19BF5C;
                    computerIN = 0x500000;
                    wtboxesOff = 0x19BFCC;
                    organizeBoxIN = 0x710000;
                    organizeBoxOUT = 0x500000;
                    wtboxviewOff = 0x66F5F2;
                    wtboxviewIN = 0xC000;
                    wtboxviewOUT = 0x4000;
                    wtboxviewRange = 0x1000;
                    mapidoff = 0x8187BD4;
                    mapxoff = 0x8187BF4;
                    mapyoff = 0x8187BFC;
                    //mapzoff = 0x8187BF8;
                    routemapid = 0xD2;
                    daycaremapid = 0x207;
                    daycaremanx = 0x44A9E000;
                    daycaremany = 0x44D92000;
                    daycaredoorx = 0x449C6000;
                    //daycaredoory = 0x44D4A000;
                    daycareexitx = 0x43610000;
                    //daycareexity = 0x43A68000;
                    computerx = 0x43828000;
                    computery = 0x43730000;
                    eggoff = 0x8C88548;
                    runtime = 2000;
                }
            }
        }

        public async Task<int> RunBot()
        {
            while (!botstop)
            {
                switch (botState)
                {
                    case (int)breedbotstates.botstart:
                        Report("Bot start");
                        if (quickbreed)
                            botState = (int)breedbotstates.facedaycareman;
                        else if (mode >= 0)
                            botState = (int)breedbotstates.walk1;
                        else
                            botState = (int)breedbotstates.botexit;
                        break;

                    case (int)breedbotstates.facedaycareman:
                        Report("Turn to Day Care Man");
                        await Task.Delay(500);
                        Program.helper.quickbuton(DpadUP, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.quickegg;
                        break;

                    case (int)breedbotstates.quickegg:
                        waitTaskbool = Program.helper.waitNTRwrite(eggoff, 0x01, Program.gCmdWindow.pid);
                        if (await waitTaskbool)
                        {
                            attempts = -10;
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        else
                        {
                            botresult = 1;
                            botState = (int)breedbotstates.botexit;
                        }
                        break;

                    case (int)breedbotstates.walk1:
                        Report("Run to south");
                        Program.helper.quickbuton(runDOWN, runtime);
                        await Task.Delay(runtime + commanddelay);
                        botState = (int)breedbotstates.walk2;
                        break;

                    case (int)breedbotstates.walk2:
                        Report("Run to north");
                        Program.helper.quickbuton(runUP, runtime);
                        await Task.Delay(runtime + commanddelay);
                        botState = (int)breedbotstates.checkegg;
                        break;

                    case (int)breedbotstates.checkegg:
                        Report("Check if egg");
                        waitTaskbool = Program.helper.memoryinrange(eggoff, 0x01, 0x01);
                        if (await waitTaskbool)
                        {
                            Report("Egg found");
                            botState = (int)breedbotstates.checkmap1;
                        }
                        else
                            botState = (int)breedbotstates.walk1;
                        break;

                    case (int)breedbotstates.checkmap1:
                        waitTaskbool = Program.helper.timememoryinrange(mapyoff, daycaremany, 0x01, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = -10;
                            Report("Egg found");
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.walk3;
                        }
                        break;

                    case (int)breedbotstates.walk3:
                        Report("Return to day care man");
                        Program.helper.quickbuton(runUP, longcommandtime);
                        await Task.Delay(longcommandtime + commanddelay);
                        botState = (int)breedbotstates.checkmap1;
                        break;

                    case (int)breedbotstates.triggerdialog:
                        Report("Talk to Day Care Man");
                        Program.helper.quickbuton(keyA, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.checknoegg;
                        break;

                    case (int)breedbotstates.checknoegg:
                        waitTaskbool = Program.helper.memoryinrange(eggoff, 0x00, 0x01);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            Report("Egg received");
                            botState = (int)breedbotstates.exitdialog;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.triggerdialog;
                        }
                        break;
                   
                    case (int)breedbotstates.exitdialog:
                        Report("Exit dialog");
                        await Task.Delay(3000);
                        Program.helper.quickbuton(keyB, commandtime);
                        await Task.Delay(commandtime + 1000);
                        Program.helper.quickbuton(keyB, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        addEggtoParty();
                        if (eggsinparty >= 5 || quantity == 0)
                        {
                            attempts = -15; // Allow more attempts
                            botState = (int)breedbotstates.walktodaycare;
                        }
                        else if (quickbreed)
                            botState = (int)breedbotstates.quickegg;
                        else
                            botState = (int)breedbotstates.walk1;
                        break;

                    case (int)breedbotstates.walktodaycare:
                        Report("Walk to Day Care");
                        if (oras && !mauvdaycare)
                            Program.helper.quickbuton(DpadLEFT, walktime);
                        else
                            Program.helper.quickbuton(DpadRIGHT, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap2;
                        break;

                    case (int)breedbotstates.checkmap2:
                        lastposition = Program.helper.lastRead;
                        waitTaskbool = Program.helper.memoryinrange(mapxoff, daycaredoorx, 0x01);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.entertodaycare;
                        }
                        else if (lastposition == Program.helper.lastRead)
                        {
                            Report("No movement detected, still on dialog?");
                            Program.helper.quickbuton(keyB, commandtime);
                            await Task.Delay(commandtime + commanddelay);
                            attempts++;
                            botState = (int)breedbotstates.walktodaycare;
                        }
                        else if (Program.helper.lastRead < daycaredoorx && oras && !mauvdaycare)
                        {
                            attempts++;
                            botState = (int)breedbotstates.fix1;
                        }
                        else if (Program.helper.lastRead > daycaredoorx && (!oras || mauvdaycare))
                        {
                            attempts++;
                            botState = (int)breedbotstates.fix1;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.walktodaycare;
                        }
                        break;

                    case (int)breedbotstates.fix1:
                        Report("Missed day care, return");
                        if (oras && !mauvdaycare)
                            Program.helper.quickbuton(DpadRIGHT, walktime);
                        else
                            Program.helper.quickbuton(DpadLEFT, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap2;
                        break;

                    case (int)breedbotstates.entertodaycare:
                        Report("Enter to Day Care");
                        Program.helper.quickbuton(runUP, longcommandtime);
                        await Task.Delay(longcommandtime + commanddelay);
                        botState = (int)breedbotstates.checkmap3;
                        break;

                    case (int)breedbotstates.checkmap3:
                        waitTaskbool = Program.helper.timememoryinrange(mapidoff, daycaremapid, 0x01, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.walktodesk;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.entertodaycare;
                        }
                        break;

                    case (int)breedbotstates.walktodesk:
                        Report("Run to desk");
                        Program.helper.quickbuton(runUP, longcommandtime);
                        await Task.Delay(longcommandtime + commanddelay);
                        botState = (int)breedbotstates.checkmap4;
                        break;

                    case (int)breedbotstates.checkmap4:
                        waitTaskbool = Program.helper.timememoryinrange(mapyoff, computery, 0x01, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.walktocomputer;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.walktodesk;
                        }
                        break;

                    case (int)breedbotstates.walktocomputer:
                        Report("Walk to the PC");
                        Program.helper.quickbuton(DpadRIGHT, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap5;
                        break;

                    case (int)breedbotstates.checkmap5:
                        waitTaskbool = Program.helper.memoryinrange(mapxoff, computerx, 0x01);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.facecomputer;
                        }
                        else if (Program.helper.lastRead > computerx)
                        {
                            attempts++;
                            botState = (int)breedbotstates.fix2;
                        }
                        else
                        { // Still far from computer
                            attempts++;
                            botState = (int)breedbotstates.walktocomputer;
                        }
                        break;

                    case (int)breedbotstates.fix2:
                        Report("Missed PC, return");
                        Program.helper.quickbuton(DpadLEFT, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap5;
                        break;

                    case (int)breedbotstates.facecomputer:
                        Report("Turn on the PC");
                        Program.helper.quickbuton(DpadUP, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.startcomputer;
                        break;

                    case (int)breedbotstates.startcomputer:
                        Program.helper.quickbuton(keyA, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.testcomputer;
                        break;

                    case (int)breedbotstates.testcomputer:
                        Report("Test if the PC is on");
                        await Task.Delay(2000); // Wait for PC on
                        waitTaskbool = Program.helper.timememoryinrange(computerOff, computerIN, 0x10000, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.computerdialog;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.facecomputer;
                        }
                        break;

                    case (int)breedbotstates.computerdialog:
                        Report("Skip PC dialog");
                        Program.helper.quickbuton(keyA, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.pressPCstorage;
                        break;

                    case (int)breedbotstates.pressPCstorage:
                        Report("Press Access PC storage");
                        Program.helper.quickbuton(keyA, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.touchOrganize;
                        break;

                    case (int)breedbotstates.touchOrganize:
                        Report("Touch Organize boxes");
                        await Task.Delay(1500);
                        if (oras && organizeboxes)
                            Program.helper.quicktouch(160, 40, commandtime);
                        else
                            Program.helper.quicktouch(160, 120, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.testboxes;
                        break;

                    case (int)breedbotstates.testboxes:
                        Report("Test if the boxes are shown");
                        await Task.Delay(500);
                        waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, organizeBoxIN, 0x10000, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.readslot;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.touchOrganize;
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
                                botState = (int)breedbotstates.botexit;
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
                        Program.helper.quicktouch(30, 220, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.testboxview;
                        break;

                    case (int)breedbotstates.testboxview:
                        Report("Test if box view is shown");
                        await Task.Delay(1000);
                        waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewIN, wtboxviewRange, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.touchnewbox;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.touchboxview;
                        }
                        break;

                    case (int)breedbotstates.touchnewbox:
                        Report("Touch New Box");
                        Program.helper.quicktouch(boxposX[currentbox], boxposY[currentbox], commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.selectnewbox;
                        break;

                    case (int)breedbotstates.selectnewbox:
                        Report("Select New Box");
                        Program.helper.quickbuton(keyA, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.testviewout;
                        break;

                    case (int)breedbotstates.testviewout:
                        Report("Test if box view is not shown");
                        await Task.Delay(1000);
                        waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewOUT, wtboxviewRange, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.touchegg;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.selectnewbox;
                        }
                        break;

                    case (int)breedbotstates.touchegg:
                        Report("Select Egg");
                        Program.helper.holdtouch(300, 100);
                        await Task.Delay(commanddelay + 250);
                        botState = (int)breedbotstates.moveegg;
                        break;

                    case (int)breedbotstates.moveegg:
                        Report("Move Egg");
                        Program.helper.holdtouch(pokeposX[currentslot], pokeposY[currentslot]);
                        await Task.Delay(commanddelay + 250);
                        botState = (int)breedbotstates.releaseegg;
                        break;

                    case (int)breedbotstates.releaseegg:
                        Report("Release Egg");
                        Program.helper.freetouch();
                        await Task.Delay(2 * commanddelay);
                        egglocations[eggsinbatch, 0] = currentbox;
                        egglocations[eggsinbatch, 1] = currentslot;
                        eggsinbatch++;
                        getNextSlot();
                        eggsinparty--;
                        if (eggsinparty > 0)
                            botState = (int)breedbotstates.readslot;
                        else
                            botState = (int)breedbotstates.exitcomputer;
                        break;

                    case (int)breedbotstates.exitcomputer:
                        Report("Exit from PC");
                        Program.helper.quickbuton(keyX, commandtime);
                        await Task.Delay(commandtime + commanddelay);
                        botState = (int)breedbotstates.testexit;
                        break;

                    case (int)breedbotstates.testexit:
                        Report("Test if out from PC");
                        waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, organizeBoxOUT, 0x10000, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            if (mode == 1 || mode == 2 || readesv)
                                botState = (int)breedbotstates.filter;
                            else if (quantity > 0)
                                botState = (int)breedbotstates.retirefromcomputer;
                            else
                            {
                                botState = (int)breedbotstates.botexit;
                            }
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.exitcomputer;
                        }
                        break;

                    case (int)breedbotstates.retirefromcomputer:
                        Report("Retire from PC");
                        eggsinbatch = 0;
                        Program.helper.quickbuton(DpadLEFT, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap6;
                        break;

                    case (int)breedbotstates.checkmap6:
                        waitTaskbool = Program.helper.memoryinrange(mapxoff, daycareexitx, 0x01);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.retirefromdesk;
                        }
                        else if (Program.helper.lastRead < daycareexitx)
                        {
                            attempts++;
                            botState = (int)breedbotstates.fix3;
                        }
                        else
                        { // Still far from exit
                            attempts++;
                            botState = (int)breedbotstates.retirefromcomputer;
                        }
                        break;

                    case (int)breedbotstates.fix3:
                        Report("Missed exit, return");
                        Program.helper.quickbuton(DpadRIGHT, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap6;
                        break;

                    case (int)breedbotstates.retirefromdesk:
                        Report("Run to exit");
                        Program.helper.quickbuton(runDOWN, longcommandtime);
                        await Task.Delay(longcommandtime + commanddelay);
                        botState = (int)breedbotstates.checkmap7;
                        break;

                    case (int)breedbotstates.checkmap7:
                        waitTaskbool = Program.helper.timememoryinrange(mapidoff, routemapid, 0x01, 100, 5000);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            botState = (int)breedbotstates.retirefromdoor;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.retirefromdesk;
                        }
                        break;

                    case (int)breedbotstates.retirefromdoor:
                        Report("Retire from door");
                        Program.helper.quickbuton(DpadDOWN, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap8;
                        break;

                    case (int)breedbotstates.checkmap8:
                        waitTaskbool = Program.helper.memoryinrange(mapyoff, daycaremany, 0x01);
                        if (await waitTaskbool)
                        {
                            attempts = 0;
                            attempts = -10; // Allow more attempts
                            botState = (int)breedbotstates.walktodaycareman;
                        }
                        else if (Program.helper.lastRead > daycaremany)
                        {
                            attempts++;
                            botState = (int)breedbotstates.fix5;
                        }
                        else
                        { // Still far from exit
                            attempts++;
                            botState = (int)breedbotstates.retirefromdoor;
                        }
                        break;

                    case (int)breedbotstates.fix5:
                        Report("Missed Day Care Man, return");
                        Program.helper.quickbuton(DpadUP, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap8;
                        break;

                    case (int)breedbotstates.walktodaycareman:
                        Report("Walk to Day Care Man");
                        if (oras && !mauvdaycare)
                            Program.helper.quickbuton(DpadRIGHT, walktime);
                        else
                            Program.helper.quickbuton(DpadLEFT, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap9;
                        break;

                    case (int)breedbotstates.checkmap9:
                        waitTaskbool = Program.helper.memoryinrange(mapxoff, daycaremanx, 0x01);
                        if (await waitTaskbool)
                        {
                            if (quickbreed)
                                botState = (int)breedbotstates.facedaycareman;
                            else
                                botState = (int)breedbotstates.walk1;
                            attempts = 0;
                        }
                        else if (Program.helper.lastRead > daycaremanx && oras && !mauvdaycare)
                        {
                            attempts++;
                            botState = (int)breedbotstates.fix4;
                        }
                        else if (Program.helper.lastRead > daycaremanx && (!oras || mauvdaycare))
                        {
                            attempts++;
                            botState = (int)breedbotstates.fix4;
                        }
                        else
                        {
                            attempts++;
                            botState = (int)breedbotstates.walktodaycareman;
                        }
                        break;

                    case (int)breedbotstates.fix4:
                        Report("Missed Day Care Man, return");
                        if (oras && !mauvdaycare)
                            Program.helper.quickbuton(DpadLEFT, walktime);
                        else
                            Program.helper.quickbuton(DpadRIGHT, walktime);
                        await Task.Delay(walktime + commanddelay);
                        botState = (int)breedbotstates.checkmap9;
                        break;

                    case (int)breedbotstates.filter:
                        for (int i = 0; i < eggsinbatch; i++)
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
                                botState = (int)breedbotstates.botexit;
                            }
                            if (testsok)
                            {
                                botState = (int)breedbotstates.testspassed;
                                break;
                            }
                            else if (quantity > 0)
                                botState = (int)breedbotstates.retirefromcomputer;
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
                        }
                        break;

                    case (int)breedbotstates.testspassed:
                        if (mode == 1)
                        {
                            Report("All tests passed");
                            botresult = 4;
                            finishmessage = "Finished. A match was found at box " + filterbox + ", slot " + filterslot + ", using filter #";
                        }
                        else if (mode == 2)
                        {
                            Report("ESV/TSV match found");
                            botresult = 5;
                            finishmessage = "Finished. A match was found at box " + filterbox + ", slot " + filterslot + ", the ESV/TSV value is: " + currentesv;
                        }
                        Report("Bot stop");
                        botState = (int)breedbotstates.botexit;
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
            Program.gCmdWindow.updateBreedingslots(currentbox, currentslot, quantity);
        }

        private void addEggtoParty()
        {
            eggsinparty++;
            quantity--;
            Program.gCmdWindow.updateBreedingslots(currentbox, currentslot, quantity);
        }
    }
}
