using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKHeX.Core;
using ntrbase.Helpers;

namespace ntrbase.Bot
{
    public partial class Bot_Breeding6 : Form
    {
        public enum breedbotstates { botstart, facedaycareman, quickegg, walk1, walk2, checkegg, walk3, checkmap1, triggerdialog, continuedialog, checknoegg, exitdialog, testparty, walktodaycare, checkmap2, fix1, entertodaycare, checkmap3, walktodesk, checkmap4, walktocomputer, checkmap5, fix2, facecomputer, startcomputer, testcomputer, computerdialog, pressPCstorage, touchOrganize, testboxes, readslot, testboxchange, touchboxview, testboxview, touchnewbox, selectnewbox, testviewout, touchegg, moveegg, releaseegg, exitcomputer, testexit, readegg, retirefromcomputer, checkmap6, fix3, retirefromdesk, checkmap7, retirefromdoor, checkmap8, fix5, walktodaycareman, checkmap9, fix4, filter, testspassed, botexit };

        // Initialize
        private int attempts;
        private int botresult;
        private int eggsinparty;
        private int eggsinbatch;
        private int maxreconnect;
        private uint lastposition;
        private bool botWorking;
        private bool boxchange;
        private breedbotstates botState;

        // Not initialize
        private int runtime;
        private bool oras;
        private Task<bool> waitTaskbool;
        private int[,] egglocations = new int[5, 2];

        // Constant
        private readonly int walktime = 100;
        private readonly int commanddelay = 250;
        private readonly int longcommandtime = 1000;

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

