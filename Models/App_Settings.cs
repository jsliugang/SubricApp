
using System.Windows.Forms;
using System.Drawing;


namespace SubricApp
{

    public class appsettings
    {
        static public decimal speedscale = (decimal)0.15;
        static public int movementdurration = 500;
        static public bool showoverlay = true;
        static public bool colorizing_sub = true;
        static public int lyriclistspace = 30;
        static public Point startUpSize = new Point(1100, 580);
        static public bool fullscreen = false;
        static public bool splashscreen = true;
        static public bool colorizing_srt = true;

    }

    public class AppSettings_Def
    {
        public Keys ExportKey { get; set; }
        public Keys ImportKey { get; set; }
        public Keys OpenKey { get; set; }
        public Keys RecordKey { get; set; }
        public Keys StartRecordKey { get; set; }
        public Keys StopRecordKey { get; set; }


        public bool fullscreen { get; set; }
        public Point startUpSize { get; set; }
        public bool splashscreen { get; set; }
        public bool colorizing_srt { get; set; }
        public int lyric_height { get; set; }

        public decimal speed_scale { get; set; }
        public int movement_durration { get; set; }
        public bool show_overlay { get; set; }
        public bool colorizing_sub { get; set; }
        

    }


}
