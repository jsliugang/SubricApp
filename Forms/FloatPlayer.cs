using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubricApp.Forms
{
    public partial class FloatPlayer : Telerik.WinControls.UI.RadForm
    {
        public FloatPlayer()
        {
            InitializeComponent();
        }

        public void SetArea(Control.ControlCollection controls)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                player_area.Controls.Add(controls[i]);
            }
            player_area.Update();
        }

        public Control.ControlCollection GetArea()
        {
            return player_area.Controls;
        }
        private void FloatPlayer_Load(object sender, EventArgs e)
        {

        }
    }
}
