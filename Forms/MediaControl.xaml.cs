using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SubricApp
{

    public partial class MediaControl : UserControl
    {

        static public MediaElement mediaplayer;


        public MediaControl()
        {
            InitializeComponent();
            mediaplayer = MasterMediaCtrl;

        }

        private async void ShowState(string state)
        {
            video_stat.Content = state;
            CircleEase ease = new CircleEase() { EasingMode= EasingMode.EaseIn};
            var doubanim = new DoubleAnimation(1, TimeSpan.FromSeconds(0.15)) { EasingFunction = ease};
            video_stat.BeginAnimation(OpacityProperty,doubanim);
            await Task.Delay(500);
            var doubanimout = new DoubleAnimation(0, TimeSpan.FromSeconds(0.15)) { EasingFunction = ease };
            video_stat.BeginAnimation(OpacityProperty, doubanimout);

        }

        public void UpdateState(string state)
        {
            ShowState(state);
        }


        public void ShowSub(string sub)
        {
            subtitle_preview.Text = sub;
            CircleEase ease = new CircleEase() { EasingMode = EasingMode.EaseIn };
            var doubanim = new DoubleAnimation(1, TimeSpan.FromSeconds(0.2)) { EasingFunction = ease };
            subtitle_preview.BeginAnimation(OpacityProperty, doubanim);
        }

        public void HideSub()
        {
            CircleEase ease = new CircleEase() { EasingMode = EasingMode.EaseIn };
            var doubanim = new DoubleAnimation(0, TimeSpan.FromSeconds(0.2)) { EasingFunction = ease };
            subtitle_preview.BeginAnimation(OpacityProperty, doubanim);
        }


    }
}
