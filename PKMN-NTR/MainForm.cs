using ntrbase.Properties;
using ntrbase.Sub_forms;
using ntrbase.Bot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using ntrbase.Helpers;
using PKHeX.Core;
using Octokit;

namespace ntrbase
{
    public partial class MainForm : Form
    {
        #region Class variables

        //A "waiting room", where functions wait for data to be acquired. Entries are indexed by their sequence number. Once a request with a given sequence number is fulfilled, handleDataReady() uses information in DataReadyWaiting object to process the data.
        public static Dictionary<uint, DataReadyWaiting> waitingForData = new Dictionary<uint, DataReadyWaiting>();

        // Set this boolean to true to enable the write feature for the party pokémon.
        public static readonly bool enablepartywrite = false;

        // Structure for box/slot last position
        struct LastBoxSlot
        {
            public decimal box { get; set; }
            public decimal slot { get; set; }
        }

        // New program-wide varialbes for PKHeX.Core
        public SaveFile SAV;
        public PKM pkm;
        private const string pkhexlang = "en";
        public byte[] fileinfo;
        public byte[] iteminfo;

        // Program constants
        public uint BOXES;
        public int MAXSPECIES;
        public const int BOXSIZE = 30;
        public const int POKEBYTES = 232;
        public const string FOLDERPOKE = "Pokemon";
        public const string FOLDERDELETE = "Deleted";
        public const string FOLDERWT = "Wonder Trade";
        public string PKXEXT;
        public string BOXEXT;
        private static string numberPattern = " ({0})";

        // Variables for update checking
        internal GitHubClient Github;
        private string updateURL = null;

        // Variables for cloning
        public byte[] selectedCloneData = new byte[POKEBYTES];
        public bool selectedCloneValid = false;

        //Game information
        public int pid;
        public byte lang;
        public string pname;
        //Offsets for basic data
        public uint langoff;
        //Offsets for Pokemon sources
        public uint tradeOff;
        public uint opponentOff;
        public uint partyOff;
        public uint boxOff;
        public uint daycare1Off;
        public uint daycare2Off;
        public uint daycare3Off; // Battle Resort Daycare
        public uint daycare4Off; // Battle Resort Daycare
        public uint battleBoxOff;

        //This array will contain controls that should be enabled when connected and disabled when disconnected.
        Control[] enableWhenConnected = new Control[] { };
        Control[] enableWhenConnected7 = new Control[] { };
        Control[] gen6onlyControls = new Control[] { };

        // Log handling
        public delegate void LogDelegate(string l);
        public LogDelegate delAddLog;

        // Bot varialges
        public bool botWorking;
        public string lastlog;

        #endregion Class variables

        #region Main window

        public MainForm()
        {
            Program.ntrClient.DataReady += handleDataReady;
            Program.ntrClient.Connected += connectCheck;
            Program.ntrClient.InfoReady += getGame;
            delAddLog = new LogDelegate(Addlog);
            InitializeComponent();

            enableWhenConnected = new Control[] { };

            enableWhenConnected7 = new Control[] { };

            gen6onlyControls = new Control[] { };

            disableControls();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lb_pkmnntrver.Text = System.Windows.Forms.Application.ProductVersion + " - DEV BUILD";

            addtoLog("THIS IS A BUILD FOR A DEVEOPMENT BRANCH - DO NOT EXPECT IT TO WORK");

            //checkUpdate();
            host.Text = Settings.Default.IP;
            callIP();
            host.Focus();
        }

