using System;
using System.Windows.Forms;

namespace UtilitariosSuporte.Features.Menu.View
{
    public interface IMenuView
    {
        event EventHandler SuporteClicked;
        void MostrarNoConteudo(Control tela);
        void Exibir();
        void DestacarBotaoMenu(string nomeBotao);
    }
}