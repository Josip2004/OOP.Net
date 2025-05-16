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
using WinFormsApp.Properties;

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

            lblName.Text = Strings.lblName + " " + player.Player.Name;
            lblPosition.Text = Strings.lblPosition + " " + LocalizePosition(player.Player.Position);
            lblCaptain.Text = Strings.lblCaptain + " " + player.Player.Captain.ToString();
            lblShirtNum.Text = Strings.lblShirtNum + " " + player.Player.ShirtNumber.ToString();
            lblFavoritePlayer.Text = Strings.lblFavoritePlayer + " ";

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

        public static string LocalizePosition(Position position)
        {
            return position switch
            {
                Position.Goalie => Strings.Position_GK,
                Position.Defender => Strings.Position_DF,
                Position.Midfield => Strings.Position_MF,
                Position.Forward => Strings.Position_FW,
                _ => position.ToString()
            };
        }

        public void ApplyLocalization()
        {
            if (CurrentPlayer != null)
            {
                lblName.Text = Strings.lblName + " ";
                lblPosition.Text = Strings.lblPosition + " ";
                lblCaptain.Text = Strings.lblCaptain + " ";
                lblShirtNum.Text = Strings.lblShirtNum + " ";
                lblFavoritePlayer.Text = Strings.lblFavoritePlayer + " ";
            }
        }
    }
}
