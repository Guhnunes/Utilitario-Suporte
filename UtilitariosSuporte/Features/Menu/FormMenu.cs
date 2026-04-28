using System;
using System.Drawing;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Infraestrutura;
using UtilitariosSuporte.Features.Menu.View;

namespace UtilitariosSuporte.Features.Menu
{
    public partial class FormMenu : BaseForm, IMenuView
    {
        public event EventHandler SuporteClicked;
        public FormMenu()
        {
            InitializeComponent();
            this.Text = "Utilitário Suporte SBR - Menu Principal";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            btnCaminhoFiscal.Click += btnSuporte_Click;
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
        public void DestacarBotaoMenu(string nomeBotao)
        {
            // Supondo que seus botões estejam dentro de um Panel chamado pnlMenuLateral
            foreach (Control ctr in pnlLateral.Controls)
            {
                if (ctr is Button btn)
                {
                    // Cor padrão (ex: transparente ou cinza escuro)
                    btn.BackColor = Color.FromArgb(45, 45, 48);

                    // Se for o botão que queremos destacar
                    if (btn.Name == nomeBotao)
                    {
                        // Cor de destaque (ex: aquele azul que usamos no salvar)
                        btn.BackColor = Color.FromArgb(0, 122, 204);
                    }
                }
            }
        }
    }
}