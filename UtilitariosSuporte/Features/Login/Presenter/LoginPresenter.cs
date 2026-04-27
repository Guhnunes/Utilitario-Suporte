using Autofac;
using System;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Infraestrutura;
using UtilitariosSuporte.Features.Login.View;

namespace UtilitariosSuporte.Features.Login.Presenter
{
    public class LoginPresenter : BasePresenter<ILoginView>
    {
        public LoginPresenter() : base(null)
        {
        }
        public override void SetView(ILoginView view)
        {
            base.SetView(view);
            view.LoginClicked += OnLoginClicked;
        }
        public void OnLoginClicked(object sender, EventArgs e)
        {
            string user = View.Usuario;
            string pass = View.Senha;
            // A validação acontece aqui
            if (user == "ADMIN" && pass == "123")
            {
                View.Logado();
            }
            else
            {
                ControleDeMensagens.Informar("Usuário ou senha incorretos!");
                View.LimparCampos();
            }
        }

    }
}