        private async void checkUpdate()
        {
            try
            {
                addtoLog("GUI: Look for updates");
                // Get current
                int major = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major;
                int minor = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor;
                int build = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build;
                addtoLog("GUI: Current version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

                // Get latest stable
                Github = new GitHubClient(new ProductHeaderValue("PKMN-NTR-UpdateCheck"));
                Release lateststable = await Github.Repository.Release.GetLatest("drgoku282", "PKMN-NTR");
                int[] verlatest = Array.ConvertAll(lateststable.TagName.Split('.'), int.Parse);
                addtoLog("GUI: Last stable: " + lateststable.TagName);

                // Look for latest stable
                if (verlatest[0] > major || verlatest[1] > minor || verlatest[2] > build)
                {
                    addtoLog("GUI: Update found!");
                    Delg.SetText(lb_update, "Version " + lateststable.TagName + " is available.");
                    updateURL = lateststable.HtmlUrl;
                    DialogResult result = MessageBox.Show("Version " + lateststable.TagName + " is available.\r\nDo you want to go to GitHub and download it?", "Update Available", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(updateURL);
                    }
                }
                else
                { // Look for beta
                    IReadOnlyList<Release> releases = await Github.Repository.Release.GetAll("drgoku282", "PKMN-NTR");
                    Release latestbeta = releases.FirstOrDefault(rel => rel.Prerelease);
                    if (latestbeta != null)
                    {
                        addtoLog("GUI: Last preview: " + latestbeta.TagName);
                        int[] verbeta = Array.ConvertAll(latestbeta.TagName.Split('.'), int.Parse);
                        if (verbeta[0] > major || verbeta[1] > minor || verbeta[2] > build)
                        {
                            addtoLog("GUI: New preview version found");
                            Delg.SetText(lb_update, "Preview version " + latestbeta.TagName + " is available.");
                            updateURL = latestbeta.HtmlUrl;
                        }
                        else
                        {
                            addtoLog("GUI: PKMN-NTR is up to date");
                            Delg.SetText(lb_update, "PKMN-NTR is up to date.");
                            updateURL = null;
                        }
                    }
                    else
                    {
                        addtoLog("GUI: PKMN-NTR is up to date");
                        Delg.SetText(lb_update, "PKMN-NTR is up to date.");
                        updateURL = null;
                    }
                }
            }
            catch (Exception ex)
            {
                updateURL = null;
                addtoLog("GUI: An error has ocurred while checking for updates:");
                addtoLog(ex.Message);
                MessageBox.Show(ex.Message);
                Delg.SetText(lb_update, "Update not found.");
            }
        }

        private void updateLabel_Click(object sender, EventArgs e)
        {
            if (updateURL != null)
            {
                Process.Start(updateURL);
            }
        }

        private void enableControls()
        {
            if (SAV.Generation == 7)
            {
                foreach (Control c in enableWhenConnected7)
                {
                    Delg.SetEnabled(c, true);
                }
                foreach (Control c in gen6onlyControls)
                {
                    Delg.SetEnabled(c, false);
                }
            }
            else
            {
                foreach (Control c in enableWhenConnected)
                {
                    Delg.SetEnabled(c, true);
                }
            }
            foreach (TabPage tab in Tabs_General.TabPages)
            {
                Delg.SetEnabled(tab, true);
            }
        }

        private void disableControls()
        {
            if (SAV.Generation == 7)
            {
                foreach (Control c in enableWhenConnected7)
                {
                    Delg.SetEnabled(c, false);
                }
            }
            else
            {
                foreach (Control c in enableWhenConnected)
                {
                    Delg.SetEnabled(c, false);
                }
            }
            foreach (TabPage tab in Tabs_General.TabPages)
            {
                if (!(tab.Name == "Tab_Log" || tab.Name == "Tab_About"))
                {
                    Delg.SetEnabled(tab, false);
                }
            }
        }

        public void Addlog(string l)
        {
            lastlog = l;
            if (l.Contains("Server disconnected") && !botWorking && SAV.Version == GameVersion.Invalid)
            {
                PerformDisconnect();
            }
            if (l.Contains("finished") && botWorking) // Supress "finished" messages on bots
            {
                l = l.Replace("finished", null);
            }
            if (!l.Contains("\r\n") && l.Length > 2)
            {
                l = l.Replace("\n", "\r\n");
            }
            if (!l.EndsWith("\n") && l.Length > 2)
            {
                l += "\r\n";
            }
            txtLog.AppendText(l);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Program.ntrClient.sendHeartbeatPacket();
            }
            catch (Exception)
            {

            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ntrClient.disconnect();
        }

        public void startAutoDisconnect()
        {
            disconnectTimer.Enabled = true;
        }

        private void disconnectTimer_Tick(object sender, EventArgs e)
        {
            disconnectTimer.Enabled = false;
            Program.ntrClient.disconnect();
            SAV = SaveUtil.getBlankSAV(GameVersion.Invalid, "PKMN-NTR");
            pkm = new PK7();
        }

        [Conditional("DEBUG")]
        private void callIP()
        {
            addtoLog("THIS IS A DEBUG VERSION - ONLY FOR TESTING");
            StreamReader sr = new StreamReader("D:\\IP.txt");
            host.Text = sr.ReadLine();
            sr.Close();
        }

        static void handleDataReady(object sender, DataReadyEventArgs e)
        { // We move data processing to a separate thread. This way even if processing takes a long time, the netcode doesn't hang.
            DataReadyWaiting args;
            if (waitingForData.TryGetValue(e.seq, out args))
            {
                Array.Copy(e.data, args.data, Math.Min(e.data.Length, args.data.Length));
                Thread t = new Thread(new ParameterizedThreadStart(args.handler));
                t.Start(args);
                waitingForData.Remove(e.seq);
            }
        }

        public void addtoLog(string msg)
        {
            Program.gCmdWindow.BeginInvoke(Program.gCmdWindow.delAddLog, msg);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //Some people leave the default IP address, hoping it would work...
            if (host.Text == "0.0.0.0")
            {
                MessageBox.Show("Please input your console's local IP address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtLog.Clear();
            Program.scriptHelper.connect(host.Text, 8000);
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            PerformDisconnect();
        }

        public void PerformDisconnect()
        {
            Program.scriptHelper.disconnect();
            SAV = SaveUtil.getBlankSAV(GameVersion.Invalid, "PKMN-NTR");
            pkm = new PK7();
            buttonConnect.Text = "Connect";
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            disableControls();
        }

        private void connectCheck(object sender, EventArgs e)
        {
            Program.scriptHelper.listprocess();
            buttonConnect.Text = "Connected";
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
            Settings.Default.IP = host.Text;
            Settings.Default.Save();
        }

        //This functions handles additional information events from NTR netcode. We are only interested in them if they are a process list, containing our game's PID and game type.
        public void getGame(object sender, EventArgs e)
        {
            InfoReadyEventArgs args = (InfoReadyEventArgs)e;
            if (args.info.Contains("kujira-1")) // X
            {
                string log = args.info;
                pname = ", pname: kujira-1";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                SAV = SaveUtil.getBlankSAV(GameVersion.X, "PKMN-NTR");
                boxOff = 0x8C861C8;
                daycare1Off = 0x8C7FF4C;
                daycare2Off = 0x8C8003C;
                langoff = 0x8C79C69;
                tradeOff = 0x8500000;
                battleBoxOff = 0x8C6AC2C;
                partyOff = 0x8CE1CF8;
                opponentOff = 0x8800000;
            }
            else if (args.info.Contains("kujira-2")) // Y
            {
                string log = args.info;
                pname = ", pname: kujira-2";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                SAV = SaveUtil.getBlankSAV(GameVersion.Y, "PKMN-NTR");
                boxOff = 0x8C861C8;
                daycare1Off = 0x8C7FF4C;
                daycare2Off = 0x8C8003C;
                langoff = 0x8C79C69;
                tradeOff = 0x8500000;
                battleBoxOff = 0x8C6AC2C;
                partyOff = 0x8CE1CF8;
                opponentOff = 0x8800000;
            }
            else if (args.info.Contains("sango-1")) // Omega Ruby
            {
                string log = args.info;
                pname = ", pname:  sango-1";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                SAV = SaveUtil.getBlankSAV(GameVersion.OR, "PKMN-NTR");
                boxOff = 0x8C9E134;
                daycare1Off = 0x8C88180;
                daycare2Off = 0x8C88270;
                daycare3Off = 0x8C88370;
                daycare4Off = 0x8C88460;
                langoff = 0x8C8136D;
                tradeOff = 0x8520000;
                battleBoxOff = 0x8C72330;
                partyOff = 0x8CFB26C;
                opponentOff = 0x8800000;
            }
            else if (args.info.Contains("sango-2")) // Alpha Sapphire
            {
                string log = args.info;
                pname = ", pname:  sango-2";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                SAV = SaveUtil.getBlankSAV(GameVersion.AS, "PKMN-NTR");
                boxOff = 0x8C9E134;
                daycare1Off = 0x8C88180;
                daycare2Off = 0x8C88270;
                daycare3Off = 0x8C88370;
                daycare4Off = 0x8C88460;
                tradeOff = 0x8520000;
                battleBoxOff = 0x8C72330;
                partyOff = 0x8CFB26C;
                opponentOff = 0x8800000;
            }
            else if (args.info.Contains("niji_loc")) // Sun/Moon
            {
                string log = args.info;
                pname = ", pname: niji_loc";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                SAV = SaveUtil.getBlankSAV(GameVersion.SN, "PKMN-NTR");
                boxOff = 0x330D9838;
                daycare1Off = 0x3313EC01;
                daycare2Off = 0x3313ECEA;
                langoff = 0x330D6805;
                tradeOff = 0x32A870C8;
                opponentOff = 0x3254F4AC;
                partyOff = 0x34195E10;
            }
            else // not a process list or game not found - ignore packet
            {
                return;
            }

            // Clear tabs to avoid writting wrong data
            if (!botWorking)
            {
                pkm = SAV.BlankPKM;
            }

            // Fill fields in the form according to gen
            Program.helper.pid = pid;
            GameInfo.Strings = GameInfo.getStrings(pkhexlang);
            GameInfo.InitializeDataSources(GameInfo.Strings);
            if (SAV.Generation == 7 && !botWorking)
            {
                PKXEXT = ".pk7";
                BOXEXT = "_boxes.ek7";
                MAXSPECIES = SAV.MaxSpeciesID;
                BOXES = 32;
                fillGen7();
                dumpAllData7();
                enableControls();
                Delg.SetCheckedRadio(radioBoxes, true);
            }
            else if (SAV.Generation == 6 && !botWorking)
            {
                PKXEXT = ".pk6";
                BOXEXT = "_boxes.ek6";
                MAXSPECIES = SAV.MaxSpeciesID;
                BOXES = 31;
                fillGen6();
                dumpAllData6();
                enableControls();
                Delg.SetCheckedRadio(radioBoxes, true);
            }
        }

        private void fillGen6()
        {
            if (radioBoxes.Checked)
            {
                Delg.SetMaximum(boxDump, BOXES);
            }
            Delg.SetText(radioDaycare, "Daycare");
            Delg.SetMaximum(Num_CDBox, BOXES);
            Delg.SetMaximum(Num_CDAmount, LookupTable.getMaxSpace((int)Num_CDBox.Value, (int)Num_CDSlot.Value));
        }

        private async void fillGen7()
        {
            if (radioBoxes.Checked)
            {
                Delg.SetMaximum(boxDump, BOXES);
            }
            Delg.SetText(radioDaycare, "Nursery");
            Delg.SetMaximum(Num_CDBox, BOXES);
            Delg.SetMaximum(Num_CDAmount, LookupTable.getMaxSpace((int)Num_CDBox.Value, (int)Num_CDSlot.Value));

            //Apply connection patch
            Task<bool> Patch = Program.helper.waitNTRwrite(LookupTable.nfcOff, LookupTable.nfcVal, pid);
            if (!(await Patch))
            {
                MessageBox.Show("An error has ocurred while applying the connection patch.", "PKMN-NTR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Main Window

        #region R/W trainer data

        // Dump data according to generation
        public void dumpAllData6()
        {
            dumpTrainerCard();
        }

        public void dumpAllData7()
        {
            dumpTrainerCard();
        }

        // Game save data handling
        public void dumpTrainerCard()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[LookupTable.trainercardSize], handleTrainerCard, null);
            waitingForData.Add(Program.scriptHelper.data(LookupTable.trainercardOff, LookupTable.trainercardSize, pid), myArgs);
        }

        public void handleTrainerCard(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            Array.Copy(args.data, 0, SAV.Data, LookupTable.trainercardLocation, LookupTable.trainercardSize);
            Delg.SetText(lb_name, SAV.OT);
            Delg.SetText(lb_tid, SAV.TID.ToString("D4"));
            Delg.SetText(lb_sid, SAV.SID.ToString("D4"));
            Delg.SetText(lb_tsv, LookupTable.getTSV(SAV.TID, SAV.SID).ToString("D4"));
            switch (SAV.Version)
            {
                case GameVersion.X:
                    Delg.SetText(lb_version, "X");
                    Delg.SetText(lb_g7id, null);
                    break;
                case GameVersion.Y:
                    Delg.SetText(lb_version, "Y");
                    Delg.SetText(lb_g7id, null);
                    break;
                case GameVersion.OR:
                    Delg.SetText(lb_version, "Omega Ruby");
                    Delg.SetText(lb_g7id, null);
                    break;
                case GameVersion.AS:
                    Delg.SetText(lb_version, "Alpha Sapphire");
                    Delg.SetText(lb_g7id, null);
                    break;
                case GameVersion.SN:
                    Delg.SetText(lb_version, "Sun");
                    Delg.SetText(lb_g7id, LookupTable.getG7ID(SAV.TID, SAV.SID).ToString("D6"));
                    break;
                case GameVersion.MN:
                    Delg.SetText(lb_version, "Moon");
                    Delg.SetText(lb_g7id, LookupTable.getG7ID(SAV.TID, SAV.SID).ToString("D6"));
                    break;
            }
        }
        
        #endregion R/W trainer data

        #region R/W pokémon data

        // Dump single pokémon
        private void dumpPokemon_Click(object sender, EventArgs e)
        {
            // Obtain offset
            uint dumpOff = 0;
            if (radioBoxes.Checked)
            {
                uint ssd = ((decimal.ToUInt32(boxDump.Value) - 1) * BOXSIZE) + decimal.ToUInt32(slotDump.Value) - 1;
                dumpOff = boxOff + (ssd * POKEBYTES);
            }
            else if (radioDaycare.Checked)
            {
                switch ((int)slotDump.Value)
                {
                    case 1: dumpOff = daycare1Off; break;
                    case 2: dumpOff = daycare2Off; break;
                    case 3: dumpOff = daycare3Off; break;
                    case 4: dumpOff = daycare4Off; break;
                    default: dumpOff = daycare1Off; break;
                }
            }
            else if (radioBattleBox.Checked)
            {
                dumpOff = battleBoxOff + ((decimal.ToUInt32(slotDump.Value) - 1) * POKEBYTES);
            }
            else if (radioTrade.Checked)
            {
                if (SAV.Generation == 6)
                {
                    DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x1FFFF], handleTradeData, null);
                    waitingForData.Add(Program.scriptHelper.data(tradeOff, 0x1FFFF, pid), myArgs);
                }
                else
                {
                    DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePkmData, null);
                    uint mySeq = Program.scriptHelper.data(tradeOff, POKEBYTES, pid);
                    waitingForData.Add(mySeq, myArgs);
                }
            }
            else if (radioOpponent.Checked)
            {
                if (SAV.Generation == 6)
                {
                    DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x1FFFF], handleOpponentData, null);
                    waitingForData.Add(Program.scriptHelper.data(opponentOff, 0x1FFFF, pid), myArgs);
                }
                else
                {
                    DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePkmData, null);
                    uint offset = 0;
                    switch ((int)boxDump.Value)
                    {
                        //Opponent 1 / wild Pokemon
                        case 1:
                            offset = opponentOff + (uint)(slotDump.Value - 1) * 260;
                            break;
                        //Opponent 2 (in dual battle)
                        case 2:
                            offset = opponentOff + 0xC98 + (uint)(slotDump.Value - 1) * 260;
                            break;
                        //Last called helper in SOS battle.
                        case 3:
                            offset = 0x3003969C;
                            break;
                        //Last 4 Pokemon in SOS battle
                        case 4:
                            offset = 0x3002F7B8 + (uint)(slotDump.Value - 1) * 0x1E4;
                            break;
                    }
                    uint mySeq = Program.scriptHelper.data(offset, POKEBYTES, pid);
                    waitingForData.Add(mySeq, myArgs);
                }
            }
            else if (radioParty.Checked)
            {
                dumpOff = partyOff + (decimal.ToUInt32(slotDump.Value) - 1) * 484;
            }

