using Dao.Repositories;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var fileRepo = new FileRepository();
        var gender = fileRepo.GetStoredGender(); 

        if (string.IsNullOrEmpty(gender))
        {
            MessageBox.Show("Gender not found in settings.txt");
            Shutdown(); 
            return;
        }

        var apiRepo = new ApiRepository(gender);
        var mainWindow = new MainWindow(apiRepo, new FileRepository());
        mainWindow.Show();
    }
}

