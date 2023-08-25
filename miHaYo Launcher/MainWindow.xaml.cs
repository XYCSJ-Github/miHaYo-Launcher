using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Diagnostics;
using Ioini;
using System.IO;
using System.Net.Http.Headers;
using Path = System.IO;


namespace miHaYo_Launcher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>

    public struct PathGameStart
    {
        public string PGS_ys { get; set; }
        public string PGS_sr { get; set; }
        public string PGS_b3 { get; set; }
    }
    public partial class MainWindow : Window
    {
        private string opening = "0";
        private bool main_background_show = false;
        public PathGameStart pgs;
        public string iniPath;

        public MainWindow()
        {
            this.ResizeMode = ResizeMode.CanMinimize;
            InitializeComponent();
            var iconsb = (Storyboard)this.FindResource("Stratup");
            iconsb.Begin();
            main_background_show = true;
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = folder + "\\MHYL";
            iniPath = specificFolder + "\\setting.ini";

            if (Directory.Exists(specificFolder) == false)
            {
                Directory.CreateDirectory(specificFolder);
                File.Create(iniPath);
            }

            IniFile ini = new IniFile(iniPath);
            if (ini != null )
            {
                string str = ini.Read("PathGameStart", "Star Rail");
                if (str != null)
                {
                    pgs.PGS_sr = str;
                }
                str = ini.Read("PathGameStart", "Genshin Impact");
                if (str != null)
                {
                    pgs.PGS_ys = str;
                }
                str = ini.Read("PathGameStart", "Honkai Impact 3");
                if (str != null)
                {
                    pgs.PGS_b3 = str;
                }
            }
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
            SettingWindow settingWindow = new SettingWindow(this);
            settingWindow.Owner = this;
            settingWindow.Show();
        }

        private void button_play_Click(object sender, RoutedEventArgs e)
        {
            if(opening == "ys")
            {
                string path = pgs.PGS_ys;
                try
                {
                    Process p = Process.Start(path);
                }
                catch (InvalidOperationException ex)
                {
                    SettingWindow sw = new SettingWindow(this);
                    sw.Owner = this;
                    sw.Show();
                    MessageBox.Show(ex.Message, "还没有设置 原神 的启动路径", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if(opening == "b3")
            {
                string path = pgs.PGS_ys;
                try
                {
                    Process p = Process.Start(path);
                }
                catch (InvalidOperationException ex)
                {
                    SettingWindow sw = new SettingWindow(this);
                    sw.Owner = this;
                    sw.Show();
                    MessageBox.Show(ex.Message, "还没有设置 崩坏3 的启动路径", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (opening == "sr")
            {
                string path = pgs.PGS_ys;
                try
                {
                    Process p = Process.Start(path);
                }
                catch (InvalidOperationException ex)
                {
                    SettingWindow sw = new SettingWindow(this);
                    sw.Owner = this;
                    sw.Show();
                    MessageBox.Show(ex.Message, "还没有设置 崩坏：星穹铁道 的启动路径",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
        }

        private void button_showweb_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Set_PGS(PathGameStart pgs)
        {
            this.pgs = pgs;
        }
    }
}
