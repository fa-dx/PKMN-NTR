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
            this.label1 = new System.Windows.Forms.Label();
            this.moneyNum = new System.Windows.Forms.NumericUpDown();
            this.milesNum = new System.Windows.Forms.NumericUpDown();
            this.bpNum = new System.Windows.Forms.NumericUpDown();
            this.pokeMoney = new System.Windows.Forms.Button();
            this.pokeMiles = new System.Windows.Forms.Button();
            this.pokeBP = new System.Windows.Forms.Button();
            this.editMoney = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.editMiles = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editBP = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectPkx = new System.Windows.Forms.Button();
            this.pokePkm = new System.Windows.Forms.Button();
            this.box = new System.Windows.Forms.NumericUpDown();
            this.slot = new System.Windows.Forms.NumericUpDown();
            this.dumpBox = new System.Windows.Forms.GroupBox();
            this.radioDaycare = new System.Windows.Forms.RadioButton();
            this.radioBoxes = new System.Windows.Forms.RadioButton();
            this.dumpBoxes = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.namePkx = new System.Windows.Forms.TextBox();
            this.dumpPkx = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.slotDump = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.boxDump = new System.Windows.Forms.NumericUpDown();
            this.writeBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pokeName = new System.Windows.Forms.Button();
            this.playerName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabItems = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemsNum2 = new System.Windows.Forms.NumericUpDown();
            this.items2 = new System.Windows.Forms.ComboBox();
            this.itemsNum1 = new System.Windows.Forms.NumericUpDown();
            this.items1 = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TIDNum = new System.Windows.Forms.NumericUpDown();
            this.pokeTID = new System.Windows.Forms.Button();
            this.pokeTime = new System.Windows.Forms.Button();
            this.hourNum = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.minNum = new System.Windows.Forms.NumericUpDown();
            this.secNum = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.milesNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpNum)).BeginInit();
            this.editMoney.SuspendLayout();
            this.editMiles.SuspendLayout();
            this.editBP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slot)).BeginInit();
            this.dumpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotDump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDump)).BeginInit();
            this.writeBox.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsNum2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsNum1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TIDNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secNum)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtLog.Location = new System.Drawing.Point(500, 199);
            this.txtLog.MaxLength = 32767000;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(689, 397);
            this.txtLog.TabIndex = 0;
            this.txtLog.Visible = false;
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
            this.host.Location = new System.Drawing.Point(33, 19);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(115, 20);
            this.host.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonDisconnect);
            this.groupBox1.Controls.Add(this.host);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Location = new System.Drawing.Point(272, 284);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 74);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
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
            this.moneyNum.Enabled = false;
            this.moneyNum.Location = new System.Drawing.Point(6, 36);
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
            this.milesNum.Enabled = false;
            this.milesNum.Location = new System.Drawing.Point(6, 36);
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
            this.bpNum.Enabled = false;
            this.bpNum.Location = new System.Drawing.Point(6, 36);
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
            this.pokeMoney.Enabled = false;
            this.pokeMoney.Location = new System.Drawing.Point(83, 33);
            this.pokeMoney.Name = "pokeMoney";
            this.pokeMoney.Size = new System.Drawing.Size(45, 23);
            this.pokeMoney.TabIndex = 10;
            this.pokeMoney.Text = "Write";
            this.pokeMoney.UseVisualStyleBackColor = true;
            this.pokeMoney.Click += new System.EventHandler(this.pokeMoney_Click);
            // 
            // pokeMiles
            // 
            this.pokeMiles.Enabled = false;
            this.pokeMiles.Location = new System.Drawing.Point(83, 33);
            this.pokeMiles.Name = "pokeMiles";
            this.pokeMiles.Size = new System.Drawing.Size(45, 23);
            this.pokeMiles.TabIndex = 11;
            this.pokeMiles.Text = "Write";
            this.pokeMiles.UseVisualStyleBackColor = true;
            this.pokeMiles.Click += new System.EventHandler(this.pokeMiles_Click);
            // 
            // pokeBP
            // 
            this.pokeBP.Enabled = false;
            this.pokeBP.Location = new System.Drawing.Point(83, 33);
            this.pokeBP.Name = "pokeBP";
            this.pokeBP.Size = new System.Drawing.Size(45, 23);
            this.pokeBP.TabIndex = 12;
            this.pokeBP.Text = "Write BP";
            this.pokeBP.UseVisualStyleBackColor = true;
            this.pokeBP.Click += new System.EventHandler(this.pokeBP_Click);
            // 
            // editMoney
            // 
            this.editMoney.Controls.Add(this.label2);
            this.editMoney.Controls.Add(this.moneyNum);
            this.editMoney.Controls.Add(this.pokeMoney);
            this.editMoney.Location = new System.Drawing.Point(12, 8);
            this.editMoney.Name = "editMoney";
            this.editMoney.Size = new System.Drawing.Size(134, 62);
            this.editMoney.TabIndex = 13;
            this.editMoney.TabStop = false;
            this.editMoney.Text = "Edit Money";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Money:";
            // 
            // editMiles
            // 
            this.editMiles.Controls.Add(this.pokeMiles);
            this.editMiles.Controls.Add(this.milesNum);
            this.editMiles.Controls.Add(this.label3);
            this.editMiles.Location = new System.Drawing.Point(292, 8);
            this.editMiles.Name = "editMiles";
            this.editMiles.Size = new System.Drawing.Size(134, 62);
            this.editMiles.TabIndex = 14;
            this.editMiles.TabStop = false;
            this.editMiles.Text = "Edit Poké Miles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Poké Miles:";
            // 
            // editBP
            // 
            this.editBP.Controls.Add(this.label4);
            this.editBP.Controls.Add(this.pokeBP);
            this.editBP.Controls.Add(this.bpNum);
            this.editBP.Location = new System.Drawing.Point(152, 8);
            this.editBP.Name = "editBP";
            this.editBP.Size = new System.Drawing.Size(134, 62);
            this.editBP.TabIndex = 15;
            this.editBP.TabStop = false;
            this.editBP.Text = "Edit BP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Battle Points:";
            // 
            // selectPkx
            // 
            this.selectPkx.Enabled = false;
            this.selectPkx.Location = new System.Drawing.Point(6, 62);
            this.selectPkx.Name = "selectPkx";
            this.selectPkx.Size = new System.Drawing.Size(66, 23);
            this.selectPkx.TabIndex = 16;
            this.selectPkx.Text = "Browse";
            this.selectPkx.UseVisualStyleBackColor = true;
            this.selectPkx.Click += new System.EventHandler(this.selectPkx_Click);
            // 
            // pokePkm
            // 
            this.pokePkm.Enabled = false;
            this.pokePkm.Location = new System.Drawing.Point(82, 62);
            this.pokePkm.Name = "pokePkm";
            this.pokePkm.Size = new System.Drawing.Size(66, 23);
            this.pokePkm.TabIndex = 17;
            this.pokePkm.Text = "Write";
            this.pokePkm.UseVisualStyleBackColor = true;
            this.pokePkm.Click += new System.EventHandler(this.button1_Click);
            // 
            // box
            // 
            this.box.Enabled = false;
            this.box.Location = new System.Drawing.Point(6, 36);
            this.box.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(66, 20);
            this.box.TabIndex = 18;
            this.box.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // slot
            // 
            this.slot.Enabled = false;
            this.slot.Location = new System.Drawing.Point(82, 36);
            this.slot.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.slot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.slot.Name = "slot";
            this.slot.Size = new System.Drawing.Size(66, 20);
            this.slot.TabIndex = 19;
            this.slot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dumpBox
            // 
            this.dumpBox.Controls.Add(this.radioDaycare);
            this.dumpBox.Controls.Add(this.radioBoxes);
            this.dumpBox.Controls.Add(this.dumpBoxes);
            this.dumpBox.Controls.Add(this.label9);
            this.dumpBox.Controls.Add(this.namePkx);
            this.dumpBox.Controls.Add(this.dumpPkx);
            this.dumpBox.Controls.Add(this.label7);
            this.dumpBox.Controls.Add(this.slotDump);
            this.dumpBox.Controls.Add(this.label8);
            this.dumpBox.Controls.Add(this.boxDump);
            this.dumpBox.Location = new System.Drawing.Point(12, 80);
            this.dumpBox.Name = "dumpBox";
            this.dumpBox.Size = new System.Drawing.Size(209, 113);
            this.dumpBox.TabIndex = 20;
            this.dumpBox.TabStop = false;
            this.dumpBox.Text = "Dump Pokémon";
            // 
            // radioDaycare
            // 
            this.radioDaycare.AutoSize = true;
            this.radioDaycare.Enabled = false;
            this.radioDaycare.Location = new System.Drawing.Point(99, 90);
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
            this.radioBoxes.Enabled = false;
            this.radioBoxes.Location = new System.Drawing.Point(38, 90);
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
            this.dumpBoxes.Enabled = false;
            this.dumpBoxes.Location = new System.Drawing.Point(98, 61);
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
            this.label9.Location = new System.Drawing.Point(96, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Filename:";
            // 
            // namePkx
            // 
            this.namePkx.Enabled = false;
            this.namePkx.Location = new System.Drawing.Point(98, 35);
            this.namePkx.Name = "namePkx";
            this.namePkx.Size = new System.Drawing.Size(105, 20);
            this.namePkx.TabIndex = 29;
            // 
            // dumpPkx
            // 
            this.dumpPkx.Enabled = false;
            this.dumpPkx.Location = new System.Drawing.Point(6, 61);
            this.dumpPkx.Name = "dumpPkx";
            this.dumpPkx.Size = new System.Drawing.Size(86, 23);
            this.dumpPkx.TabIndex = 28;
            this.dumpPkx.Text = "Dump";
            this.dumpPkx.UseVisualStyleBackColor = true;
            this.dumpPkx.Click += new System.EventHandler(this.dumpPkx_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Slot:";
            // 
            // slotDump
            // 
            this.slotDump.Enabled = false;
            this.slotDump.Location = new System.Drawing.Point(52, 35);
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
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Box:";
            // 
            // boxDump
            // 
            this.boxDump.Enabled = false;
            this.boxDump.Location = new System.Drawing.Point(6, 35);
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
            // writeBox
            // 
            this.writeBox.Controls.Add(this.label6);
            this.writeBox.Controls.Add(this.label5);
            this.writeBox.Controls.Add(this.selectPkx);
            this.writeBox.Controls.Add(this.pokePkm);
            this.writeBox.Controls.Add(this.box);
            this.writeBox.Controls.Add(this.slot);
            this.writeBox.Location = new System.Drawing.Point(227, 80);
            this.writeBox.Name = "writeBox";
            this.writeBox.Size = new System.Drawing.Size(154, 90);
            this.writeBox.TabIndex = 21;
            this.writeBox.TabStop = false;
            this.writeBox.Text = "Write Pokémon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Slot:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Box:";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Location = new System.Drawing.Point(595, 338);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(878, 449);
            this.tabMain.TabIndex = 22;
            this.tabMain.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pokeName
            // 
            this.pokeName.Enabled = false;
            this.pokeName.Location = new System.Drawing.Point(94, 33);
            this.pokeName.Name = "pokeName";
            this.pokeName.Size = new System.Drawing.Size(45, 23);
            this.pokeName.TabIndex = 23;
            this.pokeName.Text = "Write";
            this.pokeName.UseVisualStyleBackColor = true;
            this.pokeName.Click += new System.EventHandler(this.pokeName_Click);
            // 
            // playerName
            // 
            this.playerName.Enabled = false;
            this.playerName.Location = new System.Drawing.Point(8, 35);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(80, 20);
            this.playerName.TabIndex = 22;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabItems);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.tabPage3);
            this.tabItems.Controls.Add(this.tabPage4);
            this.tabItems.Location = new System.Drawing.Point(-2, 1);
            this.tabItems.Name = "tabItems";
            this.tabItems.SelectedIndex = 0;
            this.tabItems.Size = new System.Drawing.Size(885, 426);
            this.tabItems.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.itemsNum2);
            this.tabPage3.Controls.Add(this.items2);
            this.tabPage3.Controls.Add(this.itemsNum1);
            this.tabPage3.Controls.Add(this.items1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(877, 400);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Items";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 295);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(828, 20);
            this.textBox1.TabIndex = 33;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(342, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(191, 150);
            this.dataGridView1.TabIndex = 32;
            // 
            // itemsNum2
            // 
            this.itemsNum2.Location = new System.Drawing.Point(133, 33);
            this.itemsNum2.Name = "itemsNum2";
            this.itemsNum2.Size = new System.Drawing.Size(52, 20);
            this.itemsNum2.TabIndex = 3;
            // 
            // items2
            // 
            this.items2.FormattingEnabled = true;
            this.items2.Items.AddRange(new object[] {
            "None",
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
            "Potion",
            "Antidote",
            "Burn Heal",
            "Ice Heal",
            "Awakening",
            "Paralyze Heal",
            "Full Restore",
            "Max Potion",
            "Hyper Potion",
            "Super Potion",
            "Full Heal",
            "Revive",
            "Max Revive",
            "Fresh Water",
            "Soda Pop",
            "Lemonade",
            "Moomoo Milk",
            "Energy Powder",
            "Energy Root",
            "Heal Powder",
            "Revival Herb",
            "Ether",
            "Max Ether",
            "Elixir",
            "Max Elixir",
            "Lava Cookie",
            "Berry Juice",
            "Sacred Ash",
            "HP Up",
            "Protein",
            "Iron",
            "Carbos",
            "Calcium",
            "Rare Candy",
            "PP Up",
            "Zinc",
            "PP Max",
            "Old Gateau",
            "Guard Spec.",
            "Dire Hit",
            "X Attack",
            "X Defense",
            "X Speed",
            "X Accuracy",
            "X Sp. Atk",
            "X Sp. Def",
            "Poke Doll",
            "Fluffy Tail",
            "Blue Flute",
            "Yellow Flute",
            "Red Flute",
            "Black Flute",
            "White Flute",
            "Shoal Salt",
            "Shoal Shell",
            "Red Shard",
            "Blue Shard",
            "Yellow Shard",
            "Green Shard",
            "Super Repel",
            "Max Repel",
            "Escape Rope",
            "Repel",
            "Sun Stone",
            "Moon Stone",
            "Fire Stone",
            "Thunder Stone",
            "Water Stone",
            "Leaf Stone",
            "Tiny Mushroom",
            "Big Mushroom",
            "Pearl",
            "Big Pearl",
            "Stardust",
            "Star Piece",
            "Nugget",
            "Heart Scale",
            "Honey",
            "Growth Mulch",
            "Damp Mulch",
            "Stable Mulch",
            "Gooey Mulch",
            "Root Fossil",
            "Claw Fossil",
            "Helix Fossil",
            "Dome Fossil",
            "Old Amber",
            "Armor Fossil",
            "Skull Fossil",
            "Rare Bone",
            "Shiny Stone",
            "Dusk Stone",
            "Dawn Stone",
            "Oval Stone",
            "Odd Keystone",
            "Griseous Orb",
            "???",
            "???",
            "???",
            "Douse Drive",
            "Shock Drive",
            "Burn Drive",
            "Chill Drive",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "Sweet Heart",
            "Adamant Orb",
            "Lustrous Orb",
            "Greet Mail",
            "Favored Mail",
            "RSVP Mail",
            "Thanks Mail",
            "Inquiry Mail",
            "Like Mail",
            "Reply Mail",
            "Bridge Mail S",
            "Bridge Mail D",
            "Bridge Mail T",
            "Bridge Mail V",
            "Bridge Mail M",
            "Cheri Berry",
            "Chesto Berry",
            "Pecha Berry",
            "Rawst Berry",
            "Aspear Berry",
            "Leppa Berry",
            "Oran Berry",
            "Persim Berry",
            "Lum Berry",
            "Sitrus Berry",
            "Figy Berry",
            "Wiki Berry",
            "Mago Berry",
            "Aguav Berry",
            "Iapapa Berry",
            "Razz Berry",
            "Bluk Berry",
            "Nanab Berry",
            "Wepear Berry",
            "Pinap Berry",
            "Pomeg Berry",
            "Kelpsy Berry",
            "Qualot Berry",
            "Hondew Berry",
            "Grepa Berry",
            "Tamato Berry",
            "Cornn Berry",
            "Magost Berry",
            "Rabuta Berry",
            "Nomel Berry",
            "Spelon Berry",
            "Pamtre Berry",
            "Watmel Berry",
            "Durin Berry",
            "Belue Berry",
            "Occa Berry",
            "Passho Berry",
            "Wacan Berry",
            "Rindo Berry",
            "Yache Berry",
            "Chople Berry",
            "Kebai Berry",
            "Shuca Berry",
            "Coba Berry",
            "Payapa Berry",
            "Tanga Berry",
            "Charti Berry",
            "Kasib Berry",
            "Haban Berry",
            "Colbur Berry",
            "Babiri Berry",
            "Chilan Berry",
            "Liechi Berry",
            "Ganlon Berry",
            "Salac Berry",
            "Petaya Berry",
            "Apicot Berry",
            "Lansat Berry",
            "Starf Berry",
            "Enigma Berry",
            "Micle Berry",
            "Custap Berry",
            "Jaboca Berry",
            "Rowap Berry",
            "Bright Powder",
            "White Herb",
            "Macho Brace",
            "Exp. Share",
            "Quick Claw",
            "Soothe Bell",
            "Mental Herb",
            "Choice Band",
            "King\'s Rock",
            "Silver Powder",
            "Amulet Coin",
            "Cleanse Tag",
            "Soul Dew",
            "Deep Sea Tooth",
            "Deep Sea Scale",
            "Smoke Ball",
            "Everstone",
            "Focus Band",
            "Lucky Egg",
            "Scope Lens",
            "Metal Coat",
            "Leftovers",
            "Dragon Scale",
            "Light Ball",
            "Soft Sand",
            "Hard Stone",
            "Miracle Seed",
            "Black Glasses",
            "Black Belt",
            "Magnet",
            "Mystic Water",
            "Sharp Beak",
            "Poison Barb",
            "Never-Melt Ice",
            "Spell Tag",
            "Twisted Spoon",
            "Charcoal",
            "Dragon Fang",
            "Silk Scarf",
            "Up-Grade",
            "Shell Bell",
            "Sea Incense",
            "Lax Incense",
            "Lucky Punch",
            "Metal Powder",
            "Thick Club",
            "Stick",
            "Red Scarf",
            "Blue Scarf",
            "Pink Scarf",
            "Green Scarf",
            "Yellow Scarf",
            "Wide Lens",
            "Muscle Band",
            "Wise Glasses",
            "Expert Belt",
            "Light Clay",
            "Life Orb",
            "Power Herb",
            "Toxic Orb",
            "Flame Orb",
            "Quick Powder",
            "Focus Sash",
            "Zoom Lens",
            "Metronome",
            "Iron Ball",
            "Lagging Tail",
            "Destiny Knot",
            "Black Sludge",
            "Icy Rock",
            "Smooth Rock",
            "Heat Rock",
            "Damp Rock",
            "Grip Claw",
            "Choice Scarf",
            "Sticky Barb",
            "Power Bracer",
            "Power Belt",
            "Power Lens",
            "Power Band",
            "Power Anklet",
            "Power Weight",
            "Shed Shell",
            "Big Root",
            "Choice Specs",
            "Flame Plate",
            "Splash Plate",
            "Zap Plate",
            "Meadow Plate",
            "Icicle Plate",
            "Fist Plate",
            "Toxic Plate",
            "Earth Plate",
            "Sky Plate",
            "Mind Plate",
            "Insect Plate",
            "Stone Plate",
            "Spooky Plate",
            "Draco Plate",
            "Dread Plate",
            "Iron Plate",
            "Odd Incense",
            "Rock Incense",
            "Full Incense",
            "Wave Incense",
            "Rose Incense",
            "Luck Incense",
            "Pure Incense",
            "Protector",
            "Electrizer",
            "Magmarizer",
            "Dubious Disc",
            "Reaper Cloth",
            "Razor Claw",
            "Razor Fang",
            "Hone Claws",
            "Dragon Claw",
            "Psyshock",
            "Calm Mind",
            "Roar",
            "Toxic",
            "Hail",
            "Bulk Up",
            "Venoshock",
            "Hidden Power",
            "Sunny Day",
            "Taunt",
            "Ice Beam",
            "Blizzard",
            "Hyper Beam",
            "Light Screen",
            "Protect",
            "Rain Dance",
            "Roost",
            "Safeguard",
            "Frustration",
            "Solar Beam",
            "Smack Down",
            "Thunderbolt",
            "Thunder",
            "Earthquake",
            "Return",
            "Dig",
            "Psychic",
            "Shadow Ball",
            "Brick Break",
            "Double Team",
            "Reflect",
            "Sludge Wave",
            "Flamethrower",
            "Sludge Bomb",
            "Sandstorm",
            "Fire Blast",
            "Rock Tomb",
            "Aerial Ace",
            "Torment",
            "Facade",
            "Flame Charge",
            "Rest",
            "Attract",
            "Thief",
            "Low Sweep",
            "Round",
            "Echoed Voice",
            "Overheat",
            "Steel Wing",
            "Focus Blast",
            "Energy Ball",
            "False Swipe",
            "Scald",
            "Fling",
            "Charge Beam",
            "Sky Drop",
            "Incinerate",
            "Quash",
            "Will-O-Wisp",
            "Acrobatics",
            "Embargo",
            "Explosion",
            "Shadow Claw",
            "Payback",
            "Retaliate",
            "Giga Impact",
            "Rock Polish",
            "Flash",
            "Stone Edge",
            "Volt Switch",
            "Thunder Wave",
            "Gyro Ball",
            "Swords Dance",
            "Struggle Bug",
            "Psych Up",
            "Bulldoze",
            "Frost Breath",
            "Rock Slide",
            "X-Scissor",
            "Dragon Tail",
            "Infestation",
            "Poison Jab",
            "Dream Eater",
            "Grass Knot",
            "Swagger",
            "Sleep Talk",
            "U-turn",
            "Substitute",
            "Flash Cannon",
            "Trick Room",
            "Cut",
            "Fly",
            "Surf",
            "Strength",
            "Waterfall",
            "Rock Smash",
            "???",
            "???",
            "Explorer Kit",
            "Loot Sack",
            "Rule Book",
            "Poke Radar",
            "Point Card",
            "Journal",
            "Seal Case",
            "Fashion Case",
            "Seal Bag",
            "Pal Pad",
            "Works key",
            "Old Charm",
            "Galactic Key",
            "Red Chain",
            "Town Map",
            "Vs. Seeker",
            "Coin Case",
            "Old Rod",
            "Good Rod",
            "Super Rod",
            "Sprayduck",
            "Poffin Case",
            "Bike",
            "Suite Key",
            "Oak\'s Letter",
            "Lunar Wing",
            "Member Card",
            "Azure Flute",
            "S.S. Ticket",
            "Contest Pass",
            "Magma Stone",
            "Parcel",
            "Coupon 1",
            "Coupon 2",
            "Coupon 3",
            "Storage Key",
            "Secret Potion",
            "Vs. Recorder",
            "Gracidea",
            "Secret Key",
            "Apricorn Box",
            "Unown Report",
            "Berry Pots",
            "Dowsing Machine",
            "Blue Card",
            "Slowpoke Tail",
            "Clear Bell",
            "Card Key",
            "Basement Key",
            "Squirt Bottle",
            "Red Scale",
            "Lost Item",
            "Pass",
            "Machine Part",
            "Silver Wing",
            "Rainbow Wing",
            "Mystery Egg",
            "Red Apricorn",
            "Blue Apricorn",
            "Yellow Apricorn",
            "Green Apricorn",
            "Pink Apricorn",
            "White Apricorn",
            "Black Apricorn",
            "Fast Ball",
            "Level Ball",
            "Lure Ball",
            "Heavy Ball",
            "Love Ball",
            "Friend Ball",
            "Moon Ball",
            "Sport Ball",
            "Park Ball",
            "Photo Album",
            "GB Sounds",
            "Tidal Bell",
            "Rage Candy Bar",
            "Data Card 01",
            "Data Card 02",
            "Data Card 03",
            "Data Card 04",
            "Data Card 05",
            "Data Card 06",
            "Data Card 07",
            "Data Card 08",
            "Data Card 09",
            "Data Card 10",
            "Data Card 11",
            "Data Card 12",
            "Data Card 13",
            "Data Card 14",
            "Data Card 15",
            "Data Card 16",
            "Data Card 17",
            "Data Card 18",
            "Data Card 19",
            "Data Card 20",
            "Data Card 21",
            "Data Card 22",
            "Data Card 23",
            "Data Card 24",
            "Data Card 25",
            "Data Card 26",
            "Data Card 27",
            "Jade Orb",
            "Lock Capsule",
            "Red Orb",
            "Blue Orb",
            "Enigma Stone",
            "Prism Scale",
            "Eviolite",
            "Float Stone",
            "Rocky Helmet",
            "Air Balloon",
            "Red Card",
            "Ring Target",
            "Binding Band",
            "Absorb Bulb",
            "Cell Battery",
            "Eject Button",
            "Fire Gem",
            "Water Gem",
            "Electric Gem",
            "Grass Gem",
            "Ice Gem",
            "Fighting Gem",
            "Poison Gem",
            "Ground Gem",
            "Flying Gem",
            "Psychic Gem",
            "Bug Gem",
            "Rock Gem",
            "Ghost Gem",
            "Dragon Gem",
            "Dark Gem",
            "Steel Gem",
            "Normal Gem",
            "Health Wing",
            "Muscle Wing",
            "Resist Wing",
            "Genius Wing",
            "Clever Wing",
            "Swift Wing",
            "Pretty Wing",
            "Cover Fossil",
            "Plume Fossil",
            "Libery Pass",
            "Pass Orb",
            "Dream Ball",
            "Poke Toy",
            "Prop Case",
            "Dragon Skull",
            "Balm Mushroom",
            "Big Nugget",
            "Pearl String",
            "Comet Shard",
            "Relic Copper",
            "Relic Silver",
            "Relic Gold",
            "Relic Vase",
            "Relic Band",
            "Relic Statue",
            "Relic Crown",
            "Casteliacone",
            "Dire Hit 2",
            "X Speed 2",
            "X Sp. Atk 2",
            "X Sp. Def 2",
            "X Defense 2",
            "X Attack 2",
            "X Accuracy 2",
            "X Speed 3",
            "X Sp. Atk 3",
            "X Sp. Def 3",
            "X Defense 3",
            "X Attack 3",
            "X Accuracy 3",
            "X Speed 6",
            "X Sp. Atk 6",
            "X Sp. Def 6",
            "X Defense 6",
            "X Attack 6",
            "X Accuracy 6",
            "Ability Urge",
            "Item Drop",
            "Item Urge",
            "Reset Urge",
            "Dire Hit 3",
            "Light Stone",
            "Dark Stone",
            "Wild Charge",
            "Secret Power",
            "Snarl",
            "Xtransceiver(Male)",
            "???",
            "Gram 1",
            "Gram 2",
            "Gram 3",
            "Xtransceiver(Female)",
            "Medal Box",
            "DNA Splicers(Fuses)",
            "DNA Splicers(Seperates)",
            "Permit",
            "Oval Charm",
            "Shiny Charm",
            "Plasma Card",
            "Grubby Hanky",
            "Colress Machine",
            "Dropped Item (Xtransceiver Male)",
            "Dropped Item (Xtransceiver Female)",
            "Reveal Glass",
            "Weakness Policy",
            "Assault Vest",
            "Holo Caster",
            "Prof\'s Letter",
            "Roller Skates",
            "Pixie Plate",
            "Ability Capsule",
            "Whipped Dream",
            "Sachet",
            "Luminous Moss",
            "Snowball",
            "Safety Goggles",
            "Poke Flute",
            "Rich Mulch",
            "Surprise Mulch",
            "Boost Mulch",
            "Amaze Mulch",
            "Gengarite",
            "Gardevoirite",
            "Ampharosite",
            "Venusaurite",
            "Charizardite X",
            "Blastoisinite",
            "Mewtwonite X",
            "Mewtwonite Y",
            "Blazikenite",
            "Medichamite",
            "Houndoominite",
            "Aggronite",
            "Banettite",
            "Tyranitarite",
            "Scizorite",
            "Pinsirite",
            "Aerodactylite",
            "Lucarionite",
            "Abomasite",
            "Kangaskhanite",
            "Gyaradosite",
            "Absolite",
            "Charizardite Y",
            "Alakazite",
            "Heracronite",
            "Mawilite",
            "Manectite",
            "Garchompite",
            "Latiasite",
            "Latiosite",
            "Roseli Berry",
            "Kee Berry",
            "Maranga Berry",
            "Sprinklotad",
            "Nature Power",
            "Dark Pulse",
            "Power-Up Punch",
            "Dazzling Gleam",
            "Confide",
            "Power Plant Pass",
            "Mega Ring",
            "Intruiging Stone",
            "Common Stone",
            "Discount Coupon",
            "Elevator Key",
            "TMV Pass",
            "Honor of Kalos",
            "Adventure Rules",
            "Strange Souvenir",
            "Lens Case",
            "Travel Trunk (Silver)",
            "Travel Trunk (Gold)",
            "Lumiose Galette",
            "Shalour Sable",
            "Jaw Fossil",
            "Sail Fossil",
            "Looker Ticket",
            "Bike",
            "Holo Caster",
            "Fairy Gem",
            "Mega Charm",
            "Mega Glove",
            "Mach Bike",
            "Acro Bike",
            "Wailmer Pail",
            "Devon Parts",
            "Soot Sack",
            "Basement Key",
            "Pokeblock Kit",
            "Letter",
            "Eon Ticket",
            "Scanner",
            "Go-Goggles",
            "Meteorite (originally found)",
            "Key to Room 1",
            "Key to Room 2",
            "Key to Room 4",
            "Key to Room 6",
            "Storage Key",
            "Devon Scope",
            "S.S. Ticket",
            "Dive",
            "Devon Scuba Gear",
            "Contest Costume (Male)",
            "Contest Costume (Female)",
            "Magma Suit",
            "Aqua Suit",
            "Pair of Tickets",
            "Mega Bracelet",
            "Mega Pendant",
            "Mega Glasses",
            "Mega Anchor",
            "Mega Stickpin",
            "Mega Tiara",
            "Mega Anklet",
            "Meteorite (faint glow)",
            "Swampertite",
            "Sceptilite",
            "Sablenite",
            "Altarianite",
            "Galladite",
            "Audinite",
            "Metagrossite",
            "Sharpedonite",
            "Slowbronite",
            "Steelixite",
            "Pidgeotite",
            "Glalitite",
            "Diancite",
            "Prison Bottle",
            "Mega Cuff",
            "Cameruptite",
            "Lopunnite",
            "Salamencite",
            "Beedrillite",
            "Meteorite (1)",
            "Meteorite (2)",
            "Key Stone",
            "Meteorite Shard",
            "Eon Flute"});
            this.items2.Location = new System.Drawing.Point(6, 33);
            this.items2.Name = "items2";
            this.items2.Size = new System.Drawing.Size(121, 21);
            this.items2.TabIndex = 2;
            this.items2.Text = "None";
            // 
            // itemsNum1
            // 
            this.itemsNum1.Location = new System.Drawing.Point(133, 6);
            this.itemsNum1.Name = "itemsNum1";
            this.itemsNum1.Size = new System.Drawing.Size(52, 20);
            this.itemsNum1.TabIndex = 1;
            // 
            // items1
            // 
            this.items1.FormattingEnabled = true;
            this.items1.Items.AddRange(new object[] {
            "None",
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
            "Potion",
            "Antidote",
            "Burn Heal",
            "Ice Heal",
            "Awakening",
            "Paralyze Heal",
            "Full Restore",
            "Max Potion",
            "Hyper Potion",
            "Super Potion",
            "Full Heal",
            "Revive",
            "Max Revive",
            "Fresh Water",
            "Soda Pop",
            "Lemonade",
            "Moomoo Milk",
            "Energy Powder",
            "Energy Root",
            "Heal Powder",
            "Revival Herb",
            "Ether",
            "Max Ether",
            "Elixir",
            "Max Elixir",
            "Lava Cookie",
            "Berry Juice",
            "Sacred Ash",
            "HP Up",
            "Protein",
            "Iron",
            "Carbos",
            "Calcium",
            "Rare Candy",
            "PP Up",
            "Zinc",
            "PP Max",
            "Old Gateau",
            "Guard Spec.",
            "Dire Hit",
            "X Attack",
            "X Defense",
            "X Speed",
            "X Accuracy",
            "X Sp. Atk",
            "X Sp. Def",
            "Poke Doll",
            "Fluffy Tail",
            "Blue Flute",
            "Yellow Flute",
            "Red Flute",
            "Black Flute",
            "White Flute",
            "Shoal Salt",
            "Shoal Shell",
            "Red Shard",
            "Blue Shard",
            "Yellow Shard",
            "Green Shard",
            "Super Repel",
            "Max Repel",
            "Escape Rope",
            "Repel",
            "Sun Stone",
            "Moon Stone",
            "Fire Stone",
            "Thunder Stone",
            "Water Stone",
            "Leaf Stone",
            "Tiny Mushroom",
            "Big Mushroom",
            "Pearl",
            "Big Pearl",
            "Stardust",
            "Star Piece",
            "Nugget",
            "Heart Scale",
            "Honey",
            "Growth Mulch",
            "Damp Mulch",
            "Stable Mulch",
            "Gooey Mulch",
            "Root Fossil",
            "Claw Fossil",
            "Helix Fossil",
            "Dome Fossil",
            "Old Amber",
            "Armor Fossil",
            "Skull Fossil",
            "Rare Bone",
            "Shiny Stone",
            "Dusk Stone",
            "Dawn Stone",
            "Oval Stone",
            "Odd Keystone",
            "Griseous Orb",
            "???",
            "???",
            "???",
            "Douse Drive",
            "Shock Drive",
            "Burn Drive",
            "Chill Drive",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "???",
            "Sweet Heart",
            "Adamant Orb",
            "Lustrous Orb",
            "Greet Mail",
            "Favored Mail",
            "RSVP Mail",
            "Thanks Mail",
            "Inquiry Mail",
            "Like Mail",
            "Reply Mail",
            "Bridge Mail S",
            "Bridge Mail D",
            "Bridge Mail T",
            "Bridge Mail V",
            "Bridge Mail M",
            "Cheri Berry",
            "Chesto Berry",
            "Pecha Berry",
            "Rawst Berry",
            "Aspear Berry",
            "Leppa Berry",
            "Oran Berry",
            "Persim Berry",
            "Lum Berry",
            "Sitrus Berry",
            "Figy Berry",
            "Wiki Berry",
            "Mago Berry",
            "Aguav Berry",
            "Iapapa Berry",
            "Razz Berry",
            "Bluk Berry",
            "Nanab Berry",
            "Wepear Berry",
            "Pinap Berry",
            "Pomeg Berry",
            "Kelpsy Berry",
            "Qualot Berry",
            "Hondew Berry",
            "Grepa Berry",
            "Tamato Berry",
            "Cornn Berry",
            "Magost Berry",
            "Rabuta Berry",
            "Nomel Berry",
            "Spelon Berry",
            "Pamtre Berry",
            "Watmel Berry",
            "Durin Berry",
            "Belue Berry",
            "Occa Berry",
            "Passho Berry",
            "Wacan Berry",
            "Rindo Berry",
            "Yache Berry",
            "Chople Berry",
            "Kebai Berry",
            "Shuca Berry",
            "Coba Berry",
            "Payapa Berry",
            "Tanga Berry",
            "Charti Berry",
            "Kasib Berry",
            "Haban Berry",
            "Colbur Berry",
            "Babiri Berry",
            "Chilan Berry",
            "Liechi Berry",
            "Ganlon Berry",
            "Salac Berry",
            "Petaya Berry",
            "Apicot Berry",
            "Lansat Berry",
            "Starf Berry",
            "Enigma Berry",
            "Micle Berry",
            "Custap Berry",
            "Jaboca Berry",
            "Rowap Berry",
            "Bright Powder",
            "White Herb",
            "Macho Brace",
            "Exp. Share",
            "Quick Claw",
            "Soothe Bell",
            "Mental Herb",
            "Choice Band",
            "King\'s Rock",
            "Silver Powder",
            "Amulet Coin",
            "Cleanse Tag",
            "Soul Dew",
            "Deep Sea Tooth",
            "Deep Sea Scale",
            "Smoke Ball",
            "Everstone",
            "Focus Band",
            "Lucky Egg",
            "Scope Lens",
            "Metal Coat",
            "Leftovers",
            "Dragon Scale",
            "Light Ball",
            "Soft Sand",
            "Hard Stone",
            "Miracle Seed",
            "Black Glasses",
            "Black Belt",
            "Magnet",
            "Mystic Water",
            "Sharp Beak",
            "Poison Barb",
            "Never-Melt Ice",
            "Spell Tag",
            "Twisted Spoon",
            "Charcoal",
            "Dragon Fang",
            "Silk Scarf",
            "Up-Grade",
            "Shell Bell",
            "Sea Incense",
            "Lax Incense",
            "Lucky Punch",
            "Metal Powder",
            "Thick Club",
            "Stick",
            "Red Scarf",
            "Blue Scarf",
            "Pink Scarf",
            "Green Scarf",
            "Yellow Scarf",
            "Wide Lens",
            "Muscle Band",
            "Wise Glasses",
            "Expert Belt",
            "Light Clay",
            "Life Orb",
            "Power Herb",
            "Toxic Orb",
            "Flame Orb",
            "Quick Powder",
            "Focus Sash",
            "Zoom Lens",
            "Metronome",
            "Iron Ball",
            "Lagging Tail",
            "Destiny Knot",
            "Black Sludge",
            "Icy Rock",
            "Smooth Rock",
            "Heat Rock",
            "Damp Rock",
            "Grip Claw",
            "Choice Scarf",
            "Sticky Barb",
            "Power Bracer",
            "Power Belt",
            "Power Lens",
            "Power Band",
            "Power Anklet",
            "Power Weight",
            "Shed Shell",
            "Big Root",
            "Choice Specs",
            "Flame Plate",
            "Splash Plate",
            "Zap Plate",
            "Meadow Plate",
            "Icicle Plate",
            "Fist Plate",
            "Toxic Plate",
            "Earth Plate",
            "Sky Plate",
            "Mind Plate",
            "Insect Plate",
            "Stone Plate",
            "Spooky Plate",
            "Draco Plate",
            "Dread Plate",
            "Iron Plate",
            "Odd Incense",
            "Rock Incense",
            "Full Incense",
            "Wave Incense",
            "Rose Incense",
            "Luck Incense",
            "Pure Incense",
            "Protector",
            "Electrizer",
            "Magmarizer",
            "Dubious Disc",
            "Reaper Cloth",
            "Razor Claw",
            "Razor Fang",
            "Hone Claws",
            "Dragon Claw",
            "Psyshock",
            "Calm Mind",
            "Roar",
            "Toxic",
            "Hail",
            "Bulk Up",
            "Venoshock",
            "Hidden Power",
            "Sunny Day",
            "Taunt",
            "Ice Beam",
            "Blizzard",
            "Hyper Beam",
            "Light Screen",
            "Protect",
            "Rain Dance",
            "Roost",
            "Safeguard",
            "Frustration",
            "Solar Beam",
            "Smack Down",
            "Thunderbolt",
            "Thunder",
            "Earthquake",
            "Return",
            "Dig",
            "Psychic",
            "Shadow Ball",
            "Brick Break",
            "Double Team",
            "Reflect",
            "Sludge Wave",
            "Flamethrower",
            "Sludge Bomb",
            "Sandstorm",
            "Fire Blast",
            "Rock Tomb",
            "Aerial Ace",
            "Torment",
            "Facade",
            "Flame Charge",
            "Rest",
            "Attract",
            "Thief",
            "Low Sweep",
            "Round",
            "Echoed Voice",
            "Overheat",
            "Steel Wing",
            "Focus Blast",
            "Energy Ball",
            "False Swipe",
            "Scald",
            "Fling",
            "Charge Beam",
            "Sky Drop",
            "Incinerate",
            "Quash",
            "Will-O-Wisp",
            "Acrobatics",
            "Embargo",
            "Explosion",
            "Shadow Claw",
            "Payback",
            "Retaliate",
            "Giga Impact",
            "Rock Polish",
            "Flash",
            "Stone Edge",
            "Volt Switch",
            "Thunder Wave",
            "Gyro Ball",
            "Swords Dance",
            "Struggle Bug",
            "Psych Up",
            "Bulldoze",
            "Frost Breath",
            "Rock Slide",
            "X-Scissor",
            "Dragon Tail",
            "Infestation",
            "Poison Jab",
            "Dream Eater",
            "Grass Knot",
            "Swagger",
            "Sleep Talk",
            "U-turn",
            "Substitute",
            "Flash Cannon",
            "Trick Room",
            "Cut",
            "Fly",
            "Surf",
            "Strength",
            "Waterfall",
            "Rock Smash",
            "???",
            "???",
            "Explorer Kit",
            "Loot Sack",
            "Rule Book",
            "Poke Radar",
            "Point Card",
            "Journal",
            "Seal Case",
            "Fashion Case",
            "Seal Bag",
            "Pal Pad",
            "Works key",
            "Old Charm",
            "Galactic Key",
            "Red Chain",
            "Town Map",
            "Vs. Seeker",
            "Coin Case",
            "Old Rod",
            "Good Rod",
            "Super Rod",
            "Sprayduck",
            "Poffin Case",
            "Bike",
            "Suite Key",
            "Oak\'s Letter",
            "Lunar Wing",
            "Member Card",
            "Azure Flute",
            "S.S. Ticket",
            "Contest Pass",
            "Magma Stone",
            "Parcel",
            "Coupon 1",
            "Coupon 2",
            "Coupon 3",
            "Storage Key",
            "Secret Potion",
            "Vs. Recorder",
            "Gracidea",
            "Secret Key",
            "Apricorn Box",
            "Unown Report",
            "Berry Pots",
            "Dowsing Machine",
            "Blue Card",
            "Slowpoke Tail",
            "Clear Bell",
            "Card Key",
            "Basement Key",
            "Squirt Bottle",
            "Red Scale",
            "Lost Item",
            "Pass",
            "Machine Part",
            "Silver Wing",
            "Rainbow Wing",
            "Mystery Egg",
            "Red Apricorn",
            "Blue Apricorn",
            "Yellow Apricorn",
            "Green Apricorn",
            "Pink Apricorn",
            "White Apricorn",
            "Black Apricorn",
            "Fast Ball",
            "Level Ball",
            "Lure Ball",
            "Heavy Ball",
            "Love Ball",
            "Friend Ball",
            "Moon Ball",
            "Sport Ball",
            "Park Ball",
            "Photo Album",
            "GB Sounds",
            "Tidal Bell",
            "Rage Candy Bar",
            "Data Card 01",
            "Data Card 02",
            "Data Card 03",
            "Data Card 04",
            "Data Card 05",
            "Data Card 06",
            "Data Card 07",
            "Data Card 08",
            "Data Card 09",
            "Data Card 10",
            "Data Card 11",
            "Data Card 12",
            "Data Card 13",
            "Data Card 14",
            "Data Card 15",
            "Data Card 16",
            "Data Card 17",
            "Data Card 18",
            "Data Card 19",
            "Data Card 20",
            "Data Card 21",
            "Data Card 22",
            "Data Card 23",
            "Data Card 24",
            "Data Card 25",
            "Data Card 26",
            "Data Card 27",
            "Jade Orb",
            "Lock Capsule",
            "Red Orb",
            "Blue Orb",
            "Enigma Stone",
            "Prism Scale",
            "Eviolite",
            "Float Stone",
            "Rocky Helmet",
            "Air Balloon",
            "Red Card",
            "Ring Target",
            "Binding Band",
            "Absorb Bulb",
            "Cell Battery",
            "Eject Button",
            "Fire Gem",
            "Water Gem",
            "Electric Gem",
            "Grass Gem",
            "Ice Gem",
            "Fighting Gem",
            "Poison Gem",
            "Ground Gem",
            "Flying Gem",
            "Psychic Gem",
            "Bug Gem",
            "Rock Gem",
            "Ghost Gem",
            "Dragon Gem",
            "Dark Gem",
            "Steel Gem",
            "Normal Gem",
            "Health Wing",
            "Muscle Wing",
            "Resist Wing",
            "Genius Wing",
            "Clever Wing",
            "Swift Wing",
            "Pretty Wing",
            "Cover Fossil",
            "Plume Fossil",
            "Libery Pass",
            "Pass Orb",
            "Dream Ball",
            "Poke Toy",
            "Prop Case",
            "Dragon Skull",
            "Balm Mushroom",
            "Big Nugget",
            "Pearl String",
            "Comet Shard",
            "Relic Copper",
            "Relic Silver",
            "Relic Gold",
            "Relic Vase",
            "Relic Band",
            "Relic Statue",
            "Relic Crown",
            "Casteliacone",
            "Dire Hit 2",
            "X Speed 2",
            "X Sp. Atk 2",
            "X Sp. Def 2",
            "X Defense 2",
            "X Attack 2",
            "X Accuracy 2",
            "X Speed 3",
            "X Sp. Atk 3",
            "X Sp. Def 3",
            "X Defense 3",
            "X Attack 3",
            "X Accuracy 3",
            "X Speed 6",
            "X Sp. Atk 6",
            "X Sp. Def 6",
            "X Defense 6",
            "X Attack 6",
            "X Accuracy 6",
            "Ability Urge",
            "Item Drop",
            "Item Urge",
            "Reset Urge",
            "Dire Hit 3",
            "Light Stone",
            "Dark Stone",
            "Wild Charge",
            "Secret Power",
            "Snarl",
            "Xtransceiver(Male)",
            "???",
            "Gram 1",
            "Gram 2",
            "Gram 3",
            "Xtransceiver(Female)",
            "Medal Box",
            "DNA Splicers(Fuses)",
            "DNA Splicers(Seperates)",
            "Permit",
            "Oval Charm",
            "Shiny Charm",
            "Plasma Card",
            "Grubby Hanky",
            "Colress Machine",
            "Dropped Item (Xtransceiver Male)",
            "Dropped Item (Xtransceiver Female)",
            "Reveal Glass",
            "Weakness Policy",
            "Assault Vest",
            "Holo Caster",
            "Prof\'s Letter",
            "Roller Skates",
            "Pixie Plate",
            "Ability Capsule",
            "Whipped Dream",
            "Sachet",
            "Luminous Moss",
            "Snowball",
            "Safety Goggles",
            "Poke Flute",
            "Rich Mulch",
            "Surprise Mulch",
            "Boost Mulch",
            "Amaze Mulch",
            "Gengarite",
            "Gardevoirite",
            "Ampharosite",
            "Venusaurite",
            "Charizardite X",
            "Blastoisinite",
            "Mewtwonite X",
            "Mewtwonite Y",
            "Blazikenite",
            "Medichamite",
            "Houndoominite",
            "Aggronite",
            "Banettite",
            "Tyranitarite",
            "Scizorite",
            "Pinsirite",
            "Aerodactylite",
            "Lucarionite",
            "Abomasite",
            "Kangaskhanite",
            "Gyaradosite",
            "Absolite",
            "Charizardite Y",
            "Alakazite",
            "Heracronite",
            "Mawilite",
            "Manectite",
            "Garchompite",
            "Latiasite",
            "Latiosite",
            "Roseli Berry",
            "Kee Berry",
            "Maranga Berry",
            "Sprinklotad",
            "Nature Power",
            "Dark Pulse",
            "Power-Up Punch",
            "Dazzling Gleam",
            "Confide",
            "Power Plant Pass",
            "Mega Ring",
            "Intruiging Stone",
            "Common Stone",
            "Discount Coupon",
            "Elevator Key",
            "TMV Pass",
            "Honor of Kalos",
            "Adventure Rules",
            "Strange Souvenir",
            "Lens Case",
            "Travel Trunk (Silver)",
            "Travel Trunk (Gold)",
            "Lumiose Galette",
            "Shalour Sable",
            "Jaw Fossil",
            "Sail Fossil",
            "Looker Ticket",
            "Bike",
            "Holo Caster",
            "Fairy Gem",
            "Mega Charm",
            "Mega Glove",
            "Mach Bike",
            "Acro Bike",
            "Wailmer Pail",
            "Devon Parts",
            "Soot Sack",
            "Basement Key",
            "Pokeblock Kit",
            "Letter",
            "Eon Ticket",
            "Scanner",
            "Go-Goggles",
            "Meteorite (originally found)",
            "Key to Room 1",
            "Key to Room 2",
            "Key to Room 4",
            "Key to Room 6",
            "Storage Key",
            "Devon Scope",
            "S.S. Ticket",
            "Dive",
            "Devon Scuba Gear",
            "Contest Costume (Male)",
            "Contest Costume (Female)",
            "Magma Suit",
            "Aqua Suit",
            "Pair of Tickets",
            "Mega Bracelet",
            "Mega Pendant",
            "Mega Glasses",
            "Mega Anchor",
            "Mega Stickpin",
            "Mega Tiara",
            "Mega Anklet",
            "Meteorite (faint glow)",
            "Swampertite",
            "Sceptilite",
            "Sablenite",
            "Altarianite",
            "Galladite",
            "Audinite",
            "Metagrossite",
            "Sharpedonite",
            "Slowbronite",
            "Steelixite",
            "Pidgeotite",
            "Glalitite",
            "Diancite",
            "Prison Bottle",
            "Mega Cuff",
            "Cameruptite",
            "Lopunnite",
            "Salamencite",
            "Beedrillite",
            "Meteorite (1)",
            "Meteorite (2)",
            "Key Stone",
            "Meteorite Shard",
            "Eon Flute"});
            this.items1.Location = new System.Drawing.Point(6, 6);
            this.items1.Name = "items1";
            this.items1.Size = new System.Drawing.Size(121, 21);
            this.items1.TabIndex = 0;
            this.items1.Text = "None";
            this.items1.SelectedIndexChanged += new System.EventHandler(this.items1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(877, 400);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Medicine";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.groupBox2.Location = new System.Drawing.Point(12, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 159);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit Trainer";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "TID:";
            // 
            // TIDNum
            // 
            this.TIDNum.Enabled = false;
            this.TIDNum.Location = new System.Drawing.Point(8, 83);
            this.TIDNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.TIDNum.Name = "TIDNum";
            this.TIDNum.Size = new System.Drawing.Size(80, 20);
            this.TIDNum.TabIndex = 29;
            // 
            // pokeTID
            // 
            this.pokeTID.Enabled = false;
            this.pokeTID.Location = new System.Drawing.Point(95, 80);
            this.pokeTID.Name = "pokeTID";
            this.pokeTID.Size = new System.Drawing.Size(45, 23);
            this.pokeTID.TabIndex = 30;
            this.pokeTID.Text = "Write";
            this.pokeTID.UseVisualStyleBackColor = true;
            this.pokeTID.Click += new System.EventHandler(this.pokeTID_Click);
            // 
            // pokeTime
            // 
            this.pokeTime.Enabled = false;
            this.pokeTime.Location = new System.Drawing.Point(155, 128);
            this.pokeTime.Name = "pokeTime";
            this.pokeTime.Size = new System.Drawing.Size(45, 23);
            this.pokeTime.TabIndex = 33;
            this.pokeTime.Text = "Write";
            this.pokeTime.UseVisualStyleBackColor = true;
            this.pokeTime.Click += new System.EventHandler(this.pokeTime_Click);
            // 
            // hourNum
            // 
            this.hourNum.Enabled = false;
            this.hourNum.Location = new System.Drawing.Point(8, 131);
            this.hourNum.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.hourNum.Name = "hourNum";
            this.hourNum.Size = new System.Drawing.Size(59, 20);
            this.hourNum.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Hours:";
            // 
            // minNum
            // 
            this.minNum.Enabled = false;
            this.minNum.Location = new System.Drawing.Point(73, 131);
            this.minNum.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minNum.Name = "minNum";
            this.minNum.Size = new System.Drawing.Size(35, 20);
            this.minNum.TabIndex = 34;
            // 
            // secNum
            // 
            this.secNum.Enabled = false;
            this.secNum.Location = new System.Drawing.Point(114, 131);
            this.secNum.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secNum.Name = "secNum";
            this.secNum.Size = new System.Drawing.Size(35, 20);
            this.secNum.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(73, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Mins:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(114, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Secs:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 365);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.editMoney);
            this.Controls.Add(this.writeBox);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.editMiles);
            this.Controls.Add(this.dumpBox);
            this.Controls.Add(this.editBP);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PKMN NTR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.milesNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpNum)).EndInit();
            this.editMoney.ResumeLayout(false);
            this.editMoney.PerformLayout();
            this.editMiles.ResumeLayout(false);
            this.editMiles.PerformLayout();
            this.editBP.ResumeLayout(false);
            this.editBP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slot)).EndInit();
            this.dumpBox.ResumeLayout(false);
            this.dumpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slotDump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxDump)).EndInit();
            this.writeBox.ResumeLayout(false);
            this.writeBox.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsNum2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsNum1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TIDNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtLog;
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
        private System.Windows.Forms.GroupBox editMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox editMiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox editBP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectPkx;
        private System.Windows.Forms.Button pokePkm;
        private System.Windows.Forms.NumericUpDown box;
        private System.Windows.Forms.NumericUpDown slot;
        private System.Windows.Forms.GroupBox dumpBox;
        private System.Windows.Forms.GroupBox writeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button dumpPkx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown slotDump;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown boxDump;
        private System.Windows.Forms.TextBox namePkx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button dumpBoxes;
        private System.Windows.Forms.RadioButton radioDaycare;
        private System.Windows.Forms.RadioButton radioBoxes;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabItems;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.NumericUpDown itemsNum1;
        private System.Windows.Forms.ComboBox items1;
        private System.Windows.Forms.NumericUpDown itemsNum2;
        private System.Windows.Forms.ComboBox items2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button pokeName;
        private System.Windows.Forms.TextBox playerName;
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
    }
}

