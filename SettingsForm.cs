using System;
using System.Windows.Forms;

namespace DemandasApp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            txtHost.Text = Properties.Settings.Default.DB_HOST;
            txtPort.Text = Properties.Settings.Default.DB_PORT;
            txtDbName.Text = Properties.Settings.Default.DB_NAME;
            txtUser.Text = Properties.Settings.Default.DB_USER;
            txtPassword.Text = Properties.Settings.Default.DB_PASS;
            txtTableName.Text = Properties.Settings.Default.TABLE_NAME;
            txtCookie.Text = Properties.Settings.Default.AUTH_COOKIE;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DB_HOST = txtHost.Text;
            Properties.Settings.Default.DB_PORT = txtPort.Text;
            Properties.Settings.Default.DB_NAME = txtDbName.Text;
            Properties.Settings.Default.DB_USER = txtUser.Text;
            Properties.Settings.Default.DB_PASS = txtPassword.Text;
            Properties.Settings.Default.TABLE_NAME = txtTableName.Text;
            Properties.Settings.Default.AUTH_COOKIE = txtCookie.Text;

            Properties.Settings.Default.Save();

            MessageBox.Show("Configurações salvas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // A propriedade DialogResult no botão já fecha o formulário.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // A propriedade DialogResult no botão já fecha o formulário.
        }
    }
}