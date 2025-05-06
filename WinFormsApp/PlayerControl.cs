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
                if (File.Exists(imagePath))
                {
                    using (var img = Image.FromFile(imagePath))
                    {
                        pbPlayer.Image = new Bitmap(img);
                    }
                }
                else
                {
                    using (var img = Image.FromFile(DefaultImage))
                    {
                        pbPlayer.Image = new Bitmap(img);
                    }
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
