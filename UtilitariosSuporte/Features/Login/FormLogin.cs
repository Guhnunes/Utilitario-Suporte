using System;
using System.Drawing;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Login.View;

namespace UtilitariosSuporte.Features.Login
{
    public partial class FormLogin : Form, ILoginView
    {
        public event EventHandler LoginClicked;
        public string Usuario => txtUsuario.Text;
        public string Senha => txtSenha.Text;
        public FormLogin()
        {
            InitializeComponent();
            ConfigurarEstilo();
            this.AcceptButton = btnLogin;
        }

        private void ConfigurarEstilo()
        {
            // Melhora o visual inicial via código
            this.BackColor = Color.FromArgb(240, 240, 240);
            btnLogin.BackColor = Color.FromArgb(79, 70, 229);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;

            txtSenha.PasswordChar = '●';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginClicked?.Invoke(this, EventArgs.Empty);
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void LimparCampos()
        {
            txtSenha.Clear();
            txtUsuario.Focus();
        }
        public void Logado()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}