using System;
using UtilitariosSuporte.Features.Infraestrutura;
using UtilitariosSuporte.Features.CaminhoFiscal.Repositories;
using UtilitariosSuporte.Features.CaminhoFiscal.View;

namespace UtilitariosSuporte.Features.CaminhoFiscal.Presenter
{
    public class CaminhoFiscalPresenter : BasePresenter<ICaminhoFiscalView>
    {
        private readonly ICaminhoFiscalRepository _repository;

        public CaminhoFiscalPresenter(ICaminhoFiscalRepository repository) : base(null)
        {
            _repository = repository;
        }

        public override void SetView(ICaminhoFiscalView view)
        {
            base.SetView(view);
            View.SalvarAlteracaoClicked += OnSalvarAlteracaoClicked;
            CarregarDadosIniciais();
        }

        private void CarregarDadosIniciais()
        {
            // Busca no banco através da Model
            string info = _repository.ObterDiretorioNFe();
            string infomdfe = _repository.ObterDiretorioMDFe();
            string infocte = _repository.ObterDiretorioCTe();

            // Preenche na View
            View.TextoDiretorioNFe = info;
            View.TextoDiretorioMDFe = infomdfe;
            View.TextoDiretorioCTe = infocte;
        }
        private void OnSalvarAlteracaoClicked(object sender, EventArgs e)
        {
            // Pega o texto que o usuário digitou no Form
            bool nfeOk = _repository.SalvarDiretorioNFe(View.TextoDiretorioNFe);
            bool mdfeOk = _repository.SalvarDiretorioMDFe(View.TextoDiretorioMDFe);
            bool cteOk = _repository.SalvarDiretorioCTe(View.TextoDiretorioCTe);

            if (nfeOk && mdfeOk && cteOk)
            {
                ControleDeMensagens.Informar("Configurações atualizadas com sucesso!");
                CarregarDadosIniciais(); 
            }
        }
    }
}