            // Read at offset
            if (radioParty.Checked)
            {
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[260], handlePkmData, null);
                uint mySeq = Program.scriptHelper.data(dumpOff, 260, pid);
                waitingForData.Add(mySeq, myArgs);
            }
            else if (radioBoxes.Checked || radioDaycare.Checked || radioBattleBox.Checked)
            {
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePkmData, null);
                uint mySeq = Program.scriptHelper.data(dumpOff, POKEBYTES, pid);
                waitingForData.Add(mySeq, myArgs);
            }
        }

        public void handlePkmData(object args_obj)
        {
            try
            { //TODO: TEMPORARY HACK, DO PROPER ERROR HANDLING
                DataReadyWaiting args = (DataReadyWaiting)args_obj;
                PKM validator = SAV.BlankPKM;
                validator.Data = PKX.decryptArray(args.data);
                bool dataCorrect = validator.Species != 0;
                if (!onlyView.Checked && !botWorking)
                {
                    DialogResult res = DialogResult.Cancel;
                    if (!dataCorrect)
                    {
                        res = MessageBox.Show("This Pokemon's data seems to be empty.\r\nPress OK if you want to save it, Cancel if you don't.",
                           "Empty data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    if (dataCorrect || res == DialogResult.OK)
                    {
                        string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERPOKE + "\\";
                        (new FileInfo(folderPath)).Directory.Create();
                        string fileName = nameek6.Text + PKXEXT;
                        writePokemonToFile(validator.Data, folderPath + fileName);
                    }
                }
                else if (!dataCorrect && !botWorking)
                {
                    MessageBox.Show("This Pokemon's data seems to be empty.", "Empty data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!dataCorrect)
                {
                    return;
                }

                pkm = validator;
                //updateTabs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void handleTradeData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;

            byte[] relativePattern = null;
            uint offsetAfter = 0;

            if (SAV.Version == GameVersion.X || SAV.Version == GameVersion.Y)
            {
                relativePattern = new byte[] { 0x08, 0x1C, 0x01, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD8, 0xBE, 0x59 };
                offsetAfter += 98;
            }

            if (SAV.Version == GameVersion.OR || SAV.Version == GameVersion.AS)
            {
                relativePattern = new byte[] { 0x08, 0x1E, 0x01, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x9C, 0xE8, 0x5D };
                offsetAfter += 98;
            }

            List<uint> occurences = findOccurences(args.data, relativePattern);
            int count = 0;
            foreach (uint occurence in occurences)
            {
                count++;
                if (count != 2)
                {
                    continue;
                }
                int dataOffset = (int)(occurence + offsetAfter);
                DataReadyWaiting args_pkm = new DataReadyWaiting(args.data.Skip(dataOffset).Take(POKEBYTES).ToArray(), handlePkmData, null);
                handlePkmData(args_pkm);
            }
        }

        public void handleOpponentData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;

            byte[] relativePattern = null;
            uint offsetAfter = 0;

            if (SAV.Version == GameVersion.X || SAV.Version == GameVersion.Y)
            {
                relativePattern = new byte[] { 0x60, 0x75, 0xC6, 0x08, 0xDC, 0xA8, 0xC7, 0x08, 0xD0, 0xB6, 0xC7, 0x08 };
                offsetAfter = 637;
            }
            if (SAV.Version == GameVersion.OR || SAV.Version == GameVersion.AS)
            {
                relativePattern = new byte[] { 0x60, 0xE7, 0xC6, 0x08, 0x6C, 0xEC, 0xC6, 0x08, 0xE0, 0x1F, 0xC8, 0x08, 0x00, 0x39, 0xC8, 0x08 };
                offsetAfter = 673;
            }

            List<uint> occurences = findOccurences(args.data, relativePattern);
            int count = 0;
            foreach (uint occurence in occurences)
            {
                count++;
                int dataOffset = (int)(occurence + offsetAfter);
                DataReadyWaiting args_pkm = new DataReadyWaiting(args.data.Skip(dataOffset).Take(POKEBYTES).ToArray(), handlePkmData, null);
                handlePkmData(args_pkm);
            }
        }

        static List<uint> findOccurences(byte[] haystack, byte[] needle)
        {
            List<uint> occurences = new List<uint>();

            for (uint i = 0; i < haystack.Length; i++)
            {
                if (needle[0] == haystack[i])
                {
                    bool found = true;
                    uint j, k;
                    for (j = 0, k = i; j < needle.Length; j++, k++)
                    {
                        if (k >= haystack.Length || needle[j] != haystack[k])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        occurences.Add(i - 1);
                        i = k;
                    }
                }
            }
            return occurences;
        }

        // Save single pokémon
        private void onlyView_CheckedChanged(object sender, EventArgs e)
        {
            nameek6.Enabled = !onlyView.Checked;
        }

        public void writePokemonToFile(byte[] data, string fileName, bool overwrite = false)
        {
            try
            {
                if (!overwrite) // If current filename is available, it won't be changed
                {
                    fileName = NextAvailableFilename(fileName);
                }

                FileStream fs = File.OpenWrite(fileName);
                fs.Write(data, 0, data.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string NextAvailableFilename(string path)
        {
            if (!File.Exists(path))
            {
                return path;
            }

            if (Path.HasExtension(path))
            {
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));
            }

            return GetNextFilename(path + numberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
            {
                throw new ArgumentException("The pattern must include an index place-holder", "pattern");
            }

            if (!File.Exists(tmp))
            {
                return tmp;
            }

            int min = 1, max = 2;

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                {
                    min = pivot;
                }
                else
                {
                    max = pivot;
                }
            }

            return string.Format(pattern, max);
        }

        // Save all boxes
        private void dumpBoxes_Click(object sender, EventArgs e)
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[BOXES * BOXSIZE * POKEBYTES], handleAllBoxesData, null);
            waitingForData.Add(Program.scriptHelper.data(boxOff, BOXES * BOXSIZE * POKEBYTES, pid), myArgs);
        }

        public void handleAllBoxesData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERPOKE + "\\";
            (new FileInfo(folderPath)).Directory.Create();
            string fileName = nameek6.Text + BOXEXT;
            writePokemonToFile(args.data, folderPath + fileName);
        }

        // Write single pokémon from tabs
        private void pokeEkx_Click(object sender, EventArgs e)
        {
            if (pkm == null)
            {
                MessageBox.Show("No Pokemon data found, please dump a Pokemon first to edit!", "No data to edit");
            }
            else
            {
                // TO DO: Read data from fields to pkm

                pkm.RefreshChecksum();

                byte[] pkmEdited = PKX.encryptArray(pkm.DecryptedBoxData);

                if (radioBoxes.Checked)
                {
                    uint index = ((uint)boxDump.Value - 1) * BOXSIZE + (uint)slotDump.Value - 1;
                    uint offset = boxOff + (index * POKEBYTES);
                    Program.scriptHelper.write(offset, pkmEdited, pid);
                }
                else if (radioBattleBox.Checked)
                {
                    uint offset = battleBoxOff + ((uint)slotDump.Value - 1) * POKEBYTES;
                    Program.scriptHelper.write(offset, pkmEdited, pid);
                }

                else if (radioParty.Checked && enablepartywrite)
                {
                    uint offset = partyOff + ((uint)slotDump.Value - 1) * 484;
                    Program.scriptHelper.write(offset, pkmEdited, pid);
                }
                else
                {
                    MessageBox.Show("No editing support for this source.", "Editing Unavailable");
                }
            }
        }

        #endregion R/W pokémon data

        #region GUI handling

        // Radio boxes for pokémon source
        private void radioBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBoxes.Tag == null)
            {
                radioBoxes.Tag = new LastBoxSlot { box = 1, slot = 1 };
            }

            if (radioBoxes.Checked)
            {
                boxDump.Minimum = 1;
                boxDump.Maximum = BOXES;
                slotDump.Minimum = 1;
                slotDump.Maximum = BOXSIZE;
                boxDump.Enabled = true;
                slotDump.Enabled = true;
                dumpBoxes.Enabled = true;
                onlyView.Enabled = true;
                boxDump.Value = ((LastBoxSlot)radioBoxes.Tag).box;
                slotDump.Value = ((LastBoxSlot)radioBoxes.Tag).slot;
            }
            else
            {
                radioBoxes.Tag = new LastBoxSlot { box = boxDump.Value, slot = slotDump.Value };
            }

        }

        private void radioDaycare_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDaycare.Tag == null)
            {
                radioDaycare.Tag = new LastBoxSlot { box = 1, slot = 1 };
            }
            if (radioDaycare.Checked)
            {
                boxDump.Minimum = 1;
                boxDump.Maximum = 2;
                slotDump.Minimum = 1;
                if (SAV.Version == GameVersion.OR || SAV.Version == GameVersion.AS) // Handle ORAS Battle Resort Daycare
                {
                    slotDump.Maximum = 4;
                }
                else
                {
                    slotDump.Maximum = 2;
                }
                boxDump.Enabled = false;
                slotDump.Enabled = true;
                dumpBoxes.Enabled = false;
                onlyView.Enabled = true;
                boxDump.Value = ((LastBoxSlot)radioDaycare.Tag).box;
                slotDump.Value = ((LastBoxSlot)radioDaycare.Tag).slot;
            }
            else
            {
                radioDaycare.Tag = new LastBoxSlot { box = boxDump.Value, slot = slotDump.Value };
            }
        }

        private void radioBattleBox_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBattleBox.Tag == null)
            {
                radioBattleBox.Tag = new LastBoxSlot { box = 1, slot = 1 };
            }
            if (radioBattleBox.Checked)
            {
                boxDump.Minimum = 1;
                boxDump.Maximum = 1;
                slotDump.Minimum = 1;
                slotDump.Maximum = 6;
                boxDump.Enabled = false;
                slotDump.Enabled = true;
                dumpBoxes.Enabled = false;
                onlyView.Enabled = true;
                boxDump.Value = ((LastBoxSlot)radioBattleBox.Tag).box;
                slotDump.Value = ((LastBoxSlot)radioBattleBox.Tag).slot;
            }
            else
            {
                radioBattleBox.Tag = new LastBoxSlot { box = boxDump.Value, slot = slotDump.Value };
            }
        }

        private void radioTrade_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTrade.Tag == null)
            {
                radioTrade.Tag = new LastBoxSlot { box = 1, slot = 1 };
            }
            if (radioTrade.Checked)
            {
                boxDump.Minimum = 1;
                boxDump.Maximum = 1;
                slotDump.Minimum = 1;
                slotDump.Maximum = 1;
                boxDump.Enabled = false;
                slotDump.Enabled = false;
                dumpBoxes.Enabled = false;
                onlyView.Enabled = false;
                boxDump.Value = ((LastBoxSlot)radioTrade.Tag).box;
                slotDump.Value = ((LastBoxSlot)radioTrade.Tag).slot;
            }
            else
            {
                radioTrade.Tag = new LastBoxSlot { box = boxDump.Value, slot = slotDump.Value };
            }
        }

        private void radioOpponent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOpponent.Tag == null)
            {
                radioOpponent.Tag = new LastBoxSlot { box = 1, slot = 1 };
            }
            if (radioOpponent.Checked)
            {
                boxDump.Minimum = 1;
                boxDump.Maximum = 4;
                slotDump.Minimum = 1;
                slotDump.Maximum = 6;
                boxDump.Enabled = true;
                slotDump.Enabled = true;
                dumpBoxes.Enabled = false;
                onlyView.Enabled = false;
                BoxLabel.Text = "Opp.:";
                boxDump.Value = ((LastBoxSlot)radioOpponent.Tag).box;
                slotDump.Value = ((LastBoxSlot)radioOpponent.Tag).slot;
                if (SAV.Generation == 7)
                {
                    DumpInstructionsBtn.Visible = true;
                }
            }
            else
            {
                radioOpponent.Tag = new LastBoxSlot { box = boxDump.Value, slot = slotDump.Value };
                BoxLabel.Text = "Box:";
                if (SAV.Generation == 7)
                {
                    DumpInstructionsBtn.Visible = false;
                }
            }
        }

        private void radioParty_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioParty.Tag == null)
            {
                radioParty.Tag = new LastBoxSlot { box = 1, slot = 1 };
            }
            if (radioParty.Checked)
            {
                if (!botWorking && !enablepartywrite)
                {
                    MessageBox.Show("Important:\r\n\r\nThis feature is experimental, the slots that is selected in this application might not be the same slots that are shown in your party. Due the unkonown mechanics of this, the write feature has been disabled.\r\n\r\nIf you wish to edit a pokémon in your party, deposit it the PC.", "PKMN-NTR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    boxDump.Minimum = 1;
                    boxDump.Maximum = 1;
                    slotDump.Minimum = 1;
                    slotDump.Maximum = 6;
                    boxDump.Enabled = false;
                    slotDump.Enabled = true;
                    dumpBoxes.Enabled = false;
                    onlyView.Enabled = false;
                    boxDump.Value = ((LastBoxSlot)radioParty.Tag).box;
                    slotDump.Value = ((LastBoxSlot)radioParty.Tag).slot;
                }
            }
            else
            {
                radioParty.Tag = new LastBoxSlot { box = boxDump.Value, slot = slotDump.Value };
            }
        }

        // Clone/Delete tab
        private void clonedelete_Changed(object sender, EventArgs e)
        {
            Delg.SetMaximum(Num_CDAmount, LookupTable.getMaxSpace((int)Num_CDBox.Value, (int)Num_CDSlot.Value));
        }

        // Sprite handling
        private void RefreshSprite()
        {
            string resname;
            if (pkm.IsEgg)
            {
                resname = "egg";
            }
            else if (pkm.AltForm == 0 || pkm.Species == 493 || pkm.Species == 773) // All Arceus / Silvally formes have same sprite
            {
                resname = "_" + pkm.Species;
            }
            else
            {
                resname = "_" + pkm.Species + "_" + pkm.AltForm;
            }
            Bitmap data;
            data = (Bitmap)Resources.ResourceManager.GetObject(resname);
            if (data == null)
            {
                data = (Bitmap)Resources.ResourceManager.GetObject("unknown");
            }
            pictureBox2.Image = data;
            if (pkm.IsShiny)
            {
                shinypic.Image = Resources.shiny;
            }
            else
            {
                shinypic.Image = null;
            }
        }

        #endregion GUI handling

        #region Sub-forms

        // Tool start/finish
        private void Tool_Start()
        {
            txtLog.Clear();
            disableControls();
        }

        public void Tool_Finish()
        {
            enableControls();
        }

        // Trainer Editor
        private void Tool_Trainer_Click(object sender, EventArgs e)
        {
            Tool_Start();
            new Edit_Trainer().Show();
        }

        // Item Editor
        private async void Tool_Items_Click(object sender, EventArgs e)
        {
            Tool_Start();
            iteminfo = await dumpItems();
            if (iteminfo == null)
            {
                MessageBox.Show("A error ocurred while dumping items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Array.Copy(iteminfo, 0, SAV.Data, LookupTable.itemsLocation, LookupTable.itemsSize);
                new Edit_Items().Show();
            }
        }

        public async Task<byte[]> dumpItems()
        {
            Task<bool> worker = Program.helper.waitNTRmultiread(LookupTable.itemsOff, LookupTable.itemsSize);
            if (await worker)
            {
                return Program.helper.lastmultiread;
            }
            else
            {
                return null;
            }
        }

        // Remote Control
        private void Tool_Controls_Click(object sender, EventArgs e)
        {
            Tool_Start();
            new Remote_Control().Show();
        }

        // Filter Constructor
        private void Tools_Filter_Click(object sender, EventArgs e)
        {
            new Filter_Constructor().Show();
        }

        // PokeDigger
        private void Tools_PokeDigger_Click(object sender, EventArgs e)
        {
            Tool_Start();
            //new PokeDigger(pid, game != GameType.None).Show();
        }

        private void DumpInstructionsBtn_Click(object sender, EventArgs e)
        {
            if (radioOpponent.Checked)
            {
                new DumpOpponentHelp().Show();
            }
        }

        #endregion Sub-forms
    }

    //Objects of this class contains an array for data that have been acquired, a delegate function 
    //to handle them and any additional arguments it might require.
    public class DataReadyWaiting
    {
        public byte[] data;
        public object arguments;
        public delegate void DataHandler(object data_arguments);
        public DataHandler handler;

        public DataReadyWaiting(byte[] data_, DataHandler handler_, object arguments_)
        {
            this.data = data_;
            this.handler = handler_;
            this.arguments = arguments_;
        }
    }
}