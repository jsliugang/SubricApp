namespace SubricApp
{
    partial class AppSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettings));
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.set_lyrchght = new Telerik.WinControls.UI.RadSpinEditor();
            this.radToggleSwitch2 = new Telerik.WinControls.UI.RadToggleSwitch();
            this.set_splash = new Telerik.WinControls.UI.RadToggleSwitch();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.set_scsize_w = new Telerik.WinControls.UI.RadSpinEditor();
            this.set_scsize_h = new Telerik.WinControls.UI.RadSpinEditor();
            this.set_maxst = new Telerik.WinControls.UI.RadToggleSwitch();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.keyboardeditor = new Telerik.WinControls.UI.RadPropertyGrid();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_lyrchght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleSwitch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_splash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_scsize_w)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_scsize_h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_maxst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardeditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.panel1);
            this.radGroupBox1.HeaderText = "General";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.radGroupBox1.Size = new System.Drawing.Size(305, 233);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "General";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.radLabel6);
            this.panel1.Controls.Add(this.set_lyrchght);
            this.panel1.Controls.Add(this.radToggleSwitch2);
            this.panel1.Controls.Add(this.set_splash);
            this.panel1.Controls.Add(this.radLabel5);
            this.panel1.Controls.Add(this.radLabel3);
            this.panel1.Controls.Add(this.radLabel4);
            this.panel1.Controls.Add(this.radLabel2);
            this.panel1.Controls.Add(this.set_scsize_w);
            this.panel1.Controls.Add(this.set_scsize_h);
            this.panel1.Controls.Add(this.set_maxst);
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 193);
            this.panel1.TabIndex = 0;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(14, 155);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(99, 18);
            this.radLabel6.TabIndex = 3;
            this.radLabel6.Text = "Lyric Height (pixel)";
            // 
            // set_lyrchght
            // 
            this.set_lyrchght.Location = new System.Drawing.Point(213, 154);
            this.set_lyrchght.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.set_lyrchght.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.set_lyrchght.Name = "set_lyrchght";
            this.set_lyrchght.NullableValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.set_lyrchght.Size = new System.Drawing.Size(56, 20);
            this.set_lyrchght.TabIndex = 4;
            this.set_lyrchght.TabStop = false;
            this.set_lyrchght.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // radToggleSwitch2
            // 
            this.radToggleSwitch2.Location = new System.Drawing.Point(216, 119);
            this.radToggleSwitch2.Name = "radToggleSwitch2";
            this.radToggleSwitch2.Size = new System.Drawing.Size(53, 20);
            this.radToggleSwitch2.TabIndex = 5;
            // 
            // set_splash
            // 
            this.set_splash.Location = new System.Drawing.Point(216, 86);
            this.set_splash.Name = "set_splash";
            this.set_splash.Size = new System.Drawing.Size(53, 20);
            this.set_splash.TabIndex = 3;
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(14, 119);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(152, 18);
            this.radLabel5.TabIndex = 4;
            this.radLabel5.Text = "Colorizing Subtitles (SRT File)";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(201, 51);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(11, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "*";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(14, 86);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(163, 18);
            this.radLabel4.TabIndex = 2;
            this.radLabel4.Text = "Show Splash Screen On Startup";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(14, 52);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(70, 18);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Start Up Size";
            // 
            // set_scsize_w
            // 
            this.set_scsize_w.Location = new System.Drawing.Point(143, 51);
            this.set_scsize_w.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.set_scsize_w.Minimum = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.set_scsize_w.Name = "set_scsize_w";
            this.set_scsize_w.NullableValue = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.set_scsize_w.Size = new System.Drawing.Size(56, 20);
            this.set_scsize_w.TabIndex = 3;
            this.set_scsize_w.TabStop = false;
            this.set_scsize_w.Value = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            // 
            // set_scsize_h
            // 
            this.set_scsize_h.Location = new System.Drawing.Point(213, 51);
            this.set_scsize_h.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.set_scsize_h.Minimum = new decimal(new int[] {
            580,
            0,
            0,
            0});
            this.set_scsize_h.Name = "set_scsize_h";
            this.set_scsize_h.NullableValue = new decimal(new int[] {
            580,
            0,
            0,
            0});
            this.set_scsize_h.Size = new System.Drawing.Size(56, 20);
            this.set_scsize_h.TabIndex = 2;
            this.set_scsize_h.TabStop = false;
            this.set_scsize_h.Value = new decimal(new int[] {
            580,
            0,
            0,
            0});
            // 
            // set_maxst
            // 
            this.set_maxst.Location = new System.Drawing.Point(216, 17);
            this.set_maxst.Name = "set_maxst";
            this.set_maxst.Size = new System.Drawing.Size(53, 20);
            this.set_maxst.TabIndex = 1;
            this.set_maxst.Value = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(14, 17);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(95, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Start in Fullscreen";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.panel3);
            this.radGroupBox3.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.radGroupBox3.HeaderText = "Shortcuts";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 251);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.radGroupBox3.Size = new System.Drawing.Size(305, 262);
            this.radGroupBox3.TabIndex = 1;
            this.radGroupBox3.Text = "Shortcuts";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel3.Controls.Add(this.keyboardeditor);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 222);
            this.panel3.TabIndex = 0;
            // 
            // keyboardeditor
            // 
            this.keyboardeditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardeditor.EnableFiltering = false;
            this.keyboardeditor.EnableGrouping = false;
            this.keyboardeditor.EnableSorting = false;
            this.keyboardeditor.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyboardeditor.HelpVisible = false;
            this.keyboardeditor.ItemHeight = 35;
            this.keyboardeditor.ItemIndent = 0;
            this.keyboardeditor.ItemSpacing = 2;
            this.keyboardeditor.Location = new System.Drawing.Point(0, 0);
            this.keyboardeditor.Name = "keyboardeditor";
            this.keyboardeditor.ShowItemToolTips = false;
            this.keyboardeditor.Size = new System.Drawing.Size(285, 222);
            this.keyboardeditor.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.keyboardeditor.TabIndex = 0;
            // 
            // radSeparator1
            // 
            this.radSeparator1.Location = new System.Drawing.Point(12, 521);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Size = new System.Drawing.Size(305, 13);
            this.radSeparator1.TabIndex = 2;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(222, 540);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(95, 36);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "Cancel";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(85, 540);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(131, 36);
            this.radButton2.TabIndex = 4;
            this.radButton2.Text = "Save Settings";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 588);
            this.ControlBox = false;
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppSettings";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Settings";
            this.Load += new System.EventHandler(this.AppSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_lyrchght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleSwitch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_splash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_scsize_w)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_scsize_h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.set_maxst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keyboardeditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadToggleSwitch set_maxst;
        private Telerik.WinControls.UI.RadSpinEditor set_scsize_h;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadSpinEditor set_scsize_w;
        private Telerik.WinControls.UI.RadToggleSwitch set_splash;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadToggleSwitch radToggleSwitch2;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadPropertyGrid keyboardeditor;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadSpinEditor set_lyrchght;
    }
}