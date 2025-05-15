using Dao.Models;
using Dao.Repositories;
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

            cbChampionship.Items.Clear();
            cbChampionship.Items.Add(Strings.ChampionshipMen);
            cbChampionship.Items.Add(Strings.ChampionshipWomen);

            cbLanguage.Items.Clear();
            cbLanguage.Items.Add(Strings.EnglishOption);
            cbLanguage.Items.Add(Strings.CroatianOption);
        }

        private void LoadSettings()
        {
            string storedLanguage = _fileRepository.GetStoredLanguage();
            string storedGender = _fileRepository.GetStoredGender();

            if (!string.IsNullOrEmpty(storedLanguage))
            {
                if (storedLanguage.Equals("croatian", StringComparison.OrdinalIgnoreCase))
                {
                    cbLanguage.SelectedItem = Strings.CroatianOption;
                }
                else if (storedLanguage.Equals("english", StringComparison.OrdinalIgnoreCase))
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
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbChampionship.SelectedItem == null || cbLanguage.SelectedItem == null)
            {
                MessageBox.Show("Please select both a championship and a language.");
                return;
            }

            string genderSelection = cbChampionship.SelectedItem.ToString();
            string gender = genderSelection.Equals(Strings.ChampionshipMen, StringComparison.OrdinalIgnoreCase) ? "men" : "women";

            string language = cbLanguage.SelectedItem.ToString();

            string existingTeamCode = _fileRepository.GetCurrentTeam();

            string fullSettings = string.IsNullOrWhiteSpace(existingTeamCode)
                ? $"{gender}#{language}"
                : $"{gender}#{language}#{existingTeamCode}";

            _fileRepository.SaveSettings(@"../../../data/settings.txt", fullSettings);

            var apiRepository = new ApiRepository(gender);

            var mainForm = new MainForm(apiRepository, _fileRepository);
            mainForm.Show();
            this.Hide();
        }
    }
}
