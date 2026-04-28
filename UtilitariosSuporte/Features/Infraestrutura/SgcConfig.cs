using System.IO;

namespace UtilitariosSuporte.Features.Infraestrutura
{
    public class SgcConfig
    {
        private readonly string _caminhoArquivo;

        public SgcConfig(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }

        // Método atualizado para ler arquivos sequenciais
        public string ObterStringConexao()
        {
            if (!File.Exists(_caminhoArquivo))
                return string.Empty;

            // Lê todas as linhas do arquivo
            string[] linhas = File.ReadAllLines(_caminhoArquivo);

            // O arquivo deve ter pelo menos 6 linhas para formar a conexão básica
            if (linhas.Length < 6)
                return string.Empty;

            string local = linhas[0].Trim(); 
            string ip = linhas[1].Trim();
            string porta = linhas[2].Trim();
            string caminhoFdb = linhas[3].Trim();
            string usuario = linhas[4].Trim();
            string senha = "masterkey"; // A senha no INI parece estar criptografada, assumindo o padrão

            // Montando a string de conexão do Firebird
            return $"Local={local};User={usuario};Password={senha};Database={caminhoFdb};DataSource={ip};Port={porta};Dialect=3;Charset=UTF8;";
        }
    }
}