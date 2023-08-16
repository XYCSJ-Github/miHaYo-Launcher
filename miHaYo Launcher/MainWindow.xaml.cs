using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace miHaYo_Launcher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string opening = "0";
        private bool main_background_show = false;

        public MainWindow()
        {
            this.ResizeMode = ResizeMode.CanMinimize;
            InitializeComponent();
            var iconsb = (Storyboard)this.FindResource("Stratup");
            iconsb.Begin();
            main_background_show = true;
        }

        private void button_b2_Click(object sender, RoutedEventArgs e)
        {
            String str = "b2";
            imageout(str);
            if (opening == str)
            { return; }
            else
            {
                opening = str;
                Storyboard sb = (Storyboard)this.FindResource("b2_in");
                sb.Begin();
            }
        }

        private void button_b3_Click(object sender, RoutedEventArgs e)
        {
            String str = "b3";
            imageout(str);
            if (opening == str)
            { return; }
            else
            {
                opening = str;
                Storyboard sb = (Storyboard)this.FindResource("b3_in");
                sb.Begin();
            }

        }

        private void button_sr_Click(object sender, RoutedEventArgs e)
        {
            String str = "sr";
            imageout(str);
            if (opening == str)
            { return; }
            else
            {
                opening = str;
                Storyboard sb = (Storyboard)this.FindResource("sr_in");
                sb.Begin();
            }

        }

        private void button_wd_Click(object sender, RoutedEventArgs e)
        {
            String str = "wd";
            imageout(str);
            if (opening == str)
            { return; }
            else
            {
                opening = str;
                Storyboard sb = (Storyboard)this.FindResource("wd_in");
                sb.Begin();
            }

        }

        private void button_ys_Click(object sender, RoutedEventArgs e)
        {
            String str = "ys";
            imageout(str);
            if (opening == str)
            { return; }
            else
            {
                opening = str;
                Storyboard sb = (Storyboard)this.FindResource("ys_in");
                sb.Begin();
            }

        }

        private void button_jq0_Click(object sender, RoutedEventArgs e)
        {
            String str = "jq0";
            imageout(str);
            if (opening == str)
            { return; }
            else
            {
                opening = str;
                Storyboard sb = (Storyboard)this.FindResource("jq0_in");
                sb.Begin();
            }

        }

        private void imageout(String open)
        {
            if (main_background_show == true)
            {
                Storyboard sb = (Storyboard)this.FindResource("mbg_out");
                sb.Begin();
                main_background_show = false;
            }

            if (opening == "b2" && open != "b2")
            {
                Storyboard sb = (Storyboard)this.FindResource("b2_out");
                sb.Begin();
            }
            else if (opening == "b3" && open != "b3")
            {
                Storyboard sb = (Storyboard)this.FindResource("b3_out");
                sb.Begin();
            }
            else if (opening == "sr" && open != "sr")
            {
                Storyboard sb = (Storyboard)this.FindResource("sr_out");
                sb.Begin();
            }
            else if (opening == "wd" && open != "wd")
            {
                Storyboard sb = (Storyboard)this.FindResource("wd_out");
                sb.Begin();
            }
            else if (opening == "ys" && open != "ys")
            {
                Storyboard sb = (Storyboard)this.FindResource("ys_out");
                sb.Begin();
            }
            else if (opening == "jq0" && open != "jq0")
            {
                Storyboard sb = (Storyboard)this.FindResource("jq0_out");
                sb.Begin();
            }
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.Owner = this;
            settingWindow.Show();
        }
    }
}
