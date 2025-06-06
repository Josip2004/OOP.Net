using Dao.Models;
using Dao.Repositories;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp.Properties;

namespace WinFormsApp
{
    public partial class StartDisplay : Form
    {
        private readonly IFileRepository _fileRepository;

        public StartDisplay()
        {
            InitializeComponent();
            _fileRepository = new FileRepository();

            SetCultureFromSettings();
            ApplyLocalization();
            LoadSettings();
        }

        private void SetCultureFromSettings()
        {
            string lang = _fileRepository.GetStoredLanguage();
            if (string.IsNullOrWhiteSpace(lang)) return;

            string cultureCode = lang.Equals("Croatian", StringComparison.OrdinalIgnoreCase) ? "hr" : "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
        }

        private void ApplyLocalization()
        {
            lblChooserChampionship.Text = Strings.lblChooserChampionship;
            lblSelectLanguage.Text = Strings.lblSelectLanguage;
            btnApply.Text = Strings.btnApply;
            btnNext.Text = Strings.btnNext;

            var selectedLanguage = cbLanguage.SelectedItem?.ToString();
            var selectedChampionship = cbChampionship.SelectedItem?.ToString();

            cbChampionship.Items.Clear();
            cbChampionship.Items.Add(Strings.ChampionshipMen);
            cbChampionship.Items.Add(Strings.ChampionshipWomen);

            if (!string.IsNullOrEmpty(selectedChampionship))
            {
                if (selectedChampionship.Equals("Men", StringComparison.OrdinalIgnoreCase) ||
                    selectedChampionship.Equals(Strings.ChampionshipMen, StringComparison.OrdinalIgnoreCase))
                {
                    cbChampionship.SelectedItem = Strings.ChampionshipMen;
                }
                else
                {
                    cbChampionship.SelectedItem = Strings.ChampionshipWomen;
                }
            }

            cbLanguage.Items.Clear();
            cbLanguage.Items.Add(Strings.EnglishOption);
            cbLanguage.Items.Add(Strings.CroatianOption);
            cbSource.Items.Clear();
            cbSource.Items.Add("API");
            cbSource.Items.Add("File");

            if (!string.IsNullOrEmpty(selectedLanguage))
            {
                if (selectedLanguage.Equals("English", StringComparison.OrdinalIgnoreCase) ||
                    selectedLanguage.Equals(Strings.EnglishOption, StringComparison.OrdinalIgnoreCase))
                {
                    cbLanguage.SelectedItem = Strings.EnglishOption;
                }
                else
                {
                    cbLanguage.SelectedItem = Strings.CroatianOption;
                }
            }
        }

        private void LoadSettings()
        {
            string storedLanguage = _fileRepository.GetStoredLanguage();
            string storedGender = _fileRepository.GetStoredGender();

            if (!string.IsNullOrEmpty(storedLanguage))
            {
                if (storedLanguage.Equals("hr", StringComparison.OrdinalIgnoreCase))
                {
                    cbLanguage.SelectedItem = Strings.CroatianOption;
                }
                else if (storedLanguage.Equals("en", StringComparison.OrdinalIgnoreCase))
                {
                    cbLanguage.SelectedItem = Strings.EnglishOption;
                }
            }

            if (!string.IsNullOrEmpty(storedGender))
            {
                if (storedGender.Equals("men", StringComparison.OrdinalIgnoreCase))
                    cbChampionship.SelectedItem = Strings.ChampionshipMen;
                else if (storedGender.Equals("women", StringComparison.OrdinalIgnoreCase))
                    cbChampionship.SelectedItem = Strings.ChampionshipWomen;
            }

            string storedSource = _fileRepository.GetSource();
            cbSource.SelectedItem = storedSource.Equals("file", StringComparison.OrdinalIgnoreCase) ? "File" : "API";

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbChampionship.SelectedItem == null || cbLanguage.SelectedItem == null)
            {
                MessageBox.Show(Strings.msgSelect);
                return;
            }

            string selectedGender = cbChampionship.SelectedItem?.ToString() ?? "";
            string gender = selectedGender.Equals(Strings.ChampionshipMen, StringComparison.OrdinalIgnoreCase)
                ? "men"
                : "women";
            string language = cbLanguage.SelectedItem.ToString();
            string languageCode = language.Equals(Strings.CroatianOption, StringComparison.OrdinalIgnoreCase) ? "hr" : "en";

            string source = cbSource.SelectedItem?.ToString()?.ToLower() ?? "api";

            string existingTeamCode = _fileRepository.GetCurrentTeam();
            string resolution = "1280x720";
            string fullSettings = $"{gender}#{languageCode}#{existingTeamCode}#{resolution}#{source}";

            _fileRepository.SaveSettings(fullSettings);

            string cultureCode = language.Equals(Strings.CroatianOption, StringComparison.OrdinalIgnoreCase) ? "hr" : "en";
            var culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            ApplyLocalization();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string selectedGender = cbChampionship.SelectedItem?.ToString() ?? "";
            string gender = selectedGender.Equals(Strings.ChampionshipMen, StringComparison.OrdinalIgnoreCase)
                ? "men"
                : "women";
            var mainForm = new MainForm(_fileRepository);
            mainForm.Show();
            this.Hide();
        }
    }
}
