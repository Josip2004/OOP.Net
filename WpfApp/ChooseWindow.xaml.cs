using Dao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Window
    {
        private const string SettingsPath = "../../../../WinFormsApp/data/settings.txt";
        private readonly IFileRepository _repo;
        private readonly IApiRepository _apiRepo;
        public event Action? SettingsApplied;
        public bool WasApplied { get; private set; } = false;


        public ChooseWindow(IApiRepository apiRepo, IFileRepository fileRepo)
        {
            InitializeComponent();
            _repo = fileRepo;
            _apiRepo = apiRepo;

            cbLanguage.ItemsSource = new[] { "English", "Hrvatski" };
            cbChampionship.ItemsSource = new[] { "Men", "Women" };
            cbResolution.ItemsSource = new[] { "1280x720", "1200x900", "fullscreen" };

            var settings = _repo.ReadFromFile(SettingsPath);

            string langCode = "en";
            if (!string.IsNullOrEmpty(settings))
            {
                var parts = settings.Split('#');
                if (parts.Length >= 2)
                    langCode = parts[1];

                cbLanguage.SelectedItem = langCode == "hr" ? "Hrvatski" : "English";

                if (parts.Length >= 1)
                    cbChampionship.SelectedItem = parts[0] == "women" ? "Women" : "Men";

                if (parts.Length >= 4 && cbResolution.Items.Contains(parts[3]))
                    cbResolution.SelectedItem = parts[3];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string language = cbLanguage.SelectedItem?.ToString();
            string langCode = language == "Hrvatski" ? "hr" : "en";

            string championship = cbChampionship.SelectedItem?.ToString();
            string champCode = championship == "Women" ? "women" : "men";

            string resolution = cbResolution.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(language) || string.IsNullOrWhiteSpace(championship) || string.IsNullOrWhiteSpace(resolution))
            {
                MessageBox.Show("Please select all values.");
                return;
            }

            string teamCode = _repo.GetCurrentTeam();
            var confirmWindow = new ConfirmWindow();
            bool? result = confirmWindow.ShowDialog();

            if (confirmWindow.IsConfirmed)
            {
                string settings = $"{champCode}#{langCode}#{teamCode}#{resolution}";
                _repo.SaveSettings(settings);

                var dict = new ResourceDictionary
                {
                    Source = new Uri($"/Resources/Strings.{langCode}.xaml", UriKind.Relative)
                };
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dict);

                foreach (Window w in Application.Current.Windows)
                {
                    if (w is MainWindow mw)
                    {
                        mw.RefreshLanguage();
                    }
                }

                WasApplied = true;
                SettingsApplied?.Invoke();
                this.Close();
            }
        }
    }
}
