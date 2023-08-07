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
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace miHaYo_Launcher
{
    /// <summary>
    /// StartupWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();

            Thread thr = new Thread(start);
            thr.Start();
        }

        public void start()
        {
            Thread.Sleep(1500);
            Dispatcher.BeginInvoke(new Action(delegate { var ssb = (Storyboard)this.FindResource("Stratup"); ssb.Begin(); }));
            Thread.Sleep(2300);
            Dispatcher.BeginInvoke(new Action(delegate { MainWindow mw = new MainWindow(); mw.Show(); }));
            Thread.Sleep(150);
            Dispatcher.BeginInvoke(new Action(delegate { this.Close(); }));
        }
    }
}
