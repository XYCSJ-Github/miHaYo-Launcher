using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]

[assembly: AssemblyCopyright("Copyright © YuYuTianYang 2023")]//版权
[assembly: AssemblyCompany("YuYuTianYang")]//公司
[assembly: AssemblyTitle("miHaYo Launcher")]//文件说明
[assembly: AssemblyProduct("MHYL")]//产品名
[assembly: AssemblyVersion("0.13.2.*")]//版本号 [主号[次号[修订号[00:00:00-现在 的秒数/2]]]]
[assembly: AssemblyConfiguration("free")]//版本附加信息
[assembly: ComVisible(false)]//COM端口可访问性