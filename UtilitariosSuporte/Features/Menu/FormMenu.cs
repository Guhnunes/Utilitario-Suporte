using System;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Menu.View;

namespace UtilitariosSuporte.Features.Menu
{
    public partial class FormMenu : Form, IMenuView
    {
        public FormMenu()
        {
            InitializeComponent();
            this.Text = "Utilitário Suporte SBR - Menu Principal";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void Exibir()
        {
            this.ShowDialog();
        }
    }
}