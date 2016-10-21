namespace ntrbase
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.disconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.host = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.versionCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.moneyNum = new System.Windows.Forms.NumericUpDown();
            this.milesNum = new System.Windows.Forms.NumericUpDown();
            this.bpNum = new System.Windows.Forms.NumericUpDown();
            this.pokeMoney = new System.Windows.Forms.Button();
            this.pokeMiles = new System.Windows.Forms.Button();
            this.pokeBP = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dumpBox = new System.Windows.Forms.GroupBox();
            this.radioBattleBox = new System.Windows.Forms.RadioButton();
            this.onlyView = new System.Windows.Forms.CheckBox();
            this.radioParty = new System.Windows.Forms.RadioButton();
            this.radioTrade = new System.Windows.Forms.RadioButton();
            this.radioOpponent = new System.Windows.Forms.RadioButton();
            this.radioDaycare = new System.Windows.Forms.RadioButton();
            this.radioBoxes = new System.Windows.Forms.RadioButton();
            this.dumpBoxes = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nameek6 = new System.Windows.Forms.TextBox();
            this.dumpPokemon = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.slotDump = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.boxDump = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label44 = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.move4 = new System.Windows.Forms.ComboBox();
            this.ability = new System.Windows.Forms.ComboBox();
            this.move3 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.move2 = new System.Windows.Forms.ComboBox();
            this.species = new System.Windows.Forms.ComboBox();
            this.move1 = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.evSPENum = new System.Windows.Forms.NumericUpDown();
            this.evSPDNum = new System.Windows.Forms.NumericUpDown();
            this.heldItem = new System.Windows.Forms.ComboBox();
            this.evSPANum = new System.Windows.Forms.NumericUpDown();
            this.evDEFNum = new System.Windows.Forms.NumericUpDown();
            this.evATKNum = new System.Windows.Forms.NumericUpDown();
            this.evHPNum = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.isEgg = new System.Windows.Forms.CheckBox();
            this.ivSPENum = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.ivSPDNum = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.ivSPANum = new System.Windows.Forms.NumericUpDown();
            this.nature = new System.Windows.Forms.ComboBox();
            this.ivDEFNum = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.ivATKNum = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.ivHPNum = new System.Windows.Forms.NumericUpDown();
            this.hiddenPower = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.Lang = new System.Windows.Forms.ComboBox();
            this.pokeLang = new System.Windows.Forms.Button();
            this.pokeSID = new System.Windows.Forms.Button();
            this.SIDNum = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pokeTID = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.TIDNum = new System.Windows.Forms.NumericUpDown();
            this.secNum = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.minNum = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.pokeTime = new System.Windows.Forms.Button();
            this.pokeName = new System.Windows.Forms.Button();
            this.hourNum = new System.Windows.Forms.NumericUpDown();
            this.playerName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.showKeys = new System.Windows.Forms.Button();
            this.showBerries = new System.Windows.Forms.Button();
            this.showTMs = new System.Windows.Forms.Button();
            this.showMedicine = new System.Windows.Forms.Button();
            this.showItems = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.itemAdd = new System.Windows.Forms.Button();
            this.itemWrite = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.deleteAmount = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.delPkm = new System.Windows.Forms.Button();
            this.deleteBox = new System.Windows.Forms.NumericUpDown();
            this.deleteSlot = new System.Windows.Forms.NumericUpDown();
            this.dTIDNum = new System.Windows.Forms.NumericUpDown();
            this.dSIDNum = new System.Windows.Forms.NumericUpDown();
            this.dPID = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.otName = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.setShiny = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.friendship = new System.Windows.Forms.NumericUpDown();
            this.gender = new System.Windows.Forms.Button();
            this.randomPID = new System.Windows.Forms.Button();
            this.DumpedEdit = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.label56 = new System.Windows.Forms.Label();
            this.ExpPoints = new System.Windows.Forms.NumericUpDown();
            this.Stats = new System.Windows.Forms.TabPage();
            this.Moves = new System.Windows.Forms.TabPage();
            this.OT = new System.Windows.Forms.TabPage();
            this.level = new System.Windows.Forms.NumericUpDown();
            this.cloneWriteTabs = new System.Windows.Forms.TabControl();
            this.cloneTab = new System.Windows.Forms.TabPage();
            this.cloneDoIt = new System.Windows.Forms.Button();
            this.cloneSlotFrom = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.cloneBoxFrom = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.cloneCopiesNo = new System.Windows.Forms.NumericUpDown();
            this.label36 = new System.Windows.Forms.Label();
            this.cloneSlotTo = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.cloneBoxTo = new System.Windows.Forms.NumericUpDown();
            this.writeTab = new System.Windows.Forms.TabPage();
            this.writeDoIt = new System.Windows.Forms.Button();
            this.writeBrowse = new System.Windows.Forms.Button();
            this.writeAutoInc = new System.Windows.Forms.CheckBox();
            this.writeCopiesNo = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.writeSlotTo = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.writeBoxTo = new System.Windows.Forms.NumericUpDown();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.deleteKeepBackup = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.touchX = new System.Windows.Forms.NumericUpDown();
            this.touchY = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.LegendarySoftResetBot = new System.Windows.Forms.TabPage();
            this.label70 = new System.Windows.Forms.Label();
            this.HPTypeLSR = new System.Windows.Forms.ComboBox();
            this.shinyLSR = new System.Windows.Forms.CheckBox();
            this.ivHPLSR = new System.Windows.Forms.NumericUpDown();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.ivSpeLSR = new System.Windows.Forms.NumericUpDown();
            this.RunLSRbot = new System.Windows.Forms.Button();
            this.ivSpDLSR = new System.Windows.Forms.NumericUpDown();
            this.natureLSR = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.ivDefLSR = new System.Windows.Forms.NumericUpDown();
            this.ivSpALSR = new System.Windows.Forms.NumericUpDown();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.ivAtkLSR = new System.Windows.Forms.NumericUpDown();
            this.label66 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.WonderTradeBot = new System.Windows.Forms.TabPage();
            this.label59 = new System.Windows.Forms.Label();
            this.RunWTbot = new System.Windows.Forms.Button();
            this.WTtradesNo = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.WTBox = new System.Windows.Forms.NumericUpDown();
            this.WTSlot = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.RemonteControls = new System.Windows.Forms.TabPage();
            this.manualDLeft = new System.Windows.Forms.Button();
            this.manualTouch = new System.Windows.Forms.Button();
            this.manualX = new System.Windows.Forms.Button();
            this.manualY = new System.Windows.Forms.Button();
            this.touchCoord = new System.Windows.Forms.TextBox();
            this.manualDUp = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.manualL = new System.Windows.Forms.Button();
            this.manualB = new System.Windows.Forms.Button();
            this.manualA = new System.Windows.Forms.Button();
            this.manualR = new System.Windows.Forms.Button();
            this.manualSelect = new System.Windows.Forms.Button();
            this.manualDRight = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.ManualDDown = new System.Windows.Forms.Button();
            this.manualStart = new System.Windows.Forms.Button();
            this.BotTab = new System.Windows.Forms.TabControl();
            this.label69 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.milesNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpNum)).BeginInit();
            this.dumpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotDump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPENum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPANum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evDEFNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evATKNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evHPNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSPENum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSPDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSPANum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivDEFNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivATKNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivHPNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deleteAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendship)).BeginInit();
            this.DumpedEdit.SuspendLayout();
            this.Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpPoints)).BeginInit();
            this.Stats.SuspendLayout();
            this.Moves.SuspendLayout();
            this.OT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.level)).BeginInit();
            this.cloneWriteTabs.SuspendLayout();
            this.cloneTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cloneSlotFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneBoxFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneCopiesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneSlotTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneBoxTo)).BeginInit();
            this.writeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writeCopiesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeSlotTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeBoxTo)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touchX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.touchY)).BeginInit();
            this.LegendarySoftResetBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivHPLSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSpeLSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSpDLSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivDefLSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSpALSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivAtkLSR)).BeginInit();
            this.WonderTradeBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTtradesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTSlot)).BeginInit();
            this.RemonteControls.SuspendLayout();
            this.BotTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLog.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtLog.Location = new System.Drawing.Point(305, 344);
            this.txtLog.MaxLength = 32767000;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(314, 95);
            this.txtLog.TabIndex = 0;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // disconnectTimer
            // 
            this.disconnectTimer.Interval = 10000;
            this.disconnectTimer.Tick += new System.EventHandler(this.disconnectTimer_Tick);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(6, 47);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(67, 21);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(79, 47);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(69, 21);
            this.buttonDisconnect.TabIndex = 4;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // host
            // 
            this.host.Location = new System.Drawing.Point(29, 19);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(119, 20);
            this.host.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.versionCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonDisconnect);
            this.groupBox1.Controls.Add(this.host);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Location = new System.Drawing.Point(7, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // versionCheck
            // 
            this.versionCheck.ForeColor = System.Drawing.Color.Green;
            this.versionCheck.Location = new System.Drawing.Point(6, 69);
            this.versionCheck.Name = "versionCheck";
            this.versionCheck.Size = new System.Drawing.Size(142, 23);
            this.versionCheck.TabIndex = 44;
            this.versionCheck.Text = "Update Available";
            this.versionCheck.UseVisualStyleBackColor = true;
            this.versionCheck.Visible = false;
            this.versionCheck.Click += new System.EventHandler(this.versionCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP:";
            // 
            // moneyNum
            // 
            this.moneyNum.Location = new System.Drawing.Point(140, 36);
            this.moneyNum.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.moneyNum.Name = "moneyNum";
            this.moneyNum.Size = new System.Drawing.Size(71, 20);
            this.moneyNum.TabIndex = 7;
            // 
            // milesNum
            // 
            this.milesNum.Location = new System.Drawing.Point(140, 84);
            this.milesNum.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.milesNum.Name = "milesNum";
            this.milesNum.Size = new System.Drawing.Size(71, 20);
            this.milesNum.TabIndex = 8;
            // 
            // bpNum
            // 
            this.bpNum.Location = new System.Drawing.Point(140, 130);
            this.bpNum.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.bpNum.Name = "bpNum";
            this.bpNum.Size = new System.Drawing.Size(71, 20);
            this.bpNum.TabIndex = 9;
            // 
            // pokeMoney
            // 
            this.pokeMoney.Location = new System.Drawing.Point(217, 33);
            this.pokeMoney.Name = "pokeMoney";
            this.pokeMoney.Size = new System.Drawing.Size(45, 23);
            this.pokeMoney.TabIndex = 10;
            this.pokeMoney.Text = "Write";
            this.pokeMoney.UseVisualStyleBackColor = true;
            this.pokeMoney.Click += new System.EventHandler(this.pokeMoney_Click);
            // 
            // pokeMiles
            // 
            this.pokeMiles.Location = new System.Drawing.Point(217, 81);
            this.pokeMiles.Name = "pokeMiles";
            this.pokeMiles.Size = new System.Drawing.Size(45, 23);
            this.pokeMiles.TabIndex = 11;
            this.pokeMiles.Text = "Write";
            this.pokeMiles.UseVisualStyleBackColor = true;
            this.pokeMiles.Click += new System.EventHandler(this.pokeMiles_Click);
            // 
            // pokeBP
            // 
            this.pokeBP.Location = new System.Drawing.Point(217, 127);
            this.pokeBP.Name = "pokeBP";
            this.pokeBP.Size = new System.Drawing.Size(45, 23);
            this.pokeBP.TabIndex = 12;
            this.pokeBP.Text = "Write BP";
            this.pokeBP.UseVisualStyleBackColor = true;
            this.pokeBP.Click += new System.EventHandler(this.pokeBP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Money:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Poké Miles:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Battle Points:";
            // 
            // dumpBox
            // 
            this.dumpBox.Controls.Add(this.radioBattleBox);
            this.dumpBox.Controls.Add(this.onlyView);
            this.dumpBox.Controls.Add(this.radioParty);
            this.dumpBox.Controls.Add(this.radioTrade);
            this.dumpBox.Controls.Add(this.radioOpponent);
            this.dumpBox.Controls.Add(this.radioDaycare);
            this.dumpBox.Controls.Add(this.radioBoxes);
            this.dumpBox.Controls.Add(this.dumpBoxes);
            this.dumpBox.Controls.Add(this.label9);
            this.dumpBox.Controls.Add(this.nameek6);
            this.dumpBox.Controls.Add(this.dumpPokemon);
            this.dumpBox.Controls.Add(this.label7);
            this.dumpBox.Controls.Add(this.slotDump);
            this.dumpBox.Controls.Add(this.label8);
            this.dumpBox.Controls.Add(this.boxDump);
            this.dumpBox.Location = new System.Drawing.Point(7, 5);
            this.dumpBox.Name = "dumpBox";
            this.dumpBox.Size = new System.Drawing.Size(265, 131);
            this.dumpBox.TabIndex = 20;
            this.dumpBox.TabStop = false;
            this.dumpBox.Text = "Dump and Edit Pokémon";
            // 
            // radioBattleBox
            // 
            this.radioBattleBox.AutoSize = true;
            this.radioBattleBox.Location = new System.Drawing.Point(139, 87);
            this.radioBattleBox.Name = "radioBattleBox";
            this.radioBattleBox.Size = new System.Drawing.Size(73, 17);
            this.radioBattleBox.TabIndex = 99;
            this.radioBattleBox.Text = "Battle Box";
            this.radioBattleBox.UseVisualStyleBackColor = true;
            this.radioBattleBox.CheckedChanged += new System.EventHandler(this.radioBattleBox_CheckedChanged);
            // 
            // onlyView
            // 
            this.onlyView.AutoSize = true;
            this.onlyView.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.onlyView.Location = new System.Drawing.Point(192, 108);
            this.onlyView.Name = "onlyView";
            this.onlyView.Size = new System.Drawing.Size(67, 17);
            this.onlyView.TabIndex = 96;
            this.onlyView.Text = "Only edit";
            this.toolTip1.SetToolTip(this.onlyView, "If checked, Pokemon won\'t be dumped to file");
            this.onlyView.UseVisualStyleBackColor = true;
            this.onlyView.CheckedChanged += new System.EventHandler(this.onlyView_CheckedChanged);
            // 
            // radioParty
            // 
            this.radioParty.AutoSize = true;
            this.radioParty.Location = new System.Drawing.Point(139, 105);
            this.radioParty.Name = "radioParty";
            this.radioParty.Size = new System.Drawing.Size(49, 17);
            this.radioParty.TabIndex = 94;
            this.radioParty.Text = "Party";
            this.radioParty.UseVisualStyleBackColor = true;
            this.radioParty.Visible = false;
            this.radioParty.CheckedChanged += new System.EventHandler(this.radioParty_CheckedChanged_1);
            // 
            // radioTrade
            // 
            this.radioTrade.AutoSize = true;
            this.radioTrade.Location = new System.Drawing.Point(7, 105);
            this.radioTrade.Name = "radioTrade";
            this.radioTrade.Size = new System.Drawing.Size(53, 17);
            this.radioTrade.TabIndex = 43;
            this.radioTrade.TabStop = true;
            this.radioTrade.Text = "Trade";
            this.radioTrade.UseVisualStyleBackColor = true;
            this.radioTrade.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioOpponent
            // 
            this.radioOpponent.AutoSize = true;
            this.radioOpponent.Location = new System.Drawing.Point(68, 105);
            this.radioOpponent.Name = "radioOpponent";
            this.radioOpponent.Size = new System.Drawing.Size(72, 17);
            this.radioOpponent.TabIndex = 34;
            this.radioOpponent.TabStop = true;
            this.radioOpponent.Text = "Opponent";
            this.radioOpponent.UseVisualStyleBackColor = true;
            this.radioOpponent.CheckedChanged += new System.EventHandler(this.radioOpponent_CheckedChanged);
            // 
            // radioDaycare
            // 
            this.radioDaycare.AutoSize = true;
            this.radioDaycare.Location = new System.Drawing.Point(68, 87);
            this.radioDaycare.Name = "radioDaycare";
            this.radioDaycare.Size = new System.Drawing.Size(65, 17);
            this.radioDaycare.TabIndex = 33;
            this.radioDaycare.Text = "Daycare";
            this.radioDaycare.UseVisualStyleBackColor = true;
            this.radioDaycare.CheckedChanged += new System.EventHandler(this.radioDaycare_CheckedChanged);
            // 
            // radioBoxes
            // 
            this.radioBoxes.AutoSize = true;
            this.radioBoxes.Checked = true;
            this.radioBoxes.Location = new System.Drawing.Point(7, 87);
            this.radioBoxes.Name = "radioBoxes";
            this.radioBoxes.Size = new System.Drawing.Size(54, 17);
            this.radioBoxes.TabIndex = 32;
            this.radioBoxes.TabStop = true;
            this.radioBoxes.Text = "Boxes";
            this.radioBoxes.UseVisualStyleBackColor = true;
            this.radioBoxes.CheckedChanged += new System.EventHandler(this.radioBoxes_CheckedChanged);
            // 
            // dumpBoxes
            // 
            this.dumpBoxes.Location = new System.Drawing.Point(99, 61);
            this.dumpBoxes.Name = "dumpBoxes";
            this.dumpBoxes.Size = new System.Drawing.Size(105, 23);
            this.dumpBoxes.TabIndex = 31;
            this.dumpBoxes.Text = "Dump All Boxes";
            this.dumpBoxes.UseVisualStyleBackColor = true;
            this.dumpBoxes.Click += new System.EventHandler(this.dumpBoxes_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Filename:";
            // 
            // nameek6
            // 
            this.nameek6.Location = new System.Drawing.Point(100, 39);
            this.nameek6.Name = "nameek6";
            this.nameek6.Size = new System.Drawing.Size(103, 20);
            this.nameek6.TabIndex = 29;
            this.nameek6.Text = "pkmn";
            // 
            // dumpPokemon
            // 
            this.dumpPokemon.Location = new System.Drawing.Point(7, 61);
            this.dumpPokemon.Name = "dumpPokemon";
            this.dumpPokemon.Size = new System.Drawing.Size(86, 23);
            this.dumpPokemon.TabIndex = 28;
            this.dumpPokemon.Text = "Dump";
            this.dumpPokemon.UseVisualStyleBackColor = true;
            this.dumpPokemon.Click += new System.EventHandler(this.dumpPokemon_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Slot:";
            // 
            // slotDump
            // 
            this.slotDump.Location = new System.Drawing.Point(53, 39);
            this.slotDump.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.slotDump.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.slotDump.Name = "slotDump";
            this.slotDump.Size = new System.Drawing.Size(40, 20);
            this.slotDump.TabIndex = 25;
            this.slotDump.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Box:";
            // 
            // boxDump
            // 
            this.boxDump.Location = new System.Drawing.Point(7, 39);
            this.boxDump.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.boxDump.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.boxDump.Name = "boxDump";
            this.boxDump.Size = new System.Drawing.Size(40, 20);
            this.boxDump.TabIndex = 24;
            this.boxDump.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(146, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 21);
            this.pictureBox1.TabIndex = 93;
            this.pictureBox1.TabStop = false;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(32, 140);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(27, 13);
            this.label44.TabIndex = 92;
            this.label44.Text = "Ball:";
            // 
            // ball
            // 
            this.ball.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ball.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ball.FormattingEnabled = true;
            this.ball.Items.AddRange(new object[] {
            "Master Ball",
            "Ultra Ball",
            "Great Ball",
            "Poke Ball",
            "Safari Ball",
            "Net Ball",
            "Dive Ball",
            "Nest Ball",
            "Repeat Ball",
            "Timer Ball",
            "Luxury Ball",
            "Premier Ball",
            "Dusk Ball",
            "Heal Ball",
            "Quick Ball",
            "Cherish Ball",
            "Fast Ball",
            "Level Ball",
            "Lure Ball",
            "Heavy Ball",
            "Love Ball",
            "Friend Ball",
            "Moon Ball",
            "Sport Ball",
            "Dream Ball"});
            this.ball.Location = new System.Drawing.Point(59, 135);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(81, 21);
            this.ball.TabIndex = 44;
            this.ball.SelectedIndexChanged += new System.EventHandler(this.ball_SelectedIndexChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(8, 114);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(46, 13);
            this.label42.TabIndex = 91;
            this.label42.Text = "Move 4:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(7, 78);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(46, 13);
            this.label43.TabIndex = 90;
            this.label43.Text = "Move 3:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(8, 42);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(46, 13);
            this.label41.TabIndex = 89;
            this.label41.Text = "Move 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Move 1:";
            // 
            // move4
            // 
            this.move4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.move4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.move4.FormattingEnabled = true;
            this.move4.Location = new System.Drawing.Point(6, 128);
            this.move4.Name = "move4";
            this.move4.Size = new System.Drawing.Size(120, 21);
            this.move4.TabIndex = 87;
            // 
            // ability
            // 
            this.ability.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ability.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ability.FormattingEnabled = true;
            this.ability.Location = new System.Drawing.Point(59, 85);
            this.ability.Name = "ability";
            this.ability.Size = new System.Drawing.Size(81, 21);
            this.ability.TabIndex = 68;
            // 
            // move3
            // 
            this.move3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.move3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.move3.FormattingEnabled = true;
            this.move3.Location = new System.Drawing.Point(6, 92);
            this.move3.Name = "move3";
            this.move3.Size = new System.Drawing.Size(120, 21);
            this.move3.TabIndex = 86;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "Write";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.pokeEkx_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "EVs";
            // 
            // move2
            // 
            this.move2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.move2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.move2.FormattingEnabled = true;
            this.move2.Location = new System.Drawing.Point(6, 56);
            this.move2.Name = "move2";
            this.move2.Size = new System.Drawing.Size(120, 21);
            this.move2.TabIndex = 85;
            // 
            // species
            // 
            this.species.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.species.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.species.FormattingEnabled = true;
            this.species.Location = new System.Drawing.Point(59, 11);
            this.species.Name = "species";
            this.species.Size = new System.Drawing.Size(81, 21);
            this.species.TabIndex = 44;
            // 
            // move1
            // 
            this.move1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.move1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.move1.FormattingEnabled = true;
            this.move1.Location = new System.Drawing.Point(6, 19);
            this.move1.Name = "move1";
            this.move1.Size = new System.Drawing.Size(120, 21);
            this.move1.TabIndex = 84;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(11, 15);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(48, 13);
            this.label32.TabIndex = 43;
            this.label32.Text = "Species:";
            // 
            // evSPENum
            // 
            this.evSPENum.Location = new System.Drawing.Point(72, 128);
            this.evSPENum.Maximum = new decimal(new int[] {
            252,
            0,
            0,
            0});
            this.evSPENum.Name = "evSPENum";
            this.evSPENum.Size = new System.Drawing.Size(38, 20);
            this.evSPENum.TabIndex = 82;
            // 
            // evSPDNum
            // 
            this.evSPDNum.Location = new System.Drawing.Point(72, 107);
            this.evSPDNum.Maximum = new decimal(new int[] {
            252,
            0,
            0,
            0});
            this.evSPDNum.Name = "evSPDNum";
            this.evSPDNum.Size = new System.Drawing.Size(38, 20);
            this.evSPDNum.TabIndex = 81;
            // 
            // heldItem
            // 
            this.heldItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.heldItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.heldItem.FormattingEnabled = true;
            this.heldItem.Location = new System.Drawing.Point(59, 110);
            this.heldItem.Name = "heldItem";
            this.heldItem.Size = new System.Drawing.Size(81, 21);
            this.heldItem.TabIndex = 43;
            // 
            // evSPANum
            // 
            this.evSPANum.Location = new System.Drawing.Point(72, 86);
            this.evSPANum.Maximum = new decimal(new int[] {
            252,
            0,
            0,
            0});
            this.evSPANum.Name = "evSPANum";
            this.evSPANum.Size = new System.Drawing.Size(38, 20);
            this.evSPANum.TabIndex = 80;
            // 
            // evDEFNum
            // 
            this.evDEFNum.Location = new System.Drawing.Point(72, 65);
            this.evDEFNum.Maximum = new decimal(new int[] {
            252,
            0,
            0,
            0});
            this.evDEFNum.Name = "evDEFNum";
            this.evDEFNum.Size = new System.Drawing.Size(38, 20);
            this.evDEFNum.TabIndex = 79;
            // 
            // evATKNum
            // 
            this.evATKNum.Location = new System.Drawing.Point(72, 44);
            this.evATKNum.Maximum = new decimal(new int[] {
            252,
            0,
            0,
            0});
            this.evATKNum.Name = "evATKNum";
            this.evATKNum.Size = new System.Drawing.Size(38, 20);
            this.evATKNum.TabIndex = 78;
            // 
            // evHPNum
            // 
            this.evHPNum.Location = new System.Drawing.Point(72, 23);
            this.evHPNum.Maximum = new decimal(new int[] {
            252,
            0,
            0,
            0});
            this.evHPNum.Name = "evHPNum";
            this.evHPNum.Size = new System.Drawing.Size(38, 20);
            this.evHPNum.TabIndex = 77;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(244, 40);
            this.label31.Margin = new System.Windows.Forms.Padding(0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(26, 13);
            this.label31.TabIndex = 76;
            this.label31.Text = "Egg";
            // 
            // isEgg
            // 
            this.isEgg.AutoSize = true;
            this.isEgg.Location = new System.Drawing.Point(266, 40);
            this.isEgg.Name = "isEgg";
            this.isEgg.Size = new System.Drawing.Size(15, 14);
            this.isEgg.TabIndex = 74;
            this.isEgg.UseVisualStyleBackColor = true;
            // 
            // ivSPENum
            // 
            this.ivSPENum.Location = new System.Drawing.Point(33, 128);
            this.ivSPENum.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivSPENum.Name = "ivSPENum";
            this.ivSPENum.Size = new System.Drawing.Size(33, 20);
            this.ivSPENum.TabIndex = 73;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(17, 64);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 13);
            this.label23.TabIndex = 59;
            this.label23.Text = "Nature:";
            // 
            // ivSPDNum
            // 
            this.ivSPDNum.Location = new System.Drawing.Point(33, 107);
            this.ivSPDNum.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivSPDNum.Name = "ivSPDNum";
            this.ivSPDNum.Size = new System.Drawing.Size(33, 20);
            this.ivSPDNum.TabIndex = 72;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(29, 115);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(30, 13);
            this.label24.TabIndex = 61;
            this.label24.Text = "Item:";
            // 
            // ivSPANum
            // 
            this.ivSPANum.Location = new System.Drawing.Point(33, 86);
            this.ivSPANum.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivSPANum.Name = "ivSPANum";
            this.ivSPANum.Size = new System.Drawing.Size(33, 20);
            this.ivSPANum.TabIndex = 71;
            // 
            // nature
            // 
            this.nature.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.nature.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nature.FormattingEnabled = true;
            this.nature.Items.AddRange(new object[] {
            "Hardy",
            "Lonely",
            "Brave",
            "Adamant",
            "Naughty",
            "Bold",
            "Docile",
            "Relaxed",
            "Impish",
            "Lax",
            "Timid",
            "Hasty",
            "Serious",
            "Jolly",
            "Naive",
            "Modest",
            "Mild",
            "Quiet",
            "Bashful",
            "Rash",
            "Calm",
            "Gentle",
            "Sassy",
            "Careful",
            "Quirky"});
            this.nature.Location = new System.Drawing.Point(59, 60);
            this.nature.Name = "nature";
            this.nature.Size = new System.Drawing.Size(81, 21);
            this.nature.TabIndex = 67;
            // 
            // ivDEFNum
            // 
            this.ivDEFNum.Location = new System.Drawing.Point(33, 65);
            this.ivDEFNum.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivDEFNum.Name = "ivDEFNum";
            this.ivDEFNum.Size = new System.Drawing.Size(33, 20);
            this.ivDEFNum.TabIndex = 70;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(22, 90);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 13);
            this.label25.TabIndex = 63;
            this.label25.Text = "Ability:";
            // 
            // ivATKNum
            // 
            this.ivATKNum.Location = new System.Drawing.Point(33, 44);
            this.ivATKNum.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivATKNum.Name = "ivATKNum";
            this.ivATKNum.Size = new System.Drawing.Size(33, 20);
            this.ivATKNum.TabIndex = 69;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(1, 40);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(58, 13);
            this.label30.TabIndex = 66;
            this.label30.Text = "Nickname:";
            // 
            // ivHPNum
            // 
            this.ivHPNum.Location = new System.Drawing.Point(33, 23);
            this.ivHPNum.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivHPNum.Name = "ivHPNum";
            this.ivHPNum.Size = new System.Drawing.Size(33, 20);
            this.ivHPNum.TabIndex = 68;
            // 
            // hiddenPower
            // 
            this.hiddenPower.BackColor = System.Drawing.SystemColors.Control;
            this.hiddenPower.Location = new System.Drawing.Point(177, 22);
            this.hiddenPower.Name = "hiddenPower";
            this.hiddenPower.ReadOnly = true;
            this.hiddenPower.Size = new System.Drawing.Size(50, 20);
            this.hiddenPower.TabIndex = 64;
            this.hiddenPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(125, 26);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(52, 13);
            this.label29.TabIndex = 65;
            this.label29.Text = "HP Type:";
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(59, 36);
            this.nickname.MaxLength = 12;
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(81, 20);
            this.nickname.TabIndex = 46;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(2, 132);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 13);
            this.label22.TabIndex = 58;
            this.label22.Text = "SPE:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 13);
            this.label21.TabIndex = 57;
            this.label21.Text = "SPD:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(37, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "IVs";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 54;
            this.label18.Text = "ATK:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(2, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 56;
            this.label20.Text = "SPA:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 53;
            this.label17.Text = "HP:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(2, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 55;
            this.label19.Text = "DEF:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(191, 177);
            this.dataGridView1.TabIndex = 32;
            // 
            // Item
            // 
            this.Item.Name = "Item";
            // 
            // Amount
            // 
            this.Amount.Name = "Amount";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pokeMiles);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.pokeBP);
            this.groupBox2.Controls.Add(this.milesNum);
            this.groupBox2.Controls.Add(this.bpNum);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.moneyNum);
            this.groupBox2.Controls.Add(this.Lang);
            this.groupBox2.Controls.Add(this.pokeMoney);
            this.groupBox2.Controls.Add(this.pokeLang);
            this.groupBox2.Controls.Add(this.pokeSID);
            this.groupBox2.Controls.Add(this.SIDNum);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.pokeTID);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.TIDNum);
            this.groupBox2.Controls.Add(this.secNum);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.minNum);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.pokeTime);
            this.groupBox2.Controls.Add(this.pokeName);
            this.groupBox2.Controls.Add(this.hourNum);
            this.groupBox2.Controls.Add(this.playerName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(629, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 246);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit Trainer";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 158);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 13);
            this.label28.TabIndex = 44;
            this.label28.Text = "Language:";
            // 
            // Lang
            // 
            this.Lang.FormattingEnabled = true;
            this.Lang.Items.AddRange(new object[] {
            "JPN",
            "ENG",
            "FRE",
            "ITA",
            "GER",
            "SPA",
            "KOR"});
            this.Lang.Location = new System.Drawing.Point(9, 175);
            this.Lang.Name = "Lang";
            this.Lang.Size = new System.Drawing.Size(49, 21);
            this.Lang.TabIndex = 43;
            // 
            // pokeLang
            // 
            this.pokeLang.Location = new System.Drawing.Point(59, 174);
            this.pokeLang.Name = "pokeLang";
            this.pokeLang.Size = new System.Drawing.Size(45, 23);
            this.pokeLang.TabIndex = 42;
            this.pokeLang.Text = "Write";
            this.pokeLang.UseVisualStyleBackColor = true;
            this.pokeLang.Click += new System.EventHandler(this.pokeLang_Click);
            // 
            // pokeSID
            // 
            this.pokeSID.Location = new System.Drawing.Point(90, 127);
            this.pokeSID.Name = "pokeSID";
            this.pokeSID.Size = new System.Drawing.Size(45, 23);
            this.pokeSID.TabIndex = 40;
            this.pokeSID.Text = "Write";
            this.pokeSID.UseVisualStyleBackColor = true;
            this.pokeSID.Click += new System.EventHandler(this.pokeSID_Click);
            // 
            // SIDNum
            // 
            this.SIDNum.Location = new System.Drawing.Point(9, 130);
            this.SIDNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SIDNum.Name = "SIDNum";
            this.SIDNum.Size = new System.Drawing.Size(80, 20);
            this.SIDNum.TabIndex = 39;
            this.SIDNum.ValueChanged += new System.EventHandler(this.SIDNum_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "SID:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(113, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Secs:";
            // 
            // pokeTID
            // 
            this.pokeTID.Location = new System.Drawing.Point(90, 79);
            this.pokeTID.Name = "pokeTID";
            this.pokeTID.Size = new System.Drawing.Size(45, 23);
            this.pokeTID.TabIndex = 30;
            this.pokeTID.Text = "Write";
            this.pokeTID.UseVisualStyleBackColor = true;
            this.pokeTID.Click += new System.EventHandler(this.pokeTID_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(71, 199);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Mins:";
            // 
            // TIDNum
            // 
            this.TIDNum.Location = new System.Drawing.Point(9, 82);
            this.TIDNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.TIDNum.Name = "TIDNum";
            this.TIDNum.Size = new System.Drawing.Size(80, 20);
            this.TIDNum.TabIndex = 29;
            this.TIDNum.ValueChanged += new System.EventHandler(this.TIDNum_ValueChanged);
            // 
            // secNum
            // 
            this.secNum.Location = new System.Drawing.Point(114, 215);
            this.secNum.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secNum.Name = "secNum";
            this.secNum.Size = new System.Drawing.Size(35, 20);
            this.secNum.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "TID:";
            // 
            // minNum
            // 
            this.minNum.Location = new System.Drawing.Point(73, 215);
            this.minNum.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minNum.Name = "minNum";
            this.minNum.Size = new System.Drawing.Size(35, 20);
            this.minNum.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Name:";
            // 
            // pokeTime
            // 
            this.pokeTime.Location = new System.Drawing.Point(150, 212);
            this.pokeTime.Name = "pokeTime";
            this.pokeTime.Size = new System.Drawing.Size(45, 23);
            this.pokeTime.TabIndex = 33;
            this.pokeTime.Text = "Write";
            this.pokeTime.UseVisualStyleBackColor = true;
            this.pokeTime.Click += new System.EventHandler(this.pokeTime_Click);
            // 
            // pokeName
            // 
            this.pokeName.Location = new System.Drawing.Point(89, 33);
            this.pokeName.Name = "pokeName";
            this.pokeName.Size = new System.Drawing.Size(45, 23);
            this.pokeName.TabIndex = 23;
            this.pokeName.Text = "Write";
            this.pokeName.UseVisualStyleBackColor = true;
            this.pokeName.Click += new System.EventHandler(this.pokeName_Click);
            // 
            // hourNum
            // 
            this.hourNum.Location = new System.Drawing.Point(8, 215);
            this.hourNum.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.hourNum.Name = "hourNum";
            this.hourNum.Size = new System.Drawing.Size(59, 20);
            this.hourNum.TabIndex = 32;
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(8, 35);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(80, 20);
            this.playerName.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Hours:";
            // 
            // showKeys
            // 
            this.showKeys.Location = new System.Drawing.Point(199, 134);
            this.showKeys.Name = "showKeys";
            this.showKeys.Size = new System.Drawing.Size(115, 26);
            this.showKeys.TabIndex = 33;
            this.showKeys.Text = "KEY ITEMS";
            this.showKeys.UseVisualStyleBackColor = true;
            this.showKeys.Click += new System.EventHandler(this.showKeys_Click);
            // 
            // showBerries
            // 
            this.showBerries.Location = new System.Drawing.Point(199, 105);
            this.showBerries.Name = "showBerries";
            this.showBerries.Size = new System.Drawing.Size(115, 26);
            this.showBerries.TabIndex = 34;
            this.showBerries.Text = "BERRIES";
            this.showBerries.UseVisualStyleBackColor = true;
            this.showBerries.Click += new System.EventHandler(this.showBerries_Click);
            // 
            // showTMs
            // 
            this.showTMs.Location = new System.Drawing.Point(199, 76);
            this.showTMs.Name = "showTMs";
            this.showTMs.Size = new System.Drawing.Size(115, 26);
            this.showTMs.TabIndex = 35;
            this.showTMs.Text = "TMs && HMs";
            this.showTMs.UseVisualStyleBackColor = true;
            this.showTMs.Click += new System.EventHandler(this.showTMs_Click);
            // 
            // showMedicine
            // 
            this.showMedicine.Location = new System.Drawing.Point(199, 47);
            this.showMedicine.Name = "showMedicine";
            this.showMedicine.Size = new System.Drawing.Size(115, 26);
            this.showMedicine.TabIndex = 36;
            this.showMedicine.Text = "MEDICINE";
            this.showMedicine.UseVisualStyleBackColor = true;
            this.showMedicine.Click += new System.EventHandler(this.showMedicine_Click);
            // 
            // showItems
            // 
            this.showItems.ForeColor = System.Drawing.Color.Green;
            this.showItems.Location = new System.Drawing.Point(199, 18);
            this.showItems.Name = "showItems";
            this.showItems.Size = new System.Drawing.Size(115, 26);
            this.showItems.TabIndex = 37;
            this.showItems.Text = "ITEMS";
            this.showItems.UseVisualStyleBackColor = true;
            this.showItems.Click += new System.EventHandler(this.showItems_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Enabled = false;
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.ShowEditingIcon = false;
            this.dataGridView2.Size = new System.Drawing.Size(191, 177);
            this.dataGridView2.TabIndex = 38;
            this.dataGridView2.Visible = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Enabled = false;
            this.dataGridView3.Location = new System.Drawing.Point(6, 19);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.ShowEditingIcon = false;
            this.dataGridView3.Size = new System.Drawing.Size(191, 177);
            this.dataGridView3.TabIndex = 39;
            this.dataGridView3.Visible = false;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AllowUserToResizeColumns = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Enabled = false;
            this.dataGridView4.Location = new System.Drawing.Point(6, 19);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.ShowEditingIcon = false;
            this.dataGridView4.Size = new System.Drawing.Size(191, 177);
            this.dataGridView4.TabIndex = 40;
            this.dataGridView4.Visible = false;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.AllowUserToResizeColumns = false;
            this.dataGridView5.AllowUserToResizeRows = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Enabled = false;
            this.dataGridView5.Location = new System.Drawing.Point(6, 19);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.ShowEditingIcon = false;
            this.dataGridView5.Size = new System.Drawing.Size(191, 177);
            this.dataGridView5.TabIndex = 41;
            this.dataGridView5.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView5);
            this.groupBox3.Controls.Add(this.itemAdd);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.dataGridView4);
            this.groupBox3.Controls.Add(this.showKeys);
            this.groupBox3.Controls.Add(this.itemWrite);
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Controls.Add(this.showBerries);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Controls.Add(this.showTMs);
            this.groupBox3.Controls.Add(this.showItems);
            this.groupBox3.Controls.Add(this.showMedicine);
            this.groupBox3.Location = new System.Drawing.Point(305, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 201);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Edit Items";
            // 
            // itemAdd
            // 
            this.itemAdd.Location = new System.Drawing.Point(257, 173);
            this.itemAdd.Name = "itemAdd";
            this.itemAdd.Size = new System.Drawing.Size(57, 23);
            this.itemAdd.TabIndex = 46;
            this.itemAdd.Text = "Add Item";
            this.itemAdd.UseVisualStyleBackColor = true;
            this.itemAdd.Click += new System.EventHandler(this.itemAdd_Click);
            // 
            // itemWrite
            // 
            this.itemWrite.Location = new System.Drawing.Point(199, 173);
            this.itemWrite.Name = "itemWrite";
            this.itemWrite.Size = new System.Drawing.Size(57, 23);
            this.itemWrite.TabIndex = 43;
            this.itemWrite.Text = "Write";
            this.itemWrite.UseVisualStyleBackColor = true;
            this.itemWrite.Click += new System.EventHandler(this.itemWrite_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(180, 7);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(61, 13);
            this.label38.TabIndex = 25;
            this.label38.Text = "# to delete:";
            // 
            // deleteAmount
            // 
            this.deleteAmount.Enabled = false;
            this.deleteAmount.Location = new System.Drawing.Point(242, 5);
            this.deleteAmount.Maximum = new decimal(new int[] {
            930,
            0,
            0,
            0});
            this.deleteAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteAmount.Name = "deleteAmount";
            this.deleteAmount.Size = new System.Drawing.Size(50, 20);
            this.deleteAmount.TabIndex = 24;
            this.deleteAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(93, 7);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(25, 13);
            this.label26.TabIndex = 23;
            this.label26.Text = "Slot";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(25, 13);
            this.label27.TabIndex = 22;
            this.label27.Text = "Box";
            // 
            // delPkm
            // 
            this.delPkm.Enabled = false;
            this.delPkm.ForeColor = System.Drawing.Color.Red;
            this.delPkm.Location = new System.Drawing.Point(228, 66);
            this.delPkm.Name = "delPkm";
            this.delPkm.Size = new System.Drawing.Size(75, 23);
            this.delPkm.TabIndex = 17;
            this.delPkm.Text = "Delete";
            this.delPkm.UseVisualStyleBackColor = true;
            this.delPkm.Click += new System.EventHandler(this.delPkm_Click);
            // 
            // deleteBox
            // 
            this.deleteBox.Enabled = false;
            this.deleteBox.Location = new System.Drawing.Point(37, 5);
            this.deleteBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.deleteBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteBox.Name = "deleteBox";
            this.deleteBox.Size = new System.Drawing.Size(50, 20);
            this.deleteBox.TabIndex = 18;
            this.deleteBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteBox.ValueChanged += new System.EventHandler(this.deleteBox_ValueChanged);
            // 
            // deleteSlot
            // 
            this.deleteSlot.Enabled = false;
            this.deleteSlot.Location = new System.Drawing.Point(124, 5);
            this.deleteSlot.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.deleteSlot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteSlot.Name = "deleteSlot";
            this.deleteSlot.Size = new System.Drawing.Size(50, 20);
            this.deleteSlot.TabIndex = 19;
            this.deleteSlot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deleteSlot.ValueChanged += new System.EventHandler(this.deleteSlot_ValueChanged);
            // 
            // dTIDNum
            // 
            this.dTIDNum.Location = new System.Drawing.Point(44, 36);
            this.dTIDNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.dTIDNum.Name = "dTIDNum";
            this.dTIDNum.Size = new System.Drawing.Size(58, 20);
            this.dTIDNum.TabIndex = 44;
            this.dTIDNum.ValueChanged += new System.EventHandler(this.dTIDNum_ValueChanged);
            // 
            // dSIDNum
            // 
            this.dSIDNum.Location = new System.Drawing.Point(44, 62);
            this.dSIDNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.dSIDNum.Name = "dSIDNum";
            this.dSIDNum.Size = new System.Drawing.Size(58, 20);
            this.dSIDNum.TabIndex = 45;
            this.dSIDNum.ValueChanged += new System.EventHandler(this.dSIDNum_ValueChanged);
            // 
            // dPID
            // 
            this.dPID.Location = new System.Drawing.Point(201, 11);
            this.dPID.Name = "dPID";
            this.dPID.Size = new System.Drawing.Size(58, 20);
            this.dPID.TabIndex = 47;
            this.dPID.TextChanged += new System.EventHandler(this.dPID_TextChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(171, 14);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(28, 13);
            this.label45.TabIndex = 49;
            this.label45.Text = "PID:";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(15, 40);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(28, 13);
            this.label47.TabIndex = 51;
            this.label47.Text = "TID:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(15, 66);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(28, 13);
            this.label48.TabIndex = 52;
            this.label48.Text = "SID:";
            // 
            // otName
            // 
            this.otName.Location = new System.Drawing.Point(44, 10);
            this.otName.MaxLength = 12;
            this.otName.Name = "otName";
            this.otName.Size = new System.Drawing.Size(81, 20);
            this.otName.TabIndex = 53;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(5, 13);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(38, 13);
            this.label46.TabIndex = 54;
            this.label46.Text = "Name:";
            // 
            // setShiny
            // 
            this.setShiny.Location = new System.Drawing.Point(146, 10);
            this.setShiny.Name = "setShiny";
            this.setShiny.Size = new System.Drawing.Size(22, 22);
            this.setShiny.TabIndex = 55;
            this.setShiny.Text = "☆";
            this.setShiny.UseVisualStyleBackColor = true;
            this.setShiny.Click += new System.EventHandler(this.setShiny_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(142, 40);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(58, 13);
            this.label51.TabIndex = 99;
            this.label51.Text = "Friendship:";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(155, 64);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(45, 13);
            this.label49.TabIndex = 101;
            this.label49.Text = "Gender:";
            // 
            // friendship
            // 
            this.friendship.Location = new System.Drawing.Point(201, 36);
            this.friendship.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.friendship.Name = "friendship";
            this.friendship.Size = new System.Drawing.Size(43, 20);
            this.friendship.TabIndex = 97;
            // 
            // gender
            // 
            this.gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gender.ForeColor = System.Drawing.Color.Gray;
            this.gender.Location = new System.Drawing.Point(201, 60);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(22, 22);
            this.gender.TabIndex = 100;
            this.gender.Text = "-";
            this.gender.UseVisualStyleBackColor = true;
            this.gender.Click += new System.EventHandler(this.gender_Click);
            // 
            // randomPID
            // 
            this.randomPID.Location = new System.Drawing.Point(259, 10);
            this.randomPID.Name = "randomPID";
            this.randomPID.Size = new System.Drawing.Size(22, 22);
            this.randomPID.TabIndex = 98;
            this.randomPID.Text = "?";
            this.randomPID.UseVisualStyleBackColor = true;
            this.randomPID.Click += new System.EventHandler(this.randomPID_Click);
            // 
            // DumpedEdit
            // 
            this.DumpedEdit.Controls.Add(this.Main);
            this.DumpedEdit.Controls.Add(this.Stats);
            this.DumpedEdit.Controls.Add(this.Moves);
            this.DumpedEdit.Controls.Add(this.OT);
            this.DumpedEdit.Location = new System.Drawing.Point(7, 139);
            this.DumpedEdit.Multiline = true;
            this.DumpedEdit.Name = "DumpedEdit";
            this.DumpedEdit.SelectedIndex = 0;
            this.DumpedEdit.Size = new System.Drawing.Size(292, 186);
            this.DumpedEdit.TabIndex = 57;
            // 
            // Main
            // 
            this.Main.BackColor = System.Drawing.SystemColors.Control;
            this.Main.Controls.Add(this.label56);
            this.Main.Controls.Add(this.button1);
            this.Main.Controls.Add(this.label49);
            this.Main.Controls.Add(this.ExpPoints);
            this.Main.Controls.Add(this.isEgg);
            this.Main.Controls.Add(this.label31);
            this.Main.Controls.Add(this.label51);
            this.Main.Controls.Add(this.gender);
            this.Main.Controls.Add(this.nickname);
            this.Main.Controls.Add(this.label32);
            this.Main.Controls.Add(this.friendship);
            this.Main.Controls.Add(this.species);
            this.Main.Controls.Add(this.label30);
            this.Main.Controls.Add(this.setShiny);
            this.Main.Controls.Add(this.ability);
            this.Main.Controls.Add(this.label23);
            this.Main.Controls.Add(this.pictureBox1);
            this.Main.Controls.Add(this.randomPID);
            this.Main.Controls.Add(this.nature);
            this.Main.Controls.Add(this.label25);
            this.Main.Controls.Add(this.dPID);
            this.Main.Controls.Add(this.label45);
            this.Main.Controls.Add(this.heldItem);
            this.Main.Controls.Add(this.label24);
            this.Main.Controls.Add(this.label44);
            this.Main.Controls.Add(this.ball);
            this.Main.Location = new System.Drawing.Point(4, 22);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(3);
            this.Main.Size = new System.Drawing.Size(284, 160);
            this.Main.TabIndex = 2;
            this.Main.Text = "Main";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(169, 88);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(31, 13);
            this.label56.TabIndex = 102;
            this.label56.Text = "EXP:";
            // 
            // ExpPoints
            // 
            this.ExpPoints.Location = new System.Drawing.Point(201, 85);
            this.ExpPoints.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.ExpPoints.Name = "ExpPoints";
            this.ExpPoints.Size = new System.Drawing.Size(77, 20);
            this.ExpPoints.TabIndex = 58;
            // 
            // Stats
            // 
            this.Stats.BackColor = System.Drawing.SystemColors.Control;
            this.Stats.Controls.Add(this.ivHPNum);
            this.Stats.Controls.Add(this.evHPNum);
            this.Stats.Controls.Add(this.evATKNum);
            this.Stats.Controls.Add(this.label16);
            this.Stats.Controls.Add(this.evDEFNum);
            this.Stats.Controls.Add(this.ivSPENum);
            this.Stats.Controls.Add(this.evSPANum);
            this.Stats.Controls.Add(this.ivSPDNum);
            this.Stats.Controls.Add(this.evSPDNum);
            this.Stats.Controls.Add(this.evSPENum);
            this.Stats.Controls.Add(this.label19);
            this.Stats.Controls.Add(this.ivSPANum);
            this.Stats.Controls.Add(this.ivDEFNum);
            this.Stats.Controls.Add(this.ivATKNum);
            this.Stats.Controls.Add(this.label17);
            this.Stats.Controls.Add(this.label5);
            this.Stats.Controls.Add(this.label29);
            this.Stats.Controls.Add(this.label22);
            this.Stats.Controls.Add(this.hiddenPower);
            this.Stats.Controls.Add(this.label20);
            this.Stats.Controls.Add(this.label21);
            this.Stats.Controls.Add(this.label18);
            this.Stats.Location = new System.Drawing.Point(4, 22);
            this.Stats.Name = "Stats";
            this.Stats.Padding = new System.Windows.Forms.Padding(3);
            this.Stats.Size = new System.Drawing.Size(284, 160);
            this.Stats.TabIndex = 0;
            this.Stats.Text = "Stats";
            // 
            // Moves
            // 
            this.Moves.BackColor = System.Drawing.SystemColors.Control;
            this.Moves.Controls.Add(this.move1);
            this.Moves.Controls.Add(this.move2);
            this.Moves.Controls.Add(this.move3);
            this.Moves.Controls.Add(this.move4);
            this.Moves.Controls.Add(this.label6);
            this.Moves.Controls.Add(this.label41);
            this.Moves.Controls.Add(this.label43);
            this.Moves.Controls.Add(this.label42);
            this.Moves.Location = new System.Drawing.Point(4, 22);
            this.Moves.Name = "Moves";
            this.Moves.Padding = new System.Windows.Forms.Padding(3);
            this.Moves.Size = new System.Drawing.Size(284, 160);
            this.Moves.TabIndex = 3;
            this.Moves.Text = "Moves";
            // 
            // OT
            // 
            this.OT.BackColor = System.Drawing.SystemColors.Control;
            this.OT.Controls.Add(this.dSIDNum);
            this.OT.Controls.Add(this.dTIDNum);
            this.OT.Controls.Add(this.label47);
            this.OT.Controls.Add(this.label48);
            this.OT.Controls.Add(this.otName);
            this.OT.Controls.Add(this.label46);
            this.OT.Location = new System.Drawing.Point(4, 22);
            this.OT.Name = "OT";
            this.OT.Padding = new System.Windows.Forms.Padding(3);
            this.OT.Size = new System.Drawing.Size(284, 160);
            this.OT.TabIndex = 1;
            this.OT.Text = "OT";
            // 
            // level
            // 
            this.level.Enabled = false;
            this.level.Location = new System.Drawing.Point(179, 331);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(120, 20);
            this.level.TabIndex = 59;
            this.level.Visible = false;
            // 
            // cloneWriteTabs
            // 
            this.cloneWriteTabs.Controls.Add(this.cloneTab);
            this.cloneWriteTabs.Controls.Add(this.writeTab);
            this.cloneWriteTabs.Controls.Add(this.tabPage1);
            this.cloneWriteTabs.Location = new System.Drawing.Point(306, 204);
            this.cloneWriteTabs.Name = "cloneWriteTabs";
            this.cloneWriteTabs.SelectedIndex = 0;
            this.cloneWriteTabs.Size = new System.Drawing.Size(317, 121);
            this.cloneWriteTabs.TabIndex = 60;
            // 
            // cloneTab
            // 
            this.cloneTab.Controls.Add(this.cloneDoIt);
            this.cloneTab.Controls.Add(this.cloneSlotFrom);
            this.cloneTab.Controls.Add(this.label52);
            this.cloneTab.Controls.Add(this.label53);
            this.cloneTab.Controls.Add(this.cloneBoxFrom);
            this.cloneTab.Controls.Add(this.label40);
            this.cloneTab.Controls.Add(this.cloneCopiesNo);
            this.cloneTab.Controls.Add(this.label36);
            this.cloneTab.Controls.Add(this.cloneSlotTo);
            this.cloneTab.Controls.Add(this.label37);
            this.cloneTab.Controls.Add(this.label39);
            this.cloneTab.Controls.Add(this.cloneBoxTo);
            this.cloneTab.Location = new System.Drawing.Point(4, 22);
            this.cloneTab.Name = "cloneTab";
            this.cloneTab.Padding = new System.Windows.Forms.Padding(3);
            this.cloneTab.Size = new System.Drawing.Size(309, 95);
            this.cloneTab.TabIndex = 0;
            this.cloneTab.Text = "Clone";
            this.cloneTab.UseVisualStyleBackColor = true;
            // 
            // cloneDoIt
            // 
            this.cloneDoIt.Location = new System.Drawing.Point(228, 66);
            this.cloneDoIt.Name = "cloneDoIt";
            this.cloneDoIt.Size = new System.Drawing.Size(75, 23);
            this.cloneDoIt.TabIndex = 17;
            this.cloneDoIt.Text = "Clone";
            this.cloneDoIt.UseVisualStyleBackColor = true;
            this.cloneDoIt.Click += new System.EventHandler(this.cloneDoIt_Click);
            // 
            // cloneSlotFrom
            // 
            this.cloneSlotFrom.Location = new System.Drawing.Point(124, 50);
            this.cloneSlotFrom.Name = "cloneSlotFrom";
            this.cloneSlotFrom.Size = new System.Drawing.Size(50, 20);
            this.cloneSlotFrom.TabIndex = 16;
            this.cloneSlotFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(93, 52);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(25, 13);
            this.label52.TabIndex = 15;
            this.label52.Text = "Slot";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 52);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(25, 13);
            this.label53.TabIndex = 14;
            this.label53.Text = "Box";
            // 
            // cloneBoxFrom
            // 
            this.cloneBoxFrom.Location = new System.Drawing.Point(37, 50);
            this.cloneBoxFrom.Name = "cloneBoxFrom";
            this.cloneBoxFrom.Size = new System.Drawing.Size(50, 20);
            this.cloneBoxFrom.TabIndex = 13;
            this.cloneBoxFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 30);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(33, 13);
            this.label40.TabIndex = 12;
            this.label40.Text = "From:";
            // 
            // cloneCopiesNo
            // 
            this.cloneCopiesNo.Location = new System.Drawing.Point(234, 5);
            this.cloneCopiesNo.Name = "cloneCopiesNo";
            this.cloneCopiesNo.Size = new System.Drawing.Size(50, 20);
            this.cloneCopiesNo.TabIndex = 11;
            this.cloneCopiesNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(180, 7);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 13);
            this.label36.TabIndex = 10;
            this.label36.Text = "# copies";
            // 
            // cloneSlotTo
            // 
            this.cloneSlotTo.Location = new System.Drawing.Point(124, 5);
            this.cloneSlotTo.Name = "cloneSlotTo";
            this.cloneSlotTo.Size = new System.Drawing.Size(50, 20);
            this.cloneSlotTo.TabIndex = 9;
            this.cloneSlotTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(93, 7);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(25, 13);
            this.label37.TabIndex = 8;
            this.label37.Text = "Slot";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 7);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(25, 13);
            this.label39.TabIndex = 7;
            this.label39.Text = "Box";
            // 
            // cloneBoxTo
            // 
            this.cloneBoxTo.Location = new System.Drawing.Point(37, 5);
            this.cloneBoxTo.Name = "cloneBoxTo";
            this.cloneBoxTo.Size = new System.Drawing.Size(50, 20);
            this.cloneBoxTo.TabIndex = 6;
            this.cloneBoxTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // writeTab
            // 
            this.writeTab.AllowDrop = true;
            this.writeTab.Controls.Add(this.writeDoIt);
            this.writeTab.Controls.Add(this.writeBrowse);
            this.writeTab.Controls.Add(this.writeAutoInc);
            this.writeTab.Controls.Add(this.writeCopiesNo);
            this.writeTab.Controls.Add(this.label35);
            this.writeTab.Controls.Add(this.writeSlotTo);
            this.writeTab.Controls.Add(this.label34);
            this.writeTab.Controls.Add(this.label33);
            this.writeTab.Controls.Add(this.writeBoxTo);
            this.writeTab.Location = new System.Drawing.Point(4, 22);
            this.writeTab.Name = "writeTab";
            this.writeTab.Padding = new System.Windows.Forms.Padding(3);
            this.writeTab.Size = new System.Drawing.Size(309, 95);
            this.writeTab.TabIndex = 1;
            this.writeTab.Text = "Write file";
            this.writeTab.UseVisualStyleBackColor = true;
            this.writeTab.DragDrop += new System.Windows.Forms.DragEventHandler(this.writeTab_DragDrop);
            this.writeTab.DragEnter += new System.Windows.Forms.DragEventHandler(this.writeTab_DragEnter);
            // 
            // writeDoIt
            // 
            this.writeDoIt.Location = new System.Drawing.Point(228, 66);
            this.writeDoIt.Name = "writeDoIt";
            this.writeDoIt.Size = new System.Drawing.Size(75, 23);
            this.writeDoIt.TabIndex = 8;
            this.writeDoIt.Text = "Write";
            this.writeDoIt.UseVisualStyleBackColor = true;
            this.writeDoIt.Click += new System.EventHandler(this.writeDoIt_Click);
            // 
            // writeBrowse
            // 
            this.writeBrowse.Location = new System.Drawing.Point(9, 66);
            this.writeBrowse.Name = "writeBrowse";
            this.writeBrowse.Size = new System.Drawing.Size(75, 23);
            this.writeBrowse.TabIndex = 7;
            this.writeBrowse.Text = "Browse...";
            this.writeBrowse.UseVisualStyleBackColor = true;
            this.writeBrowse.Click += new System.EventHandler(this.writeBrowse_Click);
            // 
            // writeAutoInc
            // 
            this.writeAutoInc.AutoSize = true;
            this.writeAutoInc.Location = new System.Drawing.Point(9, 31);
            this.writeAutoInc.Name = "writeAutoInc";
            this.writeAutoInc.Size = new System.Drawing.Size(97, 17);
            this.writeAutoInc.TabIndex = 6;
            this.writeAutoInc.Text = "Auto-increment";
            this.toolTip1.SetToolTip(this.writeAutoInc, "Automatically go to next slot after writing.\r\nMust be enabled when importing mult" +
        "iple Pokemon.");
            this.writeAutoInc.UseVisualStyleBackColor = true;
            // 
            // writeCopiesNo
            // 
            this.writeCopiesNo.Location = new System.Drawing.Point(234, 5);
            this.writeCopiesNo.Maximum = new decimal(new int[] {
            930,
            0,
            0,
            0});
            this.writeCopiesNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeCopiesNo.Name = "writeCopiesNo";
            this.writeCopiesNo.Size = new System.Drawing.Size(50, 20);
            this.writeCopiesNo.TabIndex = 5;
            this.writeCopiesNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(180, 7);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 13);
            this.label35.TabIndex = 4;
            this.label35.Text = "# copies";
            // 
            // writeSlotTo
            // 
            this.writeSlotTo.Location = new System.Drawing.Point(124, 5);
            this.writeSlotTo.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.writeSlotTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeSlotTo.Name = "writeSlotTo";
            this.writeSlotTo.Size = new System.Drawing.Size(50, 20);
            this.writeSlotTo.TabIndex = 3;
            this.writeSlotTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeSlotTo.ValueChanged += new System.EventHandler(this.writeSlotTo_ValueChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(93, 7);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(25, 13);
            this.label34.TabIndex = 2;
            this.label34.Text = "Slot";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 7);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(25, 13);
            this.label33.TabIndex = 1;
            this.label33.Text = "Box";
            // 
            // writeBoxTo
            // 
            this.writeBoxTo.Location = new System.Drawing.Point(37, 5);
            this.writeBoxTo.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.writeBoxTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeBoxTo.Name = "writeBoxTo";
            this.writeBoxTo.Size = new System.Drawing.Size(50, 20);
            this.writeBoxTo.TabIndex = 0;
            this.writeBoxTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.writeBoxTo.ValueChanged += new System.EventHandler(this.writeBoxTo_ValueChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.deleteKeepBackup);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.deleteBox);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.deleteAmount);
            this.tabPage1.Controls.Add(this.deleteSlot);
            this.tabPage1.Controls.Add(this.delPkm);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(309, 95);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Delete";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // deleteKeepBackup
            // 
            this.deleteKeepBackup.AutoSize = true;
            this.deleteKeepBackup.Checked = true;
            this.deleteKeepBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.deleteKeepBackup.Location = new System.Drawing.Point(9, 31);
            this.deleteKeepBackup.Name = "deleteKeepBackup";
            this.deleteKeepBackup.Size = new System.Drawing.Size(90, 17);
            this.deleteKeepBackup.TabIndex = 26;
            this.deleteKeepBackup.Text = "Keep backup";
            this.toolTip1.SetToolTip(this.deleteKeepBackup, "Backup to file before deleting");
            this.deleteKeepBackup.UseVisualStyleBackColor = true;
            // 
            // touchX
            // 
            this.touchX.Location = new System.Drawing.Point(85, 97);
            this.touchX.Maximum = new decimal(new int[] {
            319,
            0,
            0,
            0});
            this.touchX.Name = "touchX";
            this.touchX.Size = new System.Drawing.Size(62, 20);
            this.touchX.TabIndex = 70;
            this.toolTip1.SetToolTip(this.touchX, "X (horizontal) coordinate, from the left part of the screen.");
            this.touchX.ValueChanged += new System.EventHandler(this.touchX_ValueChanged);
            // 
            // touchY
            // 
            this.touchY.Location = new System.Drawing.Point(153, 97);
            this.touchY.Maximum = new decimal(new int[] {
            239,
            0,
            0,
            0});
            this.touchY.Name = "touchY";
            this.touchY.Size = new System.Drawing.Size(62, 20);
            this.touchY.TabIndex = 71;
            this.toolTip1.SetToolTip(this.touchY, "Y (vertical) coordinate, from the top part of the screen.");
            this.touchY.ValueChanged += new System.EventHandler(this.touchY_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(302, 328);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(124, 13);
            this.label50.TabIndex = 61;
            this.label50.Text = "NTR communication log:";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // LegendarySoftResetBot
            // 
            this.LegendarySoftResetBot.BackColor = System.Drawing.SystemColors.Control;
            this.LegendarySoftResetBot.Controls.Add(this.label70);
            this.LegendarySoftResetBot.Controls.Add(this.HPTypeLSR);
            this.LegendarySoftResetBot.Controls.Add(this.shinyLSR);
            this.LegendarySoftResetBot.Controls.Add(this.ivHPLSR);
            this.LegendarySoftResetBot.Controls.Add(this.label61);
            this.LegendarySoftResetBot.Controls.Add(this.label62);
            this.LegendarySoftResetBot.Controls.Add(this.label60);
            this.LegendarySoftResetBot.Controls.Add(this.ivSpeLSR);
            this.LegendarySoftResetBot.Controls.Add(this.RunLSRbot);
            this.LegendarySoftResetBot.Controls.Add(this.ivSpDLSR);
            this.LegendarySoftResetBot.Controls.Add(this.natureLSR);
            this.LegendarySoftResetBot.Controls.Add(this.label63);
            this.LegendarySoftResetBot.Controls.Add(this.ivDefLSR);
            this.LegendarySoftResetBot.Controls.Add(this.ivSpALSR);
            this.LegendarySoftResetBot.Controls.Add(this.label68);
            this.LegendarySoftResetBot.Controls.Add(this.label67);
            this.LegendarySoftResetBot.Controls.Add(this.ivAtkLSR);
            this.LegendarySoftResetBot.Controls.Add(this.label66);
            this.LegendarySoftResetBot.Controls.Add(this.label64);
            this.LegendarySoftResetBot.Controls.Add(this.label65);
            this.LegendarySoftResetBot.Location = new System.Drawing.Point(4, 22);
            this.LegendarySoftResetBot.Name = "LegendarySoftResetBot";
            this.LegendarySoftResetBot.Size = new System.Drawing.Size(261, 156);
            this.LegendarySoftResetBot.TabIndex = 2;
            this.LegendarySoftResetBot.Text = "Legendary SR";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(4, 56);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(52, 13);
            this.label70.TabIndex = 107;
            this.label70.Text = "HP Type:";
            // 
            // HPTypeLSR
            // 
            this.HPTypeLSR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.HPTypeLSR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.HPTypeLSR.FormattingEnabled = true;
            this.HPTypeLSR.Items.AddRange(new object[] {
            "Fighting",
            "Flying",
            "Poison",
            "Ground",
            "Rock",
            "Bug",
            "Ghost",
            "Steel",
            "Fire",
            "Water",
            "Grass",
            "Electric",
            "Psychic",
            "Ice",
            "Dragon",
            "Dark"});
            this.HPTypeLSR.Location = new System.Drawing.Point(62, 51);
            this.HPTypeLSR.Name = "HPTypeLSR";
            this.HPTypeLSR.Size = new System.Drawing.Size(81, 21);
            this.HPTypeLSR.TabIndex = 108;
            // 
            // shinyLSR
            // 
            this.shinyLSR.AutoSize = true;
            this.shinyLSR.Location = new System.Drawing.Point(87, 130);
            this.shinyLSR.Name = "shinyLSR";
            this.shinyLSR.Size = new System.Drawing.Size(52, 17);
            this.shinyLSR.TabIndex = 106;
            this.shinyLSR.Text = "Shiny";
            this.shinyLSR.UseVisualStyleBackColor = true;
            // 
            // ivHPLSR
            // 
            this.ivHPLSR.Location = new System.Drawing.Point(221, 20);
            this.ivHPLSR.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivHPLSR.Name = "ivHPLSR";
            this.ivHPLSR.Size = new System.Drawing.Size(33, 20);
            this.ivHPLSR.TabIndex = 91;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(4, 7);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(127, 13);
            this.label61.TabIndex = 105;
            this.label61.Text = "Leave blank if don\'t care.";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(217, 4);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(41, 13);
            this.label62.TabIndex = 84;
            this.label62.Text = "min IVs";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(14, 27);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(42, 13);
            this.label60.TabIndex = 103;
            this.label60.Text = "Nature:";
            // 
            // ivSpeLSR
            // 
            this.ivSpeLSR.Location = new System.Drawing.Point(221, 125);
            this.ivSpeLSR.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivSpeLSR.Name = "ivSpeLSR";
            this.ivSpeLSR.Size = new System.Drawing.Size(33, 20);
            this.ivSpeLSR.TabIndex = 96;
            // 
            // RunLSRbot
            // 
            this.RunLSRbot.Location = new System.Drawing.Point(6, 126);
            this.RunLSRbot.Name = "RunLSRbot";
            this.RunLSRbot.Size = new System.Drawing.Size(75, 23);
            this.RunLSRbot.TabIndex = 0;
            this.RunLSRbot.Text = "Run";
            this.RunLSRbot.UseVisualStyleBackColor = true;
            this.RunLSRbot.Click += new System.EventHandler(this.RunLSRbot_Click);
            // 
            // ivSpDLSR
            // 
            this.ivSpDLSR.Location = new System.Drawing.Point(221, 104);
            this.ivSpDLSR.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivSpDLSR.Name = "ivSpDLSR";
            this.ivSpDLSR.Size = new System.Drawing.Size(33, 20);
            this.ivSpDLSR.TabIndex = 95;
            // 
            // natureLSR
            // 
            this.natureLSR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.natureLSR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.natureLSR.FormattingEnabled = true;
            this.natureLSR.Items.AddRange(new object[] {
            "Hardy",
            "Lonely",
            "Brave",
            "Adamant",
            "Naughty",
            "Bold",
            "Docile",
            "Relaxed",
            "Impish",
            "Lax",
            "Timid",
            "Hasty",
            "Serious",
            "Jolly",
            "Naive",
            "Modest",
            "Mild",
            "Quiet",
            "Bashful",
            "Rash",
            "Calm",
            "Gentle",
            "Sassy",
            "Careful",
            "Quirky"});
            this.natureLSR.Location = new System.Drawing.Point(62, 24);
            this.natureLSR.Name = "natureLSR";
            this.natureLSR.Size = new System.Drawing.Size(81, 21);
            this.natureLSR.TabIndex = 104;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(190, 66);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(31, 13);
            this.label63.TabIndex = 87;
            this.label63.Text = "DEF:";
            // 
            // ivDefLSR
            // 
            this.ivDefLSR.Location = new System.Drawing.Point(221, 62);
            this.ivDefLSR.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivDefLSR.Name = "ivDefLSR";
            this.ivDefLSR.Size = new System.Drawing.Size(33, 20);
            this.ivDefLSR.TabIndex = 93;
            // 
            // ivSpALSR
            // 
            this.ivSpALSR.Location = new System.Drawing.Point(221, 83);
            this.ivSpALSR.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivSpALSR.Name = "ivSpALSR";
            this.ivSpALSR.Size = new System.Drawing.Size(33, 20);
            this.ivSpALSR.TabIndex = 94;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(190, 45);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(31, 13);
            this.label68.TabIndex = 86;
            this.label68.Text = "ATK:";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(189, 108);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(32, 13);
            this.label67.TabIndex = 89;
            this.label67.Text = "SPD:";
            // 
            // ivAtkLSR
            // 
            this.ivAtkLSR.Location = new System.Drawing.Point(221, 41);
            this.ivAtkLSR.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ivAtkLSR.Name = "ivAtkLSR";
            this.ivAtkLSR.Size = new System.Drawing.Size(33, 20);
            this.ivAtkLSR.TabIndex = 92;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(190, 87);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(31, 13);
            this.label66.TabIndex = 88;
            this.label66.Text = "SPA:";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(196, 24);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(25, 13);
            this.label64.TabIndex = 85;
            this.label64.Text = "HP:";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(190, 129);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(31, 13);
            this.label65.TabIndex = 90;
            this.label65.Text = "SPE:";
            // 
            // WonderTradeBot
            // 
            this.WonderTradeBot.BackColor = System.Drawing.SystemColors.Control;
            this.WonderTradeBot.Controls.Add(this.label59);
            this.WonderTradeBot.Controls.Add(this.RunWTbot);
            this.WonderTradeBot.Controls.Add(this.WTtradesNo);
            this.WonderTradeBot.Controls.Add(this.label57);
            this.WonderTradeBot.Controls.Add(this.WTBox);
            this.WonderTradeBot.Controls.Add(this.WTSlot);
            this.WonderTradeBot.Controls.Add(this.label58);
            this.WonderTradeBot.Location = new System.Drawing.Point(4, 22);
            this.WonderTradeBot.Name = "WonderTradeBot";
            this.WonderTradeBot.Padding = new System.Windows.Forms.Padding(3);
            this.WonderTradeBot.Size = new System.Drawing.Size(261, 156);
            this.WonderTradeBot.TabIndex = 1;
            this.WonderTradeBot.Text = "Wonder Trade";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(95, 7);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(49, 13);
            this.label59.TabIndex = 105;
            this.label59.Text = "# trades:";
            // 
            // RunWTbot
            // 
            this.RunWTbot.Location = new System.Drawing.Point(144, 23);
            this.RunWTbot.Name = "RunWTbot";
            this.RunWTbot.Size = new System.Drawing.Size(63, 23);
            this.RunWTbot.TabIndex = 63;
            this.RunWTbot.Text = "Run";
            this.RunWTbot.UseVisualStyleBackColor = true;
            this.RunWTbot.Click += new System.EventHandler(this.RunWTbot_Click);
            // 
            // WTtradesNo
            // 
            this.WTtradesNo.Location = new System.Drawing.Point(98, 26);
            this.WTtradesNo.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.WTtradesNo.Name = "WTtradesNo";
            this.WTtradesNo.Size = new System.Drawing.Size(40, 20);
            this.WTtradesNo.TabIndex = 104;
            this.WTtradesNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(49, 7);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(28, 13);
            this.label57.TabIndex = 103;
            this.label57.Text = "Slot:";
            // 
            // WTBox
            // 
            this.WTBox.Location = new System.Drawing.Point(6, 26);
            this.WTBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.WTBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WTBox.Name = "WTBox";
            this.WTBox.Size = new System.Drawing.Size(40, 20);
            this.WTBox.TabIndex = 100;
            this.WTBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WTSlot
            // 
            this.WTSlot.Location = new System.Drawing.Point(52, 26);
            this.WTSlot.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.WTSlot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WTSlot.Name = "WTSlot";
            this.WTSlot.Size = new System.Drawing.Size(40, 20);
            this.WTSlot.TabIndex = 101;
            this.WTSlot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 7);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(28, 13);
            this.label58.TabIndex = 102;
            this.label58.Text = "Box:";
            // 
            // RemonteControls
            // 
            this.RemonteControls.BackColor = System.Drawing.SystemColors.Control;
            this.RemonteControls.Controls.Add(this.manualDLeft);
            this.RemonteControls.Controls.Add(this.manualTouch);
            this.RemonteControls.Controls.Add(this.manualX);
            this.RemonteControls.Controls.Add(this.manualY);
            this.RemonteControls.Controls.Add(this.touchCoord);
            this.RemonteControls.Controls.Add(this.manualDUp);
            this.RemonteControls.Controls.Add(this.label55);
            this.RemonteControls.Controls.Add(this.manualL);
            this.RemonteControls.Controls.Add(this.manualB);
            this.RemonteControls.Controls.Add(this.touchY);
            this.RemonteControls.Controls.Add(this.manualA);
            this.RemonteControls.Controls.Add(this.manualR);
            this.RemonteControls.Controls.Add(this.touchX);
            this.RemonteControls.Controls.Add(this.manualSelect);
            this.RemonteControls.Controls.Add(this.manualDRight);
            this.RemonteControls.Controls.Add(this.label54);
            this.RemonteControls.Controls.Add(this.ManualDDown);
            this.RemonteControls.Controls.Add(this.manualStart);
            this.RemonteControls.Location = new System.Drawing.Point(4, 22);
            this.RemonteControls.Name = "RemonteControls";
            this.RemonteControls.Padding = new System.Windows.Forms.Padding(3);
            this.RemonteControls.Size = new System.Drawing.Size(261, 156);
            this.RemonteControls.TabIndex = 0;
            this.RemonteControls.Text = "Controls";
            // 
            // manualDLeft
            // 
            this.manualDLeft.Location = new System.Drawing.Point(6, 39);
            this.manualDLeft.Name = "manualDLeft";
            this.manualDLeft.Size = new System.Drawing.Size(23, 23);
            this.manualDLeft.TabIndex = 67;
            this.manualDLeft.Text = "←";
            this.manualDLeft.UseVisualStyleBackColor = true;
            this.manualDLeft.Click += new System.EventHandler(this.manualDLeft_Click);
            // 
            // manualTouch
            // 
            this.manualTouch.Location = new System.Drawing.Point(153, 123);
            this.manualTouch.Name = "manualTouch";
            this.manualTouch.Size = new System.Drawing.Size(62, 23);
            this.manualTouch.TabIndex = 74;
            this.manualTouch.Text = "Touch";
            this.manualTouch.UseVisualStyleBackColor = true;
            this.manualTouch.Click += new System.EventHandler(this.manualTouch_Click);
            // 
            // manualX
            // 
            this.manualX.Location = new System.Drawing.Point(200, 10);
            this.manualX.Name = "manualX";
            this.manualX.Size = new System.Drawing.Size(23, 23);
            this.manualX.TabIndex = 2;
            this.manualX.Text = "X";
            this.manualX.UseVisualStyleBackColor = true;
            this.manualX.Click += new System.EventHandler(this.manualX_Click);
            // 
            // manualY
            // 
            this.manualY.Location = new System.Drawing.Point(171, 39);
            this.manualY.Name = "manualY";
            this.manualY.Size = new System.Drawing.Size(23, 23);
            this.manualY.TabIndex = 3;
            this.manualY.Text = "Y";
            this.manualY.UseVisualStyleBackColor = true;
            this.manualY.Click += new System.EventHandler(this.manualY_Click);
            // 
            // touchCoord
            // 
            this.touchCoord.Location = new System.Drawing.Point(9, 125);
            this.touchCoord.Name = "touchCoord";
            this.touchCoord.ReadOnly = true;
            this.touchCoord.Size = new System.Drawing.Size(138, 20);
            this.touchCoord.TabIndex = 73;
            this.touchCoord.Text = "0x02000000";
            this.touchCoord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // manualDUp
            // 
            this.manualDUp.Location = new System.Drawing.Point(35, 10);
            this.manualDUp.Name = "manualDUp";
            this.manualDUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.manualDUp.Size = new System.Drawing.Size(23, 23);
            this.manualDUp.TabIndex = 4;
            this.manualDUp.Text = "↑";
            this.manualDUp.UseVisualStyleBackColor = true;
            this.manualDUp.Click += new System.EventHandler(this.manualDUp_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(221, 99);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(33, 13);
            this.label55.TabIndex = 72;
            this.label55.Text = "(X, Y)";
            // 
            // manualL
            // 
            this.manualL.Location = new System.Drawing.Point(103, 10);
            this.manualL.Name = "manualL";
            this.manualL.Size = new System.Drawing.Size(23, 23);
            this.manualL.TabIndex = 63;
            this.manualL.Text = "L";
            this.manualL.UseVisualStyleBackColor = true;
            this.manualL.Click += new System.EventHandler(this.manualL_Click);
            // 
            // manualB
            // 
            this.manualB.Location = new System.Drawing.Point(200, 68);
            this.manualB.Name = "manualB";
            this.manualB.Size = new System.Drawing.Size(23, 23);
            this.manualB.TabIndex = 1;
            this.manualB.Text = "B";
            this.manualB.UseVisualStyleBackColor = true;
            this.manualB.Click += new System.EventHandler(this.manualB_Click);
            // 
            // manualA
            // 
            this.manualA.Location = new System.Drawing.Point(229, 39);
            this.manualA.Name = "manualA";
            this.manualA.Size = new System.Drawing.Size(23, 23);
            this.manualA.TabIndex = 0;
            this.manualA.Text = "A";
            this.manualA.UseVisualStyleBackColor = true;
            this.manualA.Click += new System.EventHandler(this.manualA_Click);
            // 
            // manualR
            // 
            this.manualR.Location = new System.Drawing.Point(132, 10);
            this.manualR.Name = "manualR";
            this.manualR.Size = new System.Drawing.Size(23, 23);
            this.manualR.TabIndex = 64;
            this.manualR.Text = "R";
            this.manualR.UseVisualStyleBackColor = true;
            this.manualR.Click += new System.EventHandler(this.manualR_Click);
            // 
            // manualSelect
            // 
            this.manualSelect.Location = new System.Drawing.Point(132, 68);
            this.manualSelect.Name = "manualSelect";
            this.manualSelect.Size = new System.Drawing.Size(62, 23);
            this.manualSelect.TabIndex = 67;
            this.manualSelect.Text = "SELECT";
            this.manualSelect.UseVisualStyleBackColor = true;
            this.manualSelect.Click += new System.EventHandler(this.manualSelect_Click);
            // 
            // manualDRight
            // 
            this.manualDRight.Location = new System.Drawing.Point(64, 39);
            this.manualDRight.Name = "manualDRight";
            this.manualDRight.Size = new System.Drawing.Size(23, 23);
            this.manualDRight.TabIndex = 67;
            this.manualDRight.Text = "→";
            this.manualDRight.UseVisualStyleBackColor = true;
            this.manualDRight.Click += new System.EventHandler(this.manualDRight_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 99);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(73, 13);
            this.label54.TabIndex = 69;
            this.label54.Text = "Touchscreen:";
            // 
            // ManualDDown
            // 
            this.ManualDDown.Location = new System.Drawing.Point(35, 68);
            this.ManualDDown.Name = "ManualDDown";
            this.ManualDDown.Size = new System.Drawing.Size(23, 23);
            this.ManualDDown.TabIndex = 67;
            this.ManualDDown.Text = "↓";
            this.ManualDDown.UseVisualStyleBackColor = true;
            this.ManualDDown.Click += new System.EventHandler(this.ManualDDown_Click);
            // 
            // manualStart
            // 
            this.manualStart.Location = new System.Drawing.Point(64, 68);
            this.manualStart.Name = "manualStart";
            this.manualStart.Size = new System.Drawing.Size(62, 23);
            this.manualStart.TabIndex = 68;
            this.manualStart.Text = "START";
            this.manualStart.UseVisualStyleBackColor = true;
            this.manualStart.Click += new System.EventHandler(this.manualStart_Click);
            // 
            // BotTab
            // 
            this.BotTab.Controls.Add(this.RemonteControls);
            this.BotTab.Controls.Add(this.WonderTradeBot);
            this.BotTab.Controls.Add(this.LegendarySoftResetBot);
            this.BotTab.Location = new System.Drawing.Point(629, 257);
            this.BotTab.Name = "BotTab";
            this.BotTab.SelectedIndex = 0;
            this.BotTab.Size = new System.Drawing.Size(269, 182);
            this.BotTab.TabIndex = 75;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(541, 328);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(78, 13);
            this.label69.TabIndex = 76;
            this.label69.Text = "Version: 1.1.18";
            this.label69.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 77;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 444);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.BotTab);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.cloneWriteTabs);
            this.Controls.Add(this.level);
            this.Controls.Add(this.DumpedEdit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.dumpBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PKMN NTR with Bots";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.milesNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpNum)).EndInit();
            this.dumpBox.ResumeLayout(false);
            this.dumpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotDump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPENum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evSPANum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evDEFNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evATKNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evHPNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSPENum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSPDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSPANum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivDEFNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivATKNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivHPNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deleteAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendship)).EndInit();
            this.DumpedEdit.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpPoints)).EndInit();
            this.Stats.ResumeLayout(false);
            this.Stats.PerformLayout();
            this.Moves.ResumeLayout(false);
            this.Moves.PerformLayout();
            this.OT.ResumeLayout(false);
            this.OT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.level)).EndInit();
            this.cloneWriteTabs.ResumeLayout(false);
            this.cloneTab.ResumeLayout(false);
            this.cloneTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cloneSlotFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneBoxFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneCopiesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneSlotTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cloneBoxTo)).EndInit();
            this.writeTab.ResumeLayout(false);
            this.writeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.writeCopiesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeSlotTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeBoxTo)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touchX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.touchY)).EndInit();
            this.LegendarySoftResetBot.ResumeLayout(false);
            this.LegendarySoftResetBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivHPLSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSpeLSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSpDLSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivDefLSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivSpALSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivAtkLSR)).EndInit();
            this.WonderTradeBot.ResumeLayout(false);
            this.WonderTradeBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTtradesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTSlot)).EndInit();
            this.RemonteControls.ResumeLayout(false);
            this.RemonteControls.PerformLayout();
            this.BotTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer disconnectTimer;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown moneyNum;
        private System.Windows.Forms.NumericUpDown milesNum;
        private System.Windows.Forms.NumericUpDown bpNum;
        private System.Windows.Forms.Button pokeMoney;
        private System.Windows.Forms.Button pokeMiles;
        private System.Windows.Forms.Button pokeBP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox dumpBox;
        private System.Windows.Forms.Button dumpPokemon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown slotDump;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown boxDump;
        private System.Windows.Forms.TextBox nameek6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button dumpBoxes;
        private System.Windows.Forms.RadioButton radioDaycare;
        private System.Windows.Forms.RadioButton radioBoxes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown TIDNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button pokeTID;
        private System.Windows.Forms.Button pokeTime;
        private System.Windows.Forms.NumericUpDown hourNum;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown minNum;
        private System.Windows.Forms.NumericUpDown secNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button showKeys;
        private System.Windows.Forms.Button showBerries;
        private System.Windows.Forms.Button showTMs;
        private System.Windows.Forms.Button showMedicine;
        private System.Windows.Forms.Button showItems;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button itemWrite;
        private System.Windows.Forms.Button itemAdd;
        private System.Windows.Forms.RadioButton radioOpponent;
        private System.Windows.Forms.RadioButton radioTrade;
        private System.Windows.Forms.Button pokeSID;
        private System.Windows.Forms.NumericUpDown SIDNum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button delPkm;
        private System.Windows.Forms.NumericUpDown deleteBox;
        private System.Windows.Forms.NumericUpDown deleteSlot;
        private System.Windows.Forms.Button pokeLang;
        private System.Windows.Forms.Button pokeName;
        private System.Windows.Forms.TextBox playerName;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox Lang;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox hiddenPower;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox nature;
        private System.Windows.Forms.NumericUpDown ivSPENum;
        private System.Windows.Forms.NumericUpDown ivSPDNum;
        private System.Windows.Forms.NumericUpDown ivSPANum;
        private System.Windows.Forms.NumericUpDown ivDEFNum;
        private System.Windows.Forms.NumericUpDown ivATKNum;
        private System.Windows.Forms.NumericUpDown ivHPNum;
        private System.Windows.Forms.CheckBox isEgg;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox heldItem;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox species;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.NumericUpDown deleteAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown evSPENum;
        private System.Windows.Forms.NumericUpDown evSPDNum;
        private System.Windows.Forms.NumericUpDown evSPANum;
        private System.Windows.Forms.NumericUpDown evDEFNum;
        private System.Windows.Forms.NumericUpDown evATKNum;
        private System.Windows.Forms.NumericUpDown evHPNum;
        private System.Windows.Forms.ComboBox ability;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox move4;
        private System.Windows.Forms.ComboBox move3;
        private System.Windows.Forms.ComboBox move2;
        private System.Windows.Forms.ComboBox move1;
        private System.Windows.Forms.ComboBox ball;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button versionCheck;
        private System.Windows.Forms.RadioButton radioParty;
        private System.Windows.Forms.NumericUpDown dTIDNum;
        private System.Windows.Forms.NumericUpDown dSIDNum;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox otName;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button setShiny;
        public System.Windows.Forms.TextBox dPID;
        private System.Windows.Forms.CheckBox onlyView;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown friendship;
        private System.Windows.Forms.Button randomPID;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Button gender;
        private System.Windows.Forms.TabControl DumpedEdit;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.TabPage Stats;
        private System.Windows.Forms.TabPage Moves;
        private System.Windows.Forms.TabPage OT;
        private System.Windows.Forms.RadioButton radioBattleBox;
        private System.Windows.Forms.NumericUpDown ExpPoints;
        private System.Windows.Forms.NumericUpDown level;
        private System.Windows.Forms.TabControl cloneWriteTabs;
        private System.Windows.Forms.TabPage cloneTab;
        private System.Windows.Forms.TabPage writeTab;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown writeBoxTo;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown writeSlotTo;
        private System.Windows.Forms.NumericUpDown writeCopiesNo;
        private System.Windows.Forms.Button writeDoIt;
        private System.Windows.Forms.Button writeBrowse;
        private System.Windows.Forms.CheckBox writeAutoInc;
        private System.Windows.Forms.Button cloneDoIt;
        private System.Windows.Forms.NumericUpDown cloneSlotFrom;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.NumericUpDown cloneBoxFrom;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.NumericUpDown cloneCopiesNo;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown cloneSlotTo;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.NumericUpDown cloneBoxTo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.CheckBox deleteKeepBackup;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TabPage LegendarySoftResetBot;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button RunLSRbot;
        private System.Windows.Forms.ComboBox natureLSR;
        private System.Windows.Forms.TabPage WonderTradeBot;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Button RunWTbot;
        private System.Windows.Forms.NumericUpDown WTtradesNo;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.NumericUpDown WTBox;
        private System.Windows.Forms.NumericUpDown WTSlot;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TabPage RemonteControls;
        private System.Windows.Forms.Button manualDLeft;
        private System.Windows.Forms.Button manualTouch;
        private System.Windows.Forms.Button manualX;
        private System.Windows.Forms.Button manualY;
        private System.Windows.Forms.TextBox touchCoord;
        private System.Windows.Forms.Button manualDUp;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button manualL;
        private System.Windows.Forms.Button manualB;
        private System.Windows.Forms.NumericUpDown touchY;
        private System.Windows.Forms.Button manualA;
        private System.Windows.Forms.Button manualR;
        private System.Windows.Forms.NumericUpDown touchX;
        private System.Windows.Forms.Button manualSelect;
        private System.Windows.Forms.Button manualDRight;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button ManualDDown;
        private System.Windows.Forms.Button manualStart;
        private System.Windows.Forms.TabControl BotTab;
        private System.Windows.Forms.NumericUpDown ivHPLSR;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.NumericUpDown ivSpeLSR;
        private System.Windows.Forms.NumericUpDown ivSpDLSR;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.NumericUpDown ivDefLSR;
        private System.Windows.Forms.NumericUpDown ivSpALSR;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.NumericUpDown ivAtkLSR;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.CheckBox shinyLSR;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.ComboBox HPTypeLSR;
        private System.Windows.Forms.Button button2;
    }
}

