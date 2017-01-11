using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    class BreedingBot6
    {
        public enum breedbotstates { botstart, facedaycareman, quickegg, walk1, walk2, checkegg, walk3, checkmap1, triggerdialog, continuedialog, checknoegg, exitdialog, testparty, walktodaycare, checkmap2, fix1, entertodaycare, checkmap3, walktodesk, checkmap4, walktocomputer, checkmap5, fix2, facecomputer, startcomputer, testcomputer, computerdialog, pressPCstorage, touchOrganize, testboxes, readslot, testboxchange, touchboxview, testboxview, touchnewbox, selectnewbox, testviewout, touchegg, moveegg, releaseegg, exitcomputer, testexit, readegg, retirefromcomputer, checkmap6, fix3, retirefromdesk, checkmap7, retirefromdoor, checkmap8, fix5, walktodaycareman, checkmap9, fix4, filter, testspassed, botexit };

        // Bot variables
        public int botresult;
        public bool botstop;
        public string finishmessage;

        // Class variables
        private int botState;
        private int attempts;
        private int maxreconnect;
        private int eggsinbatch;
        private int eggsinparty;
        private int currentesv;
        private int filterbox;
        private int filterslot;
        private int runtime;
        private bool boxchange;
        private uint lastposition;
        private long dataready;
        private int[,] egglocations = new int[5, 2];
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        // Class constants
        private readonly int walktime = 100;
        private readonly int commandtime = 250;
        private readonly int commanddelay = 400;
        private readonly int longcommandtime = 1000;

        // Input variables
        private int mode;
        private int currentbox;
        private int currentslot;
        private int quantity;
        private bool organizeboxes;
        private bool mauvdaycare;
        private bool readesv;
        private bool quickbreed;
        private bool oras;

        // Data offsets
        private uint wtboxesOff;
        private uint organizeBoxIN;
        private uint organizeBoxOUT;
        private uint wtboxviewOff;
        private uint wtboxviewIN;
        private uint wtboxviewOUT;
        private uint wtboxviewRange;
        private uint computerOff;
        private uint computerIN;
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

        public BreedingBot6(int selectedmode, int startbox, int startslot, int amount, bool organizeboxesposition, bool mauvilledaycare, bool readesvafterdep, bool quickbreedflag, bool orasgame)
        {
            botstop = false;
            botState = (int)breedbotstates.botstart;
            botresult = 0;
            attempts = 0;
            maxreconnect = 10;
            finishmessage = "";

            boxchange = true;
            eggsinbatch = 0;
            eggsinparty = 0;
            currentesv = 0;
            lastposition = 0;
            dataready = 0;
            filterbox = 0;
            filterslot = 0;

            mode = selectedmode;
            currentbox = startbox - 1;
            currentslot = startslot - 1;
            quantity = amount;
            organizeboxes = organizeboxesposition;
            mauvdaycare = mauvilledaycare;
            readesv = readesvafterdep;
            quickbreed = quickbreedflag;
            oras = orasgame;

            if (!oras)
            { // XY
                computerOff = 0x19A918;
                computerIN = 0x4D0000;
                wtboxesOff = 0x19A988;
                organizeBoxIN = 0x6C0000;
                organizeBoxOUT = 0x4D0000;
                wtboxviewOff = 0x627437;
                wtboxviewIN = 0x00000000;
                wtboxviewOUT = 0x20000000;
                wtboxviewRange = 0x1000000;
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
                eggoff = 0x8C80124;
                runtime = 1000;
            }
            else
            { // ORAS
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
            try
            {
                while (!botstop)
                {
                    switch (botState)
                    {
                        case (int)breedbotstates.botstart:
                            Report("Bot: START Gen 6 Breding bot");
                            if (quickbreed)
                                botState = (int)breedbotstates.facedaycareman;
                            else if (mode >= 0)
                                botState = (int)breedbotstates.walk1;
                            else
                                botState = (int)breedbotstates.botexit;
                            break;

                        case (int)breedbotstates.facedaycareman:
                            Report("Bot: Turn to Day Care Man");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.DpadUP);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.quickegg;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)breedbotstates.facedaycareman;
                            }
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
                                Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case (int)breedbotstates.walk1:
                            Report("Bot: Run south");
                            Program.helper.quickbuton(LookupTable.runDOWN, runtime);
                            await Task.Delay(runtime + commanddelay);
                            botState = (int)breedbotstates.walk2;
                            break;

                        case (int)breedbotstates.walk2:
                            Report("Bot: Run north");
                            Program.helper.quickbuton(LookupTable.runUP, runtime);
                            await Task.Delay(runtime + commanddelay);
                            botState = (int)breedbotstates.checkegg;
                            break;

                        case (int)breedbotstates.checkegg:
                            Report("Bot: Check if an egg is available");
                            waitTaskbool = Program.helper.memoryinrange(eggoff, 0x01, 0x01);
                            if (await waitTaskbool)
                            {
                                Report("Bot: Egg found");
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
                                Report("Bot: Egg found");
                                botState = (int)breedbotstates.triggerdialog;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = (int)breedbotstates.walk3;
                            }
                            break;

                        case (int)breedbotstates.walk3:
                            Report("Bot: Return to day care man");
                            Program.helper.quickbuton(LookupTable.runUP, longcommandtime);
                            await Task.Delay(longcommandtime + commanddelay);
                            botState = (int)breedbotstates.checkmap1;
                            break;

                        case (int)breedbotstates.triggerdialog:
                            Report("Bot: Talk to Day Care Man");
                            int i;
                            for (i = 0; i < 7; i++)
                            {
                                await Task.Delay(commanddelay);
                                waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                                if (!(await waitTaskbool))
                                    break;
                            }
                            if (i == 7)
                                botState = (int)breedbotstates.checknoegg;
                            else
                                botState = (int)breedbotstates.continuedialog;
                            break;

                        case (int)breedbotstates.continuedialog:
                            Report("Bot: Continue dialog");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)breedbotstates.checknoegg;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)breedbotstates.continuedialog;
                            }
                            break;

                        case (int)breedbotstates.checknoegg:
                            waitTaskbool = Program.helper.memoryinrange(eggoff, 0x00, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                Report("Bot: Egg received");
                                botState = (int)breedbotstates.exitdialog;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = (int)breedbotstates.triggerdialog;
                            }
                            break;

                        case (int)breedbotstates.exitdialog:
                            Report("Bot: Exit dialog");
                            await Task.Delay(2500);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                            if (await waitTaskbool)
                            {
                                waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                                if (await waitTaskbool)
                                {
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
                                }
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

                        case (int)breedbotstates.walktodaycare:
                            Report("Bot: Walk to Day Care");
                            await Task.Delay(commanddelay);
                            if (oras && !mauvdaycare)
                                Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            else
                                Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
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
                                Report("Bot: No movement detected, still on dialog?");
                                Program.helper.quickbuton(LookupTable.keyB, commandtime);
                                await Task.Delay(commandtime + commanddelay);
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.walktodaycare;
                            }
                            else if (Program.helper.lastRead < daycaredoorx && oras && !mauvdaycare)
                            {
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.fix1;
                            }
                            else if (Program.helper.lastRead > daycaredoorx && (!oras || mauvdaycare))
                            {
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.fix1;
                            }
                            else
                            {
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.walktodaycare;
                            }
                            break;

                        case (int)breedbotstates.fix1:
                            Report("Bot: Missed day care, return");
                            await Task.Delay(commanddelay);
                            if (oras && !mauvdaycare)
                                Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            else
                                Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = (int)breedbotstates.checkmap2;
                            break;

                        case (int)breedbotstates.entertodaycare:
                            Report("Bot: Enter to Day Care");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.runUP, longcommandtime);
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
                                botresult = 2;
                                botState = (int)breedbotstates.entertodaycare;
                            }
                            break;

                        case (int)breedbotstates.walktodesk:
                            Report("Bot: Run to desk");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.runUP, longcommandtime);
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
                                botresult = 2;
                                botState = (int)breedbotstates.walktodesk;
                            }
                            break;

                        case (int)breedbotstates.walktocomputer:
                            Report("Bot: Walk to the PC");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
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
                                botresult = -1;
                                botState = (int)breedbotstates.fix2;
                            }
                            else
                            { // Still far from computer
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.walktocomputer;
                            }
                            break;

                        case (int)breedbotstates.fix2:
                            Report("Bot: Missed PC, return");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = (int)breedbotstates.checkmap5;
                            break;

                        case (int)breedbotstates.facecomputer:
                            Report("Bot: Turn on the PC");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.DpadUP);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.startcomputer;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)breedbotstates.facecomputer;
                            }
                            break;

                        case (int)breedbotstates.startcomputer:
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
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
                            Report("Bot: Test if the PC is on");
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
                                botresult = 2;
                                botState = (int)breedbotstates.facecomputer;
                            }
                            break;

                        case (int)breedbotstates.computerdialog:
                            Report("Bot: Skip PC dialog");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.pressPCstorage;
                            }
                            else
                            {
                                botresult = 7;
                                Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case (int)breedbotstates.pressPCstorage:
                            Report("Bot: Press Access PC storage");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.touchOrganize;
                            }
                            else
                            {
                                botresult = 7;
                                Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case (int)breedbotstates.touchOrganize:
                            Report("Bot: Touch Organize boxes");
                            await Task.Delay(750);
                            if (oras && organizeboxes)
                                waitTaskbool = Program.helper.waittouch(160, 40);
                            else
                                waitTaskbool = Program.helper.waittouch(160, 120);
                            if (await waitTaskbool)
                                botState = (int)breedbotstates.testboxes;
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botState = (int)breedbotstates.touchOrganize;
                            }
                            break;

                        case (int)breedbotstates.testboxes:
                            Report("Test if the boxes are shown");
                            await Task.Delay(1250);
                            waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, organizeBoxIN, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.readslot;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = (int)breedbotstates.touchOrganize;
                            }
                            break;

                        case (int)breedbotstates.readslot:
                            Report("Bot: Search for empty slot");
                            waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                            dataready = await waitTaskint;
                            switch (dataready)
                            {
                                case -2: // Read error
                                    botresult = 2;
                                    Report("Bot: Error detected");
                                    attempts = 11;
                                    break;
                                case -1: // Empty slot
                                    botState = (int)breedbotstates.testboxchange;
                                    break;
                                default: // Not empty slot
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
                            Report("Bot: Touch Box View");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waittouch(30, 220);
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
                            Report("Bot: Test if box view is shown");
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
                                botresult = 2;
                                botState = (int)breedbotstates.touchboxview;
                            }
                            break;

                        case (int)breedbotstates.touchnewbox:
                            Report("Bot: Touch New Box");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waittouch(LookupTable.boxposX6[currentbox], LookupTable.boxposY6[currentbox]);
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
                            Report("Bot: Select New Box");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
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
                            Report("Bot: Test if box view is not shown");
                            await Task.Delay(1250);
                            waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewOUT, wtboxviewRange, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)breedbotstates.touchegg;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = (int)breedbotstates.selectnewbox;
                            }
                            break;

                        case (int)breedbotstates.touchegg:
                            Report("Bot: Select Egg");
                            await Task.Delay(750);
                            waitTaskbool = Program.helper.waitholdtouch(300, 100);
                            if (await waitTaskbool)
                                botState = (int)breedbotstates.moveegg;
                            else
                            {
                                botresult = 6;
                                Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case (int)breedbotstates.moveegg:
                            Report("Move Egg");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitholdtouch(LookupTable.pokeposX6[currentslot], LookupTable.pokeposY6[currentslot]);
                            if (await waitTaskbool)
                                botState = (int)breedbotstates.releaseegg;
                            else
                            {
                                botresult = 6;
                                Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case (int)breedbotstates.releaseegg:
                            Report("Bot: Release Egg");
                            await Task.Delay(commanddelay);
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
                                Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case (int)breedbotstates.exitcomputer:
                            Report("Bot: Exit from PC");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyX);
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
                            Report("Bot: Test if out from PC");
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
                                    Report("Bot: Error detected");
                                    attempts = 11;
                                }
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = (int)breedbotstates.exitcomputer;
                            }
                            break;

                        case (int)breedbotstates.retirefromcomputer:
                            Report("Bot: Retire from PC");
                            await Task.Delay(commanddelay);
                            eggsinbatch = 0;
                            Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
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
                                botresult = -1;
                                botState = (int)breedbotstates.fix3;
                            }
                            else
                            { // Still far from exit
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.retirefromcomputer;
                            }
                            break;

                        case (int)breedbotstates.fix3:
                            Report("Bot: Missed exit, return");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = (int)breedbotstates.checkmap6;
                            break;

                        case (int)breedbotstates.retirefromdesk:
                            Report("Bot: Run to exit");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.runDOWN, longcommandtime);
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
                                botresult = 2;
                                botState = (int)breedbotstates.retirefromdesk;
                            }
                            break;

                        case (int)breedbotstates.retirefromdoor:
                            Report("Bot: Retire from door");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadDOWN, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = (int)breedbotstates.checkmap8;
                            break;

                        case (int)breedbotstates.checkmap8:
                            waitTaskbool = Program.helper.memoryinrange(mapyoff, daycaremany, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = -10; // Allow more attempts
                                botState = (int)breedbotstates.walktodaycareman;
                            }
                            else if (Program.helper.lastRead > daycaremany)
                            {
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.fix5;
                            }
                            else
                            { // Still far from exit
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.retirefromdoor;
                            }
                            break;

                        case (int)breedbotstates.fix5:
                            Report("Bot: Missed Day Care Man, return");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadUP, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = (int)breedbotstates.checkmap8;
                            break;

                        case (int)breedbotstates.walktodaycareman:
                            Report("Bot: Walk to Day Care Man");
                            await Task.Delay(commanddelay);
                            if (oras && !mauvdaycare)
                                Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            else
                                Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
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
                                botresult = -1;
                                botState = (int)breedbotstates.fix4;
                            }
                            else if (Program.helper.lastRead > daycaremanx && (!oras || mauvdaycare))
                            {
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.fix4;
                            }
                            else
                            {
                                attempts++;
                                botresult = -1;
                                botState = (int)breedbotstates.walktodaycareman;
                            }
                            break;

                        case (int)breedbotstates.fix4:
                            Report("Bot: Missed Day Care Man, return");
                            await Task.Delay(commanddelay);
                            if (oras && !mauvdaycare)
                                Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            else
                                Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = (int)breedbotstates.checkmap9;
                            break;

                        case (int)breedbotstates.filter:
                            for (i = 0; i < eggsinbatch; i++)
                            {
                                filterbox = egglocations[i, 0];
                                filterslot = egglocations[i, 1];
                                bool testsok = false;
                                Report("Bot: Check deposited egg");
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
                                    Report("Bot: Error detected");
                                    attempts = 11;
                                    break;
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
                                        Report("Bot: No match found");
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
                                Report("Bot: All tests passed");
                                botresult = 4;
                                finishmessage = "Finished. A match was found at box " + (filterbox + 1) + ", slot " + (filterslot + 1) + ", using filter #";
                            }
                            else if (mode == 2)
                            {
                                Report("Bot: ESV/TSV match found");
                                botresult = 5;
                                finishmessage = "Finished. A match was found at box " + (filterbox + 1) + ", slot " + (filterslot + 1) + ", the ESV/TSV value is: " + currentesv;
                            }
                            botState = (int)breedbotstates.botexit;
                            break;

                        case (int)breedbotstates.botexit:
                            Report("Bot: STOP Gen 6 Breding bot");
                            botstop = true;
                            break;

                        default:
                            Report("Bot: STOP Gen 6 Breding bot");
                            botresult = 0;
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
                                await Task.Delay(1000);
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
                            Report("Bot: STOP Gen 6 Breding bot");
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
                Report("Bot: STOP Gen 6 Breding bot");
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
