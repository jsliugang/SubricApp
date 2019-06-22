using System.Reflection;


namespace SubricApp
{
    class Plugin_Control
    {
        public string plugin_name { get; set; }
        public string plugin_version { get; set; }
        public string plugin_author { get; set; }
        public Subric.SDK.API.SubricTargetVersion plugin_target { get; set; }
        public Subric.SDK.API.SubricPluginShowType plugin_showtype { get; set; }
        public System.Drawing.Bitmap plugin_icon { get; set; }

        public MethodInfo plugin_exe { get; set; }
        public object plugin_handle { get; set; }
        public bool is_loaded { get; set; }
    }
}
