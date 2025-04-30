using Dao.Repositories;

namespace WinFormsApp
{
    public partial class StartDisplay : Form
    {
        public StartDisplay()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(cbChampionship.SelectedItem == null)
            {
                MessageBox.Show("Please select something.");
                return;
            }

            string gender = cbChampionship.SelectedItem.ToString().ToLower();
        //   File.WriteAllText("/settings.json", gender);

            var apiRepository = new ApiRepository(gender);
            var fileRepository = new FileRepository();

            var mainForm = new MainForm(apiRepository, fileRepository);
            mainForm.Show();
            this.Hide();

        }

        private void StartDisplay_Load(object sender, EventArgs e)
        {
            cbChampionship.Items.Add("Men");
            cbChampionship.Items.Add("Women");
            cbChampionship.SelectedIndex = 0;
        }
    }
}
