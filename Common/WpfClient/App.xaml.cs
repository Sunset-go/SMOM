using SIE;
using SIE.Configuration;
using SIE.Wpf;
using SIE.Wpf.Modules;
using SIE.Wpf.Windows;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfClient
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application, IClientAppRuntime
    {
        public App()
        {
            ConfigManager.Create().UserJsonConfig("appsettings.json");
            //读取Debugging环境
            RT.Provider.IsDebuggingEnabled = RT.Config.Get(ConfigKeys.IsDebuggingEnabled, false);
            Startup += App_Startup;
            //注册程序未处理的异常处理方法
            DispatcherUnhandledException += OnDispatcherUnhandledException;
            //
            ClientApp.LoginHandler = () => new SIE.Wpf.Windows.Login.LoginWin().ShowDialog() == true;
            App app = this;
            ClientApp.Register(app);
            ClientApp.Current.LoginSuccessed += delegate { MoveUpdatorFiles(); };
#if DEBUG
            SIE.Data.DbAccesserFactory.DbCommandPrepared += (s, e) =>
            {
                string sqlDebug = e.DbCommand.ToTraceString();
                System.Diagnostics.Trace.WriteLine(sqlDebug);
            };
#endif
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            CRT.Service.Register<IModuleTypeLoader, ModuleTypeLoader>();
        }

        void MoveUpdatorFiles()
        {
            Task.Run(() =>
            {
                var file = RT.Config.Get(ConfigKeys.AutoUpdator, "S-MOM.exe");
                MoveUpdatorFile(file);
                MoveUpdatorFile(file + ".config");
                MoveUpdatorFile("resources/splash.mp4");
            });
        }

        void MoveUpdatorFile(string file)
        {
            try
            {
                var source = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AutoUpdator", file);
                if (File.Exists(source))
                {
                    var target = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
                    if (File.Exists(target))
                        File.Delete(target);
                    File.Move(source, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, target));
                }
            }
            catch (Exception exc) { RT.Logger.Error("AutoUpdator", exc); }
        }

        void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                if (RT.Service.IsRegistered<SIE.Services.IMessageService>())
                    e.Exception.Alert();
                else
                    SIE.Wpf.Services.WpfMessageService.DoShowErrorDetail(e.Exception, "发生错误:" + e.Exception.Message);
                e.Handled = true;
            }
            catch (Exception exc)
            {
                try
                {
                    //记录异常信息
                    CRT.Logger.Error("显示异常失败:" + e.Exception.GetExceptionDetail(), exc);
                }
                catch { 
                    //不处理
                }
            }
        }
    }
}
