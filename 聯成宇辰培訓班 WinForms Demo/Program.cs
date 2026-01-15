using 聯成宇辰培訓班_WinForms_Demo.Functions;
using 聯成宇辰培訓班_WinForms_Demo.NewFolder;
using 進銷存系統_Demo;

namespace 聯成宇辰培訓班_WinForms_Demo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
        }
    }
}