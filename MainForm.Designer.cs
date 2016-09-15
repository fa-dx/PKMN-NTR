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
            this.radioBoxes = new System.Windows.Forms.RadioButton();
            this.radioDaycare = new System.Windows.Forms.RadioButton();
            this.radioOpponent = new System.Windows.Forms.RadioButton();
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
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtLog.Location = new System.Drawing.Point(871, 362);
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
            this.groupBox1.Location = new System.Drawing.Point(387, 119);
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
            this.moneyNum.Size = new System.Drawing.Size(82, 20);
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
            this.milesNum.Size = new System.Drawing.Size(82, 20);
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
            this.bpNum.Size = new System.Drawing.Size(82, 20);
            this.bpNum.TabIndex = 9;
            // 
            // pokeMoney
            // 
            this.pokeMoney.Enabled = false;
            this.pokeMoney.Location = new System.Drawing.Point(94, 33);
            this.pokeMoney.Name = "pokeMoney";
            this.pokeMoney.Size = new System.Drawing.Size(54, 23);
            this.pokeMoney.TabIndex = 10;
            this.pokeMoney.Text = "Write";
            this.pokeMoney.UseVisualStyleBackColor = true;
            this.pokeMoney.Click += new System.EventHandler(this.pokeMoney_Click);
            // 
            // pokeMiles
            // 
            this.pokeMiles.Enabled = false;
            this.pokeMiles.Location = new System.Drawing.Point(94, 33);
            this.pokeMiles.Name = "pokeMiles";
            this.pokeMiles.Size = new System.Drawing.Size(54, 23);
            this.pokeMiles.TabIndex = 11;
            this.pokeMiles.Text = "Write";
            this.pokeMiles.UseVisualStyleBackColor = true;
            this.pokeMiles.Click += new System.EventHandler(this.pokeMiles_Click);
            // 
            // pokeBP
            // 
            this.pokeBP.Enabled = false;
            this.pokeBP.Location = new System.Drawing.Point(94, 33);
            this.pokeBP.Name = "pokeBP";
            this.pokeBP.Size = new System.Drawing.Size(54, 23);
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
            this.editMoney.Location = new System.Drawing.Point(12, 12);
            this.editMoney.Name = "editMoney";
            this.editMoney.Size = new System.Drawing.Size(154, 62);
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
            this.editMiles.Location = new System.Drawing.Point(332, 12);
            this.editMiles.Name = "editMiles";
            this.editMiles.Size = new System.Drawing.Size(154, 62);
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
            this.editBP.Location = new System.Drawing.Point(172, 12);
            this.editBP.Name = "editBP";
            this.editBP.Size = new System.Drawing.Size(154, 62);
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
            this.dumpBox.Controls.Add(this.radioOpponent);
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
            this.writeBox.Location = new System.Drawing.Point(227, 103);
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
            // radioBoxes
            // 
            this.radioBoxes.AutoSize = true;
            this.radioBoxes.Checked = true;
            this.radioBoxes.Enabled = false;
            this.radioBoxes.Location = new System.Drawing.Point(6, 90);
            this.radioBoxes.Name = "radioBoxes";
            this.radioBoxes.Size = new System.Drawing.Size(54, 17);
            this.radioBoxes.TabIndex = 32;
            this.radioBoxes.TabStop = true;
            this.radioBoxes.Text = "Boxes";
            this.radioBoxes.UseVisualStyleBackColor = true;
            this.radioBoxes.CheckedChanged += new System.EventHandler(this.radioBoxes_CheckedChanged);
            // 
            // radioDaycare
            // 
            this.radioDaycare.AutoSize = true;
            this.radioDaycare.Enabled = false;
            this.radioDaycare.Location = new System.Drawing.Point(142, 90);
            this.radioDaycare.Name = "radioDaycare";
            this.radioDaycare.Size = new System.Drawing.Size(65, 17);
            this.radioDaycare.TabIndex = 33;
            this.radioDaycare.Text = "Daycare";
            this.radioDaycare.UseVisualStyleBackColor = true;
            this.radioDaycare.CheckedChanged += new System.EventHandler(this.radioDaycare_CheckedChanged);
            // 
            // radioOpponent
            // 
            this.radioOpponent.AutoSize = true;
            this.radioOpponent.Enabled = false;
            this.radioOpponent.Location = new System.Drawing.Point(66, 90);
            this.radioOpponent.Name = "radioOpponent";
            this.radioOpponent.Size = new System.Drawing.Size(72, 17);
            this.radioOpponent.TabIndex = 34;
            this.radioOpponent.Text = "Opponent";
            this.radioOpponent.UseVisualStyleBackColor = true;
            this.radioOpponent.CheckedChanged += new System.EventHandler(this.radioOpponent_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 197);
            this.Controls.Add(this.writeBox);
            this.Controls.Add(this.dumpBox);
            this.Controls.Add(this.editBP);
            this.Controls.Add(this.editMiles);
            this.Controls.Add(this.editMoney);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PKMN NTR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CmdWindow_FormClosed);
            this.Load += new System.EventHandler(this.CmdWindow_Load);
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
        private System.Windows.Forms.RadioButton radioOpponent;
        private System.Windows.Forms.RadioButton radioDaycare;
        private System.Windows.Forms.RadioButton radioBoxes;
    }
}

