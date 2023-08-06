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
            Thread thr_ssb = new Thread(startsb);
            thr_ssb.Start();
        }

        public void startsb()
        {
            Thread.Sleep(1000);

            Dispatcher.BeginInvoke(
                new Action(
                    delegate 
                    { 
                        var ssb = (Storyboard)this.FindResource("Stratup");
                        ssb.Begin();
                    }
                    )
                );
        }
    }
}
