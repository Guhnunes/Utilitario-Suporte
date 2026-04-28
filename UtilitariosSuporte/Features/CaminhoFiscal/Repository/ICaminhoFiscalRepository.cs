namespace UtilitariosSuporte.Features.CaminhoFiscal.Repositories
{
    public interface ICaminhoFiscalRepository
    {
        string ObterDiretorioNFe();
        bool SalvarDiretorioNFe(string texto);
        string ObterDiretorioMDFe();
        bool SalvarDiretorioMDFe(string texto);
        string ObterDiretorioCTe();
        bool SalvarDiretorioCTe(string texto);
    }   
}