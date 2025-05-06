using Dao.Models;
using Dao.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class StartDisplay : Form
    {
        private readonly IFileRepository _fileRepository;

        public StartDisplay()
        {
            InitializeComponent();
            _fileRepository = new FileRepository();

            LoadSettings();
        }

        private void LoadSettings()
        {
            string storedLanguage = _fileRepository.GetStoredLanguage();
            string storedGender = _fileRepository.GetStoredGender();

            if (!string.IsNullOrEmpty(storedLanguage))
            {
                cbLanguage.SelectedItem = storedLanguage;
            }
            else
            {
                if (cbLanguage.Items.Count > 0)
                {
                    cbLanguage.SelectedIndex = 0; 
                }
            }

            if (!string.IsNullOrEmpty(storedGender))
            {
                cbChampionship.SelectedItem = storedGender;
            }
            else
            {
                if (cbChampionship.Items.Count > 0)
                {
                    cbChampionship.SelectedIndex = 0; 
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbChampionship.SelectedItem == null || cbLanguage.SelectedItem == null)
            {
                MessageBox.Show("Please select both a championship and a language.");
                return;
            }

            string gender = cbChampionship.SelectedItem.ToString().ToLower();
            string language = cbLanguage.SelectedItem.ToString();

            string existingTeamCode = _fileRepository.GetCurrentTeam();

            string fullSettings;

            if (string.IsNullOrWhiteSpace(existingTeamCode))
            {
                fullSettings = $"{gender}#{language}";
            }
            else
            {
                fullSettings = $"{gender}#{language}#{existingTeamCode}";
            }

            _fileRepository.SaveSettings(@"../../../data/settings.txt", fullSettings);

            var apiRepository = new ApiRepository(gender);

            var mainForm = new MainForm(apiRepository, _fileRepository);
            mainForm.Show();
            this.Hide();
        }


        private void StartDisplay_Load(object sender, EventArgs e)
        {
            cbChampionship.Items.Add("Men");
            cbChampionship.Items.Add("Women");

            cbLanguage.Items.Add("English");
            cbLanguage.Items.Add("Croatian");

            string storedGender = _fileRepository.GetStoredGender();
            if (!string.IsNullOrEmpty(storedGender))
            {
                if (storedGender.Equals("men", StringComparison.OrdinalIgnoreCase))
                {
                    cbChampionship.SelectedItem = "Men";
                }
                else if (storedGender.Equals("women", StringComparison.OrdinalIgnoreCase))
                {
                    cbChampionship.SelectedItem = "Women";
                }
                else
                {
                    cbChampionship.SelectedIndex = -1; 
                }
            }
            else
            {
                cbChampionship.SelectedIndex = -1;
            }

            string storedLanguage = _fileRepository.GetStoredLanguage();
            if (!string.IsNullOrEmpty(storedLanguage))
            {
                if (storedLanguage.Equals("croatian", StringComparison.OrdinalIgnoreCase))
                {
                    cbLanguage.SelectedItem = "Croatian";
                }
                else if (storedLanguage.Equals("english", StringComparison.OrdinalIgnoreCase))
                {
                    cbLanguage.SelectedItem = "English";
                }
                else
                {
                    cbLanguage.SelectedIndex = -1;  
                }
            }
            else
            {
                cbLanguage.SelectedIndex = -1;
            }
        }



    }
}
