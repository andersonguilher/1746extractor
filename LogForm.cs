using System;
using System.IO;
using System.Windows.Forms;

namespace DemandasApp
{
    public partial class LogForm : Form
    {
        public LogForm(string logFilePath)
        {
            InitializeComponent();
            try
            {
                txtLog.Text = File.ReadAllText(logFilePath);
            }
            catch (Exception ex)
            {
                txtLog.Text = $"Erro ao ler o arquivo de log: {ex.Message}";
            }
        }
    }
}
