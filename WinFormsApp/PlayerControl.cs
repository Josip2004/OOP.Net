using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dao.Models;
using Dao.Enums;

namespace WinFormsApp
{
    public partial class PlayerControl : UserControl
    {
        const string DefaultImage = @"Images\\DefaultImage.jpg";

        public PlayerWithImage CurrentPlayer { get; private set; }

        public PlayerControl()
        {
            InitializeComponent();
        }

        public void LoadPlayer(PlayerWithImage player)
        {
            CurrentPlayer = player;

            lblName.Text = "Name: " + player.Player.Name;
            lblPosition.Text = "Position: " + player.Player.Position.ToString();
            lblCaptain.Text = "Captain: " + player.Player.Captain.ToString();
            lblShirtNum.Text = "Shirt Number: " + player.Player.ShirtNumber.ToString();
            // lblFavoritePlayer.Text = " " +  player.

            LoadPlayerImage(player.ImagePath);
        }

        private void LoadPlayerImage(string imagePath)
        {
            try
            {
                if (pbPlayer.Image != null)
                {
                    pbPlayer.Image.Dispose();
                    pbPlayer.Image = null;
                }

                if (File.Exists(imagePath))
                {
                    pbPlayer.Image = new Bitmap(imagePath);
                }
                else if (File.Exists(DefaultImage))
                {
                    pbPlayer.Image = new Bitmap(DefaultImage);
                }
                else
                {
                    MessageBox.Show("Default image nije pronađena.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri učitavanju slike: {ex.Message}");
            }
        }


        public void SetImage(string imagePath)
        {
            LoadPlayerImage(imagePath);
        }
    }
}
