using Dao.Repositories;
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
    private const string Path = @"../../../../data/settings.txt";
    private FileRepository _repo = new FileRepository();
    public SettingsWindow()
    {
        InitializeComponent();

        cbLanguage.ItemsSource = new[] { "English", "Croatian" };
        cbChampionship.ItemsSource = new[] { "men", "women" };
        cbResolution.ItemsSource = new[] { "1280x720", "1600x900", "fullscreen" };


        var settings = _repo.ReadFromFile(Path);

        if (!string.IsNullOrEmpty(settings))
        {
            var parts = settings.Split('#');
            if(parts.Length >= 2)
            {
                cbChampionship.SelectedItem = parts[0];
                cbLanguage.SelectedItem = parts[1];

                if (parts.Length >= 4)
                {
                    cbResolution.SelectedItem = parts[3];
                    ApplyWindowSize(parts[3]);
                }
                else
                {
                    cbResolution.SelectedIndex = 0;
                    ApplyWindowSize(cbResolution.SelectedItem?.ToString());
                }
            }
        }
    }

    private void ApplyWindowSize(string resolution)
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

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string language = cbLanguage.SelectedItem?.ToString();
        string championship = cbChampionship.SelectedItem.ToString();
        string resolution = cbResolution.SelectedItem.ToString();

        if (language == null || championship == null || resolution == null)
        {
            MessageBox.Show("Please select all values.");
            return;
        }

        string content = $"{championship.ToLower()}#{language}##{resolution}";

        _repo.SaveSettings(content);
    }
}