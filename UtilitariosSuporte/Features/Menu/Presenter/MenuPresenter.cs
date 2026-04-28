using Autofac;
using System;
using System.Windows.Forms;
using UtilitariosSuporte.Features.Infraestrutura;
using UtilitariosSuporte.Features.Login.Presenter;
using UtilitariosSuporte.Features.Menu.View;
using UtilitariosSuporte.Features.CaminhoFiscal.Presenter;
using UtilitariosSuporte.Features.CaminhoFiscal.View;

namespace UtilitariosSuporte.Features.Menu.Presenter
{
    public class MenuPresenter : BasePresenter<IMenuView>
    {
        private readonly ILifetimeScope _scope;
        public MenuPresenter(ILifetimeScope scope) : base(null)
        {
            _scope = scope;
        }

        public override void SetView(IMenuView view)
        {
            base.SetView(view);
            view.SuporteClicked += OnSuporteClicked;
            AbrirTelaSuporte();
        }
        private void OnSuporteClicked(object sender, EventArgs e)
        {
            AbrirTelaSuporte();
        }
        private void AbrirTelaSuporte()
        {
            // Resolve a View de Suporte via Autofac
            var suporteView = _scope.Resolve<ICaminhoFiscalView>();
            var suportePresenter = _scope.Resolve<CaminhoFiscalPresenter>();
            suportePresenter.SetView(suporteView);
            // Manda a View do Menu exibir o formulário de suporte no painel
            View.MostrarNoConteudo((Control)suporteView);
            View.DestacarBotaoMenu("btnCaminhoFiscal");
        }
    }
}