using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Telerik.WinControls;
using Newtonsoft.Json;

namespace SubricApp
{
    public partial class LyricImporter : Telerik.WinControls.UI.RadForm
    {

        public List<string> lyric_list = new List<string>();

        class lyric_data_object
        {
            public string[] lyrics { get; set; }

        }



        public LyricImporter()
        {
            InitializeComponent();

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Select lyric text file :";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var readfile = File.ReadAllLines(openFileDialog.FileName);

                for (int i = 0; i < readfile.Length; i++)
                {
                    if (readfile[i] != "")
                    {
                        if (readfile[i] != " ")
                        {

                            if (readfile[i] != "\n")
                            {

                                if (readfile[i] != "  ")
                                {

                                    radListView1.Items.Add(readfile[i]);

                                }

                            }
                        }
                    }
                    
                }

                radListView1.SelectedIndex = 0;
                radListView1.SelectedItem = radListView1.Items.Last();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            radListView1.Items.Remove(radListView1.SelectedItem);
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < radListView1.Items.Count; i++)
            {
                lyric_list.Add(radListView1.Items[i].Text);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            radListView1.Items.Add("<Empty Lyric>");
            radListView1.SelectedItem = radListView1.Items.Last();
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            if (inputchar.Text.Length != 0) { 
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Select lyric text file :";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var readfile = File.ReadAllText(openFileDialog.FileName).Split(inputchar.Text[0]);

               radListView1.Items.Add(readfile[0]);

                    for (int i = 1; i < readfile.Length-1; i++)
                {
                    radListView1.Items.Add(readfile[i].Substring(2, readfile[i].Length-2));

                }

                    radListView1.SelectedItem = radListView1.Items.Last();
                }

            }
            else
            {
                RadMessageBox.Show("Please enter a CHAR", "No Char Found!", MessageBoxButtons.OK, RadMessageIcon.Error);
            }


        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            radListView1.Items.Clear();
        }

        private void radButton8_Click(object sender, EventArgs e)
        {
         
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Subric Lyric Writer Data (*.slw)|*.slw";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Select Subric Lyric Writer Data file :";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var decompjson = JsonConvert.DeserializeObject<lyric_data_object>(
                Encoding.Unicode.GetString(
                Subric.Compression.GZCompressor.Decompress(
                File.ReadAllBytes(openFileDialog.FileName
                ))    
                ));

                radListView1.Items.AddRange(decompjson.lyrics);
                radListView1.SelectedItem = radListView1.Items.Last();

            }



        }

        private void LyricImporter_Load(object sender, EventArgs e)
        {

        }
    }
}
