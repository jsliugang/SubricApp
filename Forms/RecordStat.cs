using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubricApp
{
    public partial class RecordStat : UserControl
    {


        public void changetext(string textin)
        {
            label1.Text = textin;
        }
        public RecordStat()
        {
            InitializeComponent();
        }
    }
}
