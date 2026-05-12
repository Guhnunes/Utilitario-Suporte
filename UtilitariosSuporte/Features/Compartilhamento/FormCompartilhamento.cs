using System;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Infraestrutura;
using UtilitariosSuporte.Features.Compartilhamento.View;

namespace UtilitariosSuporte.Features.Compartilhamento
{
    public partial class FormCompartilhamento : BaseForm, ICompartilhamentoView
    {
        public event EventHandler ConfirmarClicked;

        public FormCompartilhamento()
        {
            InitializeComponent();

            // Padrão para abrir dentro do FormMenu.pnlConteudo
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // Vinculando o evento do botão
            btnConfirmar.Click += (s, e) => ConfirmarClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ExibirMensagem(string mensagem, bool sucesso)
        {
            MessageBox.Show(mensagem, "Sistema", MessageBoxButtons.OK,
                sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }
}