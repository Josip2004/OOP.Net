using Dao.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Settings : Form
    {
        private readonly IFileRepository _fileRepository;
        public event Action? SettingsApplied;
        public bool SettingsWereConfirmed { get; private set; } = false;
        public Settings()
        {
            InitializeComponent();

            _fileRepository = new FileRepository();

            ApplyLocalization();
            LoadSettings();
        }

        private void ApplyLocalization()
        {
            lblChampionshipSettings.Text = Strings.lblChampionshipSettings;
            lblChooseLanguage.Text = Strings.lblChooseLanguage;
            btnApplySettings.Text = Strings.btnApplySettings;

            var selectedLanguage = cbChooseChampionShip.SelectedItem?.ToString();
            var selectedChampionship = cbChooseLanguage.SelectedItem?.ToString();

            cbChooseChampionShip.Items.Clear();
            cbChooseChampionShip.Items.Add(Strings.ChampionshipMen);
            cbChooseChampionShip.Items.Add(Strings.ChampionshipWomen);

            if (!string.IsNullOrEmpty(selectedChampionship))
            {
                if (selectedChampionship.Equals("Men", StringComparison.OrdinalIgnoreCase) ||
                    selectedChampionship.Equals(Strings.ChampionshipMen, StringComparison.OrdinalIgnoreCase))
                {
                    cbChooseChampionShip.SelectedItem = Strings.ChampionshipMen;
                }
                else
                {
                    cbChooseChampionShip.SelectedItem = Strings.ChampionshipWomen;
                }
            }

            cbChooseLanguage.Items.Clear();
            cbChooseLanguage.Items.Add(Strings.EnglishOption);
            cbChooseLanguage.Items.Add(Strings.CroatianOption);

            if (!string.IsNullOrEmpty(selectedLanguage))
            {
                if (selectedLanguage.Equals("English", StringComparison.OrdinalIgnoreCase) ||
                    selectedLanguage.Equals(Strings.EnglishOption, StringComparison.OrdinalIgnoreCase))
                {
                    cbChooseLanguage.SelectedItem = Strings.EnglishOption;
                }
                else
                {
                    cbChooseLanguage.SelectedItem = Strings.CroatianOption;
                }
            }
        }

        private void LoadSettings()
        {
            string storedLanguage = _fileRepository.GetStoredLanguage();
            string storedGender = _fileRepository.GetStoredGender();

            if (!string.IsNullOrEmpty(storedLanguage))
            {
                if (storedLanguage.Equals("croatian", StringComparison.OrdinalIgnoreCase))
                {
                    cbChooseLanguage.SelectedItem = Strings.CroatianOption;
                }
                else if (storedLanguage.Equals("english", StringComparison.OrdinalIgnoreCase))
                {
                    cbChooseLanguage.SelectedItem = Strings.EnglishOption;
                }
            }

            if (!string.IsNullOrEmpty(storedGender))
            {
                if (storedGender.Equals("men", StringComparison.OrdinalIgnoreCase))
                    cbChooseChampionShip.SelectedItem = Strings.ChampionshipMen;
                else if (storedGender.Equals("women", StringComparison.OrdinalIgnoreCase))
                    cbChooseChampionShip.SelectedItem = Strings.ChampionshipWomen;
            }
        }

        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            if (cbChooseChampionShip.SelectedItem == null || cbChooseLanguage.SelectedItem == null)
            {
                MessageBox.Show("Please select both a championship and a language.");
                return;
            }

            using (var confirmBox = new ConfirmSettingsBox())
            {
                var confirmResult = confirmBox.ShowDialog();

                if (confirmResult != DialogResult.Yes)
                {
                    this.Close();
                    return;
                }
            }

            string selectedGender = cbChooseChampionShip.SelectedItem?.ToString() ?? "";
            string gender = selectedGender.Equals(Strings.ChampionshipMen, StringComparison.OrdinalIgnoreCase)
                ? "men"
                : "women";
            string language = cbChooseLanguage.SelectedItem.ToString();

            string existingTeamCode = _fileRepository.GetCurrentTeam();
            string fullSettings = string.IsNullOrWhiteSpace(existingTeamCode)
                ? $"{gender}#{language}"
                : $"{gender}#{language}#{existingTeamCode}";

            _fileRepository.SaveSettings(@"../../../data/settings.txt", fullSettings);

            string cultureCode = language.Equals("Croatian", StringComparison.OrdinalIgnoreCase) ? "hr" : "en";
            var culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            ApplyLocalization();

            var apiRepo = new ApiRepository(gender);
            var newMainForm = new MainForm(apiRepo, _fileRepository);
            newMainForm.Show();

            SettingsApplied?.Invoke();
            this.Close();
        }
    }
}
