using FirebirdSql.Data.FirebirdClient;
using System;
using System.Text.Json;
using System.Text.Json.Nodes; // Necessário para manipular o JSON
using UtilitariosSuporte.Features.Infraestrutura;

namespace UtilitariosSuporte.Features.CaminhoFiscal.Repositories
{
    public class CaminhoFiscalRepository : ICaminhoFiscalRepository
    {
        private readonly IFabricaDeConexao _fabricaDeConexao;
        private string _jsonNFe;
        private string _jsonMDFe;
        private string _jsonCTe;
        private int _idNFe;
        private int _idMDFe;
        private int _idCTe;

        public CaminhoFiscalRepository(IFabricaDeConexao fabricaDeConexao)
        {
            _fabricaDeConexao = fabricaDeConexao;
        }

        public string ObterDiretorioNFe()
        {
            string caminhoEncontrado = "";
            try
            {
                using (var conn = _fabricaDeConexao.RetornarNovaConexao())
                {
                    conn.Open();
                    string sql = "SELECT CODIGO_EMPRESA, NFE FROM CONFIG";

                    using (var cmd = new FbCommand(sql, (FbConnection)conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // 1. Pegamos o JSON da linha atual
                                string jsonTemporario = reader.IsDBNull(1) ? null : reader.GetString(1);

                                // 2. Se não for nulo, processamos, mas NÃO damos return aqui
                                if (!string.IsNullOrEmpty(jsonTemporario))
                                {
                                    _idNFe = reader.GetInt32(0);
                                    _jsonNFe = jsonTemporario;

                                    var nodo = JsonNode.Parse(_jsonNFe);
                                    caminhoEncontrado = nodo?["CaminhoDoDiretorioFiscalDeNfe"]?.ToString() ?? "";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Erro ao ler: " + ex.Message;
            }

            // Só retornamos ao final de percorrer toda a tabela
            return !string.IsNullOrEmpty(caminhoEncontrado) ? caminhoEncontrado : "Nenhuma empresa foi configurada.";
        }
        public string ObterDiretorioMDFe()
        {
            string caminhoEncontrado = ""; // Variável para armazenar o que encontrarmos
            try
            {
                using (var conn = _fabricaDeConexao.RetornarNovaConexao())
                {
                    conn.Open();
                    string sql = "SELECT CODIGO_EMPRESA, MDFE FROM CONFIG";

                    using (var cmd = new FbCommand(sql, (FbConnection)conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // 1. Pegamos o JSON da linha atual
                                string jsonTemporario = reader.IsDBNull(1) ? null : reader.GetString(1);

                                // 2. Se não for nulo, processamos, mas NÃO damos return aqui
                                if (!string.IsNullOrEmpty(jsonTemporario))
                                {
                                    _idMDFe = reader.GetInt32(0);
                                    _jsonMDFe = jsonTemporario;

                                    var nodo = JsonNode.Parse(_jsonMDFe);
                                    caminhoEncontrado = nodo?["CaminhoMdfe"]?.ToString() ?? "";

                                    // O loop continua... se houver outra empresa com MDFe, 
                                    // ela vai sobrescrever as variáveis acima.
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Erro ao ler: " + ex.Message;
            }

            // Só retornamos ao final de percorrer toda a tabela
            return !string.IsNullOrEmpty(caminhoEncontrado) ? caminhoEncontrado : "Nenhuma empresa foi configurada.";
        }
        public string ObterDiretorioCTe()
        {
            string caminhoEncontrado = ""; // Variável para armazenar o que encontrarmos
            try
            {
                using (var conn = _fabricaDeConexao.RetornarNovaConexao())
                {
                    conn.Open();
                    string sql = "SELECT CODIGO_EMPRESA, CTE FROM CONFIG";

                    using (var cmd = new FbCommand(sql, (FbConnection)conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string jsonTemporario = reader.IsDBNull(1) ? null : reader.GetString(1);
                                if (!string.IsNullOrEmpty(jsonTemporario))
                                {
                                    _idCTe = reader.GetInt32(0);
                                    _jsonCTe = jsonTemporario;

                                    var nodo = JsonNode.Parse(_jsonCTe);
                                    caminhoEncontrado = nodo?["CaminhoDoDretorioDeCte"]?.ToString() ?? "";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Erro ao ler: " + ex.Message;
            }

            // Só retornamos ao final de percorrer toda a tabela
            return !string.IsNullOrEmpty(caminhoEncontrado) ? caminhoEncontrado : "Nenhuma empresa foi configurada.";
        }


        public bool SalvarDiretorioNFe(string novoValorCampo)
        {
            try
            {
                var nodo = JsonNode.Parse(_jsonNFe);
                nodo["CaminhoDoDiretorioFiscalDeNfe"] = novoValorCampo;
                string jsonAtualizado = nodo.ToJsonString(new JsonSerializerOptions { WriteIndented = true });

                using (var conn = _fabricaDeConexao.RetornarNovaConexao())
                {
                    conn.Open();
                    string sql = "UPDATE CONFIG SET NFE = @Json WHERE CODIGO_EMPRESA = @Id";

                    using (var cmd = new FbCommand(sql, (FbConnection)conn))
                    {
                        cmd.Parameters.Add("@Json", FbDbType.VarChar).Value = jsonAtualizado;
                        cmd.Parameters.Add("@Id", FbDbType.Integer).Value = _idNFe;

                        cmd.ExecuteNonQuery();
                        _jsonNFe = jsonAtualizado;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ControleDeMensagens.Avisar("Erro ao salvar: " + ex.Message);
                return false;
            }
        }
        public bool SalvarDiretorioMDFe(string novoValorCampo)
        {
            try
            {
                var nodo = JsonNode.Parse(_jsonMDFe);
                nodo["CaminhoMdfe"] = novoValorCampo;
                string jsonAtualizado = nodo.ToJsonString(new JsonSerializerOptions { WriteIndented = true });

                using (var conn = _fabricaDeConexao.RetornarNovaConexao())
                {
                    conn.Open();
                    // Adicionamos o WHERE com o ID capturado anteriormente
                    string sql = "UPDATE CONFIG SET MDFE = @Json WHERE CODIGO_EMPRESA = @Id";

                    using (var cmd = new FbCommand(sql, (FbConnection)conn))
                    {
                        cmd.Parameters.Add("@Json", FbDbType.VarChar).Value = jsonAtualizado;
                        cmd.Parameters.Add("@Id", FbDbType.Integer).Value = _idMDFe;

                        cmd.ExecuteNonQuery();
                        _jsonMDFe = jsonAtualizado;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ControleDeMensagens.Avisar("Erro ao salvar: " + ex.Message);
                return false;
            }
        }
        public bool SalvarDiretorioCTe(string novoValorCampo)
        {
            try
            {
                var nodo = JsonNode.Parse(_jsonCTe);
                nodo["CaminhoDoDretorioDeCte"] = novoValorCampo;
                string jsonAtualizado = nodo.ToJsonString(new JsonSerializerOptions { WriteIndented = true });

                using (var conn = _fabricaDeConexao.RetornarNovaConexao())
                {
                    conn.Open();
                    // Adicionamos o WHERE com o ID capturado anteriormente
                    string sql = "UPDATE CONFIG SET CTE = @Json WHERE CODIGO_EMPRESA = @Id";

                    using (var cmd = new FbCommand(sql, (FbConnection)conn))
                    {
                        cmd.Parameters.Add("@Json", FbDbType.VarChar).Value = jsonAtualizado;
                        cmd.Parameters.Add("@Id", FbDbType.Integer).Value = _idCTe;

                        cmd.ExecuteNonQuery();
                        _jsonCTe = jsonAtualizado;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ControleDeMensagens.Avisar("Erro ao salvar: " + ex.Message);
                return false;
            }
        }
    }
}