using System;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Menu.View;

namespace UtilitariosSuporte.Features.Menu
{
    public partial class FormMenu : Form, IMenuView
    {
        public event EventHandler SuporteClicked;
        public FormMenu()
        {
            InitializeComponent();
            this.Text = "Utilitário Suporte SBR - Menu Principal";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            btnSuporte.Click += btnSuporte_Click;
        }

        public void Exibir()
        {
            this.ShowDialog();
        }
        private void btnSuporte_Click(object sender, EventArgs e)
        {
            SuporteClicked?.Invoke(this, EventArgs.Empty);
        }
        public void MostrarNoConteudo(Control tela)
        {
            if (this.pnlConteudo.Controls.Count > 0)
                this.pnlConteudo.Controls.Clear();

            this.pnlConteudo.Controls.Add(tela);
            tela.Show();
        }
    }
}