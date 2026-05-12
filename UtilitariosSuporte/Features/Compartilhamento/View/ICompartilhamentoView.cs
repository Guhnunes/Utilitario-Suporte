using System;

namespace UtilitariosSuporte.Features.Compartilhamento.View
{
    public interface ICompartilhamentoView
    {
        event EventHandler ConfirmarClicked;
        void ExibirMensagem(string mensagem, bool sucesso);
    }
}