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
    public partial class AppSettings : Telerik.WinControls.UI.RadForm
    {




        private hotkeysettings g_hotkeys;
        public AppSettings()
        {
            g_hotkeys = new hotkeysettings();
           
            InitializeComponent();


            keyboardeditor.ContextMenuOpening += (p, s) =>
            {
                s.Cancel = true;
            };
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hotkeys.ExportKey = (Keys)(int)g_hotkeys.ExportKey;
            Hotkeys.ImportKey = (Keys)(int)g_hotkeys.ImportKey;
            Hotkeys.OpenKey = (Keys)(int)g_hotkeys.OpenKey;
            Hotkeys.RecordKey = (Keys)(int)g_hotkeys.RecordKey;
            Hotkeys.StartRecordKey = (Keys)(int)g_hotkeys.StartRecordKey;
            Hotkeys.StopRecordKey = (Keys)(int)g_hotkeys.StopRecordKey;


           appsettings.lyriclistspace =(int)set_lyrchght.Value;
           appsettings.fullscreen = set_maxst.Value;
           appsettings.startUpSize.Y = (int)set_scsize_h.Value;
           appsettings.startUpSize.X = (int)set_scsize_w.Value;
           appsettings.splashscreen = set_splash.Value;



            this.Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AppSettings_Load(object sender, EventArgs e)
        {

            set_lyrchght.Value = appsettings.lyriclistspace;
            set_maxst.Value = appsettings.fullscreen;
            set_scsize_h.Value = appsettings.startUpSize.Y;
            set_scsize_w.Value = appsettings.startUpSize.X;
            set_splash.Value = appsettings.splashscreen;


            g_hotkeys.ExportKey = (ShortcutXKeys)(int)Hotkeys.ExportKey;
            g_hotkeys.ImportKey = (ShortcutXKeys)(int)Hotkeys.ImportKey;
            g_hotkeys.OpenKey = (ShortcutXKeys)(int)Hotkeys.OpenKey;
            g_hotkeys.RecordKey = (ShortcutXKeys)(int)Hotkeys.RecordKey;
            g_hotkeys.StartRecordKey = (ShortcutXKeys)(int)Hotkeys.StartRecordKey;
            g_hotkeys.StopRecordKey = (ShortcutXKeys)(int)Hotkeys.StopRecordKey;
            keyboardeditor.SelectedObject = g_hotkeys;
            keyboardeditor.Update();



        }
    }
}
