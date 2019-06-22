﻿namespace SubricApp.Forms
{
    partial class FloatPlayer
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
            this.player_area = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // player_area
            // 
            this.player_area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player_area.Location = new System.Drawing.Point(0, 0);
            this.player_area.Name = "player_area";
            this.player_area.Size = new System.Drawing.Size(504, 450);
            this.player_area.TabIndex = 0;
            // 
            // FloatPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(504, 450);
            this.Controls.Add(this.player_area);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FloatPlayer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[ SubricApp : Float Player ] ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FloatPlayer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel player_area;
    }
}