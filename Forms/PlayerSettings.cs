using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubricApp
{
    public partial class PlayerSettings : Telerik.WinControls.UI.RadForm
    {

        public decimal speedscale;
        public int movementdurration;
        public bool showoverlay;
        public bool colorizing_sub;


        public void UpdateValues(decimal sp_sc , int movesc, bool overl,bool colorize)
        {
            speedscaleedit.Value = sp_sc;
            movespeededit.Value = movesc;
            overlayedit.Value = overl;
            colorize_sub.Value = colorize;


        }

        public PlayerSettings()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            speedscale = speedscaleedit.Value;
            movementdurration = (int)movespeededit.Value;
            showoverlay = overlayedit.Value;
            colorizing_sub = colorize_sub.Value;

            this.Close();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
