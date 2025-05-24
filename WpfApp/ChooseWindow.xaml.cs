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

            cbLanguage.ItemsSource = new[] { "English", "Croatian" };
            cbChampionship.ItemsSource = new[] { "men", "women" };
            cbResolution.ItemsSource = new[] { "1280x720", "1200x900", "fullscreen" };

            var settings = _repo.ReadFromFile(SettingsPath);
            if (!string.IsNullOrEmpty(settings))
            {
                var parts = settings.Split('#');
                if (parts.Length >= 2)
                {
                    cbChampionship.SelectedItem = parts[0];
                    cbLanguage.SelectedItem = parts[1];

                    if (parts.Length >= 4)
                    {
                        cbResolution.SelectedItem = parts[3];
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string language = cbLanguage.SelectedItem?.ToString();
            string championship = cbChampionship.SelectedItem?.ToString();
            string resolution = cbResolution.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(language) || string.IsNullOrWhiteSpace(championship) || string.IsNullOrWhiteSpace(resolution))
            {
                MessageBox.Show("Please select all values.");
                return;
            }

            string teamCode = _repo.GetCurrentTeam();
            string settings = $"{championship.ToLower()}#{language}#{teamCode}#{resolution}";
            _repo.SaveSettings(settings);

            WasApplied = true;
            SettingsApplied?.Invoke();
            this.Close();
        }
    }
}