        public Bot_Breeding6()
        {
            InitializeComponent();
            switch (Program.gCmdWindow.SAV.Version)
            {
                case GameVersion.X:
                case GameVersion.Y:
                    oras = false;
                    Delg.SetEnabled(orgbox_pos, false);
                    Delg.SetEnabled(daycare_select, false);
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
                    break;
                case GameVersion.OR:
                case GameVersion.AS:
                    if (optionRoute117.Checked)
                    {
                        oras = true;
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
                    {
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
                    break;
            }
        }

        private void runBreedingBot_Click(object sender, EventArgs e)
        {
            string modemessage;
            switch (optionMode.SelectedIndex)
            {
                case 0:
                    modemessage = "Simple: This bot will produce " + eggs.Value.ToString() + " eggs and deposit them in the pc, starting at box " + box.Value.ToString() + " slot " + slot.Value.ToString() + ".\r\n\r\n";
                    break;
                case 1:
                    modemessage = "Filter: This bot will produce eggs and deposit them in the pc, starting at box " + box.Value.ToString() + " slot " + slot.Value.ToString() + ". Then it will check against the selected filters and if it finds a match the bot will stop. The bot will also stop if it produces " + eggs.Value.ToString() + " eggs before finding a match.\r\n\r\n";
                    break;
                case 2:
                    modemessage = "ESV/TSV: This bot will produce eggs and deposit them in the pc, starting at box " + box.Value.ToString() + " slot " + slot.Value.ToString() + ". Then it will check the egg's ESV and if it finds a match with the values in the TSV list, the bot will stop. The bot will also stop if it produces " + eggs.Value.ToString() + " eggs before finding a match.\r\n\r\n";
                    break;
                default:
                    modemessage = "No mode selected. Select one and try again.\r\n\r\n";
                    return;
            }
            DialogResult dialogResult = MessageBox.Show("This bot will start producing eggs from the day care using the following rules:\r\n\r\n" + modemessage + "Make sure that you only have one pokémon in your party. Please read the Wiki at Github before starting. Do you want to continue?", "Breeding bot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK && eggs.Value > 0 && optionMode.SelectedIndex >= 0)
            {
                botWorking = true;
                RunBot();
            }
            else
            {
                return;
            }
        }

        public async void RunBot()
        {
            try
            {
                while (botWorking)
                {
                    switch (botState)
                    {
                        case breedbotstates.botstart:
                            Bot.Report("Bot: START Gen 6 Breding bot");
                            if (optionQuickBreed.Checked)
                            {
                                botState = breedbotstates.facedaycareman;
                            }
                            else if (optionMode.SelectedIndex >= 0)
                            {
                                botState = breedbotstates.walk1;
                            }
                            else
                            {
                                botState = breedbotstates.botexit;
                            }
                            break;

                        case breedbotstates.facedaycareman:
                            Bot.Report("Bot: Turn to Day Care Man");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.DpadUP);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.quickegg;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = breedbotstates.facedaycareman;
                            }
                            break;

                        case breedbotstates.quickegg:
                            waitTaskbool = Program.helper.waitNTRwrite(eggoff, 0x01, Program.gCmdWindow.pid);
                            if (await waitTaskbool)
                            {
                                attempts = -10;
                                botState = breedbotstates.triggerdialog;
                            }
                            else
                            {
                                botresult = 1;
                                Bot.Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case breedbotstates.walk1:
                            Bot.Report("Bot: Run south");
                            Program.helper.quickbuton(LookupTable.runDOWN, runtime);
                            await Task.Delay(runtime + commanddelay);
                            botState = breedbotstates.walk2;
                            break;

                        case breedbotstates.walk2:
                            Bot.Report("Bot: Run north");
                            Program.helper.quickbuton(LookupTable.runUP, runtime);
                            await Task.Delay(runtime + commanddelay);
                            botState = breedbotstates.checkegg;
                            break;

                        case breedbotstates.checkegg:
                            Bot.Report("Bot: Check if an egg is available");
                            waitTaskbool = Program.helper.memoryinrange(eggoff, 0x01, 0x01);
                            if (await waitTaskbool)
                            {
                                Bot.Report("Bot: Egg found");
                                botState = breedbotstates.checkmap1;
                            }
                            else
                            {
                                botState = breedbotstates.walk1;
                            }
                            break;

                        case breedbotstates.checkmap1:
                            waitTaskbool = Program.helper.timememoryinrange(mapyoff, daycaremany, 0x01, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = -10;
                                Bot.Report("Bot: Egg found");
                                botState = breedbotstates.triggerdialog;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.walk3;
                            }
                            break;

                        case breedbotstates.walk3:
                            Bot.Report("Bot: Return to day care man");
                            Program.helper.quickbuton(LookupTable.runUP, longcommandtime);
                            await Task.Delay(longcommandtime + commanddelay);
                            botState = breedbotstates.checkmap1;
                            break;

                        case breedbotstates.triggerdialog:
                            Bot.Report("Bot: Talk to Day Care Man");
                            int i;
                            for (i = 0; i < 7; i++)
                            {
                                await Task.Delay(commanddelay);
                                waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                                if (!(await waitTaskbool))
                                    break;
                            }
                            if (i == 7)
                            {
                                botState = breedbotstates.checknoegg;
                            }
                            else
                            {
                                botState = breedbotstates.continuedialog;
                            }
                            break;

                        case breedbotstates.continuedialog:
                            Bot.Report("Bot: Continue dialog");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                botState = breedbotstates.checknoegg;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = breedbotstates.continuedialog;
                            }
                            break;

                        case breedbotstates.checknoegg:
                            waitTaskbool = Program.helper.memoryinrange(eggoff, 0x00, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                Bot.Report("Bot: Egg received");
                                botState = breedbotstates.exitdialog;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.triggerdialog;
                            }
                            break;

                        case breedbotstates.exitdialog:
                            Bot.Report("Bot: Exit dialog");
                            await Task.Delay(5 * commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                            if (await waitTaskbool)
                            {
                                waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                                if (await waitTaskbool)
                                {
                                    addEggtoParty();
                                    if (eggsinparty >= 5 || eggs.Value == 0)
                                    {
                                        attempts = -15; // Allow more attempts
                                        botState = breedbotstates.walktodaycare;
                                    }
                                    else if (optionQuickBreed.Checked)
                                    {
                                        botState = breedbotstates.quickegg;
                                    }
                                    else
                                    {
                                        botState = breedbotstates.walk1;
                                    }
                                }
                                else
                                {
                                    attempts++;
                                    botresult = 7;
                                    botState = breedbotstates.exitdialog;
                                }
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = breedbotstates.exitdialog;
                            }
                            break;

                        case breedbotstates.walktodaycare:
                            Bot.Report("Bot: Walk to Day Care");
                            await Task.Delay(commanddelay);
                            if (oras && optionBattleResort.Checked)
                            {
                                Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            }
                            else
                            {
                                Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            }
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap2;
                            break;

                        case breedbotstates.checkmap2:
                            lastposition = Program.helper.lastRead;
                            waitTaskbool = Program.helper.memoryinrange(mapxoff, daycaredoorx, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.entertodaycare;
                            }
                            else if (lastposition == Program.helper.lastRead)
                            {
                                Bot.Report("Bot: No movement detected, still on dialog?");
                                Program.helper.quickbuton(LookupTable.keyB, 250);
                                await Task.Delay(2 * commanddelay);
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.walktodaycare;
                            }
                            else if (Program.helper.lastRead < daycaredoorx && oras && optionBattleResort.Checked)
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.fix1;
                            }
                            else if (Program.helper.lastRead > daycaredoorx && (!oras || optionRoute117.Checked))
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.fix1;
                            }
                            else
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.walktodaycare;
                            }
                            break;

                        case breedbotstates.fix1:
                            Bot.Report("Bot: Missed day care, return");
                            await Task.Delay(commanddelay);
                            if (oras && optionBattleResort.Checked)
                            {
                                Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            }
                            else
                            {
                                Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            }
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap2;
                            break;

                        case breedbotstates.entertodaycare:
                            Bot.Report("Bot: Enter to Day Care");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.runUP, longcommandtime);
                            await Task.Delay(longcommandtime + commanddelay);
                            botState = breedbotstates.checkmap3;
                            break;

                        case breedbotstates.checkmap3:
                            waitTaskbool = Program.helper.timememoryinrange(mapidoff, daycaremapid, 0x01, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.walktodesk;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.entertodaycare;
                            }
                            break;

                        case breedbotstates.walktodesk:
                            Bot.Report("Bot: Run to desk");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.runUP, longcommandtime);
                            await Task.Delay(longcommandtime + commanddelay);
                            botState = breedbotstates.checkmap4;
                            break;

                        case breedbotstates.checkmap4:
                            waitTaskbool = Program.helper.timememoryinrange(mapyoff, computery, 0x01, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.walktocomputer;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.walktodesk;
                            }
                            break;

                        case breedbotstates.walktocomputer:
                            Bot.Report("Bot: Walk to the PC");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap5;
                            break;

                        case breedbotstates.checkmap5:
                            waitTaskbool = Program.helper.memoryinrange(mapxoff, computerx, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.facecomputer;
                            }
                            else if (Program.helper.lastRead > computerx)
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.fix2;
                            }
                            else
                            { // Still far from computer
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.walktocomputer;
                            }
                            break;

