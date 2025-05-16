using System.Windows.Forms;

namespace WinFormsApp.Properties
{
    internal static class ApplicationConfiguration
    {
        public static void Initialize()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
