using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
namespace Subric.SDK.API
{
    public interface SDK_Interface
    {
        Action<Uri> OpenMedia { get; set; }
        Func<TimeSpan> GetMoviePosition { get; set; }
        Action<TimeSpan> SetMoviePosition { get; set; }
        Action PlayMovie { get; set; }
        Action PauseMovie { get; set; }
        Action StopMovie { get; set; }
        Func<Subtitle_Object[]> GetSubtitles { get; set; }
        Action<Subtitle_Object[]> SetSubtitles { get; set; }
        Func<List<string>> GetLyrics { get; set; }
        Action<List<string>> SetLyrics { get; set; }
        Func<string> GetUpcomingLyricText { get; set; }
        Action<string> SetUpcomingLyricText { get; set; }
        Action<Subtitle_Object> AddSubtitle { get; set; }
        Action<string> AddLyric { get; set; }
        Action<string,string,SubricMessageIcon> ShowSubricMessageBox { get; set; }
        Action<string> ChangeStatus { get; set; }
        Func<string> GetSubricAppRoot { get; set; }
        Func<string> GetPluginFolder { get; set; }
        Action<string, string> GZip_CompressFile { get; set; }
        Action<string, string> GZip_DecompressFile { get; set; }
        Action<string> ShowVideoStatus { get; set; }
        Action<string> ShowSubtitle { get; set; }
        Action<string, int> ShowSubtitleForMs { get; set; }
        Action HideSubtitle { get; set; }
        Action SetLyricLoaded { get; set; }
        Action<Action, string> RegisterCallback { get; set; }
        Action<string> UnegisterCallback { get; set; }
        Action<string> ChangePreviewSubtitleDefaultColor { get; set; }
        Action ResetPreviewSubtitleDefaultColor { get; set; }
    }
    public class Bridge : SDK_Interface
    {

        public Action<Uri> OpenMedia { get; set; }
        public Func<TimeSpan> GetMoviePosition { get; set; }
        public Action<TimeSpan> SetMoviePosition { get; set; }
        public Action PlayMovie { get; set; }
        public Action PauseMovie { get; set; }
        public Action StopMovie { get; set; }
        public Func<Subtitle_Object[]> GetSubtitles { get; set; }
        public Action<Subtitle_Object[]> SetSubtitles { get; set; }
        public Func<List<string>> GetLyrics { get; set; }
        public Action<List<string>> SetLyrics { get; set; }
        public Func<string> GetUpcomingLyricText { get; set; }
        public Action<string> SetUpcomingLyricText { get; set; }
        public Action<Subtitle_Object> AddSubtitle { get; set; }
        public Action<string> AddLyric { get; set; }
        public Action<string, string, SubricMessageIcon> ShowSubricMessageBox { get; set; }
        public Action<string> ChangeStatus { get; set; }
        public Func<string> GetSubricAppRoot { get; set; }
        public Func<string> GetPluginFolder { get; set; }
        public Action<string, string>  GZip_CompressFile { get; set; }
        public Action<string, string> GZip_DecompressFile { get; set; }
        public Action<string> ShowVideoStatus { get; set; }
        public Action<string> ShowSubtitle { get; set; }
        public Action<string,int> ShowSubtitleForMs { get; set; }
        public Action HideSubtitle { get; set; }
        public Action SetLyricLoaded { get; set; }
        public Action<Action,string> RegisterCallback { get; set; }
        public Action<string> UnegisterCallback { get; set; }
        public Action<string> ChangePreviewSubtitleDefaultColor { get; set; }
        public Action ResetPreviewSubtitleDefaultColor { get; set; }

    }
    public enum SubricTargetVersion
    {
        All_Versions = 0,
        Beta_2019_0_0 = 1,
        Stable_2019_0_0 = 2
    }
    public enum SubricPluginShowType
    {
        MENU_ONLY = 0x65,
        ICON_ONLY = 0x88,
        MENU_AND_ICON = 0xC3,
        STARTUP_ONLY = 0xF5,
        STARTUP_AND_MENU = 0xFA,
        STARTUP_AND_ICON = 0x14,
        ALL_OPTIONS = 0xFF
    }
    public enum SubricMessageIcon
    {
        error = 4,
        warning = 3,
        info = 1
    }
    public enum ConvertText
    {
        normal = 0,
        upper = 1,
        lower = 2
    }
    public class Subtitle_Object
    {
        [ReadOnly(true)]
        public int _id { get; set; }

        [DisplayName("Text"), Description("Sets text of the subtitle.")]
        public string _text { get; set; }

        [DisplayName("Color"), Description("Sets color of the subtitle. [Only in HTML Supported Players]")]
        public Color _color { get; set; }

        [DisplayName("Start Time"), Description("Sets starting of subtitle.")]
        public string _start { get; set; }

        [DisplayName("End Time"), Description("Sets ending of subtitle.")]
        public string _end { get; set; }

        [DisplayName("Position"), Description("Sets position of subtitle on screen. [Not Programmed Yet]")]
        public Point _pos { get; set; }

        [DisplayName("Bold"), Description("Sets text style to Bold. [Not Programmed Yet]")]
        public bool _isBold { get; set; }

        [DisplayName("Italic"), Description("Sets text style to Italic. [Not Programmed Yet]")]
        public bool _isItalic { get; set; }

        [DisplayName("Convert Text"), Description("Converts subtitle text to Up/Low . [Not Programmed Yet]")]
        public ConvertText _Convert { get; set; }


    }
}
