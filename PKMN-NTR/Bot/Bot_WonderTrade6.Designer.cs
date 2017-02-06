namespace ntrbase.Bot
{
    partial class Bot_WonderTrade6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bot_WonderTrade6));
            this.label58 = new System.Windows.Forms.Label();
            this.WT_After = new System.Windows.Forms.GroupBox();
            this.WTafter_Delete = new System.Windows.Forms.RadioButton();
            this.WTafter_Restore = new System.Windows.Forms.RadioButton();
            this.WTafter_DoNothing = new System.Windows.Forms.RadioButton();
            this.WTafter_Dump = new System.Windows.Forms.CheckBox();
            this.label57 = new System.Windows.Forms.Label();
            this.WTBox = new System.Windows.Forms.NumericUpDown();
            this.WT_Sources = new System.Windows.Forms.GroupBox();
            this.WTsource_Random = new System.Windows.Forms.RadioButton();
            this.WTsource_Folder = new System.Windows.Forms.RadioButton();
            this.WTsource_Boxes = new System.Windows.Forms.RadioButton();
            this.WTtradesNo = new System.Windows.Forms.NumericUpDown();
            this.WTSlot = new System.Windows.Forms.NumericUpDown();
            this.label59 = new System.Windows.Forms.Label();
            this.WT_RunEndless = new System.Windows.Forms.CheckBox();
            this.RunWTbot = new System.Windows.Forms.Button();
            this.WT_After.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTBox)).BeginInit();
            this.WT_Sources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTtradesNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTSlot)).BeginInit();
            this.SuspendLayout();
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(12, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(28, 13);
            this.label58.TabIndex = 4;
            this.label58.Text = "Box:";
            // 
            // WT_After
            // 
            this.WT_After.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WT_After.Controls.Add(this.WTafter_Delete);
            this.WT_After.Controls.Add(this.WTafter_Restore);
            this.WT_After.Controls.Add(this.WTafter_DoNothing);
            this.WT_After.Controls.Add(this.WTafter_Dump);
            this.WT_After.Location = new System.Drawing.Point(156, 12);
            this.WT_After.Name = "WT_After";
            this.WT_After.Size = new System.Drawing.Size(148, 143);
            this.WT_After.TabIndex = 10;
            this.WT_After.TabStop = false;
            this.WT_After.Text = "After trading";
            // 
            // WTafter_Delete
            // 
            this.WTafter_Delete.AutoSize = true;
            this.WTafter_Delete.Location = new System.Drawing.Point(6, 88);
            this.WTafter_Delete.Name = "WTafter_Delete";
            this.WTafter_Delete.Size = new System.Drawing.Size(136, 17);
            this.WTafter_Delete.TabIndex = 1;
            this.WTafter_Delete.Text = "Delete traded pokémon";
            this.WTafter_Delete.UseVisualStyleBackColor = true;
            // 
            // WTafter_Restore
            // 
            this.WTafter_Restore.AutoSize = true;
            this.WTafter_Restore.Location = new System.Drawing.Point(6, 65);
            this.WTafter_Restore.Name = "WTafter_Restore";
            this.WTafter_Restore.Size = new System.Drawing.Size(101, 17);
            this.WTafter_Restore.TabIndex = 1;
            this.WTafter_Restore.Text = "Restore backup";
            this.WTafter_Restore.UseVisualStyleBackColor = true;
            // 
            // WTafter_DoNothing
            // 
            this.WTafter_DoNothing.AutoSize = true;
            this.WTafter_DoNothing.Checked = true;
            this.WTafter_DoNothing.Location = new System.Drawing.Point(6, 42);
            this.WTafter_DoNothing.Name = "WTafter_DoNothing";
            this.WTafter_DoNothing.Size = new System.Drawing.Size(77, 17);
            this.WTafter_DoNothing.TabIndex = 1;
            this.WTafter_DoNothing.TabStop = true;
            this.WTafter_DoNothing.Text = "Do nothing";
            this.WTafter_DoNothing.UseVisualStyleBackColor = true;
            // 
            // WTafter_Dump
            // 
            this.WTafter_Dump.AutoSize = true;
            this.WTafter_Dump.Location = new System.Drawing.Point(6, 20);
            this.WTafter_Dump.Name = "WTafter_Dump";
            this.WTafter_Dump.Size = new System.Drawing.Size(109, 17);
            this.WTafter_Dump.TabIndex = 0;
            this.WTafter_Dump.Text = "Dump boxes and:";
            this.WTafter_Dump.UseVisualStyleBackColor = true;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(55, 9);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(28, 13);
            this.label57.TabIndex = 5;
            this.label57.Text = "Slot:";
            // 
            // WTBox
            // 
            this.WTBox.Location = new System.Drawing.Point(12, 28);
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
            this.WTBox.TabIndex = 0;
            this.WTBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WT_Sources
            // 
            this.WT_Sources.AutoSize = true;
            this.WT_Sources.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WT_Sources.Controls.Add(this.WTsource_Random);
            this.WT_Sources.Controls.Add(this.WTsource_Folder);
            this.WT_Sources.Controls.Add(this.WTsource_Boxes);
            this.WT_Sources.Location = new System.Drawing.Point(12, 54);
            this.WT_Sources.Name = "WT_Sources";
            this.WT_Sources.Size = new System.Drawing.Size(138, 101);
            this.WT_Sources.TabIndex = 8;
            this.WT_Sources.TabStop = false;
            this.WT_Sources.Text = "Pokémon Source";
            // 
            // WTsource_Random
            // 
            this.WTsource_Random.AutoSize = true;
            this.WTsource_Random.Location = new System.Drawing.Point(6, 65);
            this.WTsource_Random.Name = "WTsource_Random";
            this.WTsource_Random.Size = new System.Drawing.Size(124, 17);
            this.WTsource_Random.TabIndex = 2;
            this.WTsource_Random.Text = "WT Folder (Random)";
            this.WTsource_Random.UseVisualStyleBackColor = true;
            // 
            // WTsource_Folder
            // 
            this.WTsource_Folder.AutoSize = true;
            this.WTsource_Folder.Location = new System.Drawing.Point(6, 42);
            this.WTsource_Folder.Name = "WTsource_Folder";
            this.WTsource_Folder.Size = new System.Drawing.Size(126, 17);
            this.WTsource_Folder.TabIndex = 1;
            this.WTsource_Folder.Text = "Wonder Trade Folder";
            this.WTsource_Folder.UseVisualStyleBackColor = true;
            // 
            // WTsource_Boxes
            // 
            this.WTsource_Boxes.AutoSize = true;
            this.WTsource_Boxes.Checked = true;
            this.WTsource_Boxes.Location = new System.Drawing.Point(6, 19);
            this.WTsource_Boxes.Name = "WTsource_Boxes";
            this.WTsource_Boxes.Size = new System.Drawing.Size(71, 17);
            this.WTsource_Boxes.TabIndex = 0;
            this.WTsource_Boxes.TabStop = true;
            this.WTsource_Boxes.Text = "PC Boxes";
            this.WTsource_Boxes.UseVisualStyleBackColor = true;
            // 
            // WTtradesNo
            // 
            this.WTtradesNo.Location = new System.Drawing.Point(104, 28);
            this.WTtradesNo.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.WTtradesNo.Name = "WTtradesNo";
            this.WTtradesNo.Size = new System.Drawing.Size(46, 20);
            this.WTtradesNo.TabIndex = 2;
            this.WTtradesNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WTSlot
            // 
            this.WTSlot.Location = new System.Drawing.Point(58, 28);
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
            this.WTSlot.TabIndex = 1;
            this.WTSlot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(101, 9);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(49, 13);
            this.label59.TabIndex = 6;
            this.label59.Text = "# trades:";
            // 
            // WT_RunEndless
            // 
            this.WT_RunEndless.AutoSize = true;
            this.WT_RunEndless.Location = new System.Drawing.Point(214, 165);
            this.WT_RunEndless.Name = "WT_RunEndless";
            this.WT_RunEndless.Size = new System.Drawing.Size(90, 17);
            this.WT_RunEndless.TabIndex = 13;
            this.WT_RunEndless.Text = "Run endessly";
            this.WT_RunEndless.UseVisualStyleBackColor = true;
            // 
            // RunWTbot
            // 
            this.RunWTbot.Location = new System.Drawing.Point(12, 161);
            this.RunWTbot.Name = "RunWTbot";
            this.RunWTbot.Size = new System.Drawing.Size(196, 23);
            this.RunWTbot.TabIndex = 12;
            this.RunWTbot.Text = "Start Bot";
            this.RunWTbot.UseVisualStyleBackColor = true;
            // 
            // Bot_WonderTrade6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(319, 197);
            this.Controls.Add(this.WT_After);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.WT_RunEndless);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.RunWTbot);
            this.Controls.Add(this.WTBox);
            this.Controls.Add(this.WT_Sources);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.WTtradesNo);
            this.Controls.Add(this.WTSlot);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bot_WonderTrade6";
            this.Text = "Wonder Trade Bot";
            this.WT_After.ResumeLayout(false);
            this.WT_After.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTBox)).EndInit();
            this.WT_Sources.ResumeLayout(false);
            this.WT_Sources.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WTtradesNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTSlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.GroupBox WT_After;
        private System.Windows.Forms.RadioButton WTafter_Delete;
        private System.Windows.Forms.RadioButton WTafter_Restore;
        private System.Windows.Forms.RadioButton WTafter_DoNothing;
        private System.Windows.Forms.CheckBox WTafter_Dump;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.NumericUpDown WTBox;
        private System.Windows.Forms.GroupBox WT_Sources;
        private System.Windows.Forms.RadioButton WTsource_Random;
        private System.Windows.Forms.RadioButton WTsource_Folder;
        private System.Windows.Forms.RadioButton WTsource_Boxes;
        private System.Windows.Forms.NumericUpDown WTtradesNo;
        private System.Windows.Forms.NumericUpDown WTSlot;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.CheckBox WT_RunEndless;
        private System.Windows.Forms.Button RunWTbot;
    }
}