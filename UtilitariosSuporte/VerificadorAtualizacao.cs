using System.Net.Http;
using System.Threading.Tasks;

public static class VerificadorAtualizacao
{
    // URL do arquivo 'version.txt' no seu repositório (clique em 'Raw' no GitHub para pegar o link direto)
    private const string UrlVersaoGithub = "https://github.com/Guhnunes/Utilitario-Suporte/blob/master/UtilitariosSuporte/version.txt";

    public static async Task<bool> IsVersaoAtualizada(string versaoLocal)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                // O GitHub exige um User-Agent na requisição
                client.DefaultRequestHeaders.Add("User-Agent", "request");

                string versaoRemota = await client.GetStringAsync(UrlVersaoGithub);

                // Remove espaços ou quebras de linha e compara
                return versaoLocal.Trim() == versaoRemota.Trim();
            }
        }
        catch
        {
            // Se falhar a internet, ignora e deixa abrir o app
            return true;
        }
    }
}