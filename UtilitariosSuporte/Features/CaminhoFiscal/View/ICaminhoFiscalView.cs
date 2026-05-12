using System;

namespace UtilitariosSuporte.Features.CaminhoFiscal.View
{
    public interface IDirFiscalView
    {
        event EventHandler SalvarAlteracaoClicked;
        string TextoDiretorioNFe { get; set; }
        string TextoDiretorioMDFe { get; set; }
        string TextoDiretorioCTe { get; set; }
    }
}