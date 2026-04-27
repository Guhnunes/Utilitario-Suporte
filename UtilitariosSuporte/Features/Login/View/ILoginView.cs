using System;
using System.Windows.Forms;

namespace UtilitariosSuporte.Features.Login.View
{
    public interface ILoginView
    {
        event EventHandler LoginClicked;
        string Usuario { get; }
        string Senha { get; }
        void Fechar();
    }
}