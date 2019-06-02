
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using HScada.SystemElement.Contract;
using HScada.SystemElement;

namespace Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : HScadaApp
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            App.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
            DispatcherUnhandledException += (sender, ex) =>
            {
                MessageBox.Show(ex.Exception.ToString());
                ex.Handled = true;
            };
            HScada.PLCModule.PlcModule.StaticCtorMotherd();
            base.OnStartup(e);


        }

        //模块注册
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HScada.Services.Module_ServicesModule>();
            moduleCatalog.AddModule<HScada.SystemElement.SystemModuleModule>();
            moduleCatalog.AddModule<HScada.PLCModule.PlcModule>();
            moduleCatalog.AddModule<Module1.Module1Module>();
        }



    }
}
