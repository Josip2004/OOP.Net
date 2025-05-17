using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class ConfirmSettingsBox : Form
    {
        public ConfirmSettingsBox()
        {
            InitializeComponent();
            ApplyLocalization();
            this.CancelButton = btnSettingsNo;
            this.AcceptButton = btnSettingsYes;
        }

        private void ApplyLocalization()
        {
            lblConfirmLabel.Text = Strings.lblConfirmLabel;
            btnSettingsNo.Text = Strings.btnSettingsNo;
            btnSettingsYes.Text = Strings.btnSettingsYes;
        }

        private void btnSettingsYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnSettingsNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
