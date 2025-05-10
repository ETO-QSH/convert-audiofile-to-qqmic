using System.Windows;
using NAudio.MediaFoundation;

namespace AudioToMicWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            try
            {
                // 初始化Media Foundation（用于AAC等格式支持）
                MediaFoundationApi.Startup();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                // 处理缺少Media Foundation的情况
                MessageBox.Show(
                    $"媒体基础初始化失败: {ex.Message}\n" +
                    "请确保系统已安装Windows Media Feature Pack",
                    "严重错误", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                
                Shutdown(1); // 非正常退出
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            MediaFoundationApi.Shutdown(); // 清理Media Foundation资源
            base.OnExit(e);
        }
    }
}
