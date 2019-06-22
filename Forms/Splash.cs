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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
         
        }
        private async void CloseSplash()
        {
            await Task.Delay(3000);
            this.Close();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            CloseSplash();
        }
    }
}
