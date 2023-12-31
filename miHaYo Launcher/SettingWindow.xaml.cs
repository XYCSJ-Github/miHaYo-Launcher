﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Ioini;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace miHaYo_Launcher
{
    /// <summary>
    /// SettingWindow.xaml 的交互逻辑
    /// </summary>

    public partial class SettingWindow : Window
    {
        PathGameStart pgs;
        MainWindow mw;

        [DllImport("Memory Cleaner.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int CleanMomery();
        public SettingWindow(MainWindow mainWindow)
        {
            this.ResizeMode = ResizeMode.CanMinimize;
            InitializeComponent();
            mw = mainWindow;

            PathGameStart_b3.Text = pgs.PGS_b3 = mw.pgs.PGS_b3;
            PathGameStart_ys.Text = pgs.PGS_ys = mw.pgs.PGS_ys;
            PathGameStart_sr.Text = pgs.PGS_sr = mw.pgs.PGS_sr;
        }

        private void 浏览_Click_ys(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "原神 启动可执行文件（YuanShen.exe）|YuanShen.exe|可执行文件（*.exe）|*.exe|所有文件（*.*）|*.*";
            fileDialog.Title = "选取 原神 的可执行文件启动路径";
            if (fileDialog.ShowDialog() == true)
            {
                PathGameStart_ys.Text = fileDialog.FileName;
                pgs.PGS_ys = fileDialog.FileName;
            }
        }

        private void 浏览_Click_b3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "选取 崩坏3 的可执行文件启动路径";
            fileDialog.Filter = "崩坏3 启动可执行文件（BH3.exe）|BH3.exe|可执行文件（*.exe）|*.exe|所有文件（*.*）|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                PathGameStart_b3.Text = fileDialog.FileName;
                pgs.PGS_b3 = fileDialog.FileName;
            }
        }

        private void 浏览_Click_sr(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "选取 崩坏：星穹铁道 的可执行文件启动路径";
            fileDialog.Filter = "崩坏：星穹铁道 可执行文件（StarRail.exe）|StarRail.exe|可执行文件（*.exe）|*.exe|所有文件（*.*）|*.*";
            if (fileDialog.ShowDialog() == true)
            {
                PathGameStart_sr.Text = fileDialog.FileName;
                pgs.PGS_sr = fileDialog.FileName;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Set_PGS(pgs);
            Ioini.IniFile ini = new IniFile(mw.iniPath);
            ini.Write("PathGameStart", mw.pgs.PGS_sr, "Star Rail");
            ini.Write("PathGameStart", mw.pgs.PGS_ys, "Genshin Impact");
            ini.Write("PathGameStart", mw.pgs.PGS_b3, "Honkai Impact 3");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void OpenSettingIni_Click(object sender, RoutedEventArgs e)
        {
            Process myProcess = new Process();//创建进程对象
            myProcess.StartInfo.FileName = "cmd.exe";//设置打开cmd命令窗口
            myProcess.StartInfo.UseShellExecute = false;//不使用操作系统shell启动进程的值
            myProcess.StartInfo.RedirectStandardInput = true;//设置可以从标准输入流读取值
            myProcess.StartInfo.RedirectStandardOutput = true;//设置可以向标准输出流写入值
            myProcess.StartInfo.RedirectStandardError = true;//设置可以显示输入输出流中出现的错误
            myProcess.StartInfo.CreateNoWindow = true;//设置在新窗口中启动进程
            myProcess.Start();//启动进程
            myProcess.StandardInput.WriteLine(mw.iniPath);//传入要执行的命令
        }

        private void MemoryCleaner_Click(object sender, RoutedEventArgs e)
        {
            Thread thr_ = new Thread(CleanMomery);
            thr_.Start();
        }

        private void CleanMomery(object? obj)
        {
            CleanMomery();
        }
    }
}
