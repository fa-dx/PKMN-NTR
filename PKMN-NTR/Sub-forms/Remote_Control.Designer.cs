namespace pkmn_ntr.Sub_forms
{
    partial class Remote_Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remote_Control));
            this.Remote_Stick = new System.Windows.Forms.GroupBox();
            this.StickX = new System.Windows.Forms.TrackBar();
            this.StickY = new System.Windows.Forms.TrackBar();
            this.StickNumY = new System.Windows.Forms.NumericUpDown();
            this.StickSend = new System.Windows.Forms.Button();
            this.StickNumX = new System.Windows.Forms.NumericUpDown();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.Remote_touch = new System.Windows.Forms.GroupBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.touchX = new System.Windows.Forms.NumericUpDown();
            this.touchY = new System.Windows.Forms.NumericUpDown();
            this.manualTouch = new System.Windows.Forms.Button();
            this.Remote_buttons = new System.Windows.Forms.GroupBox();
            this.manualDUp = new System.Windows.Forms.Button();
            this.manualA = new System.Windows.Forms.Button();
            this.manualR = new System.Windows.Forms.Button();
            this.manualB = new System.Windows.Forms.Button();
            this.manualL = new System.Windows.Forms.Button();
            this.manualSelect = new System.Windows.Forms.Button();
            this.manualDRight = new System.Windows.Forms.Button();
            this.ManualDDown = new System.Windows.Forms.Button();
            this.manualY = new System.Windows.Forms.Button();
            this.manualStart = new System.Windows.Forms.Button();
            this.manualX = new System.Windows.Forms.Button();
            this.manualDLeft = new System.Windows.Forms.Button();
            this.manualSR = new System.Windows.Forms.Button();
            this.Remote_Stick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StickX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickNumY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickNumX)).BeginInit();
            this.Remote_touch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touchX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.touchY)).BeginInit();
            this.Remote_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // Remote_Stick
            // 
            this.Remote_Stick.Controls.Add(this.StickX);
            this.Remote_Stick.Controls.Add(this.StickY);
            this.Remote_Stick.Controls.Add(this.StickNumY);
            this.Remote_Stick.Controls.Add(this.StickSend);
            this.Remote_Stick.Controls.Add(this.StickNumX);
            this.Remote_Stick.Controls.Add(this.label62);
            this.Remote_Stick.Controls.Add(this.label61);
            this.Remote_Stick.Location = new System.Drawing.Point(290, 12);
            this.Remote_Stick.Name = "Remote_Stick";
            this.Remote_Stick.Size = new System.Drawing.Size(268, 154);
            this.Remote_Stick.TabIndex = 2;
            this.Remote_Stick.TabStop = false;
            this.Remote_Stick.Text = "Control Stick";
            // 
            // StickX
            // 
            this.StickX.Location = new System.Drawing.Point(57, 103);
            this.StickX.Maximum = 100;
            this.StickX.Minimum = -100;
            this.StickX.Name = "StickX";
            this.StickX.Size = new System.Drawing.Size(205, 45);
            this.StickX.TabIndex = 1;
            this.StickX.TickFrequency = 25;
            this.StickX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.StickX.Scroll += new System.EventHandler(this.StickX_Scroll);
            // 
            // StickY
            // 
            this.StickY.Location = new System.Drawing.Point(6, 19);
            this.StickY.Maximum = 100;
            this.StickY.Minimum = -100;
            this.StickY.Name = "StickY";
            this.StickY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.StickY.Size = new System.Drawing.Size(45, 129);
            this.StickY.TabIndex = 0;
            this.StickY.TickFrequency = 25;
            this.StickY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.StickY.Scroll += new System.EventHandler(this.StickY_Scroll);
            // 
            // StickNumY
            // 
            this.StickNumY.Location = new System.Drawing.Point(57, 22);
            this.StickNumY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.StickNumY.Name = "StickNumY";
            this.StickNumY.Size = new System.Drawing.Size(100, 20);
            this.StickNumY.TabIndex = 2;
            this.StickNumY.ValueChanged += new System.EventHandler(this.StickNumY_ValueChanged);
            // 
            // StickSend
            // 
            this.StickSend.Location = new System.Drawing.Point(57, 63);
            this.StickSend.Name = "StickSend";
            this.StickSend.Size = new System.Drawing.Size(205, 23);
            this.StickSend.TabIndex = 4;
            this.StickSend.Text = "Send Command";
            this.StickSend.UseVisualStyleBackColor = true;
            this.StickSend.Click += new System.EventHandler(this.StickSend_Click);
            // 
            // StickNumX
            // 
            this.StickNumX.Location = new System.Drawing.Point(163, 22);
            this.StickNumX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.StickNumX.Name = "StickNumX";
            this.StickNumX.Size = new System.Drawing.Size(99, 20);
            this.StickNumX.TabIndex = 3;
            this.StickNumX.ValueChanged += new System.EventHandler(this.StickNumX_ValueChanged);
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(163, 45);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(99, 18);
            this.label62.TabIndex = 25;
            this.label62.Text = "Horizontal";
            this.label62.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(57, 45);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(100, 18);
            this.label61.TabIndex = 24;
            this.label61.Text = "Vertical";
            this.label61.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Remote_touch
            // 
            this.Remote_touch.AutoSize = true;
            this.Remote_touch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Remote_touch.Controls.Add(this.label54);
            this.Remote_touch.Controls.Add(this.label30);
            this.Remote_touch.Controls.Add(this.touchX);
            this.Remote_touch.Controls.Add(this.touchY);
            this.Remote_touch.Controls.Add(this.manualTouch);
            this.Remote_touch.Location = new System.Drawing.Point(12, 127);
            this.Remote_touch.Name = "Remote_touch";
            this.Remote_touch.Size = new System.Drawing.Size(272, 71);
            this.Remote_touch.TabIndex = 1;
            this.Remote_touch.TabStop = false;
            this.Remote_touch.Text = "Touchscreen";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(72, 42);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(61, 13);
            this.label54.TabIndex = 15;
            this.label54.Text = "Y (from top)";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 42);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(60, 13);
            this.label30.TabIndex = 15;
            this.label30.Text = "X (from left)";
            // 
            // touchX
            // 
            this.touchX.Location = new System.Drawing.Point(6, 19);
            this.touchX.Maximum = new decimal(new int[] {
            319,
            0,
            0,
            0});
            this.touchX.Name = "touchX";
            this.touchX.Size = new System.Drawing.Size(60, 20);
            this.touchX.TabIndex = 0;
            // 
            // touchY
            // 
            this.touchY.Location = new System.Drawing.Point(72, 19);
            this.touchY.Maximum = new decimal(new int[] {
            239,
            0,
            0,
            0});
            this.touchY.Name = "touchY";
            this.touchY.Size = new System.Drawing.Size(60, 20);
            this.touchY.TabIndex = 1;
            // 
            // manualTouch
            // 
            this.manualTouch.Location = new System.Drawing.Point(138, 16);
            this.manualTouch.Name = "manualTouch";
            this.manualTouch.Size = new System.Drawing.Size(128, 23);
            this.manualTouch.TabIndex = 2;
            this.manualTouch.Text = "Touch";
            this.manualTouch.UseVisualStyleBackColor = true;
            this.manualTouch.Click += new System.EventHandler(this.manualTouch_Click);
            // 
            // Remote_buttons
            // 
            this.Remote_buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Remote_buttons.Controls.Add(this.manualDUp);
            this.Remote_buttons.Controls.Add(this.manualA);
            this.Remote_buttons.Controls.Add(this.manualR);
            this.Remote_buttons.Controls.Add(this.manualB);
            this.Remote_buttons.Controls.Add(this.manualL);
            this.Remote_buttons.Controls.Add(this.manualSelect);
            this.Remote_buttons.Controls.Add(this.manualDRight);
            this.Remote_buttons.Controls.Add(this.ManualDDown);
            this.Remote_buttons.Controls.Add(this.manualY);
            this.Remote_buttons.Controls.Add(this.manualStart);
            this.Remote_buttons.Controls.Add(this.manualX);
            this.Remote_buttons.Controls.Add(this.manualDLeft);
            this.Remote_buttons.Location = new System.Drawing.Point(12, 12);
            this.Remote_buttons.Name = "Remote_buttons";
            this.Remote_buttons.Size = new System.Drawing.Size(272, 109);
            this.Remote_buttons.TabIndex = 0;
            this.Remote_buttons.TabStop = false;
            this.Remote_buttons.Text = "Buttons";
            // 
            // manualDUp
            // 
            this.manualDUp.Location = new System.Drawing.Point(35, 19);
            this.manualDUp.Name = "manualDUp";
            this.manualDUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.manualDUp.Size = new System.Drawing.Size(23, 23);
            this.manualDUp.TabIndex = 4;
            this.manualDUp.Text = "↑";
            this.manualDUp.UseVisualStyleBackColor = true;
            this.manualDUp.Click += new System.EventHandler(this.manualDUp_Click);
            // 
            // manualA
            // 
            this.manualA.Location = new System.Drawing.Point(243, 46);
            this.manualA.Name = "manualA";
            this.manualA.Size = new System.Drawing.Size(23, 23);
            this.manualA.TabIndex = 0;
            this.manualA.Text = "A";
            this.manualA.UseVisualStyleBackColor = true;
            this.manualA.Click += new System.EventHandler(this.manualA_Click);
            // 
            // manualR
            // 
            this.manualR.Location = new System.Drawing.Point(146, 19);
            this.manualR.Name = "manualR";
            this.manualR.Size = new System.Drawing.Size(23, 23);
            this.manualR.TabIndex = 9;
            this.manualR.Text = "R";
            this.manualR.UseVisualStyleBackColor = true;
            this.manualR.Click += new System.EventHandler(this.manualR_Click);
            // 
            // manualB
            // 
            this.manualB.Location = new System.Drawing.Point(214, 74);
            this.manualB.Name = "manualB";
            this.manualB.Size = new System.Drawing.Size(23, 23);
            this.manualB.TabIndex = 1;
            this.manualB.Text = "B";
            this.manualB.UseVisualStyleBackColor = true;
            this.manualB.Click += new System.EventHandler(this.manualB_Click);
            // 
            // manualL
            // 
            this.manualL.Location = new System.Drawing.Point(103, 19);
            this.manualL.Name = "manualL";
            this.manualL.Size = new System.Drawing.Size(23, 23);
            this.manualL.TabIndex = 8;
            this.manualL.Text = "L";
            this.manualL.UseVisualStyleBackColor = true;
            this.manualL.Click += new System.EventHandler(this.manualL_Click);
            // 
            // manualSelect
            // 
            this.manualSelect.Location = new System.Drawing.Point(146, 74);
            this.manualSelect.Name = "manualSelect";
            this.manualSelect.Size = new System.Drawing.Size(62, 23);
            this.manualSelect.TabIndex = 11;
            this.manualSelect.Text = "SELECT";
            this.manualSelect.UseVisualStyleBackColor = true;
            this.manualSelect.Click += new System.EventHandler(this.manualSelect_Click);
            // 
            // manualDRight
            // 
            this.manualDRight.Location = new System.Drawing.Point(64, 46);
            this.manualDRight.Name = "manualDRight";
            this.manualDRight.Size = new System.Drawing.Size(23, 23);
            this.manualDRight.TabIndex = 7;
            this.manualDRight.Text = "→";
            this.manualDRight.UseVisualStyleBackColor = true;
            this.manualDRight.Click += new System.EventHandler(this.manualDRight_Click);
            // 
            // ManualDDown
            // 
            this.ManualDDown.Location = new System.Drawing.Point(35, 74);
            this.ManualDDown.Name = "ManualDDown";
            this.ManualDDown.Size = new System.Drawing.Size(23, 23);
            this.ManualDDown.TabIndex = 5;
            this.ManualDDown.Text = "↓";
            this.ManualDDown.UseVisualStyleBackColor = true;
            this.ManualDDown.Click += new System.EventHandler(this.ManualDDown_Click);
            // 
            // manualY
            // 
            this.manualY.Location = new System.Drawing.Point(185, 46);
            this.manualY.Name = "manualY";
            this.manualY.Size = new System.Drawing.Size(23, 23);
            this.manualY.TabIndex = 3;
            this.manualY.Text = "Y";
            this.manualY.UseVisualStyleBackColor = true;
            this.manualY.Click += new System.EventHandler(this.manualY_Click);
            // 
            // manualStart
            // 
            this.manualStart.Location = new System.Drawing.Point(64, 74);
            this.manualStart.Name = "manualStart";
            this.manualStart.Size = new System.Drawing.Size(62, 23);
            this.manualStart.TabIndex = 10;
            this.manualStart.Text = "START";
            this.manualStart.UseVisualStyleBackColor = true;
            this.manualStart.Click += new System.EventHandler(this.manualStart_Click);
            // 
            // manualX
            // 
            this.manualX.Location = new System.Drawing.Point(214, 19);
            this.manualX.Name = "manualX";
            this.manualX.Size = new System.Drawing.Size(23, 23);
            this.manualX.TabIndex = 2;
            this.manualX.Text = "X";
            this.manualX.UseVisualStyleBackColor = true;
            this.manualX.Click += new System.EventHandler(this.manualX_Click);
            // 
            // manualDLeft
            // 
            this.manualDLeft.Location = new System.Drawing.Point(6, 46);
            this.manualDLeft.Name = "manualDLeft";
            this.manualDLeft.Size = new System.Drawing.Size(23, 23);
            this.manualDLeft.TabIndex = 6;
            this.manualDLeft.Text = "←";
            this.manualDLeft.UseVisualStyleBackColor = true;
            this.manualDLeft.Click += new System.EventHandler(this.manualDLeft_Click);
            // 
            // manualSR
            // 
            this.manualSR.Location = new System.Drawing.Point(290, 175);
            this.manualSR.Name = "manualSR";
            this.manualSR.Size = new System.Drawing.Size(268, 23);
            this.manualSR.TabIndex = 3;
            this.manualSR.Text = "Soft-Reset";
            this.manualSR.UseVisualStyleBackColor = true;
            this.manualSR.Click += new System.EventHandler(this.manualSR_Click);
            // 
            // Remote_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(589, 214);
            this.Controls.Add(this.Remote_Stick);
            this.Controls.Add(this.Remote_touch);
            this.Controls.Add(this.Remote_buttons);
            this.Controls.Add(this.manualSR);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Remote_Control";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.Text = "Remote Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Remote_Control_FormClosed);
            this.Remote_Stick.ResumeLayout(false);
            this.Remote_Stick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StickX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickNumY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickNumX)).EndInit();
            this.Remote_touch.ResumeLayout(false);
            this.Remote_touch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touchX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.touchY)).EndInit();
            this.Remote_buttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Remote_Stick;
        private System.Windows.Forms.TrackBar StickX;
        private System.Windows.Forms.TrackBar StickY;
        private System.Windows.Forms.NumericUpDown StickNumY;
        private System.Windows.Forms.Button StickSend;
        private System.Windows.Forms.NumericUpDown StickNumX;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.GroupBox Remote_touch;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown touchX;
        private System.Windows.Forms.NumericUpDown touchY;
        private System.Windows.Forms.Button manualTouch;
        private System.Windows.Forms.GroupBox Remote_buttons;
        private System.Windows.Forms.Button manualDUp;
        private System.Windows.Forms.Button manualA;
        private System.Windows.Forms.Button manualR;
        private System.Windows.Forms.Button manualB;
        private System.Windows.Forms.Button manualL;
        private System.Windows.Forms.Button manualSelect;
        private System.Windows.Forms.Button manualDRight;
        private System.Windows.Forms.Button ManualDDown;
        private System.Windows.Forms.Button manualY;
        private System.Windows.Forms.Button manualStart;
        private System.Windows.Forms.Button manualX;
        private System.Windows.Forms.Button manualDLeft;
        private System.Windows.Forms.Button manualSR;
    }
}