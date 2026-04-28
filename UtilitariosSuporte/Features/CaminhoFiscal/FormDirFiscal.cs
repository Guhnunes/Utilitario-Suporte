using System;
using System.Windows.Forms;
using UtilitariosSuporte.Features.CaminhoFiscal.View;

namespace UtilitariosSuporte.Features.CaminhoFiscal
{
    public partial class FormDirFiscal : Form, ICaminhoFiscalView
    {
        // Supondo que você arrastou um TextBox chamado txtInfoSuporte no Designer
        public string TextoDiretorioNFe
        {
            get { return txtDirNFe.Text; }
            set { txtDirNFe.Text = value; }
        }
        public string TextoDiretorioMDFe
        {
            get { return txtDirMDFe.Text; }
            set { txtDirMDFe.Text = value; }
        }
        public string TextoDiretorioCTe
        {
            get { return txtDirCTe.Text; }
            set { txtDirCTe.Text = value; }
        }
        public event EventHandler SalvarAlteracaoClicked;
        public FormDirFiscal()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            btnSalvar.Click += (s, e) => SalvarAlteracaoClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}