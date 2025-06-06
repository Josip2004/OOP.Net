using Dao.Repositories;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
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

        string settingsPath = @"../../../../WinFormsApp/data/settings.txt";
        string langCode = "en"; 

        if (File.Exists(settingsPath))
        {
            string content = File.ReadAllText(settingsPath);
            var parts = content.Split('#');
            if (parts.Length >= 2)
                langCode = parts[1]; 
        }

        SetLanguageResources(langCode);

        var fileRepo = new FileRepository(); 
        var gender = fileRepo.GetStoredGender();

        if (string.IsNullOrEmpty(gender))
        {
            Shutdown();
            return;
        }

        var apiRepo = new ApiRepository(gender);
        var settingsWindow = new SettingsWindow();
        settingsWindow.ShowDialog();
    }

    private void SetLanguageResources(string langCode)
    {
        var dict = new ResourceDictionary();
        dict.Source = new Uri($"/Resources/Strings.{langCode}.xaml", UriKind.Relative);
        Resources.MergedDictionaries.Clear();
        Resources.MergedDictionaries.Add(dict);
    }
}

