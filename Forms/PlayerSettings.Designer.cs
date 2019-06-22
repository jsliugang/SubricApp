namespace SubricApp
{
    partial class PlayerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerSettings));
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.colorize_sub = new Telerik.WinControls.UI.RadToggleSwitch();
            this.overlayedit = new Telerik.WinControls.UI.RadToggleSwitch();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.movespeededit = new Telerik.WinControls.UI.RadSpinEditor();
            this.speedscaleedit = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorize_sub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movespeededit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedscaleedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.colorize_sub);
            this.radGroupBox1.Controls.Add(this.overlayedit);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.movespeededit);
            this.radGroupBox1.Controls.Add(this.speedscaleedit);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(243, 168);
            this.radGroupBox1.TabIndex = 0;
            // 
            // colorize_sub
            // 
            this.colorize_sub.Location = new System.Drawing.Point(174, 128);
            this.colorize_sub.Name = "colorize_sub";
            this.colorize_sub.Size = new System.Drawing.Size(50, 20);
            this.colorize_sub.TabIndex = 7;
            // 
            // overlayedit
            // 
            this.overlayedit.Location = new System.Drawing.Point(174, 94);
            this.overlayedit.Name = "overlayedit";
            this.overlayedit.Size = new System.Drawing.Size(50, 20);
            this.overlayedit.TabIndex = 5;
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(20, 128);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(135, 18);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "Coloring Preview Subtitle ";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(20, 94);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(74, 18);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Show Overlay";
            // 
            // movespeededit
            // 
            this.movespeededit.Location = new System.Drawing.Point(149, 59);
            this.movespeededit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.movespeededit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.movespeededit.Name = "movespeededit";
            this.movespeededit.NullableValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.movespeededit.Size = new System.Drawing.Size(75, 20);
            this.movespeededit.TabIndex = 3;
            this.movespeededit.TabStop = false;
            this.movespeededit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // speedscaleedit
            // 
            this.speedscaleedit.DecimalPlaces = 6;
            this.speedscaleedit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.speedscaleedit.Location = new System.Drawing.Point(149, 21);
            this.speedscaleedit.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speedscaleedit.Name = "speedscaleedit";
            this.speedscaleedit.Size = new System.Drawing.Size(75, 20);
            this.speedscaleedit.TabIndex = 1;
            this.speedscaleedit.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(20, 59);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(114, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Movement Scale (ms)";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(20, 21);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(66, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Speed Scale";
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(12, 188);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(143, 30);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Save Settings";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(161, 188);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(94, 30);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "Cancel";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // PlayerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 230);
            this.ControlBox = false;
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerSettings";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Player Settings";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorize_sub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movespeededit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedscaleedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadSpinEditor movespeededit;
        private Telerik.WinControls.UI.RadSpinEditor speedscaleedit;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadToggleSwitch overlayedit;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadToggleSwitch colorize_sub;
        private Telerik.WinControls.UI.RadLabel radLabel4;
    }
}