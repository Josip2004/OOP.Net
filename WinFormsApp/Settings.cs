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

            cbSource.Items.Clear();
            cbSource.Items.Add("API");
            cbSource.Items.Add("File");

            ApplyLocalization();
            LoadSettings();
        }

        private void ApplyLocalization()
        {
            lblChampionshipSettings.Text = Strings.lblChampionshipSettings;
            lblChooseLanguage.Text = Strings.lblChooseLanguage;
            btnApplySettings.Text = Strings.btnApplySettings;

            string storedLanguage = _fileRepository.GetStoredLanguage();
            string storedGender = _fileRepository.GetStoredGender();
            string storedSource = _fileRepository.GetSource();

            cbChooseLanguage.Items.Clear();
            cbChooseLanguage.Items.Add(Strings.EnglishOption);
            cbChooseLanguage.Items.Add(Strings.CroatianOption);

            if (storedLanguage == "hr")
                cbChooseLanguage.SelectedItem = Strings.CroatianOption;
            else
                cbChooseLanguage.SelectedItem = Strings.EnglishOption;

            cbChooseChampionShip.Items.Clear();
            cbChooseChampionShip.Items.Add(Strings.ChampionshipMen);
            cbChooseChampionShip.Items.Add(Strings.ChampionshipWomen);

            if (storedGender == "women")
                cbChooseChampionShip.SelectedItem = Strings.ChampionshipWomen;
            else
                cbChooseChampionShip.SelectedItem = Strings.ChampionshipMen;

            cbSource.Items.Clear();
            cbSource.Items.Add("API");
            cbSource.Items.Add("File");

            cbSource.SelectedItem = storedSource.Equals("file", StringComparison.OrdinalIgnoreCase) ? "File" : "API";
        }


        private void LoadSettings()
        {
            string storedLanguage = _fileRepository.GetStoredLanguage();
            string storedGender = _fileRepository.GetStoredGender();
            string storedSource = _fileRepository.GetSource();


            if (!string.IsNullOrEmpty(storedLanguage))
            {
                if (storedLanguage.Equals("hr", StringComparison.OrdinalIgnoreCase))
                {
                    cbChooseLanguage.SelectedItem = Strings.CroatianOption;
                }
                else if (storedLanguage.Equals("en", StringComparison.OrdinalIgnoreCase))
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

            cbSource.SelectedItem = storedSource.Equals("file", StringComparison.OrdinalIgnoreCase)
                  ? "File"
                  : "API";
        }

        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            if (cbChooseChampionShip.SelectedItem == null || cbChooseLanguage.SelectedItem == null || cbSource.SelectedItem == null)
            {
                MessageBox.Show(Strings.msgSelect);
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
            string languageCode = language.Equals(Strings.CroatianOption, StringComparison.OrdinalIgnoreCase) ? "hr" : "en";

            string teamCode = _fileRepository.GetCurrentTeam();

            string resolution = "1280x720"; 

            string source = cbSource.SelectedItem.ToString().ToLower();

            string fullSettings = $"{gender}#{languageCode}#{teamCode}#{resolution}#{source}";
            _fileRepository.SaveSettings(fullSettings);

            var culture = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            ApplyLocalization();

            var newMainForm = new MainForm(_fileRepository);
            newMainForm.Show();

            SettingsApplied?.Invoke();
            this.Close();
        }

    }
}
