using ntrbase.Properties;
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
using ntrbase.Helpers;
using Octokit;
using System.Diagnostics;

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

        // Program-wide variables
        public enum GameType { None, X, Y, OR, AS, SM };
        public bool gen7;
        public int MAXSPECIES;
        public uint BOXES;
        public const int BOXSIZE = 30;
        public const int POKEBYTES = 232;
        public const string FOLDERPOKE = "Pokemon";
        public const string FOLDERDELETE = "Deleted";
        public const string FOLDERBOT = "Bot";
        public const string FOLDERWT = "Wonder Trade";
        public string PKXEXT;
        public string BOXEXT;
        public PKHeX dumpedPKHeX = new PKHeX();
        private static string numberPattern = " ({0})";

        // Variables for update checking
        internal GitHubClient Github;
        public string updateURL = null;

        // Variables for cloning
        public byte[] selectedCloneData = new byte[POKEBYTES];
        public bool selectedCloneValid = false;

        // Variables for bots
        public bool botWorking = false;
        public bool botStop = false;
        public int botnumber = -1;
        public int botState = 0;
        public static readonly int timeout = 10;
        public uint lastmemoryread;
        public string lastlog;
        private string filterstr;
        public int currentfilter = 0;
        public static readonly string readerror = "An error has ocurred while reading data from your 3DS RAM, please check connection and try again.";
        public static readonly string toucherror = "An error has ocurred while sending a Touch Screen command, please check connection and try again.\r\n\r\nIf the buttons / touch screen / control stick of your 3DS system doesn't work, send any comand from the Remote Control tab to fix them";
        public static readonly string buttonerror = "An error has ocurred while sending a button command, please check connection and try again.\r\n\r\nIf the buttons / touch screen / control stick of your 3DS system doesn't work, send any comand from the Remote Control tab to fix them";
        public static readonly string stickerror = "An error has ocurred while sending a Control Stick command, please check connection and try again.\r\n\r\nIf the buttons / touch screen / control stick of your 3DS system doesn't work, send any comand from the Remote Control tab to fix them";
        public static readonly string writeerror = "An error has ocurred while writting data to your 3DS RAM, please check connection and try again.";
        private WonderTradeBot6 WTBot6;
        private WonderTradeBot7 WTBot7;
        private BreedingBot6 BreedBot6;
        private BreedingBot7 BreedBot7;
        private SoftResetbot6 SRBot6;
        private SoftResetbot7 SRBot7;

        //Game information
        public int pid;
        public byte lang;
        public string pname;
        public GameType game = GameType.None;
        //Offsets for basic data
        public uint nameoff;
        public uint tidoff;
        public uint sidoff;
        public uint timeoff;
        public uint langoff;
        public uint moneyoff;
        public uint milesoff;
        public uint currentFCoff;
        public uint totalFCoff;
        public uint bpoff;
        public uint eggseedOff;
        //Offsets for items data
        public uint itemsoff;
        public uint medsoff;
        public uint keysoff;
        public uint tmsoff;
        public uint bersoff;
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

        // Variables for inventory (Gen 6)
        private byte[] itemData = new byte[1600];
        private byte[] keyData = new byte[384];
        private byte[] tmData = new byte[432];
        private byte[] medData = new byte[256];
        private byte[] berryData = new byte[288];
        public byte[] items;

        public DataGridViewComboBoxColumn itemItem;
        public DataGridViewColumn itemAmount;
        public DataGridViewComboBoxColumn keyItem;
        public DataGridViewColumn keyAmount;
        public DataGridViewComboBoxColumn tmItem;
        public DataGridViewColumn tmAmount;
        public DataGridViewComboBoxColumn medItem;
        public DataGridViewColumn medAmount;
        public DataGridViewComboBoxColumn berItem;
        public DataGridViewColumn berAmount;

        // Variables for inventory (Gen 7)
        private int currentpouch = 0;
        private int medcount7 = 53;
        private byte[] medData7 = new byte[53 * 4];
        private int[,] meds7 = new int[53, 2];
        private int itemcount7 = 336;
        private byte[] itemData7 = new byte[336 * 4];
        private int[,] items7 = new int[336, 2];
        private int tmscount7 = 100;
        private byte[] tmsData7 = new byte[100 * 4];
        private int[,] tms7 = new int[100, 2];
        private int berscount7 = 67;
        private byte[] bersData7 = new byte[67 * 4];
        private int[,] bers7 = new int[67, 2];
        private int keyscount7 = 24;
        private byte[] keysData7 = new byte[24 * 4];
        private int[,] keys7 = new int[24, 2];

        // Variables for ability change
        int[] absno;
        string[] abstr = new string[3];

        //This array will contain controls that should be enabled when connected and disabled when disconnected.
        Control[] enableWhenConnected = new Control[] { };
        Control[] enableWhenConnected7 = new Control[] { };
        Control[] gen6onlyControls = new Control[] { };

        // Tooltips for TSV and ESV
        public ToolTip ToolTipTSVpoke = new ToolTip();
        public ToolTip ToolTipPSV = new ToolTip();

        // Log handling
        public delegate void LogDelegate(string l);
        public LogDelegate delAddLog;

        #endregion Class variables

        #region Main window

        private void MainForm_Load(object sender, EventArgs e)
        {
            label69.Text = "Version: " + System.Windows.Forms.Application.ProductVersion;

            DataGridViewComboBoxColumn itemItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn itemAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            DataGridViewComboBoxColumn keyItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn keyAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            DataGridViewComboBoxColumn tmItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn tmAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            DataGridViewComboBoxColumn medItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn medAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            DataGridViewComboBoxColumn berItem = new DataGridViewComboBoxColumn
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                DisplayIndex = 0,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "Items",
                Width = 120,
            };

            DataGridViewColumn berAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                DisplayIndex = 1,
                Width = 51,
            };

            itemsGridView.Columns.Add(itemItem);
            itemsGridView.Columns.Add(itemAmount);
            keysGridView.Columns.Add(keyItem);
            keysGridView.Columns.Add(keyAmount);
            tmsGridView.Columns.Add(tmItem);
            tmsGridView.Columns.Add(tmAmount);
            medsGridView.Columns.Add(medItem);
            medsGridView.Columns.Add(medAmount);
            bersGridView.Columns.Add(berItem);
            bersGridView.Columns.Add(berAmount);

            foreach (string t in LookupTable.Item6)
            {
                itemItem.Items.Add(t);
                keyItem.Items.Add(t);
                tmItem.Items.Add(t);
                medItem.Items.Add(t);
                berItem.Items.Add(t);
            }

            foreach (string t in LookupTable.Item7)
            {
                nameItem7.Items.Add(t);
            }

            nameItem7.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            nameItem7.DisplayIndex = 0;
            nameItem7.FlatStyle = FlatStyle.Flat;
            countItem7.DisplayIndex = 1;

            checkUpdate();
            host.Text = Settings.Default.IP;
            callIP();
            host.Focus();
        }

        public MainForm()
        {
            Program.ntrClient.DataReady += handleDataReady;
            Program.ntrClient.Connected += connectCheck;
            Program.ntrClient.InfoReady += getGame;
            delAddLog = new LogDelegate(Addlog);
            InitializeComponent();

            enableWhenConnected = new Control[] { dumpBox, itemsGridView, keysGridView, tmsGridView, medsGridView, bersGridView };

            enableWhenConnected7 = new Control[] { dumpBox, totalFCNum, pokeTotalFC, WTcollectFC };

            gen6onlyControls = new Control[] { radioBattleBox, orgbox_pos, daycare_select };

            disableControls();
            SetSelectedIndex(filterHPlogic, 0);
            SetSelectedIndex(filterATKlogic, 0);
            SetSelectedIndex(filterDEFlogic, 0);
            SetSelectedIndex(filterSPAlogic, 0);
            SetSelectedIndex(filterSPDlogic, 0);
            SetSelectedIndex(filterSPElogic, 0);
            SetSelectedIndex(filterPerIVlogic, 0);
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
                    SetText(updateLabel, "Version " + lateststable.TagName + " is available.");
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
                            SetText(updateLabel, "Preview version " + latestbeta.TagName + " is available.");
                            updateURL = latestbeta.HtmlUrl;
                        }
                        else
                        {
                            addtoLog("GUI: PKMN-NTR is up to date");
                            SetText(updateLabel, "PKMN-NTR is up to date.");
                            updateURL = null;
                        }
                    }
                    else
                    {
                        addtoLog("GUI: PKMN-NTR is up to date");
                        SetText(updateLabel, "PKMN-NTR is up to date.");
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
                SetText(updateLabel, "Update not found.");
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
            if (gen7)
            {
                foreach (Control c in enableWhenConnected7)
                {
                    SetEnabled(c, true);
                }
                foreach (Control c in gen6onlyControls)
                {
                    SetEnabled(c, false);
                }
            }
            else
            {
                foreach (Control c in enableWhenConnected)
                {
                    SetEnabled(c, true);
                }
            }
            foreach (TabPage tab in DumpedEdit.TabPages)
            {
                SetEnabled(tab, true);
            }
            foreach (TabPage tab in miscTabs.TabPages)
            {
                SetEnabled(tab, true);
            }
            HyperTrainBoxes();
        }

        private void disableControls()
        {
            if (gen7)
            {
                foreach (Control c in enableWhenConnected7)
                {
                    SetEnabled(c, false);
                }
            }
            else
            {
                foreach (Control c in enableWhenConnected)
                {
                    SetEnabled(c, false);
                }
            }
            foreach (TabPage tab in DumpedEdit.TabPages)
            {
                SetEnabled(tab, false);
            }
            foreach (TabPage tab in miscTabs.TabPages)
            {
                if (!(tab.Name == "tabFilters" || tab.Name == "tabNTRlog"))
                {
                    SetEnabled(tab, false);
                }
            }
        }

        public void Addlog(string l)
        {
            lastlog = l;
            if (l.Contains("Server disconnected") && !botWorking && game != GameType.None)
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
            game = GameType.None;
        }

        [Conditional("DEBUG")]
        private void callIP()
        {
            addtoLog("THIS IS A DEBUG VERSION - ONLY FOR TESTING");
            StreamReader sr = new StreamReader("D:\\IP.txt");
            host.Text = sr.ReadLine();
            sr.Close();
        }

        #endregion window

        #region Functions

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

        public int getHiddenPower()
        {
            int hp = (15 * ((dumpedPKHeX.IV_HP & 1) + 2 * (dumpedPKHeX.IV_ATK & 1) + 4 * (dumpedPKHeX.IV_DEF & 1) + 8 * (dumpedPKHeX.IV_SPE & 1) + 16 * (dumpedPKHeX.IV_SPA & 1) + 32 * (dumpedPKHeX.IV_SPD & 1)) / 63);
            return hp;
        }

        public int getTSV(decimal TID, decimal SID)
        {
            return ((int)TID ^ (int)SID) >> 4;
        }

        public int getGen7ID(decimal TID, decimal SID)
        {
            return (int)((uint)((int)TID | ((int)SID << 16)) % 1000000);
        }

        public uint getPSV(uint PID)
        {
            return ((PID >> 16 ^ PID & 0xFFFF) >> 4);
        }

        public void updateAbility(int speciesno, int formeno, int abnumber)
        {
            if (gen7)
            {
                absno = LookupTable.getAbilities7(speciesno, formeno);
                abstr[0] = LookupTable.Ability7[absno[0] - 1] + " (1)";
                abstr[1] = LookupTable.Ability7[absno[1] - 1] + " (2)";
                abstr[2] = LookupTable.Ability7[absno[2] - 1] + " (H)";
                ComboboxFill(ability, abstr);
            }
            else
            {
                absno = LookupTable.getAbilities(speciesno, formeno);
                abstr[0] = LookupTable.Ability6[absno[0] - 1] + " (1)";
                abstr[1] = LookupTable.Ability6[absno[1] - 1] + " (2)";
                abstr[2] = LookupTable.Ability6[absno[2] - 1] + " (H)";
                ComboboxFill(ability, abstr);
            }

            if (ability.Items.Count == 3)
            {
                switch (abnumber)
                {
                    case 1:
                        SetSelectedIndex(ability, 0);
                        break;
                    case 2:
                        SetSelectedIndex(ability, 1);
                        break;
                    case 4:
                        SetSelectedIndex(ability, 2);
                        break;
                    default:
                        SetSelectedIndex(ability, 0);
                        break;
                }
            }
        }

        #endregion Functions

        #region Connection

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

        private void PerformDisconnect()
        {
            Program.scriptHelper.disconnect();
            game = GameType.None;
            buttonConnect.Text = "Connect";
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            disableControls();
            itemsGridView.Rows.Clear();
            keysGridView.Rows.Clear();
            tmsGridView.Rows.Clear();
            medsGridView.Rows.Clear();
            bersGridView.Rows.Clear();
            itemsView7.Rows.Clear();
        }

        public void connectCheck(object sender, EventArgs e)
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
                game = GameType.X;
                gen7 = false;
                string log = args.info;
                pname = ", pname: kujira-1";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x8C6A6AC;
                milesoff = 0x8C82BA0;
                bpoff = 0x8C6A6E0;
                boxOff = 0x8C861C8;
                daycare1Off = 0x8C7FF4C;
                daycare2Off = 0x8C8003C;
                itemsoff = 0x8C67564;
                medsoff = 0x8C67ECC;
                keysoff = 0x8C67BA4;
                tmsoff = 0x8C67D24;
                bersoff = 0x8C67FCC;
                nameoff = 0x8C79C84;
                tidoff = 0x8C79C3C;
                sidoff = 0x8C79C3E;
                timeoff = 0x8CE2814;
                langoff = 0x8C79C69;
                tradeOff = 0x8500000;
                battleBoxOff = 0x8C6AC2C;
                partyOff = 0x8CE1CF8;
                opponentOff = 0x8800000;
            }
            else if (args.info.Contains("kujira-2")) // Y
            {
                game = GameType.Y;
                gen7 = false;
                string log = args.info;
                pname = ", pname: kujira-2";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x8C6A6AC;
                milesoff = 0x8C82BA0;
                bpoff = 0x8C6A6E0;
                boxOff = 0x8C861C8;
                daycare1Off = 0x8C7FF4C;
                daycare2Off = 0x8C8003C;
                itemsoff = 0x8C67564;
                medsoff = 0x8C67ECC;
                keysoff = 0x8C67BA4;
                tmsoff = 0x8C67D24;
                bersoff = 0x8C67FCC;
                nameoff = 0x8C79C84;
                tidoff = 0x8C79C3C;
                sidoff = 0x8C79C3E;
                timeoff = 0x8CE2814;
                langoff = 0x8C79C69;
                tradeOff = 0x8500000;
                battleBoxOff = 0x8C6AC2C;
                partyOff = 0x8CE1CF8;
                opponentOff = 0x8800000;
            }
            else if (args.info.Contains("sango-1")) // Omega Ruby
            {
                game = GameType.OR;
                gen7 = false;
                string log = args.info;
                pname = ", pname:  sango-1";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x8C71DC0;
                milesoff = 0x8C8B36C;
                bpoff = 0x8C71DE8;
                boxOff = 0x8C9E134;
                daycare1Off = 0x8C88180;
                daycare2Off = 0x8C88270;
                daycare3Off = 0x8C88370;
                daycare4Off = 0x8C88460;
                itemsoff = 0x8C6EC70;
                medsoff = 0x8C6F5E0;
                keysoff = 0x8C6F2B0;
                tmsoff = 0x8C6F430;
                bersoff = 0x8C6F6E0;
                nameoff = 0x8C81388;
                tidoff = 0x8C81340;
                sidoff = 0x8C81342;
                timeoff = 0x8CFBD88;
                langoff = 0x8C8136D;
                tradeOff = 0x8520000;
                battleBoxOff = 0x8C72330;
                partyOff = 0x8CFB26C;
                opponentOff = 0x8800000;
            }
            else if (args.info.Contains("sango-2")) // Alpha Sapphire
            {
                game = GameType.AS;
                gen7 = false;
                string log = args.info;
                pname = ", pname:  sango-2";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x8C71DC0;
                milesoff = 0x8C8B36C;
                bpoff = 0x8C71DE8;
                boxOff = 0x8C9E134;
                daycare1Off = 0x8C88180;
                daycare2Off = 0x8C88270;
                daycare3Off = 0x8C88370;
                daycare4Off = 0x8C88460;
                itemsoff = 0x8C6EC70;
                medsoff = 0x8C6F5E0;
                keysoff = 0x8C6F2B0;
                tmsoff = 0x8C6F430;
                bersoff = 0x8C6F6E0;
                nameoff = 0x8C81388;
                tidoff = 0x8C81340;
                sidoff = 0x8C81342;
                timeoff = 0x8CFBD88;
                langoff = 0x8C8136D;
                tradeOff = 0x8520000;
                battleBoxOff = 0x8C72330;
                partyOff = 0x8CFB26C;
                opponentOff = 0x8800000;
            }
            else if (args.info.Contains("niji_loc")) // Sun/Moon
            {
                game = GameType.SM;
                gen7 = true;
                string log = args.info;
                pname = ", pname: niji_loc";
                string splitlog = log.Substring(log.IndexOf(pname) - 8, log.Length - log.IndexOf(pname));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                moneyoff = 0x330D8FC0;
                currentFCoff = 0x33124D58;
                totalFCoff = 0x33124D5C;
                bpoff = 0x330D90D8;
                boxOff = 0x330D9838;
                daycare1Off = 0x3313EC01;
                daycare2Off = 0x3313ECEA;
                itemsoff = 0x330D5934;
                medsoff = 0x330D647C;
                keysoff = 0x330D5FEC;
                tmsoff = 0x330D62CC;
                bersoff = 0x330D657C;
                nameoff = 0x330D6808;
                tidoff = 0x330D67D0;
                sidoff = 0x330D67D2;
                timeoff = 0x34197648;
                langoff = 0x330D6805;
                eggseedOff = 0x3313EDDC;
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
                clearTabs();
                SetSelectedIndex(typeLSR, -1);
                SetSelectedIndex(modeBreed, -1);
                if (gen7)
                {
                    dumpedPKHeX.Data = PKHeX.decryptArray(LookupTable.EmptyPoke7);
                }
                else
                {
                    dumpedPKHeX.Data = PKHeX.decryptArray(LookupTable.EmptyPoke6);
                }
            }

            // Fill fields in the form according to gen
            Program.helper.pid = pid;
            if (game != GameType.None && gen7 && !botWorking)
            {
                PKXEXT = ".pk7";
                BOXEXT = "_boxes.ek7";
                MAXSPECIES = 802;
                BOXES = 32;
                fillGen7();
                dumpAllData7();
                enableControls();
                SetCheckedRadio(radioBoxes, true);
            }
            else if (game != GameType.None && !gen7 && !botWorking)
            {
                PKXEXT = ".pk6";
                BOXEXT = "_boxes.ek6";
                MAXSPECIES = 721;
                BOXES = 31;
                fillGen6();
                dumpAllData();
                enableControls();
                SetCheckedRadio(radioBoxes, true);
            }
        }

        private void fillGen6()
        {
            ComboboxFill(Lang, LookupTable.Lang6);
            ComboboxFill(pkLang, LookupTable.Lang6);
            ComboboxFill(species, LookupTable.Species6);
            ComboboxFill(ability, LookupTable.Ability6);
            ComboboxFill(filterAbility, LookupTable.Ability6);
            ComboboxFill(heldItem, LookupTable.Item6);
            ComboboxFill(ball, LookupTable.Balls6);
            ComboboxFill(move1, LookupTable.Moves6);
            ComboboxFill(move2, LookupTable.Moves6);
            ComboboxFill(move3, LookupTable.Moves6);
            ComboboxFill(move4, LookupTable.Moves6);
            ComboboxFill(relearnmove1, LookupTable.Moves6);
            ComboboxFill(relearnmove2, LookupTable.Moves6);
            ComboboxFill(relearnmove3, LookupTable.Moves6);
            ComboboxFill(relearnmove4, LookupTable.Moves6);
            ComboboxFill(typeLSR, LookupTable.SoftResetModes6);
            ComboboxFill(modeBreed, LookupTable.BreedingModes6);
            SetVisible(itemsView7, false);
            SetVisible(itemsGridView, true);
            SetVisible(keysGridView, false);
            SetVisible(tmsGridView, false);
            SetVisible(medsGridView, false);
            SetVisible(bersGridView, false);
            if (radioBoxes.Checked)
            {
                SetMaximum(boxDump, BOXES);
            }
            SetMaximum(cloneBoxTo, BOXES);
            SetMaximum(cloneBoxFrom, BOXES);
            SetMaximum(writeBoxTo, BOXES);
            SetMaximum(boxBreed, BOXES);
            SetMaximum(WTBox, BOXES);
            SetText(label3, "Poké Miles:");
            SetText(radioDaycare, "Daycare");
        }

        private async void fillGen7()
        {
            ComboboxFill(Lang, LookupTable.Lang7);
            ComboboxFill(pkLang, LookupTable.Lang7);
            ComboboxFill(species, LookupTable.Species7);
            ComboboxFill(ability, LookupTable.Ability7);
            ComboboxFill(filterAbility, LookupTable.Ability7);
            ComboboxFill(heldItem, LookupTable.Item7);
            ComboboxFill(ball, LookupTable.Balls7);
            ComboboxFill(move1, LookupTable.Moves7);
            ComboboxFill(move2, LookupTable.Moves7);
            ComboboxFill(move3, LookupTable.Moves7);
            ComboboxFill(move4, LookupTable.Moves7);
            ComboboxFill(relearnmove1, LookupTable.Moves7);
            ComboboxFill(relearnmove2, LookupTable.Moves7);
            ComboboxFill(relearnmove3, LookupTable.Moves7);
            ComboboxFill(relearnmove4, LookupTable.Moves7);
            ComboboxFill(typeLSR, LookupTable.SoftResetModes7);
            ComboboxFill(sr_Species, LookupTable.Species7);
            ComboboxFill(modeBreed, LookupTable.BreedingModes7);
            SetVisible(itemsView7, true);
            SetVisible(itemsGridView, false);
            SetVisible(keysGridView, false);
            SetVisible(tmsGridView, false);
            SetVisible(medsGridView, false);
            SetVisible(bersGridView, false);
            if (radioBoxes.Checked)
            {
                SetMaximum(boxDump, BOXES);
            }
            SetMaximum(cloneBoxTo, BOXES);
            SetMaximum(cloneBoxFrom, BOXES);
            SetMaximum(writeBoxTo, BOXES);
            SetMaximum(boxBreed, BOXES);
            SetMaximum(WTBox, BOXES);
            SetText(label3, "Current FC:");
            SetText(radioDaycare, "Nursery");

            // Apply connection patch
            Task<bool> Patch = Program.helper.waitNTRwrite(LookupTable.nfcOff, LookupTable.nfcVal, pid);
            if (!(await Patch))
            {
                MessageBox.Show("An error has ocurred while applying the connection patch.", "PKMN-NTR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Connection

        #region R/W trainer data

        // Dump data according to generation
        public void dumpAllData()
        {
            dumpName();
            dumpTID();
            dumpSID();
            dumpMoney();
            dumpMiles();
            dumpBP();
            dumpLang();
            dumpTime();
            dumpItems();
        }

        public void dumpAllData7()
        {
            dumpName();
            dumpTID();
            dumpSID();
            dumpMoney();
            dumpBP();
            dumpFC();
            dumpLang();
            dumpTime();
            dumpEggSeed();
            dumpRNGSeed();
            dumpItems7();
        }

        private void ReloadFields_Click(object sender, EventArgs e)
        {
            if (gen7)
            {
                dumpAllData7();
                showItems.ForeColor = Color.Green;
                showMedicine.ForeColor = Color.Black;
                showTMs.ForeColor = Color.Black;
                showBerries.ForeColor = Color.Black;
                showKeys.ForeColor = Color.Black;
            }
            else
            {
                dumpAllData();
            }
        }

        // Name handling
        public void dumpName()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x18], handleNameData, null);
            waitingForData.Add(Program.scriptHelper.data(nameoff, 0x18, pid), myArgs);
        }

        public void handleNameData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetText(playerName, Encoding.Unicode.GetString(args.data));
        }

        private void pokeName_Click(object sender, EventArgs e)
        {
            if (playerName.Text.Length <= 12)
            {
                string nameS = playerName.Text.PadRight(12, '\0');
                byte[] nameBytes = Encoding.Unicode.GetBytes(nameS);
                Program.scriptHelper.write(nameoff, nameBytes, pid);
            }
            else
            {
                MessageBox.Show("That name is too long, please choose a trainer name of 12 character or less.", "Name too long!");
            }
        }

        // TID handling
        public void dumpTID()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x02], handleTIDData, null);
            waitingForData.Add(Program.scriptHelper.data(tidoff, 0x02, pid), myArgs);
        }

        public void handleTIDData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(TIDNum, BitConverter.ToUInt16(args.data, 0));
        }

        private void pokeTID_Click(object sender, EventArgs e)
        {
            byte[] tidbyte = BitConverter.GetBytes(Convert.ToUInt16(TIDNum.Value));
            Program.scriptHelper.write(tidoff, tidbyte, pid);
        }

        // SID handling
        public void dumpSID()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x02], handleSIDData, null);
            waitingForData.Add(Program.scriptHelper.data(sidoff, 0x02, pid), myArgs);
        }

        public void handleSIDData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(SIDNum, BitConverter.ToUInt16(args.data, 0));
        }

        private void pokeSID_Click(object sender, EventArgs e)
        {
            byte[] sidbyte = BitConverter.GetBytes(Convert.ToUInt16(SIDNum.Value));
            Program.scriptHelper.write(sidoff, sidbyte, pid);
        }

        // Money handling
        public void dumpMoney()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMoneyData, null);
            waitingForData.Add(Program.scriptHelper.data(moneyoff, 0x04, pid), myArgs);
        }

        public void handleMoneyData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(moneyNum, BitConverter.ToInt32(args.data, 0));
        }

        private void pokeMoney_Click(object sender, EventArgs e)
        {
            byte[] moneybyte = BitConverter.GetBytes(Convert.ToInt32(moneyNum.Value));
            Program.scriptHelper.write(moneyoff, moneybyte, pid);
        }

        // Battle Points Handling
        public void dumpBP()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleBPData, null);
            waitingForData.Add(Program.scriptHelper.data(bpoff, 0x04, pid), myArgs);
        }

        public void handleBPData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(bpNum, BitConverter.ToInt32(args.data, 0));
        }

        private void pokeBP_Click(object sender, EventArgs e)
        {
            byte[] bpbyte = BitConverter.GetBytes(Convert.ToInt32(bpNum.Value));
            Program.scriptHelper.write(bpoff, bpbyte, pid);
        }

        // Poké Miles and Current FC handling
        public void dumpMiles()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMilesData, null);
            waitingForData.Add(Program.scriptHelper.data(milesoff, 0x04, pid), myArgs);
        }

        public void handleMilesData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(milesNum, BitConverter.ToInt32(args.data, 0));
        }

        private void pokeMiles_Click(object sender, EventArgs e)
        {
            if (gen7)
            { // Current Festival Coins
                byte[] FCbyte = BitConverter.GetBytes(Convert.ToInt32(milesNum.Value));
                Program.scriptHelper.write(currentFCoff, FCbyte, pid);
            }
            else
            { // Poké Miles
                byte[] milesbyte = BitConverter.GetBytes(Convert.ToInt32(milesNum.Value));
                Program.scriptHelper.write(milesoff, milesbyte, pid);
            }
        }

        // Total Festival Coins handling
        public void dumpFC()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMilesData, null);
            waitingForData.Add(Program.scriptHelper.data(currentFCoff, 0x04, pid), myArgs);
            DataReadyWaiting myArgs2 = new DataReadyWaiting(new byte[0x04], handleFC, null);
            waitingForData.Add(Program.scriptHelper.data(totalFCoff, 0x04, pid), myArgs2);
        }

        public void handleFC(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(totalFCNum, BitConverter.ToInt32(args.data, 0));
        }

        private void pokeTotalFC_Click(object sender, EventArgs e)
        {
            byte[] FCbyte = BitConverter.GetBytes(Convert.ToInt32(totalFCNum.Value));
            Program.scriptHelper.write(totalFCoff, FCbyte, pid);
        }

        // Language handling
        public void dumpLang()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x01], handleLangData, null);
            waitingForData.Add(Program.scriptHelper.data(langoff, 0x01, pid), myArgs);
        }

        public void handleLangData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;

            byte langbyte = args.data[0];
            int i = 0;
            switch (langbyte)
            {
                case 1: i = 0; break;
                case 2: i = 1; break;
                case 3: i = 2; break;
                case 4: i = 3; break;
                case 5: i = 4; break;
                case 7: i = 5; break;
                case 8: i = 6; break;
                case 9: i = 7; break;
                case 10: i = 8; break;
                default: i = -1; break;
            }
            SetSelectedIndex(Lang, i);
        }

        private void pokeLang_Click(object sender, EventArgs e)
        {
            switch (Lang.SelectedIndex)
            {
                case 0: lang = 0x01; break;
                case 1: lang = 0x02; break;
                case 2: lang = 0x03; break;
                case 3: lang = 0x04; break;
                case 4: lang = 0x05; break;
                case 5: lang = 0x07; break;
                case 6: lang = 0x08; break;
                case 7: lang = 0x09; break;
                case 8: lang = 0x0A; break;
            }
            Program.scriptHelper.writebyte(langoff, lang, pid);
        }

        // Time handling
        public void dumpTime()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleTimeData, null);
            waitingForData.Add(Program.scriptHelper.data(timeoff, 0x04, pid), myArgs);
        }

        public void handleTimeData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetValue(hourNum, BitConverter.ToUInt16(args.data, 0));
            SetValue(minNum, args.data[2]);
            SetValue(secNum, args.data[3]);
        }

        private void pokeTime_Click(object sender, EventArgs e)
        {
            byte[] timeData = new byte[4];
            BitConverter.GetBytes(Convert.ToUInt16(hourNum.Value)).CopyTo(timeData, 0);
            timeData[2] = Convert.ToByte(minNum.Value);
            timeData[3] = Convert.ToByte(secNum.Value);
            Program.scriptHelper.write(timeoff, timeData, pid);
        }

        // Egg Seed handling
        public void dumpEggSeed()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x10], handleEggSeed, null);
            waitingForData.Add(Program.scriptHelper.data(eggseedOff, 0x10, pid), myArgs);
        }

        public void handleEggSeed(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetText(EggSeed, BitConverter.ToString(args.data.Reverse().ToArray()).Replace("-", ""));
        }

        public string updateSeed(byte[] data)
        {
            string str = BitConverter.ToString(data.Reverse().ToArray()).Replace("-", "");
            SetText(EggSeed, str);
            return str;
        }

        // RNG Seed
        public void dumpRNGSeed()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleRNGSeed, null);
            waitingForData.Add(Program.scriptHelper.data(0x325A3838, 0x04, pid), myArgs);
        }

        public void handleRNGSeed(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            SetText(seedRNG, BitConverter.ToUInt32(args.data, 0).ToString("X8"));
        }

        // Item handling
        public void dumpItems()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0xB90], handleItemData, null);
            waitingForData.Add(Program.scriptHelper.data(itemsoff, 0xB90, pid), myArgs);
        }

        public void handleItemData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            items = new byte[args.data.Length];
            Array.Copy(args.data, items, args.data.Length);
            //Final data processing will be done in GUI thread
            ItemDumpFinished();
        }

        private void ItemDumpFinished()
        {
            if (itemsGridView.InvokeRequired)
            {
                itemsGridView.Invoke((MethodInvoker)delegate { readItems(); });
            }
            else
            {
                readItems();
            }
        }

        public void readItems()
        {
            const int itemsLength = 1600;
            const int keysLength = 384;
            const int tmsLength = 432;
            const int medsLength = 256;
            const int bersLength = 288;
            const int totalLength = itemsLength + keysLength + tmsLength + medsLength + bersLength;

            if (items == null || items.Length != totalLength)
            {
                throw new ArgumentOutOfRangeException("Item data array is of wrong length");
            }

            itemData = items.Skip(0).Take(itemsLength).ToArray();
            keyData = items.Skip((int)(keysoff - itemsoff)).Take(keysLength).ToArray();
            tmData = items.Skip((int)(tmsoff - itemsoff)).Take(tmsLength).ToArray();
            medData = items.Skip((int)(medsoff - itemsoff)).Take(medsLength).ToArray();
            berryData = items.Skip((int)(bersoff - itemsoff)).Take(bersLength).ToArray();

            addItemsToGridView(itemData, itemsGridView);
            addItemsToGridView(keyData, keysGridView);
            addItemsToGridView(tmData, tmsGridView);
            addItemsToGridView(medData, medsGridView);
            addItemsToGridView(berryData, bersGridView);
        }

        private void addItemsToGridView(byte[] data, DataGridView gv)
        {
            int numOfItems = countItems(data);
            if (numOfItems > 0)
            {
                gv.Rows.Add(numOfItems);
                for (int i = 0; i < numOfItems; i++)
                {
                    int itemsfinal = BitConverter.ToUInt16(data, i * 4);
                    int amountfinal = BitConverter.ToUInt16(data, (i * 4) + 2);
                    gv.Rows[i].Cells[0].Value = LookupTable.Item6[itemsfinal];
                    gv.Rows[i].Cells[1].Value = amountfinal;
                }
            }
        }

        private int countItems(byte[] data)
        {
            int i = 0;
            for (i = 0; i < data.Length; i += 4)
            {
                uint type = BitConverter.ToUInt16(data, i);
                uint amount = BitConverter.ToUInt16(data, i + 2);
                if (type == 0 && amount == 0)
                    break;
            }
            return i / 4;
        }

        private void itemAdd_Click(object sender, EventArgs e)
        {
            if (itemsGridView.Visible == true)
            {
                if (itemsGridView.RowCount >= 400)
                {
                    MessageBox.Show("You already have the max amount of items!", "Too many items");
                }
                else
                {
                    itemsGridView.Rows.Add("[None]", 0);
                }
            }

            else if (keysGridView.Visible == true)
            {
                if (keysGridView.RowCount >= 96)
                {
                    MessageBox.Show("You already have the max amount of key items!", "Too many items");
                }
                else
                {
                    keysGridView.Rows.Add("[None]", 0);
                }
            }

            else if (tmsGridView.Visible == true)
            {
                if (tmsGridView.RowCount >= 96)
                {
                    MessageBox.Show("You already have the max amount of medicine items!", "Too many items");
                }
                else
                {
                    tmsGridView.Rows.Add("[None]", 0);
                }
            }

            else if (medsGridView.Visible == true)
            {
                if (medsGridView.RowCount >= 108)
                {
                    MessageBox.Show("You already have the max amount of TMs & HMs!", "Too many items");
                }
                else
                {
                    medsGridView.Rows.Add("[None]", 0);
                }
            }

            else if (bersGridView.Visible == true)
            {
                if (bersGridView.RowCount >= 72)
                {
                    MessageBox.Show("You already have the max amount of berries!", "Too many items");
                }
                else
                {
                    bersGridView.Rows.Add("[None]", 0);
                }
            }
        }

        public void itemWrite_Click(object sender, EventArgs e)
        {
            byte[] dataToWrite = new byte[0] { };
            uint offsetToWrite = 0;
            if (gen7)
            {
                itemData = new byte[itemsView7.Rows.Count * 4];
                for (int i = 0; i < itemsView7.Rows.Count; i++)
                {
                    // Build Item Value
                    uint val = 0;
                    string datastring = itemsView7.Rows[i].Cells[0].Value.ToString();
                    int itemIndex = Array.IndexOf(LookupTable.Item7, datastring);
                    int itemcnt;
                    itemcnt = Convert.ToInt32(itemsView7.Rows[i].Cells[1].Value.ToString());
                    val |= (uint)(itemIndex & 0x3FF);
                    val |= (uint)(itemcnt & 0x3FF) << 10;
                    BitConverter.GetBytes(val).CopyTo(itemData, i * 4);
                }
                dataToWrite = itemData;
                switch (currentpouch)
                {
                    case 0:
                        offsetToWrite = medsoff;
                        break;
                    case 1:
                        offsetToWrite = itemsoff;
                        break;
                    case 2:
                        offsetToWrite = tmsoff;
                        break;
                    case 3:
                        offsetToWrite = bersoff;
                        break;
                    case 4:
                        offsetToWrite = keysoff;
                        break;
                }
            }
            else
            {
                if (itemsGridView.Visible == true)
                {
                    itemData = new byte[1600];
                    for (int i = 0; i < itemsGridView.RowCount; i++)
                    {
                        string datastring = itemsGridView.Rows[i].Cells[0].Value.ToString();
                        int itemIndex = Array.IndexOf(LookupTable.Item6, datastring);
                        int itemcnt;
                        itemcnt = Convert.ToUInt16(itemsGridView.Rows[i].Cells[1].Value.ToString());

                        BitConverter.GetBytes((ushort)itemIndex).CopyTo(itemData, i * 4);
                        BitConverter.GetBytes((ushort)itemcnt).CopyTo(itemData, i * 4 + 2);
                    }
                    dataToWrite = itemData;
                    offsetToWrite = itemsoff;
                }

                else if (keysGridView.Visible == true)
                {
                    keyData = new byte[384];
                    for (int i = 0; i < keysGridView.RowCount; i++)
                    {
                        string datastring = keysGridView.Rows[i].Cells[0].Value.ToString();
                        int itemIndex = Array.IndexOf(LookupTable.Item6, datastring);
                        int itemcnt;
                        itemcnt = Convert.ToUInt16(keysGridView.Rows[i].Cells[1].Value.ToString());

                        BitConverter.GetBytes((ushort)itemIndex).CopyTo(keyData, i * 4);
                        BitConverter.GetBytes((ushort)itemcnt).CopyTo(keyData, i * 4 + 2);
                    }
                    dataToWrite = keyData;
                    offsetToWrite = keysoff;
                }

                else if (tmsGridView.Visible == true)
                {
                    tmData = new byte[432];
                    for (int i = 0; i < tmsGridView.RowCount; i++)
                    {
                        string datastring = tmsGridView.Rows[i].Cells[0].Value.ToString();
                        int itemIndex = Array.IndexOf(LookupTable.Item6, datastring);
                        int itemcnt;
                        itemcnt = Convert.ToUInt16(tmsGridView.Rows[i].Cells[1].Value.ToString());

                        BitConverter.GetBytes((ushort)itemIndex).CopyTo(tmData, i * 4);
                        BitConverter.GetBytes((ushort)1).CopyTo(tmData, i * 4 + 2);
                    }
                    dataToWrite = tmData;
                    offsetToWrite = tmsoff;
                }

                else if (medsGridView.Visible == true)
                {
                    medData = new byte[256];
                    for (int i = 0; i < medsGridView.RowCount; i++)
                    {
                        string datastring = medsGridView.Rows[i].Cells[0].Value.ToString();
                        int itemIndex = Array.IndexOf(LookupTable.Item6, datastring);
                        int itemcnt;
                        itemcnt = Convert.ToUInt16(medsGridView.Rows[i].Cells[1].Value.ToString());

                        BitConverter.GetBytes((ushort)itemIndex).CopyTo(medData, i * 4);
                        BitConverter.GetBytes((ushort)itemcnt).CopyTo(medData, i * 4 + 2);
                    }
                    dataToWrite = medData;
                    offsetToWrite = medsoff;
                }

                else if (bersGridView.Visible == true)
                {
                    berryData = new byte[288];
                    for (int i = 0; i < bersGridView.RowCount; i++)
                    {
                        string datastring = bersGridView.Rows[i].Cells[0].Value.ToString();
                        int itemIndex = Array.IndexOf(LookupTable.Item6, datastring);
                        int itemcnt;
                        itemcnt = Convert.ToUInt16(bersGridView.Rows[i].Cells[1].Value.ToString());

                        BitConverter.GetBytes((ushort)itemIndex).CopyTo(berryData, i * 4);
                        BitConverter.GetBytes((ushort)itemcnt).CopyTo(berryData, i * 4 + 2);
                    }
                    dataToWrite = berryData;
                    offsetToWrite = bersoff;
                }
            }
            Program.scriptHelper.write(offsetToWrite, dataToWrite, pid);
        }

        // Item handling Gen 7
        public void dumpItems7()
        {
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[53 * 4], handleMeds7, null);
            waitingForData.Add(Program.scriptHelper.data(medsoff, 53 * 4, pid), myArgs);
            DataReadyWaiting myArgs2 = new DataReadyWaiting(new byte[336 * 4], handleItems7, null);
            waitingForData.Add(Program.scriptHelper.data(itemsoff, 336 * 4, pid), myArgs2);
            DataReadyWaiting myArgs3 = new DataReadyWaiting(new byte[100 * 4], handleTMs7, null);
            waitingForData.Add(Program.scriptHelper.data(tmsoff, 100 * 4, pid), myArgs3);
            DataReadyWaiting myArgs4 = new DataReadyWaiting(new byte[67 * 4], handleBerries7, null);
            waitingForData.Add(Program.scriptHelper.data(bersoff, 67 * 4, pid), myArgs4);
            DataReadyWaiting myArgs5 = new DataReadyWaiting(new byte[24 * 4], handleKeyItems7, null);
            waitingForData.Add(Program.scriptHelper.data(keysoff, 24 * 4, pid), myArgs5);
        }

        public void handleMeds7(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            Array.Copy(args.data, medData7, args.data.Length);
            for (int i = 0; i < medcount7; i++)
            {
                uint val = BitConverter.ToUInt32(medData7, i * 4);
                meds7[i, 0] = (int)(val & 0x3FF); // 10bit itemID
                meds7[i, 1] = (int)(val >> 10 & 0x3FF); // 10bit count
            }
        }

        public void handleItems7(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            Array.Copy(args.data, itemData7, args.data.Length);
            for (int i = 0; i < itemcount7; i++)
            {
                uint val = BitConverter.ToUInt32(itemData7, i * 4);
                items7[i, 0] = (int)(val & 0x3FF); // 10bit itemID
                items7[i, 1] = (int)(val >> 10 & 0x3FF); // 10bit count
            }
            ItemDumpFinished7(items7);
            currentpouch = 1;
        }

        public void handleTMs7(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            Array.Copy(args.data, tmsData7, args.data.Length);
            for (int i = 0; i < tmscount7; i++)
            {
                uint val = BitConverter.ToUInt32(tmsData7, i * 4);
                tms7[i, 0] = (int)(val & 0x3FF); // 10bit itemID
                tms7[i, 1] = (int)(val >> 10 & 0x3FF); // 10bit count
            }
        }

        public void handleBerries7(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            Array.Copy(args.data, bersData7, args.data.Length);
            for (int i = 0; i < berscount7; i++)
            {
                uint val = BitConverter.ToUInt32(bersData7, i * 4);
                bers7[i, 0] = (int)(val & 0x3FF); // 10bit itemID
                bers7[i, 1] = (int)(val >> 10 & 0x3FF); // 10bit count
            }
        }

        public void handleKeyItems7(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            Array.Copy(args.data, keysData7, args.data.Length);
            for (int i = 0; i < keyscount7; i++)
            {
                uint val = BitConverter.ToUInt32(keysData7, i * 4);
                keys7[i, 0] = (int)(val & 0x3FF); // 10bit itemID
                keys7[i, 1] = (int)(val >> 10 & 0x3FF); // 10bit count
            }
        }

        private void ItemDumpFinished7(int[,] itemdata)
        {
            if (itemsView7.InvokeRequired)
            {
                itemsView7.Invoke((MethodInvoker)delegate { readItems7(itemdata); });
            }
            else
            {
                readItems7(itemdata);
            }
        }

        private void readItems7(int[,] itemdata)
        {
            itemsView7.Rows.Clear();
            for (int i = 0; i < itemdata.GetLength(0); i++)
            {
                itemsView7.Rows.Add();
                itemsView7.Rows[i].Cells[0].Value = LookupTable.Item7[itemdata[i, 0]];
                itemsView7.Rows[i].Cells[1].Value = itemdata[i, 1];
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
                if (!gen7)
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
                if (!gen7)
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
                PKHeX validator = new PKHeX();
                validator.Data = PKHeX.decryptArray(args.data);
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

                dumpedPKHeX.Data = validator.Data;
                updateTabs();
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

            if (game == GameType.X || game == GameType.Y)
            {
                relativePattern = new byte[] { 0x08, 0x1C, 0x01, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD8, 0xBE, 0x59 };
                offsetAfter += 98;
            }

            if (game == GameType.OR || game == GameType.AS)
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

            if (game == GameType.X || game == GameType.Y)
            {
                relativePattern = new byte[] { 0x60, 0x75, 0xC6, 0x08, 0xDC, 0xA8, 0xC7, 0x08, 0xD0, 0xB6, 0xC7, 0x08 };
                offsetAfter = 637;
            }
            if (game == GameType.OR || game == GameType.AS)
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
            if (dumpedPKHeX.Data == null)
            {
                MessageBox.Show("No Pokemon data found, please dump a Pokemon first to edit!", "No data to edit");
            }
            else if (dumpedPKHeX.Data.Length != POKEBYTES)
            {
                MessageBox.Show("The data size of this pokémon data is invalid. If you dumped it from the party, please deposit it in a box before editing and try again.", "Invalid data size");
            }
            else if (evHPNum.Value + evATKNum.Value + evDEFNum.Value + evSPENum.Value + evSPANum.Value + evSPDNum.Value >= 511)
            {
                MessageBox.Show("Pokemon EV count is too high, the sum of all EVs should be 510 or less!", "EVs too high");
            }
            else if (nickname.Text.Length > 12)
            {
                MessageBox.Show("Pokemon name length too long! Please use a name with a length of 12 or less.", "Name too long");
            }
            else if (otName.Text.Length > 12)
            {
                MessageBox.Show("OT name length too long! Please use a name with a length of 12 or less.", "Name too long");
            }
            else
            {
                // Main Tab
                dumpedPKHeX.Species = species.SelectedIndex + 1;
                dumpedPKHeX.Nickname = nickname.Text.PadRight(12, '\0');
                dumpedPKHeX.IsNicknamed = nickBox.Checked;
                dumpedPKHeX.Nature = nature.SelectedIndex;
                switch (ability.SelectedIndex)
                {
                    case 0:
                        dumpedPKHeX.AbilityNumber = 1;
                        dumpedPKHeX.Ability = absno[0];
                        break;
                    case 1:
                        dumpedPKHeX.AbilityNumber = 2;
                        dumpedPKHeX.Ability = absno[1];
                        break;
                    case 2:
                        dumpedPKHeX.AbilityNumber = 4;
                        dumpedPKHeX.Ability = absno[2];
                        break;
                    default:
                        dumpedPKHeX.AbilityNumber = 1;
                        dumpedPKHeX.Ability = absno[0];
                        break;
                }
                dumpedPKHeX.HeldItem = heldItem.SelectedIndex;
                dumpedPKHeX.Ball = ball.SelectedIndex + 1;
                dumpedPKHeX.PID = PKHeX.getHEXval(dPID.Text);
                dumpedPKHeX.Gender = genderBox.SelectedIndex;
                dumpedPKHeX.IsEgg = isEgg.Checked;
                dumpedPKHeX.EXP = (uint)ExpPoints.Value;
                dumpedPKHeX.CurrentFriendship = (int)friendship.Value;

                // Stats Tab
                dumpedPKHeX.IV_HP = (int)ivHPNum.Value;
                dumpedPKHeX.IV_ATK = (int)ivATKNum.Value;
                dumpedPKHeX.IV_DEF = (int)ivDEFNum.Value;
                dumpedPKHeX.IV_SPE = (int)ivSPENum.Value;
                dumpedPKHeX.IV_SPA = (int)ivSPANum.Value;
                dumpedPKHeX.IV_SPD = (int)ivSPDNum.Value;
                dumpedPKHeX.EV_HP = (int)evHPNum.Value;
                dumpedPKHeX.EV_ATK = (int)evATKNum.Value;
                dumpedPKHeX.EV_DEF = (int)evDEFNum.Value;
                dumpedPKHeX.EV_SPE = (int)evSPENum.Value;
                dumpedPKHeX.EV_SPA = (int)evSPANum.Value;
                dumpedPKHeX.EV_SPD = (int)evSPDNum.Value;
                if (gen7 && level.Value == 100)
                {
                    dumpedPKHeX.HT_HP = HypT_HP.Checked;
                    dumpedPKHeX.HT_ATK = HypT_Atk.Checked;
                    dumpedPKHeX.HT_DEF = HypT_Def.Checked;
                    dumpedPKHeX.HT_SPA = HypT_SpA.Checked;
                    dumpedPKHeX.HT_SPD = HypT_SpD.Checked;
                    dumpedPKHeX.HT_SPE = HypT_Spe.Checked;
                }

                // Moves Tab
                dumpedPKHeX.Move1 = move1.SelectedIndex;
                dumpedPKHeX.Move2 = move2.SelectedIndex;
                dumpedPKHeX.Move3 = move3.SelectedIndex;
                dumpedPKHeX.Move4 = move4.SelectedIndex;
                dumpedPKHeX.RelearnMove1 = relearnmove1.SelectedIndex;
                dumpedPKHeX.RelearnMove2 = relearnmove2.SelectedIndex;
                dumpedPKHeX.RelearnMove3 = relearnmove3.SelectedIndex;
                dumpedPKHeX.RelearnMove4 = relearnmove4.SelectedIndex;
                dumpedPKHeX.FixMoves();
                dumpedPKHeX.FixRelearn();

                // Misc Tab
                dumpedPKHeX.OT_Name = otName.Text.PadRight(12, '\0');
                dumpedPKHeX.SID = (int)dSIDNum.Value;
                dumpedPKHeX.TID = (int)dTIDNum.Value;
                switch (pkLang.SelectedIndex)
                {
                    case 0: dumpedPKHeX.Language = 0x01; break;
                    case 1: dumpedPKHeX.Language = 0x02; break;
                    case 2: dumpedPKHeX.Language = 0x03; break;
                    case 3: dumpedPKHeX.Language = 0x04; break;
                    case 4: dumpedPKHeX.Language = 0x05; break;
                    case 5: dumpedPKHeX.Language = 0x07; break;
                    case 6: dumpedPKHeX.Language = 0x08; break;
                    case 7: dumpedPKHeX.Language = 0x09; break;
                    case 8: dumpedPKHeX.Language = 0x0A; break;
                }

                dumpedPKHeX.RefreshChecksum();

                byte[] pkmEdited = PKHeX.encryptArray(dumpedPKHeX.Data);

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

        private void randomPID_Click(object sender, EventArgs e)
        {
            dumpedPKHeX.setRandomPID();
            dPID.Text = dumpedPKHeX.PID.ToString("X8");
            setShinyMark();
        }

        // Clone pokémon
        private void cloneDoIt_Click(object sender, EventArgs e)
        {
            uint offset = boxOff + cloneGetBoxIndexFrom() * POKEBYTES;
            uint mySeq = Program.scriptHelper.data(offset, POKEBYTES, pid);
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handleCloneData, null);
            waitingForData.Add(mySeq, myArgs);
        }

        private void handleCloneData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            writePokemonToBox(args.data, cloneGetBoxIndexTo(), cloneGetCopies());
        }

        private uint cloneGetCopies()
        {
            return decimal.ToUInt32(cloneCopiesNo.Value);
        }

        private uint cloneGetBoxIndexTo()
        {
            return decimal.ToUInt32((cloneBoxTo.Value - 1) * BOXSIZE + cloneSlotTo.Value - 1);
        }

        private uint cloneGetBoxIndexFrom()
        {
            return decimal.ToUInt32((cloneBoxFrom.Value - 1) * BOXSIZE + cloneSlotFrom.Value - 1);
        }

        private void cloneBoxTo_ValueChanged(object sender, EventArgs e)
        {
            cloneCopiesNo.Maximum = BOXES * BOXSIZE - cloneGetBoxIndexTo();
        }

        private void cloneSlotTo_ValueChanged(object sender, EventArgs e)
        {
            cloneCopiesNo.Maximum = BOXES * BOXSIZE - cloneGetBoxIndexTo();
        }

        // Write pokémon from file
        private void writeBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog selectWriteDialog = new OpenFileDialog();
                selectWriteDialog.Title = "Select an EKX/PKX file";
                if (gen7)
                {
                    selectWriteDialog.Filter = "Gen 7 pokémon files|*.ek7;*.pk7";
                }
                else
                {
                    selectWriteDialog.Filter = "Gen 6 pokémon files|*.ek6;*.pk6";
                }
                string path = System.Windows.Forms.@Application.StartupPath + "\\Pokemon";
                selectWriteDialog.InitialDirectory = path;
                if (selectWriteDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedCloneValid = (readPokemonFromFile(selectWriteDialog.FileName, out selectedCloneData) == 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int readPokemonFromFile(string filename, out byte[] result)
        { //Returns 0 on success, other values on failure
            string extension = Path.GetExtension(filename);
            result = new byte[POKEBYTES];

            // Test if correct generation format
            if ((gen7 && (extension == ".pk7" || extension == ".ek7")) || (!gen7 && (extension == ".pk6" || extension == ".ek6")))
            {
                bool isEncrypted = false;
                if (extension == ".pk6" || extension == ".pk7")
                {
                    isEncrypted = false;
                }
                else if (extension == ".ek6" || extension == ".ek7")
                {
                    isEncrypted = true;
                }
                else
                {
                    MessageBox.Show("Please make sure you are using a valid PKX/EKX file.", "Incorrect File Size");
                    return 1;
                }

                byte[] tmpBytes = File.ReadAllBytes(filename);
                if (tmpBytes.Length == 260 || tmpBytes.Length == POKEBYTES)
                { // All OK, commit
                    if (isEncrypted)
                    {
                        tmpBytes.CopyTo(result, 0);
                    }
                    else
                    {
                        PKHeX.encryptArray(tmpBytes.Take(POKEBYTES).ToArray()).CopyTo(result, 0);
                    }
                }
                else
                {
                    MessageBox.Show("Please make sure you are using a valid PKX/EKX file.", "Incorrect File Size");
                    return 2;
                }
                return 0;
            }
            else
            {
                MessageBox.Show("This program does not support conversion of pokémon files between generations.", "Incorrect Generation Number");
                return 3;
            }
        }

        private void writeDoIt_Click(object sender, EventArgs e)
        {
            if (!selectedCloneValid)
            {
                MessageBox.Show("No Pokemon selected!", "Error");
                return;
            }
            int ret = writePokemonToBox(selectedCloneData, writeGetBoxIndex(), writeGetCopies());
            if (ret > 0)
            {
                MessageBox.Show(ret + " write(s) failed because the end of boxes was reached.", "Error");
            }
            else if (ret <= 0)
            {
                if (writeAutoInc.Checked)
                {
                    writeSetBoxIndex(writeGetBoxIndex() + writeGetCopies());
                }
            }
        }

        private int writePokemonToBox(byte[] data, uint boxFrom, uint count)
        { //Returns 0 on success, positive value represents how many copies could not be written.
            if (data.Length != POKEBYTES)
            {
                return -1;
            }

            int ret = 0;
            if (boxFrom + count > BOXES * BOXSIZE)
            {
                uint newCount = BOXES * BOXSIZE - boxFrom;
                ret = (int)(count - newCount);
                count = newCount;
            }

            byte[] dataToWrite = new byte[count * POKEBYTES];
            for (int i = 0; i < count; i++)
            {
                data.CopyTo(dataToWrite, i * POKEBYTES);
            }
            uint offset = boxOff + boxFrom * POKEBYTES;
            Program.scriptHelper.write(offset, dataToWrite, pid);
            return ret;
        }

        void writeTab_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void writeTab_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length <= 0)
            {
                return;
            }
            int fails = 0;
            foreach (string filename in files)
            {
                byte[] data = new byte[POKEBYTES];
                if (readPokemonFromFile(filename, out data) == 0)
                {
                    int ret = writePokemonToBox(data, writeGetBoxIndex(), writeGetCopies());
                    if (ret > 0)
                    {
                        fails += ret;
                    }
                    else if (ret < 0)
                    {
                        return;
                    }
                }

                if (writeAutoInc.Checked)
                {
                    writeSetBoxIndex(writeGetBoxIndex() + writeGetCopies());
                }
            }
            if (fails > 0)
            {
                MessageBox.Show(fails + " write(s) failed because end of boxes was reached.", "Error");
            }
        }

        private uint writeGetCopies()
        {
            return decimal.ToUInt32(writeCopiesNo.Value);
        }

        private uint writeGetBoxIndex()
        {
            return decimal.ToUInt32((writeBoxTo.Value - 1) * BOXSIZE + writeSlotTo.Value - 1);
        }

        private void writeSetBoxIndex(uint index)
        {
            if (index >= BOXES * BOXSIZE)
            {
                index = BOXES * BOXSIZE - 1;
            }
            uint box = index / BOXSIZE;
            uint slot = index % BOXSIZE;
            SetValue(writeBoxTo, box + 1);
            SetValue(writeSlotTo, slot + 1);
        }

        private void writeBoxTo_ValueChanged(object sender, EventArgs e)
        {
            writeCopiesNo.Maximum = BOXES * BOXSIZE - writeGetBoxIndex();
        }

        private void writeSlotTo_ValueChanged(object sender, EventArgs e)
        {
            writeCopiesNo.Maximum = BOXES * BOXSIZE - writeGetBoxIndex();
        }

        // Delete pokémon
        private void delPkm_Click(object sender, EventArgs e)
        {
            uint offset = boxOff + deleteGetIndex() * POKEBYTES;
            uint size = POKEBYTES * deleteGetAmount();
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[size], handleDeleteData, null);
            uint mySeq = Program.scriptHelper.data(offset, size, pid);
            waitingForData.Add(mySeq, myArgs);
        }

        private void handleDeleteData(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;

            if (deleteKeepBackup.Checked)
            {
                try
                {
                    string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERPOKE + "\\" + FOLDERDELETE + "\\";
                    FileInfo folder = new FileInfo(folderPath);
                    folder.Directory.Create();
                    PKHeX validator = new PKHeX();
                    for (int i = 0; i < args.data.Length; i += POKEBYTES)
                    {
                        validator.Data = PKHeX.decryptArray(args.data.Skip(i).Take(POKEBYTES).ToArray());
                        if (validator.Species == 0)
                        {
                            continue;
                        }
                        string fileName;
                        if (gen7)
                        {
                            fileName = folderPath + "backup.pk7";
                        }
                        else
                        {
                            fileName = folderPath + "backup.pk6";
                        }
                        writePokemonToFile(validator.Data, fileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (gen7)
            {
                writePokemonToBox(LookupTable.EmptyPoke7, deleteGetIndex(), deleteGetAmount());
            }
            else
            {
                writePokemonToBox(LookupTable.EmptyPoke6, deleteGetIndex(), deleteGetAmount());
            }
        }

        private uint deleteGetAmount()
        {
            return decimal.ToUInt32(deleteAmount.Value);
        }

        private uint deleteGetIndex()
        {
            return decimal.ToUInt32((deleteBox.Value - 1) * BOXSIZE + deleteSlot.Value - 1);
        }

        private void deleteBox_ValueChanged(object sender, EventArgs e)
        {
            deleteAmount.Maximum = BOXES * BOXSIZE - deleteGetIndex();
        }

        private void deleteSlot_ValueChanged(object sender, EventArgs e)
        {
            deleteAmount.Maximum = BOXES * BOXSIZE - deleteGetIndex();
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
                if (game == GameType.OR || game == GameType.AS) // Handle ORAS Battle Resort Daycare
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
                if (gen7)
                {
                    DumpInstructionsBtn.Visible = true;
                }
            }
            else
            {
                radioOpponent.Tag = new LastBoxSlot { box = boxDump.Value, slot = slotDump.Value };
                BoxLabel.Text = "Box:";
                if (gen7)
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

        // Item buttons
        private void showItems_Click(object sender, EventArgs e)
        {
            if (gen7)
            {
                readItems7(items7);
                currentpouch = 1;
            }
            else
            {
                itemsGridView.Visible = true;
                keysGridView.Visible = false;
                tmsGridView.Visible = false;
                medsGridView.Visible = false;
                bersGridView.Visible = false;
            }
            showItems.ForeColor = Color.Green;
            showMedicine.ForeColor = Color.Black;
            showTMs.ForeColor = Color.Black;
            showBerries.ForeColor = Color.Black;
            showKeys.ForeColor = Color.Black;
        }

        private void showMedicine_Click(object sender, EventArgs e)
        {
            if (gen7)
            {
                readItems7(meds7);
                currentpouch = 0;
            }
            else
            {
                itemsGridView.Visible = false;
                keysGridView.Visible = false;
                tmsGridView.Visible = false;
                medsGridView.Visible = true;
                bersGridView.Visible = false;
            }
            showItems.ForeColor = Color.Black;
            showMedicine.ForeColor = Color.Green;
            showTMs.ForeColor = Color.Black;
            showBerries.ForeColor = Color.Black;
            showKeys.ForeColor = Color.Black;
        }

        private void showTMs_Click(object sender, EventArgs e)
        {
            if (gen7)
            {
                readItems7(tms7);
                currentpouch = 2;
            }
            else
            {
                itemsGridView.Visible = false;
                keysGridView.Visible = false;
                tmsGridView.Visible = true;
                medsGridView.Visible = false;
                bersGridView.Visible = false;
            }
            showItems.ForeColor = Color.Black;
            showMedicine.ForeColor = Color.Black;
            showTMs.ForeColor = Color.Green;
            showBerries.ForeColor = Color.Black;
            showKeys.ForeColor = Color.Black;
        }

        private void showBerries_Click(object sender, EventArgs e)
        {
            if (gen7)
            {
                readItems7(bers7);
                currentpouch = 3;
            }
            else
            {
                itemsGridView.Visible = false;
                keysGridView.Visible = false;
                tmsGridView.Visible = false;
                medsGridView.Visible = false;
                bersGridView.Visible = true;
            }
            showItems.ForeColor = Color.Black;
            showMedicine.ForeColor = Color.Black;
            showTMs.ForeColor = Color.Black;
            showBerries.ForeColor = Color.Green;
            showKeys.ForeColor = Color.Black;
        }

        private void showKeys_Click(object sender, EventArgs e)
        {
            if (gen7)
            {
                readItems7(keys7);
                currentpouch = 4;
            }
            else
            {
                itemsGridView.Visible = false;
                keysGridView.Visible = true;
                tmsGridView.Visible = false;
                medsGridView.Visible = false;
                bersGridView.Visible = false;
            }
            showItems.ForeColor = Color.Black;
            showMedicine.ForeColor = Color.Black;
            showTMs.ForeColor = Color.Black;
            showBerries.ForeColor = Color.Black;
            showKeys.ForeColor = Color.Green;
        }

        // Tooltips for TSV / ESV / G7ID
        private void setTSVToolTip(NumericUpDown TID, NumericUpDown SID)
        {
            int TSV = getTSV(TID.Value, SID.Value);
            if (gen7)
            {
                int G7ID = getGen7ID(TID.Value, SIDNum.Value);
                SetTooltip(ToolTipTSVpoke, TID, "G7ID: " + G7ID.ToString("D6") + "\r\nTSV: " + TSV.ToString("D4"));
                SetTooltip(ToolTipTSVpoke, SID, "G7ID: " + G7ID.ToString("D6") + "\r\nTSV: " + TSV.ToString("D4"));
            }
            else
            {
                SetTooltip(ToolTipTSVpoke, TID, "TSV: " + TSV.ToString("D4"));
                SetTooltip(ToolTipTSVpoke, SID, "TSV: " + TSV.ToString("D4"));
            }
        }

        private void dTIDNum_ValueChanged(object sender, EventArgs e)
        { // Handles pokémon OT's TID/SID fields
            setTSVToolTip(dTIDNum, dSIDNum);
        }

        private void TIDNum_ValueChanged(object sender, EventArgs e)
        { // Handles Trainer's TID/SID fields
            setTSVToolTip(TIDNum, SIDNum);
        }

        private void dPID_TextChanged(object sender, EventArgs e)
        {
            SetTooltip(ToolTipPSV, dPID, "PSV: " + getPSV(PKHeX.getHEXval(dPID.Text)).ToString("D4"));
        }

        // Ability, Exp and sprite update on species change
        private void species_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateAbility(species.SelectedIndex + 1, 0, 1);
            uint newexp = LookupTable.getExp(species.SelectedIndex + 1, (int)level.Value);
            SetValue(ExpPoints, newexp);
            ExpPoints.Maximum = LookupTable.getExp(species.SelectedIndex + 1, 100);
            if (dumpedPKHeX.Data != null)
            {
                dumpedPKHeX.Species = species.SelectedIndex + 1;
                dumpedPKHeX.AltForm = 0;
                dumpedPKHeX.AbilityNumber = 1;
                dumpedPKHeX.Ability = absno[0];
                dumpedPKHeX.EXP = newexp;
            }
            setSprite(species.SelectedIndex + 1, 0, false);
            updateName();
        }

        private void setSprite(int speciesindex, int formindex, bool isegg)
        {
            string resname;
            if (isegg)
            {
                resname = "egg";
            }
            else if (formindex == 0 || speciesindex == 493 || speciesindex == 773) // All Arceus / Silvally formes have same sprite
            {
                resname = "_" + speciesindex;
            }
            else
            {
                resname = "_" + speciesindex + "_" + formindex;
            }
            Bitmap data;
            data = (Bitmap)Resources.ResourceManager.GetObject(resname);
            if (data == null)
            {
                data = (Bitmap)Resources.ResourceManager.GetObject("unknown");
            }
            pictureBox2.Image = data;
        }

        private void ExpPoints_ValueChanged(object sender, EventArgs e)
        {
            level.ValueChanged -= level_ValueChanged;
            int speciesno = 0;
            Invoke(new MethodInvoker(delegate () { speciesno = species.SelectedIndex; }));
            int newlevel = LookupTable.getLevel(speciesno + 1, (int)ExpPoints.Value);
            SetValue(level, newlevel);
            HyperTrainBoxes();
            level.ValueChanged += level_ValueChanged;
        }

        private void level_ValueChanged(object sender, EventArgs e)
        {
            ExpPoints.ValueChanged -= ExpPoints_ValueChanged;
            uint newexp = LookupTable.getExp(species.SelectedIndex + 1, (int)level.Value);
            SetValue(ExpPoints, newexp);
            HyperTrainBoxes();
            ExpPoints.ValueChanged += ExpPoints_ValueChanged;
        }

        // Nickname
        private void nickBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((pkLang.SelectedIndex == 7 || pkLang.SelectedIndex == 8) && !nickBox.Checked)
            { // Chinese language handling
                SetEnabled(nickBox, false);
                SetReadOnly(nickname, true);
            }
            else
            {
                SetEnabled(nickBox, true);
                SetReadOnly(nickname, false);
            }
            updateName();
        }

        private void pkLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((pkLang.SelectedIndex == 7 || pkLang.SelectedIndex == 8) && !nickBox.Checked)
            { // Chinese language handling
                SetEnabled(nickBox, false);
                SetReadOnly(nickname, true);
            }
            else
            {
                SetEnabled(nickBox, true);
                SetReadOnly(nickname, false);
            }
            updateName();
        }

        public void updateName()
        {
            if (!nickBox.Checked)
            {
                int currentlang;
                switch (pkLang.SelectedIndex)
                {
                    case 0: currentlang = 0x01; break;
                    case 1: currentlang = 0x02; break;
                    case 2: currentlang = 0x03; break;
                    case 3: currentlang = 0x04; break;
                    case 4: currentlang = 0x05; break;
                    case 5: currentlang = 0x07; break;
                    case 6: currentlang = 0x08; break;
                    case 7: currentlang = 0x09; break;
                    case 8: currentlang = 0x0A; break;
                    default: currentlang = 0x02; break;
                }
                SetText(nickname, LookupTable.getSpeciesName(species.SelectedIndex + 1, currentlang, isEgg.Checked));
            }
        }

        private void nickname_TextChanged(object sender, EventArgs e)
        {
            SetChecked(nickBox, true);
        }

        // Poké ball image
        private void ball_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ball.SelectedIndex >= 0)
            {
                pictureBox1.Image = (Bitmap)Resources.ResourceManager.GetObject("ball" + ball.SelectedIndex);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        // Shiny pokémon mark
        private void setShinyMark()
        {
            shinyBox.CheckedChanged -= shinyBox_CheckedChanged;
            SetChecked(shinyBox, dumpedPKHeX.isShiny);
            shinyBox.CheckedChanged += shinyBox_CheckedChanged;
            if (dumpedPKHeX.isShiny)
            {
                shinypic.Image = Resources.shiny;
            }
            else
            {
                shinypic.Image = null;
            }
        }

        private void setShinySprite()
        {
            if (dumpedPKHeX.isShiny)
            {
                shinypic.Image = Resources.shiny;
            }
            else
            {
                shinypic.Image = null;
            }
        }

        private void shinyBox_CheckedChanged(object sender, EventArgs e)
        {
            if (shinyBox.Checked == true)
            {
                dumpedPKHeX.setShinyPID();
            }
            else
            {
                while (dumpedPKHeX.isShiny)
                {
                    dumpedPKHeX.setRandomPID();
                }
            }
            dPID.Text = dumpedPKHeX.PID.ToString("X8");
            setShinySprite();
        }

        // Automatic Hidden Power Calculation and Hyper Training Boxes
        private void ivChanged(object sender, EventArgs e)
        {
            int hp = (15 * (((int)ivHPNum.Value & 1) + 2 * ((int)ivATKNum.Value & 1) + 4 * ((int)ivDEFNum.Value & 1) + 8 * ((int)ivSPENum.Value & 1) + 16 * ((int)ivSPANum.Value & 1) + 32 * ((int)ivSPDNum.Value & 1)) / 63);
            SetText(hiddenPower, LookupTable.HPName[hp]);
            SetColor(hiddenPower, LookupTable.HPColor[hp], true);
            HyperTrainBoxes();
        }

        private void HyperTrainBoxes()
        {
            if (gen7 && level.Value == 100 && !botWorking)
            {
                if (ivHPNum.Value == 31)
                {
                    HypT_HP.Checked = false;
                    HypT_HP.Enabled = false;
                }
                else
                {
                    HypT_HP.Enabled = true;
                }

                if (ivATKNum.Value == 31)
                {
                    HypT_Atk.Checked = false;
                    HypT_Atk.Enabled = false;
                }
                else
                {
                    HypT_Atk.Enabled = true;
                }

                if (ivDEFNum.Value == 31)
                {
                    HypT_Def.Checked = false;
                    HypT_Def.Enabled = false;
                }
                else
                {
                    HypT_Def.Enabled = true;
                }

                if (ivSPANum.Value == 31)
                {
                    HypT_SpA.Checked = false;
                    HypT_SpA.Enabled = false;
                }
                else
                {
                    HypT_SpA.Enabled = true;
                }

                if (ivSPDNum.Value == 31)
                {
                    HypT_SpD.Checked = false;
                    HypT_SpD.Enabled = false;
                }
                else
                {
                    HypT_SpD.Enabled = true;
                }

                if (ivSPENum.Value == 31)
                {
                    HypT_Spe.Checked = false;
                    HypT_Spe.Enabled = false;
                }
                else
                {
                    HypT_Spe.Enabled = true;
                }
            }
            else
            {
                HypT_HP.Checked = false;
                HypT_Atk.Checked = false;
                HypT_Def.Checked = false;
                HypT_SpA.Checked = false;
                HypT_SpD.Checked = false;
                HypT_Spe.Checked = false;
                HypT_HP.Enabled = false;
                HypT_Atk.Enabled = false;
                HypT_Def.Enabled = false;
                HypT_SpA.Enabled = false;
                HypT_SpD.Enabled = false;
                HypT_Spe.Enabled = false;
            }
        }

        // Control Stick controls
        private void StickY_Scroll(object sender, EventArgs e)
        {
            StickNumY.Value = StickY.Value;
        }

        private void StickX_Scroll(object sender, EventArgs e)
        {
            StickNumX.Value = StickX.Value;
        }

        private void StickNumY_ValueChanged(object sender, EventArgs e)
        {
            StickY.Value = (int)StickNumY.Value;
        }

        private void StickNumX_ValueChanged(object sender, EventArgs e)
        {
            StickX.Value = (int)StickNumX.Value;
        }

        // Roaming soft-reset
        private void typeLSR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gen7 && (typeLSR.SelectedIndex == 4 || typeLSR.SelectedIndex == 5))
            {
                SetVisible(label8, true);
                SetVisible(sr_Species, true);
            }
            else
            {
                SetVisible(label8, false);
                SetVisible(sr_Species, false);
            }
        }

        // Update pokémon editing tabs 
        public void updateTabs()
        {
            species.SelectedIndexChanged -= species_SelectedIndexChanged;
            level.ValueChanged -= level_ValueChanged;
            nickname.TextChanged -= nickname_TextChanged;
            nickBox.CheckedChanged -= nickBox_CheckedChanged;
            pkLang.SelectedIndexChanged -= pkLang_SelectedIndexChanged;

            // Main tab
            SetSelectedIndex(species, dumpedPKHeX.Species - 1);
            SetText(nickname, dumpedPKHeX.Nickname);
            SetChecked(nickBox, dumpedPKHeX.IsNicknamed);
            SetSelectedIndex(nature, dumpedPKHeX.Nature);
            updateAbility(dumpedPKHeX.Species, dumpedPKHeX.AltForm, dumpedPKHeX.AbilityNumber);
            SetSelectedIndex(heldItem, dumpedPKHeX.HeldItem);
            SetSelectedIndex(ball, dumpedPKHeX.Ball - 1);
            SetText(dPID, dumpedPKHeX.PID.ToString("X8"));
            SetSelectedIndex(genderBox, dumpedPKHeX.Gender);
            SetChecked(isEgg, dumpedPKHeX.IsEgg);
            SetMaximum(ExpPoints, LookupTable.getExp(dumpedPKHeX.Species, 100));
            SetValue(ExpPoints, dumpedPKHeX.EXP);
            SetValue(friendship, dumpedPKHeX.CurrentFriendship);

            setSprite(dumpedPKHeX.Species, dumpedPKHeX.AltForm, dumpedPKHeX.IsEgg);
            setShinyMark();
            if (dumpedPKHeX.CurrentHandler == 0)
            {
                SetColor(friendship, Color.Cornsilk, true);
            }
            else
            {
                SetColor(friendship, Color.White, true);
            }

            // Stats tab
            SetValue(ivHPNum, dumpedPKHeX.IV_HP);
            SetValue(ivATKNum, dumpedPKHeX.IV_ATK);
            SetValue(ivDEFNum, dumpedPKHeX.IV_DEF);
            SetValue(ivSPANum, dumpedPKHeX.IV_SPA);
            SetValue(ivSPDNum, dumpedPKHeX.IV_SPD);
            SetValue(ivSPENum, dumpedPKHeX.IV_SPE);
            SetValue(evHPNum, dumpedPKHeX.EV_HP);
            SetValue(evATKNum, dumpedPKHeX.EV_ATK);
            SetValue(evDEFNum, dumpedPKHeX.EV_DEF);
            SetValue(evSPANum, dumpedPKHeX.EV_SPA);
            SetValue(evSPDNum, dumpedPKHeX.EV_SPD);
            SetValue(evSPENum, dumpedPKHeX.EV_SPE);
            if (gen7)
            {
                SetChecked(HypT_HP, dumpedPKHeX.HT_HP);
                SetChecked(HypT_Atk, dumpedPKHeX.HT_ATK);
                SetChecked(HypT_Def, dumpedPKHeX.HT_DEF);
                SetChecked(HypT_SpA, dumpedPKHeX.HT_SPA);
                SetChecked(HypT_SpD, dumpedPKHeX.HT_SPD);
                SetChecked(HypT_Spe, dumpedPKHeX.HT_SPE);
            }

            // Moves tab
            SetSelectedIndex(move1, dumpedPKHeX.Move1);
            SetSelectedIndex(move2, dumpedPKHeX.Move2);
            SetSelectedIndex(move3, dumpedPKHeX.Move3);
            SetSelectedIndex(move4, dumpedPKHeX.Move4);
            SetSelectedIndex(relearnmove1, dumpedPKHeX.RelearnMove1);
            SetSelectedIndex(relearnmove2, dumpedPKHeX.RelearnMove2);
            SetSelectedIndex(relearnmove3, dumpedPKHeX.RelearnMove3);
            SetSelectedIndex(relearnmove4, dumpedPKHeX.RelearnMove4);

            // Misc tab
            SetText(otName, dumpedPKHeX.OT_Name);
            SetValue(dTIDNum, dumpedPKHeX.TID);
            SetValue(dSIDNum, dumpedPKHeX.SID);
            int i;
            switch (dumpedPKHeX.Language)
            {
                case 1: i = 0; break;
                case 2: i = 1; break;
                case 3: i = 2; break;
                case 4: i = 3; break;
                case 5: i = 4; break;
                case 7: i = 5; break;
                case 8: i = 6; break;
                case 9: i = 7; break;
                case 10: i = 8; break;
                default: i = -1; break;
            }
            SetSelectedIndex(pkLang, i);

            species.SelectedIndexChanged += species_SelectedIndexChanged;
            level.ValueChanged += level_ValueChanged;
            nickname.TextChanged += nickname_TextChanged;
            nickBox.CheckedChanged += nickBox_CheckedChanged;
            pkLang.SelectedIndexChanged += pkLang_SelectedIndexChanged;
        }

        public void clearTabs()
        {
            species.SelectedIndexChanged -= species_SelectedIndexChanged;
            level.ValueChanged -= level_ValueChanged;
            nickname.TextChanged -= nickname_TextChanged;
            nickBox.CheckedChanged -= nickBox_CheckedChanged;
            pkLang.SelectedIndexChanged -= pkLang_SelectedIndexChanged;

            if (gen7)
            {
                dumpedPKHeX.Data = LookupTable.EmptyPoke7;
            }
            else
            {
                dumpedPKHeX.Data = LookupTable.EmptyPoke6;
            }

            // Main Tab
            SetSelectedIndex(species, -1);
            setSprite(-1, -1, false);
            SetText(nickname, null);
            SetChecked(nickBox, false);
            SetSelectedIndex(nature, -1);
            ComboboxFill(ability, null);
            SetSelectedIndex(ability, -1);
            SetSelectedIndex(heldItem, -1);
            SetSelectedIndex(ball, -1);
            SetText(dPID, "");
            SetSelectedIndex(genderBox, -1);
            SetChecked(isEgg, false);
            SetMaximum(ExpPoints, 1640000);
            SetValue(ExpPoints, 0);
            SetValue(friendship, 0);
            SetColor(friendship, Color.White, true);

            // Stats tab
            SetValue(ivHPNum, 0);
            SetValue(ivATKNum, 0);
            SetValue(ivDEFNum, 0);
            SetValue(ivSPANum, 0);
            SetValue(ivSPDNum, 0);
            SetValue(ivSPENum, 0);
            SetValue(evHPNum, 0);
            SetValue(evATKNum, 0);
            SetValue(evDEFNum, 0);
            SetValue(evSPANum, 0);
            SetValue(evSPDNum, 0);
            SetValue(evSPENum, 0);

            // Moves tab
            SetSelectedIndex(move1, -1);
            SetSelectedIndex(move2, -1);
            SetSelectedIndex(move3, -1);
            SetSelectedIndex(move4, -1);
            SetSelectedIndex(relearnmove1, -1);
            SetSelectedIndex(relearnmove2, -1);
            SetSelectedIndex(relearnmove3, -1);
            SetSelectedIndex(relearnmove4, -1);

            // Misc tab
            SetText(otName, "");
            SetValue(dTIDNum, 0);
            SetValue(dSIDNum, 0);
            SetSelectedIndex(pkLang, -1);

            species.SelectedIndexChanged += species_SelectedIndexChanged;
            level.ValueChanged += level_ValueChanged;
            nickname.TextChanged += nickname_TextChanged;
            nickBox.CheckedChanged += nickBox_CheckedChanged;
            pkLang.SelectedIndexChanged += pkLang_SelectedIndexChanged;
        }

        // PokeDigger
        private void PokeDiggerBtn_Click(object sender, EventArgs e)
        {
            new PokeDigger(pid, game != GameType.None).Show();
        }

        private void DumpInstructionsBtn_Click(object sender, EventArgs e)
        {
            if (radioOpponent.Checked)
            {
                new DumpOpponentHelp().Show();
            }
        }

        #endregion GUI handling

        #region Thread Safety

        public void addtoLog(string msg)
        {
            Program.gCmdWindow.BeginInvoke(Program.gCmdWindow.delAddLog, msg);
        }

        delegate void SetTextDelegate(Control ctrl, string text);

        public static void SetText(Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextDelegate del = new SetTextDelegate(SetText);
                ctrl.Invoke(del, ctrl, text);
            }
            else
                ctrl.Text = text;
        }

        delegate void SetReadOnlyDelegate(TextBox ctrl, bool en);

        public static void SetReadOnly(TextBox ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SetReadOnlyDelegate del = new SetReadOnlyDelegate(SetReadOnly);
                ctrl.Invoke(del, ctrl, en);
            }
            else
                ctrl.ReadOnly = en;
        }

        delegate void SetTooltipDelegate(ToolTip source, Control ctrl, string text);

        public static void SetTooltip(ToolTip source, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTooltipDelegate del = new SetTooltipDelegate(SetTooltip);
                ctrl.Invoke(del, source, ctrl, text);
            }
            else
                source.SetToolTip(ctrl, text);
        }

        delegate void RemoveTooltipDelegate(ToolTip source, Control ctrl);

        public static void RemoveTooltip(ToolTip source, Control ctrl)
        {
            if (ctrl.InvokeRequired)
            {
                RemoveTooltipDelegate del = new RemoveTooltipDelegate(RemoveTooltip);
                ctrl.Invoke(del, source, ctrl);
            }
            else
                source.RemoveAll();
        }

        delegate void SetEnabledDelegate(Control ctrl, bool en);

        public static void SetEnabled(Control ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SetEnabledDelegate del = new SetEnabledDelegate(SetEnabled);
                ctrl.Invoke(del, ctrl, en);
            }
            else
                ctrl.Enabled = en;
        }

        delegate void SeVisibleDelegate(Control ctrl, bool en);

        public static void SetVisible(Control ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SeVisibleDelegate del = new SeVisibleDelegate(SetVisible);
                ctrl.Invoke(del, ctrl, en);
            }
            else
                ctrl.Visible = en;
        }

        delegate void SetCheckedDelegate(CheckBox ctrl, bool en);

        public static void SetChecked(CheckBox ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SetCheckedDelegate del = new SetCheckedDelegate(SetChecked);
                ctrl.Invoke(del, ctrl, en);
            }
            else
                ctrl.Checked = en;
        }

        delegate void SetCheckedRadioDelegate(RadioButton ctrl, bool en);

        public static void SetCheckedRadio(RadioButton ctrl, bool en)
        {
            if (ctrl.InvokeRequired)
            {
                SetCheckedRadioDelegate del = new SetCheckedRadioDelegate(SetCheckedRadio);
                ctrl.Invoke(del, ctrl, en);
            }
            else
                ctrl.Checked = en;
        }

        delegate void SetValueDelegate(NumericUpDown ctrl, decimal val);

        public static void SetValue(NumericUpDown ctrl, decimal val)
        {
            if (ctrl.InvokeRequired)
            {
                SetValueDelegate del = new SetValueDelegate(SetValue);
                ctrl.Invoke(del, ctrl, val);
            }
            else
                ctrl.Value = val;
        }

        delegate void SetMaximumDelegate(NumericUpDown ctrl, decimal val);

        public static void SetMaximum(NumericUpDown ctrl, decimal val)
        {
            if (ctrl.InvokeRequired)
            {
                SetMaximumDelegate del = new SetMaximumDelegate(SetMaximum);
                ctrl.Invoke(del, ctrl, val);
            }
            else
                ctrl.Maximum = val;
        }

        delegate void SetMinimumDelegate(NumericUpDown ctrl, decimal val);

        public static void SetMinimum(NumericUpDown ctrl, decimal val)
        {
            if (ctrl.InvokeRequired)
            {
                SetMinimumDelegate del = new SetMinimumDelegate(SetMinimum);
                ctrl.Invoke(del, ctrl, val);
            }
            else
                ctrl.Minimum = val;
        }

        delegate void SetSelectedIndexDelegate(ComboBox ctrl, int i);

        public static void SetSelectedIndex(ComboBox ctrl, int i)
        {
            if (ctrl.InvokeRequired)
            {
                SetSelectedIndexDelegate del = new SetSelectedIndexDelegate(SetSelectedIndex);
                ctrl.Invoke(del, ctrl, i);
            }
            else
                ctrl.SelectedIndex = i;
        }

        delegate void ComboboxFillDelegate(ComboBox ctrl, string[] val);

        public static void ComboboxFill(ComboBox ctrl, string[] val)
        {
            if (ctrl.InvokeRequired)
            {
                ComboboxFillDelegate del = new ComboboxFillDelegate(ComboboxFill);
                ctrl.Invoke(del, ctrl, val);
            }
            else
            {
                ctrl.Items.Clear();
                if (val != null)
                {
                    ctrl.Items.AddRange(val);
                }
            }
        }

        delegate void DataGridViewAddRowDelegate(DataGridView ctrl, params object[] args);

        public static void DataGridViewAddRow(DataGridView ctrl, params object[] args)
        {
            if (ctrl.InvokeRequired)
            {
                DataGridViewAddRowDelegate del = new DataGridViewAddRowDelegate(DataGridViewAddRow);
                ctrl.Invoke(del, args);
            }
            else
            {
                ctrl.Rows.Add(args);
            }
        }

        delegate void SetColorDelegate(Control ctrl, Color c, bool back);

        public static void SetColor(Control ctrl, Color c, bool back)
        {
            if (ctrl.InvokeRequired)
            {
                SetColorDelegate del = new SetColorDelegate(SetColor);
                ctrl.Invoke(del, ctrl, c, back);
            }
            else
            {
                if (back)
                    ctrl.BackColor = c;
                else
                    ctrl.ForeColor = c;
            }
        }

        #endregion Thread Safety

        #region Remote control

        // Manual button presses
        private void sendButton(uint command)
        {
            Program.helper.quickbuton(command, 200);
        }

        private void manualA_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyA);
        }

        private void manualB_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyB);
        }

        private void manualX_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyX);
        }

        private void manualY_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyY);
        }

        private void manualDUp_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.DpadUP);
        }

        private void ManualDDown_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.DpadDOWN);
        }

        private void manualDLeft_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.DpadLEFT);
        }

        private void manualDRight_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.DpadRIGHT);
        }

        private void manualStart_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keySTART);
        }

        private void manualSelect_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keySELECT);
        }

        private void manualL_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyL);
        }

        private void manualR_Click(object sender, EventArgs e)
        {
            sendButton(LookupTable.keyR);
        }

        private async void manualSR_Click(object sender, EventArgs e)
        {
            DialogResult dialogr = MessageBox.Show("Are you sure that you want to send a soft-reset command? The application will automatically disconnect from the game afterwards.", "Remote Control", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogr == DialogResult.Yes)
            {
                sendButton(LookupTable.softReset);
                await Task.Delay(1000);
                PerformDisconnect();
            }
        }

        // Send manual touch command
        private void manualTouch_Click(object sender, EventArgs e)
        {
            Program.helper.quicktouch(touchX.Value, touchY.Value, 200);
        }

        // Send Control Stick command
        private void StickSend_Click(object sender, EventArgs e)
        {
            Program.helper.quickstick(StickX.Value, StickY.Value, 500);
        }

        #endregion Remote control

        #region Bots

        // General Bot functions
        private void stopBotButton_Click(object sender, EventArgs e)
        {
            switch (botnumber)
            {
                case 1: // Breeding bot
                    if (gen7)
                    {
                        BreedBot7.botstop = true;
                    }
                    else
                    {
                        BreedBot6.botstop = true;
                    }
                    break;
                case 2: // Soft-reset bot
                    if (gen7)
                    {
                        SRBot7.botstop = true;
                    }
                    else
                    {
                        SRBot6.botstop = true;
                    }
                    break;
                case 3: // Wonder Trade bot
                    if (gen7)
                    {
                        WTBot7.botstop = true;
                    }
                    else
                    {
                        WTBot6.botstop = true;
                    }
                    break;
            }
            addtoLog("Bot: Stopping bot, please wait");
            stopBotButton.Enabled = false;
            botStop = true;
        }

        public void HandleRAMread(uint value)
        {
            addtoLog("NTR: Read sucessful - 0x" + value.ToString("X8"));
            SetText(readResult, "0x" + value.ToString("X8"));
        }

        public void addwaitingForData(uint newkey, DataReadyWaiting newvalue)
        {
            waitingForData.Add(newkey, newvalue);
        }

        public void updateDumpBoxes(int box, int slot)
        {
            SetValue(boxDump, box + 1);
            SetValue(slotDump, slot + 1);
        }

        private void startBot()
        {
            botWorking = true;
            botStop = false;
            txtLog.Clear();
            disableControls();
            timer1.Interval = 500;
            SetEnabled(stopBotButton, true);
        }

        private void finishBot()
        {
            botWorking = false;
            botnumber = -1;
            enableControls();
            timer1.Interval = 1000;
            SetEnabled(stopBotButton, false);
        }

        // Filter handlers
        public bool FilterCheck(DataGridView filters)
        {
            if (filters.Rows.Count > 0)
            {
                currentfilter = 0;
                int failedtests = 0;
                int perfectIVs = 0;
                foreach (DataGridViewRow row in filters.Rows)
                {
                    currentfilter++;
                    addtoLog("Filter: Analyze pokémon using filter # " + currentfilter);
                    failedtests = 0;

                    // Test shiny
                    filterstr = " (PSV: " + getPSV(dumpedPKHeX.PID).ToString("D4") + " TSV: " + getTSV(TIDNum.Value, SIDNum.Value).ToString("D4") + ")";
                    if ((int)row.Cells[0].Value == 1)
                    {
                        if (dumpedPKHeX.isShiny)
                        {
                            addtoLog("Filter: Shiny - PASS" + filterstr);
                        }
                        else
                        {
                            addtoLog("Filter: Shiny - FAIL" + filterstr);
                            failedtests++;
                        }
                    }
                    else
                    {
                        addtoLog("Filter: Shiny - Don't care" + filterstr);
                    }

                    // Test nature
                    filterstr = " (" + LookupTable.getNature(dumpedPKHeX.Nature) + " -> " + LookupTable.getNature((int)row.Cells[1].Value) + ")";
                    if ((int)row.Cells[1].Value < 0 || dumpedPKHeX.Nature == (int)row.Cells[1].Value)
                    {
                        addtoLog("Filter: Nature - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Nature - FAIL" + filterstr);
                        failedtests++;
                    }

                    // Test Ability
                    if (gen7)
                    {
                        filterstr = " (" + LookupTable.getAbil7(dumpedPKHeX.Ability) + " -> " + LookupTable.getAbil7((int)row.Cells[2].Value) + ")";
                    }
                    else
                    {
                        filterstr = " (" + LookupTable.getAbil6(dumpedPKHeX.Ability) + " -> " + LookupTable.getAbil6((int)row.Cells[2].Value) + ")";
                    }
                    if ((int)row.Cells[2].Value < 0 || (dumpedPKHeX.Ability - 1) == (int)row.Cells[2].Value)
                    {
                        addtoLog("Filter: Ability - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Ability - FAIL" + filterstr);
                        failedtests++;
                    }

                    // Test Hidden Power
                    filterstr = " (" + LookupTable.getHPName(getHiddenPower()) + " -> " + LookupTable.getHPName((int)row.Cells[3].Value) + ")";
                    if ((int)row.Cells[3].Value < 0 || getHiddenPower() == (int)row.Cells[3].Value)
                    {
                        addtoLog("Filter: Hidden Power - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Hidden Power - FAIL" + filterstr);
                        failedtests++;
                    }

                    // Test Gender
                    filterstr = " (" + LookupTable.getGender(dumpedPKHeX.Gender) + " -> " + LookupTable.getGender((int)row.Cells[4].Value) + ")";
                    if ((int)row.Cells[4].Value < 0 || (int)row.Cells[4].Value == dumpedPKHeX.Gender)
                    {
                        addtoLog("Filter: Gender - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Gender - FAIL" + filterstr);
                        failedtests++;
                    }

                    // Test HP
                    if (IVCheck((int)row.Cells[5].Value, dumpedPKHeX.IV_HP, (int)row.Cells[6].Value))
                    {
                        addtoLog("Filter: Hit Points IV - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Hit Points IV - FAIL" + filterstr);
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_HP == 31)
                    {
                        perfectIVs++;
                    }

                    // Test Atk
                    if (IVCheck((int)row.Cells[7].Value, dumpedPKHeX.IV_ATK, (int)row.Cells[8].Value))
                    {
                        addtoLog("Filter: Attack IV - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Attack IV - FAIL" + filterstr);
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_ATK == 31)
                    {
                        perfectIVs++;
                    }

                    // Test Def
                    if (IVCheck((int)row.Cells[9].Value, dumpedPKHeX.IV_DEF, (int)row.Cells[10].Value))
                    {
                        addtoLog("Filter: Defense IV - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Defense IV - FAIL" + filterstr);
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_DEF == 31)
                    {
                        perfectIVs++;
                    }

                    // Test SpA
                    if (IVCheck((int)row.Cells[11].Value, dumpedPKHeX.IV_SPA, (int)row.Cells[12].Value))
                    {
                        addtoLog("Filter: Special Attack IV - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Special Attack IV - FAIL" + filterstr);
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_SPA == 31)
                    {
                        perfectIVs++;
                    }

                    // Test SpD
                    if (IVCheck((int)row.Cells[13].Value, dumpedPKHeX.IV_SPD, (int)row.Cells[14].Value))
                    {
                        addtoLog("Filter: Special Defense IV - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Special Defense IV - FAIL" + filterstr);
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_SPD == 31)
                    {
                        perfectIVs++;
                    }

                    // Test Spe
                    if (IVCheck((int)row.Cells[15].Value, dumpedPKHeX.IV_SPE, (int)row.Cells[16].Value))
                    {
                        addtoLog("Filter: Speed IV - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Speed IV - FAIL" + filterstr);
                        failedtests++;
                    }
                    if (dumpedPKHeX.IV_SPE == 31)
                    {
                        perfectIVs++;
                    }

                    // Test Perfect IVs
                    if (IVCheck((int)row.Cells[17].Value, perfectIVs, (int)row.Cells[18].Value))
                    {
                        addtoLog("Filter: Perfect IVs - PASS" + filterstr);
                    }
                    else
                    {
                        addtoLog("Filter: Perfect IVs - FAIL" + filterstr);
                        failedtests++;
                    }
                    if (failedtests == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IVCheck(int refiv, int actualiv, int logic)
        {
            switch (logic)
            {
                case 0: // Greater or equal
                    filterstr = " (" + actualiv + " >= " + refiv + ")";
                    if (actualiv >= refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 1: // Greater
                    filterstr = " (" + actualiv + " > " + refiv + ")";
                    if (actualiv > refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2: // Equal
                    filterstr = " (" + actualiv + " = " + refiv + ")";
                    if (actualiv == refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3: // Less
                    filterstr = " (" + actualiv + " < " + refiv + ")";
                    if (actualiv < refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 4: // Less or equal
                    filterstr = " (" + actualiv + " <= " + refiv + ")";
                    if (actualiv <= refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 5: // Different
                    filterstr = " (" + actualiv + " != " + refiv + ")";
                    if (actualiv != refiv)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 6: // Even
                    filterstr = " (" + actualiv + " -> Even)";
                    if (actualiv % 2 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 7: // Odd
                    filterstr = " (" + actualiv + " -> Odd)";
                    if (actualiv % 2 == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return true;
            }
        }

        private void filterAdd_Click(object sender, EventArgs e)
        {
            filterList.Rows.Add(filterShiny.Checked ? 1 : 0, Convert.ToInt32(filterNature.SelectedIndex), Convert.ToInt32(filterAbility.SelectedIndex), Convert.ToInt32(filterHPtype.SelectedIndex), Convert.ToInt32(filterGender.SelectedIndex), Convert.ToInt32(filterHPvalue.Value), Convert.ToInt32(filterHPlogic.SelectedIndex), Convert.ToInt32(filterATKvalue.Value), Convert.ToInt32(filterATKlogic.SelectedIndex), Convert.ToInt32(filterDEFvalue.Value), Convert.ToInt32(filterDEFlogic.SelectedIndex), Convert.ToInt32(filterSPAvalue.Value), Convert.ToInt32(filterSPAlogic.SelectedIndex), Convert.ToInt32(filterSPDvalue.Value), Convert.ToInt32(filterSPDlogic.SelectedIndex), Convert.ToInt32(filterSPEvalue.Value), Convert.ToInt32(filterSPElogic.SelectedIndex), Convert.ToInt32(filterPerIVvalue.Value), Convert.ToInt32(filterPerIVlogic.SelectedIndex));
        }

        private void filterRemove_Click(object sender, EventArgs e)
        {
            if (filterList.SelectedRows.Count > 0 && filterList.Rows.Count > 0)
            {
                filterList.Rows.RemoveAt(filterList.SelectedRows[0].Index);
            }
            else
                MessageBox.Show("There is no filter selected.");
        }

        private void filterRead_Click(object sender, EventArgs e)
        {
            if (filterList.SelectedRows.Count > 0)
            {
                if ((int)filterList.SelectedRows[0].Cells[0].Value == 1)
                {
                    SetChecked(filterShiny, true);
                }
                else
                {
                    SetChecked(filterShiny, false);
                }
                SetSelectedIndex(filterNature, (int)filterList.SelectedRows[0].Cells[1].Value);
                SetSelectedIndex(filterAbility, (int)filterList.SelectedRows[0].Cells[2].Value);
                SetSelectedIndex(filterHPtype, (int)filterList.SelectedRows[0].Cells[3].Value);
                SetSelectedIndex(filterGender, (int)filterList.SelectedRows[0].Cells[4].Value);
                SetValue(filterHPvalue, (int)filterList.SelectedRows[0].Cells[5].Value);
                SetSelectedIndex(filterHPlogic, (int)filterList.SelectedRows[0].Cells[6].Value);
                SetValue(filterATKvalue, (int)filterList.SelectedRows[0].Cells[7].Value);
                SetSelectedIndex(filterATKlogic, (int)filterList.SelectedRows[0].Cells[8].Value);
                SetValue(filterDEFvalue, (int)filterList.SelectedRows[0].Cells[9].Value);
                SetSelectedIndex(filterDEFlogic, (int)filterList.SelectedRows[0].Cells[10].Value);
                SetValue(filterSPAvalue, (int)filterList.SelectedRows[0].Cells[11].Value);
                SetSelectedIndex(filterSPAlogic, (int)filterList.SelectedRows[0].Cells[12].Value);
                SetValue(filterSPDvalue, (int)filterList.SelectedRows[0].Cells[13].Value);
                SetSelectedIndex(filterSPDlogic, (int)filterList.SelectedRows[0].Cells[14].Value);
                SetValue(filterSPEvalue, (int)filterList.SelectedRows[0].Cells[15].Value);
                SetSelectedIndex(filterSPElogic, (int)filterList.SelectedRows[0].Cells[16].Value);
                SetValue(filterPerIVvalue, (int)filterList.SelectedRows[0].Cells[17].Value);
                SetSelectedIndex(filterPerIVlogic, (int)filterList.SelectedRows[0].Cells[18].Value);
            }
            else
            {
                MessageBox.Show("There is no filter selected.");
            }
        }

        private void filterSave_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new FileInfo(folderPath)).Directory.Create();

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
                saveFileDialog1.Title = "Save a filter set";
                saveFileDialog1.InitialDirectory = folderPath;
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    var filters = new StringBuilder();
                    foreach (DataGridViewRow row in filterList.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        filters.AppendLine(string.Join(",", cells.Select(cell => cell.Value).ToArray()));
                    }
                    File.WriteAllText(saveFileDialog1.FileName, filters.ToString());
                    MessageBox.Show("Filter set saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void filterLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new FileInfo(folderPath)).Directory.Create();
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
                openFileDialog1.Title = "Select a filter set";
                openFileDialog1.InitialDirectory = folderPath;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    filterList.Rows.Clear();
                    List<int[]> rows = File.ReadAllLines(openFileDialog1.FileName).Select(s => s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();
                    foreach (int[] row in rows)
                    {
                        filterList.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15], row[16], row[17], row[18]);
                    }
                    MessageBox.Show("Filter set loaded");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void filterReset_Click(object sender, EventArgs e)
        {
            SetChecked(filterShiny, false);
            SetSelectedIndex(filterNature, -1);
            SetSelectedIndex(filterAbility, -1);
            SetSelectedIndex(filterHPtype, -1);
            SetSelectedIndex(filterGender, -1);
            SetSelectedIndex(filterHPlogic, 0);
            SetSelectedIndex(filterATKlogic, 0);
            SetSelectedIndex(filterDEFlogic, 0);
            SetSelectedIndex(filterSPAlogic, 0);
            SetSelectedIndex(filterSPDlogic, 0);
            SetSelectedIndex(filterSPElogic, 0);
            SetSelectedIndex(filterPerIVlogic, 0);
            SetValue(filterHPvalue, 0);
            SetValue(filterATKvalue, 0);
            SetValue(filterDEFvalue, 0);
            SetValue(filterSPAvalue, 0);
            SetValue(filterSPDvalue, 0);
            SetValue(filterSPEvalue, 0);
        }

        private void bFilterLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new FileInfo(folderPath)).Directory.Create();
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
                openFileDialog1.Title = "Select a filter set";
                openFileDialog1.InitialDirectory = folderPath;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    filterBreeding.Rows.Clear();
                    List<int[]> rows = File.ReadAllLines(openFileDialog1.FileName).Select(s => s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();
                    foreach (int[] row in rows)
                    {
                        filterBreeding.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15], row[16], row[17], row[18]);
                    }
                    MessageBox.Show("Filter Set loaded correctly.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void srFilterLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new FileInfo(folderPath)).Directory.Create();
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "PKMN-NTR Filter|*.pftr";
                openFileDialog1.Title = "Select a filter set";
                openFileDialog1.InitialDirectory = folderPath;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    filtersSoftReset.Rows.Clear();
                    List<int[]> rows = File.ReadAllLines(openFileDialog1.FileName).Select(s => s.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();
                    foreach (int[] row in rows)
                    {
                        filtersSoftReset.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12], row[13], row[14], row[15], row[16], row[17], row[18]);
                    }
                    MessageBox.Show("Filter set loaded correctly");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Wonder Trade bot
        private async void RunWTbot_Click_1(object sender, EventArgs e)
        {
            // Show warning
            DialogResult dialogResult = MessageBox.Show("This scirpt will try to Wonder Trade " + WTtradesNo.Value + " pokémon, starting from the slot " + WTSlot.Value + " of box " + WTBox.Value + ". Remember to read the wiki for this bot in GitHub before starting.\r\n\r\nDo you want to continue?", "Wonder Trade Bot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK && WTtradesNo.Value > 0)
            {
                startBot();
                botnumber = 3;
                radioBoxes.Checked = true;

                string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERWT + "\\";
                (new FileInfo(folderPath)).Directory.Create();

                int wtmode = 0;
                if (WTsource_Boxes.Checked)
                {
                    wtmode = 1;
                }
                else if (WTsource_Folder.Checked)
                {
                    wtmode = 2;
                }
                else if (WTsource_Random.Checked)
                {
                    wtmode = 3;
                }

                int wtafter = 0;
                if (WTafter_DoNothing.Checked)
                {
                    wtafter = 1;
                }
                else if (WTafter_Restore.Checked)
                {
                    wtafter = 2;
                }
                else if (WTafter_Delete.Checked)
                {
                    wtafter = 3;
                }

                Task<int> Bot;
                if (gen7)
                {
                    WTBot7 = new WonderTradeBot7((int)WTBox.Value, (int)WTSlot.Value, (int)WTtradesNo.Value, WTcollectFC.Checked, wtmode, WT_RunEndless.Checked, WTafter_Dump.Checked, wtafter);
                    Bot = WTBot7.RunBot();
                }
                else
                {
                    bool oras;
                    if (game == GameType.X || game == GameType.Y)
                    {
                        oras = false;
                    }
                    else
                    {
                        oras = true;
                    }
                    WTBot6 = new WonderTradeBot6((int)WTBox.Value, (int)WTSlot.Value, (int)WTtradesNo.Value, oras, wtmode, WT_RunEndless.Checked, wtafter, WTafter_Dump.Checked);
                    Bot = WTBot6.RunBot();
                }
                int result = await Bot;
                if (botStop)
                {
                    addtoLog("Bot: STOP Wonder Trade bot by user command");
                    result = 8;
                }
                switch (result)
                {
                    case 0: // General finish message
                        MessageBox.Show("Bot finished sucessfully", "Wonder Trade Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1: // PSS error
                        MessageBox.Show("Please go to the PSS menu and try again.", "Wonder Trade Bot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 2: // Read error
                        MessageBox.Show(readerror, "Wonder Trade Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 3: // Festival plaza level-up
                        MessageBox.Show("Bot finished due level up in Festival Plaza", "Wonder Trade Bot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 4: // Communication error
                        MessageBox.Show("A communication error has ocurred.", "Wonder Trade Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 6: // Touch screen error
                        MessageBox.Show(toucherror, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 7: // Button error
                        MessageBox.Show(buttonerror, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 8: // User stop
                        MessageBox.Show("Bot stopped by user", "Wonder Trade Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default: // General error message
                        MessageBox.Show("An error has occurred.", "Wonder Trade Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                finishBot();
            }
        }

        public void updateWTslots(int box, int slot, int quantity)
        {
            SetValue(WTBox, box + 1);
            SetValue(WTSlot, slot + 1);
            SetValue(WTtradesNo, quantity);
        }

        public void updateFCfields(uint totalFC, uint currentFC)
        {
            SetValue(milesNum, currentFC);
            SetValue(totalFCNum, totalFC);
        }

        private void WTsource_Folder_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERWT + "\\";
                (new FileInfo(folderPath)).Directory.Create();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Soft-reset bot
        private async void RunLSRbot_Click_1(object sender, EventArgs e)
        {
            string typemessage;
            string resumemessage;
            botWorking = true; // Supress warning messages
            if (gen7)
            {
                resumemessage = "No resume support for Gen 7";
                switch (typeLSR.SelectedIndex)
                {
                    case 0:
                        typemessage = "Event - Make sure you are in front of the man in the Pokémon Center. Also, you must only have one pokémon in your party.";
                        radioParty.Checked = true;
                        SetValue(boxDump, 1);
                        SetValue(slotDump, 2);
                        break;
                    case 1:
                        typemessage = "Type: Null - Make sure you are in front of Gladion at the Aether Paradise. Also, you must only have one pokémon in your party.\r\n\r\nThis mode can also be used for event pokémon.";
                        radioParty.Checked = true;
                        SetValue(boxDump, 1);
                        SetValue(slotDump, 2);
                        break;
                    case 2:
                        typemessage = "Tapus - Make sure you are in front of the statue at the ruins.";
                        radioOpponent.Checked = true;
                        SetValue(boxDump, 1);
                        SetValue(slotDump, 1);
                        break;
                    case 3:
                        typemessage = "Solgaleo/Lunala - Make sure you are in front of Solgaleo/Lunala at the Altar of the Sunne/Moone.";
                        radioOpponent.Checked = true;
                        SetValue(boxDump, 1);
                        SetValue(slotDump, 1);
                        break;
                    case 4:
                        typemessage = "Wild Pokémon - Make sure you are in the place where wild pokémon can appear. Also, check that Honey is the item at the top of your Item list and can be selected by just opening the menu and pressing A.";
                        radioOpponent.Checked = true;
                        SetValue(boxDump, 1);
                        SetValue(slotDump, 1);
                        break;
                    case 5:
                        typemessage = "Ultra Beast/Necrozma - Make sure you are in the place where the Ultra Beast / Necrozma appears. Also, check that Honey is the item at the top of your Item list and can be selected by just opening the menu and pressing A.";
                        radioOpponent.Checked = true;
                        SetValue(boxDump, 1);
                        SetValue(slotDump, 1);
                        break;
                    default:
                        typemessage = "No type - Select one type of soft-reset and try again.";
                        resumemessage = "";
                        break;
                }
            }
            else
            {
                switch (typeLSR.SelectedIndex)
                {
                    case 0:
                        typemessage = "Regular - Make sure you are in front of the pokémon.";
                        resumemessage = "In front of pokémon, will press A to trigger start the battle";
                        radioOpponent.Checked = true;
                        break;
                    case 1:
                        typemessage = "Mirage Spot - Make sure you are in front of the hole.";
                        resumemessage = "In front of hole, will press A to trigger dialog";
                        radioOpponent.Checked = true;
                        break;
                    case 2:
                        typemessage = "Event - Make sure you are in front of the lady in the Pokémon Center. Also, you must only have one pokémon in your party.";
                        resumemessage = "In front of the lady, will press A to trigger dialog";
                        radioParty.Checked = true;
                        SetValue(boxDump, 1);
                        SetValue(slotDump, 2);
                        break;
                    case 3:
                        typemessage = "Groudon/Kyogre - You must disable the PSS communications manually due PokéNav malfunction. Go in front of Groudon/Kyogre and save game before starting the battle.";
                        resumemessage = "In front of Groudon/Kyogre, will press A to trigger dialog";
                        radioOpponent.Checked = true;
                        break;
                    case 4:
                        typemessage = "Walk - Make sure you are one step south of the pokémon.";
                        resumemessage = "One step south of the pokémon, will press up to trigger dialog";
                        radioOpponent.Checked = true;
                        break;
                    case 5:
                        typemessage = "Dialga/Palkia/Giratina - Make sure you are anywhere in Dewford Town and the Eon Flute is the only registered item.";
                        resumemessage = "In Dewford Town, will press Y to activate the Eon Flute";
                        radioOpponent.Checked = true;
                        break;
                    case 6:
                        typemessage = "Tornadus/Thundurus/Landorus - Make sure you are anywhere in Route 120 and the Eon Flute is the only registered item.";
                        resumemessage = "In Dewford Town, will press Y to activate the Eon Flute";
                        radioOpponent.Checked = true;
                        break;
                    default:
                        typemessage = "No type - Select one type of soft-reset and try again.";
                        resumemessage = "";
                        break;
                }
            }
            botWorking = false;
            DialogResult dialogResult = MessageBox.Show("This bot will trigger an encounter with a pokémon, and soft-reset if it doesn't match with the loaded filters.\r\n\r\nType: " + typemessage + "\r\nResume: " + resumemessage + "\r\n\r\nPlease read the wiki at GitHub before using this bot. Do you want to continue?", "Soft-reset bot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.OK && typeLSR.SelectedIndex >= 0)
            {
                startBot();
                botnumber = 2;
                Task<int> Bot;
                if (gen7)
                {
                    SRBot7 = new SoftResetbot7(typeLSR.SelectedIndex, sr_Species.SelectedIndex);
                    Bot = SRBot7.RunBot();
                }
                else
                {
                    bool oras;
                    if (game == GameType.X || game == GameType.Y)
                    {
                        oras = false;
                        if (typeLSR.SelectedIndex == 3 || typeLSR.SelectedIndex == 5 || typeLSR.SelectedIndex == 6)
                        {
                            MessageBox.Show("This bot only works in ORAS", "Soft-reset Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            finishBot();
                            return;
                        }
                    }
                    else
                    {
                        oras = true;
                    }
                    SRBot6 = new SoftResetbot6(typeLSR.SelectedIndex, resumeLSR.Checked, oras);
                    Bot = SRBot6.RunBot();
                }
                int result = await Bot;
                if (botStop)
                {
                    addtoLog("Bot: STOP Soft-reset bot by user command");
                    result = 8;
                }
                int totalresets;
                if (gen7)
                {
                    totalresets = SRBot7.resetNo;
                }
                else
                {
                    totalresets = SRBot6.resetNo;
                }
                switch (result)
                {
                    case 0: // General finish message
                        MessageBox.Show("Bot finished sucessfully", "Soft-reset Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1: // PSS error
                        MessageBox.Show("Please go to the PSS menu and try again.", "Soft-reset Bot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 2: // Write error
                        MessageBox.Show(writeerror, "Soft-reset Bot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 3: // Read error
                        MessageBox.Show(readerror, "Soft-reset Bot", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case 4: // Finish
                        MessageBox.Show("Finished, number of resets: " + totalresets, "Soft-reset bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 6: // Touch screen error
                        MessageBox.Show(toucherror, "Soft-reset bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 7: // Button error
                        MessageBox.Show(buttonerror, "Soft-reset bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 8: // User stop
                        MessageBox.Show("Bot stopped by user", "Soft-reset bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default: // General error message
                        MessageBox.Show("An error has occurred.", "Soft-reset bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                finishBot();
            }
        }

        public async Task<long> ReadOpponent()
        {
            addtoLog("NTR: Read opponent pokémon data");
            SetText(dPID, "");
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x1FFFF], handleOpponentData, null);
            waitingForData.Add(Program.scriptHelper.data(0x8800000, 0x1FFFF, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 10; readcount++)
            {
                await Task.Delay(100);
                if (lastlog.Contains("finished"))
                {
                    break;
                }
            }
            if (readcount == timeout * 10)
            {
                addtoLog("NTR: Read failed");
                return -2; // No data received
            }
            for (readcount = 0; readcount < 10; readcount++)
            {
                await Task.Delay(100);
                if (dPID.Text.Length > 1)
                {
                    break;
                }
            }
            if (readcount == 10)
            {
                addtoLog("NTR: Read failed");
                return -2; // No data received
            }
            else if (dumpedPKHeX.Species != 0)
            {
                addtoLog("NTR: Read sucessful - PID 0x" + dumpedPKHeX.PID.ToString("X8"));
                return dumpedPKHeX.PID;
            }
            else // Empty slot
            {
                addtoLog("NTR: Empty pokémon data");
                return -1;
            }
        }

        public async Task<bool> Reconnect()
        {
            addtoLog("NTR: Reconnect");
            Program.scriptHelper.connect(host.Text, 8000);
            int waittimeout;
            for (waittimeout = 0; waittimeout < timeout * 10; waittimeout++)
            {
                await Task.Delay(500);
                if (lastlog.Contains("end of process list"))
                {
                    break;
                }
            }
            if (waittimeout < timeout * 10)
            {
                addtoLog("NTR: Reconnect sucessful");
                return true;
            }
            else
            {
                addtoLog("NTR: Reconnect failed");
                return false;
            }
        }

        public bool CheckSoftResetFilters()
        {
            return FilterCheck(filtersSoftReset);
        }

        private void srClear_Click(object sender, EventArgs e)
        {
            SetSelectedIndex(typeLSR, -1);
            SetChecked(resumeLSR, false);
            filtersSoftReset.Rows.Clear();
        }

        // Breeding bot
        private async void runBreedingBot_Click_1(object sender, EventArgs e)
        {
            string modemessage;
            switch (modeBreed.SelectedIndex)
            {
                case 0:
                    modemessage = "Simple: This bot will produce " + eggsNoBreed.Value.ToString() + " eggs and deposit them in the pc, starting at box " + boxBreed.Value.ToString() + " slot " + slotBreed.Value.ToString() + ".\r\n\r\n";
                    break;
                case 1:
                    modemessage = "Filter: This bot will produce eggs and deposit them in the pc, starting at box " + boxBreed.Value.ToString() + " slot " + slotBreed.Value.ToString() + ". Then it will check against the selected filters and if it finds a match the bot will stop. The bot will also stop if it produces " + eggsNoBreed.Value.ToString() + " eggs before finding a match.\r\n\r\n";
                    break;
                case 2:
                    modemessage = "ESV/TSV: This bot will produce eggs and deposit them in the pc, starting at box " + boxBreed.Value.ToString() + " slot " + slotBreed.Value.ToString() + ". Then it will check the egg's ESV and if it finds a match with the values in the TSV list, the bot will stop. The bot will also stop if it produces " + eggsNoBreed.Value.ToString() + " eggs before finding a match.\r\n\r\n";
                    break;
                case 3:
                    modemessage = "Accept/Reject: This bot will talk to the Nursery Lady and accept " + boxBreed.Value + " eggs, then it will reject " + slotBreed.Value + " eggs and stop.\r\n\r\n";
                    break;
                default:
                    modemessage = "No mode selected. Select one and try again.\r\n\r\n";
                    break;
            }

            DialogResult dialogResult;
            if (gen7)
            {
                dialogResult = MessageBox.Show("This bot will start producing eggs from the day care using the following rules:\r\n\r\n" + modemessage + "Make sure that your party is full. Please read the Wiki at Github before starting. Do you want to continue?", "Breeding bot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                dialogResult = MessageBox.Show("This bot will start producing eggs from the day care using the following rules:\r\n\r\n" + modemessage + "Make sure that you only have one pokémon in your party. Please read the Wiki at Github before starting. Do you want to continue?", "Breeding bot", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            if (dialogResult == DialogResult.OK && eggsNoBreed.Value > 0 && modeBreed.SelectedIndex >= 0)
            {
                startBot();
                botnumber = 1;
                radioBoxes.Checked = true;
                Task<int> Bot;
                if (gen7)
                {
                    BreedBot7 = new BreedingBot7(modeBreed.SelectedIndex, (int)boxBreed.Value, (int)slotBreed.Value, (int)eggsNoBreed.Value, readESV.Checked);
                    Bot = BreedBot7.RunBot();
                }
                else
                {
                    bool oras;
                    if (game == GameType.X || game == GameType.Y)
                    {
                        oras = false;
                    }
                    else
                    {
                        oras = true;
                    }
                    BreedBot6 = new BreedingBot6(modeBreed.SelectedIndex, (int)boxBreed.Value, (int)slotBreed.Value, (int)eggsNoBreed.Value, OrganizeTop.Checked, radioDayCare1.Checked, readESV.Checked, quickBreed.Checked, oras);
                    Bot = BreedBot6.RunBot();
                }
                int result = await Bot;
                if (botStop)
                {
                    addtoLog("Bot: STOP Breeding bot by user command");
                    result = 8;
                }
                switch (await Bot)
                {
                    case 0: // Finished
                        MessageBox.Show("Bot finished sucessfully", "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1: // Write error
                        MessageBox.Show(writeerror, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2: // Read error
                        MessageBox.Show(readerror, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 3: // Finish with no matches
                        MessageBox.Show("Finished. Maximum number of eggs reached without a match.", "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 4: // Filter mode sucessful
                        if (gen7)
                            MessageBox.Show(BreedBot7.finishmessage + currentfilter, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(BreedBot6.finishmessage + currentfilter, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 5: // ESV/TSV mode sucessful
                        if (gen7)
                            MessageBox.Show(BreedBot7.finishmessage, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(BreedBot6.finishmessage, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 6: // Touch screen error
                        MessageBox.Show(toucherror, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 7: // Button error
                        MessageBox.Show(buttonerror, "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 8: // User stop
                        MessageBox.Show("Bot stopped by user", "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default: // General error
                        MessageBox.Show("An error has occurred.", "Breeding Bot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                finishBot();
            }
        }

        public void updateBreedingslots(int box, int slot, int quantity)
        {
            SetValue(boxBreed, box + 1);
            SetValue(slotBreed, slot + 1);
            SetValue(eggsNoBreed, quantity);
        }

        public void AddESVrow(int row, int slot, int tsv)
        {
            DataGridViewAddRow(ESVlist, row + 1, slot + 1, tsv.ToString("D4"));
        }

        public bool CheckBreedingFilters()
        {
            return FilterCheck(filterBreeding);
        }

        private void ESVlistSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ESVlist.Rows.Count > 0)
                {
                    string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERBOT + "\\";
                    (new FileInfo(folderPath)).Directory.Create();
                    string fileName = "ESVlist.csv";
                    var esvlst = new StringBuilder();
                    var headers = ESVlist.Columns.Cast<DataGridViewColumn>();
                    esvlst.AppendLine(string.Join(",", headers.Select(column => column.HeaderText).ToArray()));
                    foreach (DataGridViewRow row in ESVlist.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        esvlst.AppendLine(string.Join(",", cells.Select(cell => cell.Value).ToArray()));
                    }
                    File.WriteAllText(folderPath + fileName, esvlst.ToString());
                    MessageBox.Show("ESV list saved");
                }
                else
                {
                    MessageBox.Show("There are no eggs on the ESV list");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TSVlistAdd_Click(object sender, EventArgs e)
        {
            TSVlist.Items.Add(((int)TSVlistNum.Value).ToString("D4"));
        }

        private void TSVlistRemove_Click(object sender, EventArgs e)
        {
            if (TSVlist.SelectedIndices.Count > 0)
            {
                TSVlist.Items.RemoveAt(TSVlist.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("No TSV selected for remove");
            }
        }

        private void TSVlistSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (TSVlist.Items.Count > 0)
                {
                    string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERBOT + "\\";
                    (new FileInfo(folderPath)).Directory.Create();
                    string fileName;
                    if (gen7)
                    {
                        fileName = "TSVlist.csv";
                    }
                    else
                    {
                        fileName = "TSVlist7.csv";
                    }
                    var tsvlst = new StringBuilder();
                    foreach (var value in TSVlist.Items)
                    {
                        tsvlst.AppendLine(value.ToString());
                    }
                    File.WriteAllText(folderPath + fileName, tsvlst.ToString());
                    MessageBox.Show("TSV list saved");
                }
                else
                {
                    MessageBox.Show("There are no numbers on the TSV list");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TSVlistLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = System.Windows.Forms.@Application.StartupPath + "\\" + FOLDERBOT + "\\";
                (new FileInfo(folderPath)).Directory.Create();
                string fileName;
                if (gen7)
                {
                    fileName = "TSVlist.csv";
                }
                else
                {
                    fileName = "TSVlist7.csv";
                }
                if (File.Exists(folderPath + fileName))
                {
                    string[] values = File.ReadAllLines(folderPath + fileName);
                    TSVlist.Items.Clear();
                    TSVlist.Items.AddRange(values);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ESV_TSV_check(int esv)
        {
            if (TSVlist.Items.Count > 0)
            {
                addtoLog("Filter: Checking egg with ESV: " + esv);
                foreach (var tsv in TSVlist.Items)
                {
                    if (Convert.ToInt32(tsv) == esv)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        private void breedingClear_Click(object sender, EventArgs e)
        {
            SetSelectedIndex(modeBreed, -1);
            SetValue(boxBreed, 1);
            SetValue(slotBreed, 1);
            SetValue(eggsNoBreed, 1);
            OrganizeMiddle.Checked = true;
            radioDayCare1.Checked = true;
            SetChecked(readESV, false);
            SetChecked(quickBreed, false);
            ESVlist.Rows.Clear();
            TSVlist.Items.Clear();
            filterBreeding.Rows.Clear();
        }

        private void modeBreed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gen7 && modeBreed.SelectedIndex == 3)
            {
                SetText(Breed_labelBox, "Acc:");
                SetText(Breed_labelSlot, "Rej:");
                SetEnabled(slotBreed, true);
                SetMaximum(boxBreed, 999);
                SetMaximum(slotBreed, 999);
                SetMinimum(boxBreed, 0);
                SetMinimum(slotBreed, 0);
                SetEnabled(eggsNoBreed, false);
            }
            else
            {
                SetText(Breed_labelBox, "Box:");
                SetText(Breed_labelSlot, "Slot:");
                SetEnabled(slotBreed, false);
                SetMaximum(boxBreed, 30);
                SetMaximum(slotBreed, BOXES);
                SetMinimum(boxBreed, 1);
                SetMinimum(slotBreed, 1);
                SetEnabled(eggsNoBreed, true);
            }
        }

        #endregion Bots

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