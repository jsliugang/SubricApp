using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Subric.SDK.API;



namespace Subric.Plugin
{
    public class subric_plugin
    {

        static private Bridge SubricAPI;

        //// Plug-In Information
        public static string _plugin_name = "Untitled Plugin";
        public static string _plugin_version = "1.0";
        public static string _plugin_author = "Unknown";
        public static SubricTargetVersion _plugin_subrictarget = SubricTargetVersion.All_Versions;
        public static SubricPluginShowType _plugin_showtype = SubricPluginShowType.MENU_ONLY;
        public static Bitmap _plucin_icon = plugin_resources.plugin_icon;


        //// Plug-In Base & Initializing
        public static void Init(Bridge sdkinit)
        {
            SubricAPI = sdkinit;
        }


        //// Plug-In Execution
        public static void Execute()
        {
            //// Do Stuffs Here with `SubricAPI`
            SubricAPI.ShowSubricMessageBox("Sample Text", "Sample Title", SubricMessageIcon.warning);

        }

    }
}
