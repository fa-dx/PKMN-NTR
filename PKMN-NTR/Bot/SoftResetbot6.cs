﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntrbase.Bot
{
    class SoftResetbot6
    {
        public enum srbotstates { botstart, pssmenush, fixwifi, touchpssset, testpssset, touchpssdis, testpssdis, touchpssconf, testpssout, returncontrol, touchsave, testsave, saveconf, saveout, typesr, trigger, readopp, filter, testspassed, testshiny, testnature, testhp, testatk, testdef, testspa, testspd, testspe, testhdnpwr, testability, testgender, alltestsok, softreset, skipintro, skiptitle, startgame, reconnect, tev_start, tev_dialog, tev_cont1, tev_check, twk_start, botexit };

        // Bot variables
        public int botresult;
        public int resetNo;
        public bool botstop;

        // Class variables
        private int botState;
        private int attempts;
        private int maxreconnect;
        private long dataready;
        Task<bool> waitTaskbool;
        Task<long> waitTaskint;

        // Bot constants
        private readonly int commandtime = 250;
        private readonly int commanddelay = 250;

        // Input variables
        private int mode;
        private bool resume;
        private bool oras;

        // Data offsets
        private uint partyOff;
        private uint psssmenu1Off;
        private uint psssmenu1IN;
        //private uint psssmenu1OUT;
        public uint savescrnOff;
        public uint savescrnIN;
        public uint savescrnOUT;
        public uint pssettingsOff;
        public uint pssettingsIN;
        public uint pssettingsOUT;
        public uint pssdisableOff;
        public uint pssdisableY;
        public uint pssdisableIN;
        public uint pssdisableOUT;
        public uint dialogOff;
        public uint dialogIN;
        public uint dialogOUT;

        public SoftResetbot6(int botmode, bool botresume, bool orasgame)
        {
            botresult = 0;
            resetNo = 0;
            botstop = false;

            botState = (int)srbotstates.botstart;
            attempts = 0;
            maxreconnect = 10;
            dataready = 0;

            mode = botmode;
            resume = botresume;
            oras = orasgame;

            if (!oras)
            { // XY
                partyOff = 0x8CE1CF8;
                psssmenu1Off = 0x19ABC0;
                psssmenu1IN = 0x7E0000;
                //psssmenu1OUT = 0x4D0000;
                savescrnOff = 0x19AB78;
                savescrnIN = 0x7E0000;
                savescrnOUT = 0x4D0000;
                pssettingsOff = 0x19ABF0;
                pssettingsIN = 0x7E0000;
                pssettingsOUT = 0x4D0000;
                pssdisableOff = 0x5EEEA4;
                pssdisableY = 100;
                pssdisableIN = 0x00000000;
                pssdisableOUT = 0x15000000;
                dialogOff = 0x5EA188;
                dialogIN = 0x0D;
                dialogOUT = 0x00;
            }
            else
            { // ORAS
                partyOff = 0x8CFB26C;
                psssmenu1Off = 0x19C21C;
                psssmenu1IN = 0x830000;
                //psssmenu1OUT = 0x500000;
                savescrnOff = 0x19C1CC;
                savescrnIN = 0x830000;
                savescrnOUT = 0x500000;
                pssettingsOff = 0x19C244;
                pssettingsIN = 0x830000;
                pssettingsOUT = 0x500000;
                pssdisableOff = 0x630DA5;
                pssdisableY = 120;
                pssdisableIN = 0x33000000;
                pssdisableOUT = 0x33100000;
                dialogOff = 0x62C2F4;
                dialogIN = 0x0D;
                dialogOUT = 0x0A;
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
                        case (int)srbotstates.botstart:
                            Report("Bot start");
                            switch (mode)
                            {
                                case 0:
                                    if (resume)
                                        botState = (int)srbotstates.trigger;
                                    else
                                        botState = (int)srbotstates.pssmenush;
                                    break;
                                case 1:
                                    if (resume)
                                        botState = (int)srbotstates.trigger;
                                    else
                                        botState = (int)srbotstates.pssmenush;

                                    break;
                                case 2:
                                    if (resume)
                                    {
                                        botState = (int)srbotstates.tev_start;
                                    }
                                    else
                                    {
                                        botState = (int)srbotstates.pssmenush;
                                        resetNo = -1;
                                    }
                                    break;
                                case 3:
                                    if (resume)
                                        botState = (int)srbotstates.trigger;
                                    else
                                        botState = (int)srbotstates.fixwifi;
                                    break;
                                case 4:
                                    if (resume)
                                        botState = (int)srbotstates.twk_start;
                                    else
                                        botState = (int)srbotstates.pssmenush;
                                    break;
                                default:
                                    botState = (int)srbotstates.botexit;
                                    break;
                            }
                            break;

                        case (int)srbotstates.pssmenush:
                            Report("Test if the PSS menu is shown");
                            waitTaskbool = Program.helper.memoryinrange(psssmenu1Off, psssmenu1IN, 0x10000);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.fixwifi;
                            else
                            {
                                botresult = 1;
                                botState = (int)srbotstates.botexit;
                            }
                            break;

                        case (int)srbotstates.fixwifi:
                            waitTaskbool = Program.helper.waitNTRwrite(0x0105AE4, 0x4770, 0x1A);
                            if (await waitTaskbool)
                            {
                                if (mode == 3)
                                    botState = (int)srbotstates.trigger;
                                else
                                    botState = (int)srbotstates.touchpssset;
                            }
                            else
                            {
                                botresult = 1;
                                Report("Error detected");
                                attempts = 11;
                            }
                            break;

                        case (int)srbotstates.touchpssset:
                            Report("Touch Box View");
                            waitTaskbool = Program.helper.waittouch(240, 180);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.testpssset;
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botState = (int)srbotstates.touchpssset;
                            }
                            break;

                        case (int)srbotstates.testpssset:
                            Report("Test if the PSS setings are shown");
                            waitTaskbool = Program.helper.timememoryinrange(pssettingsOff, pssettingsIN, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotstates.touchpssdis;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotstates.touchpssset;
                            }
                            break;

                        case (int)srbotstates.touchpssdis:
                            Report("Touch Disable PSS communication");
                            waitTaskbool = Program.helper.waittouch(160, pssdisableY);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.testpssdis;
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botState = (int)srbotstates.touchpssdis;
                            }
                            break;

                        case (int)srbotstates.testpssdis:
                            Report("Test if PSS disable confirmation appears");
                            waitTaskbool = Program.helper.timememoryinrange(pssdisableOff, pssdisableIN, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotstates.touchpssconf;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotstates.touchpssdis;
                            }
                            break;

                        case (int)srbotstates.touchpssconf:
                            Report("Touch Yes");
                            waitTaskbool = Program.helper.waittouch(160, 120);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.testpssout;
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botState = (int)srbotstates.touchpssconf;
                            }
                            break;

                        case (int)srbotstates.testpssout:
                            Report("Test if back to PSS screen");
                            waitTaskbool = Program.helper.timememoryinrange(pssettingsOff, pssettingsOUT, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotstates.returncontrol;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotstates.touchpssconf;
                            }
                            break;

                        case (int)srbotstates.returncontrol:
                            Report("Return contol to character");
                            await Task.Delay(1500);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.touchsave;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotstates.returncontrol;
                            }
                            break;

                        case (int)srbotstates.touchsave:
                            Report("Touch Save button");
                            await Task.Delay(1000);
                            waitTaskbool = Program.helper.waittouch(220, 220);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.testsave;
                            else
                            {
                                attempts++;
                                botresult = 6;
                                botState = (int)srbotstates.touchsave;
                            }
                            break;

                        case (int)srbotstates.testsave:
                            Report("Test if the save screen is shown");
                            waitTaskbool = Program.helper.timememoryinrange(savescrnOff, savescrnIN, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotstates.saveconf;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotstates.touchsave;
                            }
                            break;

                        case (int)srbotstates.saveconf:
                            Report("Press Yes");
                            await Task.Delay(2000);
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.saveout;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotstates.saveconf;
                            }
                            break;

                        case (int)srbotstates.saveout:
                            Report("Test if the save screen is not shown");
                            waitTaskbool = Program.helper.timememoryinrange(savescrnOff, savescrnOUT, 0x10000, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                if (mode == 2)
                                {
                                    Report("Soft-reset for party data intialize");
                                    botState = (int)srbotstates.softreset;
                                }
                                else
                                    botState = (int)srbotstates.typesr;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotstates.saveconf;
                            }
                            break;

                        case (int)srbotstates.typesr:
                            switch (mode)
                            {
                                case 0:
                                    botState = (int)srbotstates.trigger;
                                    break;
                                case 1:
                                    botState = (int)srbotstates.trigger;
                                    break;
                                case 2:
                                    botState = (int)srbotstates.tev_start;
                                    break;
                                case 3:
                                    botState = (int)srbotstates.trigger;
                                    break;
                                case 4:
                                    botState = (int)srbotstates.twk_start;
                                    break;
                                default:
                                    botState = (int)srbotstates.trigger;
                                    break;
                            }
                            break;

                        case (int)srbotstates.trigger:
                            Report("Try to trigger encounter");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.readopp;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotstates.trigger;
                            }
                            break;

                        case (int)srbotstates.readopp:
                            Report("Try to read opponent");
                            await Task.Delay(500); // Wait for pokémon data
                            waitTaskint = Program.gCmdWindow.ReadOpponent();
                            dataready = await waitTaskint;
                            if (dataready >= 0)
                            {
                                attempts = 0;
                                Report("PID: 0x" + dataready.ToString("X8"));
                                botState = (int)srbotstates.filter;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotstates.trigger;
                            }
                            break;

                        case (int)srbotstates.filter:
                            bool testsok = Program.gCmdWindow.CheckSoftResetFilters();
                            if (testsok)
                                botState = (int)srbotstates.testspassed;
                            else
                                botState = (int)srbotstates.softreset;
                            break;

                        case (int)srbotstates.testspassed:
                            Report("All tests passed!");
                            botresult = 4;
                            botState = (int)srbotstates.botexit;
                            break;

                        case (int)srbotstates.softreset:
                            resetNo++;
                            Report("Sof-reset #" + resetNo.ToString());
                            waitTaskbool = Program.helper.waitSoftReset();
                            if (await waitTaskbool)
                            {
                                botState = (int)srbotstates.skipintro;
                            }
                            else
                            {
                                botresult = 2;
                                botState = (int)srbotstates.botexit;
                            }
                            break;

                        case (int)srbotstates.skipintro:
                            await Task.Delay(9000);
                            Report("Skip intro cutscene");
                            Program.helper.quickbuton(LookupTable.keyA, commandtime);
                            await Task.Delay(commandtime + commanddelay);
                            if (!oras)
                                botState = (int)srbotstates.startgame;
                            else
                                botState = (int)srbotstates.skiptitle;
                            break;

                        case (int)srbotstates.skiptitle:
                            await Task.Delay(4000);
                            Report("Skip title screen");
                            Program.helper.quickbuton(LookupTable.keyA, commandtime);
                            await Task.Delay(commandtime + commanddelay);
                            botState = (int)srbotstates.startgame;
                            break;

                        case (int)srbotstates.startgame:
                            await Task.Delay(5000);
                            Report("Start game");
                            Program.helper.quickbuton(LookupTable.keyA, commandtime);
                            await Task.Delay(commandtime + commanddelay);
                            botState = (int)srbotstates.reconnect;
                            break;

                        case (int)srbotstates.reconnect:
                            await Task.Delay(3000);
                            waitTaskbool = Program.gCmdWindow.Reconnect();
                            if (await waitTaskbool)
                            {
                                await Task.Delay(2000);
                                botState = (int)srbotstates.typesr;
                            }
                            else
                            {
                                botresult = -1;
                                botState = (int)srbotstates.botexit;
                            }
                            break;

                        case (int)srbotstates.tev_start:
                            Report("Trigger Dialog");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyA);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.tev_dialog;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotstates.tev_start;
                            }
                            break;

                        case (int)srbotstates.tev_dialog:
                            Report("Test if dialog has started");
                            waitTaskbool = Program.helper.timememoryinrange(dialogOff, dialogIN, 0x01, 100, 5000);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotstates.tev_cont1;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotstates.tev_start;
                            }
                            break;

                        case (int)srbotstates.tev_cont1:
                            await Task.Delay(1000);
                            Report("Talk to lady");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.keyB);
                            if (await waitTaskbool)
                                botState = (int)srbotstates.tev_check;
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotstates.tev_cont1;
                            }
                            break;

                        case (int)srbotstates.tev_check:
                            Report("Try to read party");
                            waitTaskint = Program.helper.waitPartyRead(partyOff, 1);
                            dataready = await waitTaskint;
                            if (dataready >= 0)
                            {
                                attempts = 0;
                                Report("PID: 0x" + dataready.ToString("X8"));
                                botState = (int)srbotstates.filter;
                            }
                            else
                            {
                                attempts++;
                                botresult = 3;
                                botState = (int)srbotstates.tev_cont1;
                            }
                            break;

                        case (int)srbotstates.twk_start:
                            await Task.Delay(1000);
                            Report("Walk one step");
                            waitTaskbool = Program.helper.waitbutton(LookupTable.runUP);
                            if (await waitTaskbool)
                            {
                                attempts = 0;
                                botState = (int)srbotstates.trigger;
                            }
                            else
                            {
                                attempts++;
                                botresult = 7;
                                botState = (int)srbotstates.twk_start;
                            }
                            break;

                        case (int)srbotstates.botexit:
                            Report("Bot stop");
                            botstop = true;
                            break;

                        default:
                            Report("Bot stop");
                            botresult = 0;
                            botstop = true;
                            break;
                    }
                    if (attempts > 15)
                    { // Too many attempts
                        if (maxreconnect > 0)
                        {
                            waitTaskbool = Program.gCmdWindow.Reconnect();
                            maxreconnect--;
                            if (await waitTaskbool)
                            {
                                await Task.Delay(1000);
                                attempts = 0;
                                if (botState == (int)srbotstates.tev_check || botState == (int)srbotstates.tev_cont1)
                                    botState = (int)srbotstates.tev_dialog;
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
            catch (Exception ex)
            {
                Report(ex.Source);
                Report(ex.Message);
                Report(ex.StackTrace);
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void Report(string log)
        {
            Program.gCmdWindow.Addlog(log);
        }
    }
}
