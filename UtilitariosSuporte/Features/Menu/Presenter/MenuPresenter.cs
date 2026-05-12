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
            view.CompartilhamentoClicked += OnCompartilhamentoClicked;
            AbrirTelaSuporte();
        }
        private void OnCompartilhamentoClicked(object sender, EventArgs e)
        {
            AbrirTelaCompartilhamento();
        }
        private void AbrirTelaCompartilhamento()
        {
            var compView = _scope.Resolve<UtilitariosSuporte.Features.Compartilhamento.View.ICompartilhamentoView>();
            var compPresenter = _scope.Resolve<UtilitariosSuporte.Features.Compartilhamento.Presenter.CompartilhamentoPresenter>();

            compPresenter.SetView(compView);

            View.MostrarNoConteudo((Control)compView);
            View.DestacarBotaoMenu("btnCompartilhamento");
        }
        private void OnSuporteClicked(object sender, EventArgs e)
        {
            AbrirTelaSuporte();
        }
        private void AbrirTelaSuporte()
        {
            var suporteView = _scope.Resolve<IDirFiscalView>();
            var suportePresenter = _scope.Resolve<CaminhoFiscalPresenter>();
            suportePresenter.SetView(suporteView);
            View.MostrarNoConteudo((Control)suporteView);
            View.DestacarBotaoMenu("btnCaminhoFiscal");
        }
    }
}