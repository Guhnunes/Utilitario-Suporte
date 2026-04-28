using System;
using System.Drawing;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Login.View;
using UtilitariosSuporte.Features.Infraestrutura;

namespace UtilitariosSuporte.Features.Login
{
    public partial class FormLogin : BaseForm, ILoginView
    {
        public event EventHandler LoginClicked;
        public string Usuario => txtUsuario.Text;
        public string Senha => txtSenha.Text;
        public FormLogin()
        {
            InitializeComponent();
            ConfigurarEstilo();
            this.AcceptButton = btnLogin;
            this.Shown += FormLogin_Shown;
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
            txtSenha.Focus();
        }
        public void Logado()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void FormLogin_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtSenha.Focus();
            }
            else
            {
                txtUsuario.Focus();
            }
        }
    }
}