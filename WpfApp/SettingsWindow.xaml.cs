using Dao.Repositories;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp;

public partial class SettingsWindow : Window
{
    private const string Path = @"../../../../WinFormsApp/data/settings.txt";
    private FileRepository _repo = new FileRepository();
    private readonly IApiRepository _apiRepo;

    public SettingsWindow(IApiRepository apiRepo)
    {

        InitializeComponent();

        _apiRepo = apiRepo;
        _repo = new FileRepository();

        cbLanguage.ItemsSource = new[] { "English", "Hrvatski" };
        cbChampionship.ItemsSource = new[] { "Men", "Women" };
        cbResolution.ItemsSource = new[] { "1280x720", "1200x900", "fullscreen" };

        var settings = _repo.ReadFromFile(Path);

        string langCode = "en";
        if (!string.IsNullOrWhiteSpace(settings))
        {
            var parts = settings.Split('#');

            if (parts.Length >= 2)
                langCode = parts[1];

            cbLanguage.SelectedItem = langCode == "hr" ? "Hrvatski" : "English";

            if (parts.Length >= 1)
                cbChampionship.SelectedItem = parts[0] == "women" ? "Women" : "Men";

            if (parts.Length >= 4 && cbResolution.Items.Contains(parts[3]))
            {
                cbResolution.SelectedItem = parts[3];
            }
            else
            {
                cbResolution.SelectedItem = "1280x720";
            }
        }

        ApplyWindowSize(cbResolution.SelectedItem?.ToString());

    }

        private void ApplyWindowSize(string resolution)
        {
            try
            {
                if (resolution.ToLower() == "fullscreen")
                {
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    var parts = resolution.Split('x');

                    if (parts.Length == 2 &&
                        int.TryParse(parts[0], out int width) &&
                        int.TryParse(parts[1], out int height))
                    {

                        Width = width;
                        Height = height;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        string language = cbLanguage.SelectedItem?.ToString();
        string langCode = language == "Hrvatski" ? "hr" : "en";

        string championship = cbChampionship.SelectedItem.ToString();
        string champCode = championship == "Women" ? "women" : "men";

        string resolution = cbResolution.SelectedItem.ToString();

        if (language == null || championship == null || resolution == null)
        {
            MessageBox.Show("Please select all values.");
            return;
        }

        string teamCode = _repo.GetCurrentTeam();
        string content = $"{champCode}#{langCode}#{teamCode}#{resolution}";
        _repo.SaveSettings(content);

        var dict = new ResourceDictionary
        {
            Source = new Uri($"/Resources/Strings.{langCode}.xaml", UriKind.Relative)
        };
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(dict);

        var mainWindow = new MainWindow(_apiRepo, new FileRepository());
        mainWindow.Show();
        this.Close();
    }
}