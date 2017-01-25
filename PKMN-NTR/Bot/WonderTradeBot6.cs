using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    class WonderTradeBot6
    {
        private enum botstates { botstart, backup, testpssmenu, readpoke, readfolder, writefromfolder, pressWTbutton, testsavescrn, confirmsave, testwtscrn, confirmwt, testboxes, gotoboxchange, touchboxview, testboxview, touchnewbox, selectnewbox, testboxviewout, touchpoke, selectrade, confirmsend, testboxesout, waitfortrade, testbackpssmenu, notradepartner, dumpafter, actionafter, restorebackup, delete1, delete2, endbot };

        // Bot variables
        public int botresult;
        public bool botstop;

        // Class variables
        private int botstate;
        private int attempts;
        private int tradewait;
        private int maxreconnect;
        private int currentfile;
        private bool boxchange;
        private bool taskresultbool;
        private uint currentPID;
        private string backuppath;
        private string[] pkfiles;
        private Random rng;
        private Task<bool> waitTaskbool;
        private Task<long> waitTaskint;
        private List<byte[]> pklist;

        // Input variables
        private int currentbox;
        private int currentslot;
        private int quantity;
        private int startbox;
        private int startslot;
        private int starttrades;
        private int source;
        private int afteraction;
        private bool endless;
        private bool afterdump;

        // Class constants
        private readonly int commandtime = 250;
        private readonly int delaytime = 250;
        private string wtfolderpath = @Application.StartupPath + "\\Wonder Trade\\";

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
        private uint pcpkmOff;

        public WonderTradeBot6(int StartBox, int StartSlot, int Amount, bool oras, int Sourcepkm, bool endlessrun, int inputafteraction, bool inputdumpafter)
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
            currentfile = 0;

            currentbox = StartBox - 1;
            currentslot = StartSlot - 1;
            quantity = Amount;
            startbox = StartBox - 1;
            startslot = StartSlot - 1;
            starttrades = Amount;
            source = Sourcepkm;
            endless = endlessrun;
            afteraction = inputafteraction;
            afterdump = inputdumpafter;
            pklist = new List<byte[]> { };
            rng = new Random();

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
                pcpkmOff = 0x8C861C8;
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
                pcpkmOff = 0x8C9E134;
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
                            botstate = (int)botstates.backup;
                            break;

                        case (int)botstates.backup:
                            Report("Bot: Backup boxes");
                            waitTaskbool = Program.helper.waitNTRmultiread(pcpkmOff, 232 * 30 * 31);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                string fileName = "WTBefore-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".ek6";
                                backuppath = wtfolderpath + fileName;
                                Program.gCmdWindow.writePokemonToFile(Program.helper.lastmultiread, backuppath);
                                botstate = (int)botstates.testpssmenu;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botstate = (int)botstates.backup;
                            }
                            break;

                        case (int)botstates.testpssmenu:
                            Report("Bot: Test if the PSS menu is shown");
                            waitTaskbool = Program.helper.memoryinrange(psssmenu1Off, psssmenu1IN, 0x10000);
                            if (await waitTaskbool)
                            {
                                if (source == 1)
                                {
                                    botstate = (int)botstates.readpoke;
                                }
                                else
                                {
                                    botstate = (int)botstates.readfolder;
                                }
                            }
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
                                    {
                                        botstate = (int)botstates.readpoke;
                                    }
                                    else if (endless)
                                    {
                                        currentbox = startbox;
                                        currentslot = startslot;
                                        quantity = starttrades;
                                        Program.gCmdWindow.updateWTslots(currentbox, currentslot, quantity);
                                        botstate = (int)botstates.readpoke;
                                    }
                                    else
                                    { // Stop if no more trades
                                        botstate = (int)botstates.dumpafter;
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

                        case (int)botstates.readfolder:
                            Report("Bot: Reading Wonder Trade folder");
                            pkfiles = Directory.GetFiles(wtfolderpath, "*.pk6");
                            if (pkfiles.Length > 0)
                            {
                                PKHeX validator = new PKHeX();
                                foreach (string pkf in pkfiles)
                                {
                                    byte[] temp = File.ReadAllBytes(pkf);
                                    if (temp.Length == 232)
                                    {
                                        validator.Data = temp;
                                        if (validator.Species > 0 && validator.Species <= 721)
                                        { // Valid looking file
                                            pklist.Add(temp);
                                        }
                                        else
                                        { // Not valid file
                                            Report("Bot: File " + pkf + " is not a valid pk6 file");
                                        }
                                    }
                                    else
                                    { // Not valid file
                                        Report("Bot: File " + pkf + " is not a valid pk6 file");
                                    }
                                }
                            }
                            if (pklist.Count > 0)
                            {
                                botstate = (int)botstates.writefromfolder;
                            }
                            else
                            {
                                Report("Bot: No files detected");
                                botresult = 0;
                                botstate = (int)botstates.endbot;
                            }
                            break;

                        case (int)botstates.writefromfolder:
                            Report("Bot: Write pkm file from list");
                            if (source == 3)
                            { // Select a random file
                                currentfile = rng.Next() % pklist.Count;
                            }
                            waitTaskbool = Program.helper.waitNTRwrite(pcpkmOff + (uint)(30 * 232 * currentbox) + (uint)(232 * currentslot), PKHeX.encryptArray(pklist[currentfile]), Program.gCmdWindow.pid);
                            if (await waitTaskbool)
                            {
                                Program.gCmdWindow.updateDumpBoxes(currentbox, currentslot);
                                Program.gCmdWindow.dumpedPKHeX.Data = pklist[currentfile];
                                Program.gCmdWindow.updateTabs();
                                currentPID = Program.gCmdWindow.dumpedPKHeX.PID;
                                if (source == 2)
                                {
                                    currentfile++;
                                    if (currentfile > pklist.Count - 1)
                                    {
                                        currentfile = 0;
                                    }
                                }
                                attempts = 0;
                                botstate = (int)botstates.pressWTbutton;
                            }
                            else
                            {
                                attempts++;
                                botresult = 1;
                                botstate = (int)botstates.writefromfolder;
                            }
                            break;

                        case (int)botstates.pressWTbutton:
                            Report("Bot: Touch Wonder Trade button");
                            waitTaskbool = Program.helper.waittouch(240, 120);
                            if (await waitTaskbool)
                            {
                                botstate = (int)botstates.testsavescrn;
                            }
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botstate = (int)botstates.pressWTbutton;
                            }
                            break;

                        case (int)botstates.testsavescrn:
                            Report("Bot: Test if the save screen is shown");
                            await Task.Delay(delaytime);
                            waitTaskbool = Program.helper.timememoryinrange(savescrnOff, savescrnIN, 0x10000, 500, 5000);
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
                            await Task.Delay(delaytime);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                botstate = (int)botstates.testwtscrn;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.confirmsave;
                            }
                            break;

                        case (int)botstates.testwtscrn:
                            Report("Bot: Test if Wonder Trade screen is shown");
                            waitTaskbool = Program.helper.timememoryinrange(wtconfirmationOff, wtconfirmationIN, 0x10000, 500, 5000);
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
                            await Task.Delay(delaytime);
                            waitTaskbool = Program.helper.waittouch(160, 100);
                            if (await waitTaskbool)
                            {
                                botstate = (int)botstates.testboxes;
                            }
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botstate = (int)botstates.confirmwt;
                            }
                            break;

                        case (int)botstates.testboxes:
                            Report("Bot: Test if the boxes are shown");
                            waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, wtboxesIN, 0x10000, 500, 5000);
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
                            await Task.Delay(8 * delaytime);
                            if (boxchange)
                            {
                                botstate = (int)botstates.touchboxview;
                                boxchange = false;
                            }
                            else
                            {
                                botstate = (int)botstates.touchpoke;
                            }
                            break;

                        case (int)botstates.touchboxview:
                            Report("Bot: Touch Box View");
                            waitTaskbool = Program.helper.waittouch(30, 220);
                            if (await waitTaskbool)
                                botstate = (int)botstates.testboxview;
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botstate = (int)botstates.touchboxview;
                            }
                            break;

                        case (int)botstates.testboxview:
                            Report("Bot: Test if box view is shown");
                            waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewIN, wtboxviewRange, 500, 5000);
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
                            Report("Bot: Touch New Box");
                            await Task.Delay(delaytime);
                            waitTaskbool = Program.helper.waittouch(LookupTable.boxposX6[currentbox], LookupTable.boxposY6[currentbox]);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.selectnewbox;
                            }
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botstate = (int)botstates.touchboxview;
                            }
                            break;

                        case (int)botstates.selectnewbox:
                            Report("Bot: Select New Box");
                            await Task.Delay(delaytime);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                botstate = (int)botstates.testboxviewout;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.confirmsave;
                            }
                            break;

                        case (int)botstates.testboxviewout:
                            Report("Bot: Test if box view is not shown");
                            waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewOUT, wtboxviewRange, 500, 5000);
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
                            await Task.Delay(delaytime);
                            waitTaskbool = Program.helper.waittouch(LookupTable.pokeposX6[currentslot], LookupTable.pokeposY6[currentslot]);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.selectrade;
                            }
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botstate = (int)botstates.touchpoke;
                            }
                            break;

                        case (int)botstates.selectrade:
                            Report("Bot: Select Trade");
                            await Task.Delay(2 * delaytime);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.confirmsend;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.selectrade;
                            }
                            break;

                        case (int)botstates.confirmsend:
                            Report("Bot: Select Yes");
                            await Task.Delay(2 * delaytime);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.testboxesout;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botstate = (int)botstates.confirmsend;
                            }
                            break;

                        case (int)botstates.testboxesout:
                            Report("Bot: Test if the boxes are not shown");
                            waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, wtboxesOUT, 0x10000, 500, 5000);
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
                                await Task.Delay(8 * delaytime);
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
                                {
                                    if (source == 1)
                                    {
                                        botstate = (int)botstates.readpoke;
                                    }
                                    else
                                    {
                                        botstate = (int)botstates.writefromfolder;
                                    }
                                    attempts = 0;
                                }
                                else if (endless)
                                {
                                    currentbox = startbox;
                                    currentslot = startslot;
                                    quantity = starttrades;
                                    Program.gCmdWindow.updateWTslots(currentbox, currentslot, quantity);
                                    if (source == 1)
                                    {
                                        botstate = (int)botstates.readpoke;
                                    }
                                    else
                                    {
                                        botstate = (int)botstates.writefromfolder;
                                    }
                                    attempts = 0;
                                }
                                else
                                { // Stop if no more trades
                                    botstate = (int)botstates.dumpafter;
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

                        case (int)botstates.dumpafter:
                            if (afterdump)
                            {
                                Report("Bot: Dump boxes");
                                waitTaskbool = Program.helper.waitNTRmultiread(pcpkmOff, 232 * 30 * 31);
                                if (await waitTaskbool)
                                {
                                    attempts = 0;
                                    string fileName = "WTAfter-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".ek6";
                                    Program.gCmdWindow.writePokemonToFile(Program.helper.lastmultiread, wtfolderpath + fileName);
                                    botstate = (int)botstates.actionafter;
                                }
                                else
                                {
                                    attempts++;
                                    botresult = 2;
                                    botstate = (int)botstates.dumpafter;
                                }
                            }
                            else
                            {
                                botstate = (int)botstates.actionafter;
                            }
                            break;

                        case (int)botstates.actionafter:
                            switch (afteraction)
                            {
                                case 2:
                                    botstate = (int)botstates.restorebackup;
                                    break;
                                case 3:
                                    botstate = (int)botstates.delete1;
                                    break;
                                default:
                                    botresult = 0;
                                    botstate = (int)botstates.endbot;
                                    break;
                            }
                            break;

                        case (int)botstates.restorebackup:
                            Report("Bot: Restore boxes backup");
                            byte[] restore = File.ReadAllBytes(backuppath);
                            if (restore.Length == 232 * 30 * 31)
                            {
                                waitTaskbool = Program.helper.waitNTRwrite(pcpkmOff, restore, Program.gCmdWindow.pid);
                                if (await waitTaskbool)
                                {
                                    attempts = 0;
                                    botresult = 0;
                                    botstate = (int)botstates.endbot;
                                }
                            }
                            else
                            {
                                Report("Bot: Invalid boxes file");
                                botresult = -1;
                                botstate = (int)botstates.endbot;
                            }
                            break;

                        case (int)botstates.delete1:
                            Report("Bot: Delete traded pokémon");
                            int todelete = 0;
                            if (startbox * 30 + startslot + starttrades > 930)
                            { // Check if it overflows position
                                quantity = startbox * 30 + startslot + starttrades - 930;
                                todelete = starttrades - quantity;
                            }
                            else
                            {
                                todelete = starttrades;
                                quantity = 0;
                            }
                            byte[] deletearray = new byte[232 * todelete];
                            for (int i = 0; i < todelete; i++)
                            {
                                LookupTable.EmptyPoke6.CopyTo(deletearray, i * 232);
                            }
                            waitTaskbool = Program.helper.waitNTRwrite(pcpkmOff + (uint)(30 * 232 * startbox) + (uint)(232 * startslot), deletearray, Program.gCmdWindow.pid);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botstate = (int)botstates.delete2;
                            }
                            else
                            {
                                attempts++;
                                botstate = (int)botstates.delete1;
                            }
                            break;

                        case (int)botstates.delete2:
                            if (quantity > 0)
                            {
                                byte[] remainarray = new byte[232 * quantity];
                                for (int i = 0; i < quantity; i++)
                                {
                                    LookupTable.EmptyPoke6.CopyTo(remainarray, i * 232);
                                }
                                waitTaskbool = Program.helper.waitNTRwrite(pcpkmOff, remainarray, Program.gCmdWindow.pid);
                                if (await waitTaskbool)
                                {
                                    attempts = 0;
                                    botresult = 0;
                                    botstate = (int)botstates.endbot;
                                }
                                else
                                {
                                    attempts++;
                                    botstate = (int)botstates.delete2;
                                }
                            }
                            else
                            {
                                botresult = 0;
                                botstate = (int)botstates.endbot;
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
                                await Task.Delay(10 * delaytime);
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
                {
                    currentbox = 0;
                }
            }
            quantity--;
            Program.gCmdWindow.updateWTslots(currentbox, currentslot, quantity);
        }
    }
}