                        case breedbotstates.fix2:
                            Bot.Report("Bot: Missed PC, return");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap5;
                            break;

                        case breedbotstates.facecomputer:
                            Bot.Report("Bot: Turn on the PC");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.DpadUP);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.startcomputer;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = breedbotstates.facecomputer;
                            }
                            break;

                        case breedbotstates.startcomputer:
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                botState = breedbotstates.testcomputer;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = breedbotstates.startcomputer;
                            }
                            break;

                        case breedbotstates.testcomputer:
                            Bot.Report("Bot: Test if the PC is on");
                            await Task.Delay(8 * commanddelay); // Wait for PC on
                            waitTaskbool = Program.helper.timememoryinrange(computerOff, computerIN, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.computerdialog;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.facecomputer;
                            }
                            break;

                        case breedbotstates.computerdialog:
                            Bot.Report("Bot: Skip PC dialog");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.pressPCstorage;
                            }
                            else
                            {
                                botresult = 7;
                                Bot.Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case breedbotstates.pressPCstorage:
                            Bot.Report("Bot: Press Access PC storage");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.touchOrganize;
                            }
                            else
                            {
                                botresult = 7;
                                Bot.Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case breedbotstates.touchOrganize:
                            Bot.Report("Bot: Touch Organize boxes");
                            await Task.Delay(2 * commanddelay);
                            if (oras && optionTop.Checked)
                            {
                                waitTaskbool = Program.helper.waittouch(160, 40);
                            }
                            else
                            {
                                waitTaskbool = Program.helper.waittouch(160, 120);
                            }
                            if (await waitTaskbool)
                            {
                                botState = breedbotstates.testboxes;
                            }
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botState = breedbotstates.touchOrganize;
                            }
                            break;

                        case breedbotstates.testboxes:
                            Bot.Report("Test if the boxes are shown");
                            await Task.Delay(4 * commanddelay);
                            waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, organizeBoxIN, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.readslot;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.touchOrganize;
                            }
                            break;

                        case breedbotstates.readslot:
                            Bot.Report("Bot: Search for empty slot");
                            //waitTaskint = Program.helper.waitPokeRead(currentbox, currentslot);
                            //dataready = await waitTaskint;
                            //switch (dataready)
                            //{
                            //    case -2: // Read error
                            //        botresult = 2;
                            //        Bot.Report("Bot: Error detected");
                            //        attempts = 11;
                            //        break;
                            //    case -1: // Empty slot
                            //        botState = breedbotstates.testboxchange;
                            //        break;
                            //    default: // Not empty slot
                            //        getNextSlot();
                            //        botState = breedbotstates.readslot;
                            //        break;
                            //}
                            break;

                        case breedbotstates.testboxchange:
                            if (boxchange)
                            {
                                botState = breedbotstates.touchboxview;
                                boxchange = false;
                            }
                            else
                            {
                                botState = breedbotstates.touchegg;
                            }
                            break;

                        case breedbotstates.touchboxview:
                            Bot.Report("Bot: Touch Box View");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waittouch(30, 220);
                            if (await waitTaskbool)
                            {
                                botState = breedbotstates.testboxview;
                            }
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botState = breedbotstates.touchboxview;
                            }
                            break;

                        case breedbotstates.testboxview:
                            Bot.Report("Bot: Test if box view is shown");
                            await Task.Delay(4 * commanddelay);
                            waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewIN, wtboxviewRange, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.touchnewbox;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.touchboxview;
                            }
                            break;

                        case breedbotstates.touchnewbox:
                            Bot.Report("Bot: Touch New Box");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waittouch(LookupTable.boxposX6[(int)box.Value], LookupTable.boxposY6[(int)box.Value]);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.selectnewbox;
                            }
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botState = breedbotstates.touchnewbox;
                            }
                            break;

                        case breedbotstates.selectnewbox:
                            Bot.Report("Bot: Select New Box");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                            {
                                botState = breedbotstates.testviewout;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = breedbotstates.selectnewbox;
                            }
                            break;

                        case breedbotstates.testviewout:
                            Bot.Report("Bot: Test if box view is not shown");
                            await Task.Delay(4 * commanddelay);
                            waitTaskbool = Program.helper.timememoryinrange(wtboxviewOff, wtboxviewOUT, wtboxviewRange, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.touchegg;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.selectnewbox;
                            }
                            break;

                        case breedbotstates.touchegg:
                            Bot.Report("Bot: Select Egg");
                            await Task.Delay(2 * commanddelay);
                            waitTaskbool = Program.helper.waitholdtouch(300, 100);
                            if (await waitTaskbool)
                            {
                                botState = breedbotstates.moveegg;
                            }
                            else
                            {
                                botresult = 6;
                                Bot.Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case breedbotstates.moveegg:
                            Bot.Report("Move Egg");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitholdtouch(LookupTable.pokeposX6[(int)slot.Value], LookupTable.pokeposY6[(int)slot.Value]);
                            if (await waitTaskbool)
                            {
                                botState = breedbotstates.releaseegg;
                            }
                            else
                            {
                                botresult = 6;
                                Bot.Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case breedbotstates.releaseegg:
                            Bot.Report("Bot: Release Egg");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitfreetouch();
                            if (await waitTaskbool)
                            {
                                egglocations[eggsinbatch, 0] = (int)box.Value;
                                egglocations[eggsinbatch, 1] = (int)slot.Value;
                                eggsinbatch++;
                                getNextSlot();
                                eggsinparty--;
                                if (eggsinparty > 0)
                                {
                                    botState = breedbotstates.readslot;
                                }
                                else
                                {
                                    botState = breedbotstates.exitcomputer;
                                }
                            }
                            else
                            {
                                botresult = 6;
                                Bot.Report("Bot: Error detected");
                                attempts = 11;
                            }
                            break;

                        case breedbotstates.exitcomputer:
                            Bot.Report("Bot: Exit from PC");
                            await Task.Delay(commanddelay);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyX);
                            if (await waitTaskbool)
                            {
                                botState = breedbotstates.testexit;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = breedbotstates.exitcomputer;
                            }
                            break;

                        case breedbotstates.testexit:
                            Bot.Report("Bot: Test if out from PC");
                            waitTaskbool = Program.helper.timememoryinrange(wtboxesOff, organizeBoxOUT, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                if (optionMode.SelectedIndex == 1 || optionMode.SelectedIndex == 2 || optionReadESV.Checked)
                                {
                                    botState = breedbotstates.filter;
                                }
                                else if (eggs.Value > 0)
                                {
                                    botState = breedbotstates.retirefromcomputer;
                                }
                                else
                                {
                                    Bot.Report("Bot: Error detected");
                                    attempts = 11;
                                }
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.exitcomputer;
                            }
                            break;

                        case breedbotstates.retirefromcomputer:
                            Bot.Report("Bot: Retire from PC");
                            await Task.Delay(commanddelay);
                            eggsinbatch = 0;
                            Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap6;
                            break;

                        case breedbotstates.checkmap6:
                            waitTaskbool = Program.helper.memoryinrange(mapxoff, daycareexitx, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.retirefromdesk;
                            }
                            else if (Program.helper.lastRead < daycareexitx)
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.fix3;
                            }
                            else
                            { // Still far from exit
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.retirefromcomputer;
                            }
                            break;

                        case breedbotstates.fix3:
                            Bot.Report("Bot: Missed exit, return");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap6;
                            break;

                        case breedbotstates.retirefromdesk:
                            Bot.Report("Bot: Run to exit");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.runDOWN, longcommandtime);
                            await Task.Delay(longcommandtime + commanddelay);
                            botState = breedbotstates.checkmap7;
                            break;

                        case breedbotstates.checkmap7:
                            waitTaskbool = Program.helper.timememoryinrange(mapidoff, routemapid, 0x01, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = breedbotstates.retirefromdoor;
                            }
                            else
                            {
                                attempts++;
                                botresult = 2;
                                botState = breedbotstates.retirefromdesk;
                            }
                            break;

                        case breedbotstates.retirefromdoor:
                            Bot.Report("Bot: Retire from door");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadDOWN, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap8;
                            break;

                        case breedbotstates.checkmap8:
                            waitTaskbool = Program.helper.memoryinrange(mapyoff, daycaremany, 0x01);
                            if (await waitTaskbool)
                            {
                                attempts = -10; // Allow more attempts
                                botState = breedbotstates.walktodaycareman;
                            }
                            else if (Program.helper.lastRead > daycaremany)
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.fix5;
                            }
                            else
                            { // Still far from exit
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.retirefromdoor;
                            }
                            break;

                        case breedbotstates.fix5:
                            Bot.Report("Bot: Missed Day Care Man, return");
                            await Task.Delay(commanddelay);
                            Program.helper.quickbuton(LookupTable.DpadUP, walktime);
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap8;
                            break;

                        case breedbotstates.walktodaycareman:
                            Bot.Report("Bot: Walk to Day Care Man");
                            await Task.Delay(commanddelay);
                            if (oras && optionBattleResort.Checked)
                            {
                                Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            }
                            else
                            {
                                Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            }
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap9;
                            break;

                        case breedbotstates.checkmap9:
                            waitTaskbool = Program.helper.memoryinrange(mapxoff, daycaremanx, 0x01);
                            if (await waitTaskbool)
                            {
                                if (optionQuickBreed.Checked)
                                {
                                    botState = breedbotstates.facedaycareman;
                                }
                                else
                                {
                                    botState = breedbotstates.walk1;
                                }
                                attempts = 0;
                            }
                            else if (Program.helper.lastRead > daycaremanx && oras && optionBattleResort.Checked)
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.fix4;
                            }
                            else if (Program.helper.lastRead > daycaremanx && (!oras || optionRoute117.Checked))
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.fix4;
                            }
                            else
                            {
                                attempts++;
                                botresult = -1;
                                botState = breedbotstates.walktodaycareman;
                            }
                            break;

                        case breedbotstates.fix4:
                            Bot.Report("Bot: Missed Day Care Man, return");
                            await Task.Delay(commanddelay);
                            if (oras && optionBattleResort.Checked)
                            {
                                Program.helper.quickbuton(LookupTable.DpadRIGHT, walktime);
                            }
                            else
                            {
                                Program.helper.quickbuton(LookupTable.DpadLEFT, walktime);
                            }
                            await Task.Delay(walktime + commanddelay);
                            botState = breedbotstates.checkmap9;
                            break;

                        case breedbotstates.filter:
                            //for (i = 0; i < eggsinbatch; i++)
                            //{
                            //    filterbox = egglocations[i, 0];
                            //    filterslot = egglocations[i, 1];
                            //    bool testsok = false;
                            //    Bot.Report("Bot: Check deposited egg");
                            //    waitTaskint = Program.helper.waitPokeRead(filterbox, filterslot);
                            //    dataready = await waitTaskint;
                            //    if (dataready >= 0)
                            //    {
                            //        uint PID = Convert.ToUInt32(dataready);
                            //        if (readesv || mode == 2)
                            //        {
                            //            int esv = ((PID >> 16 ^ PID & 0xFFFF) >> 4);
                            //            Program.gCmdWindow.AddESVrow(filterbox, filterslot, esv);
                            //            if (mode == 2)
                            //            {
                            //                currentesv = esv;
                            //                testsok = Program.gCmdWindow.ESV_TSV_check(esv);
                            //            }
                            //        }
                            //        if (mode == 1)
                            //        {
                            //            testsok = Program.gCmdWindow.CheckBreedingFilters();
                            //        }
                            //    }
                            //    else
                            //    {
                            //        botresult = 2;
                            //        Bot.Report("Bot: Error detected");
                            //        attempts = 11;
                            //        break;
                            //    }
                            //    if (testsok)
                            //    {
                            //        botState = breedbotstates.testspassed;
                            //        break;
                            //    }
                            //    else if (quantity > 0)
                            //    {
                            //        botState = breedbotstates.retirefromcomputer;
                            //    }
                            //    else
                            //    {
                            //        if (mode == 1 || mode == 2)
                            //        {
                            //            Bot.Report("Bot: No match found");
                            //            botresult = 3;
                            //        }
                            //        else
                            //        {
                            //            botresult = 0;
                            //        }
                            //        botState = breedbotstates.botexit;
                            //    }
                            //}
                            break;

                        case breedbotstates.testspassed:
                            //if (optionMode.SelectedIndex == 1)
                            //{
                            //    Bot.Report("Bot: All tests passed");
                            //    botresult = 4;
                            //    finishmessage = "Finished. A match was found at box " + (filterbox + 1) + ", slot " + (filterslot + 1) + ", using filter #";
                            //}
                            //else if (mode == 2)
                            //{
                            //    Bot.Report("Bot: ESV/TSV match found");
                            //    botresult = 5;
                            //    finishmessage = "Finished. A match was found at box " + (filterbox + 1) + ", slot " + (filterslot + 1) + ", the ESV/TSV value is: " + currentesv;
                            //}
                            //botState = breedbotstates.botexit;
                            break;

                        case breedbotstates.botexit:
                            Bot.Report("Bot: STOP Gen 6 Breding bot");
                            botWorking = false;
                            break;

                        default:
                            Bot.Report("Bot: STOP Gen 6 Breding bot");
                            botresult = 0;
                            botWorking = false;
                            break;
                    }
                    if (attempts > 10)
                    { // Too many attempts
                        if (maxreconnect > 0)
                        {
                            Bot.Report("Bot: Try reconnection to fix error");
                            waitTaskbool = Program.gCmdWindow.Reconnect();
                            maxreconnect--;
                            if (await waitTaskbool)
                            {
                                await Task.Delay(10 * commanddelay);
                                attempts = 0;
                            }
                            else
                            {
                                botresult = -1;
                                botWorking = false;
                            }
                        }
                        else
                        {
                            Bot.Report("Bot: STOP Gen 6 Breding bot");
                            botWorking = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bot.Report("Bot: Exception detected:");
                Bot.Report(ex.Source);
                Bot.Report(ex.Message);
                Bot.Report(ex.StackTrace);
                Bot.Report("Bot: STOP Gen 6 Breding bot");
                MessageBox.Show(ex.Message);
                botresult = -1;
            }
        }

        private void getNextSlot()
        {
            if (slot.Value == 30)
            {
                boxchange = true;
                Delg.SetValue(slot, 1);
                if (box.Value == 31)
                {
                    Delg.SetValue(box, 1);
                }
                else
                {
                    Delg.SetValue(box, box.Value + 1);
                }
            }
            else
            {
                Delg.SetValue(slot, slot.Value + 1);
            }
        }

        private void addEggtoParty()
        {
            eggsinparty++;
            Delg.SetValue(eggs, eggs.Value - 1);
        }
    }
}
