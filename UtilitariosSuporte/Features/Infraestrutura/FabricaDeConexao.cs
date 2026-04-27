using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.Common;

namespace UtilitariosSuporte.Features.Infraestrutura
{
    public class FabricaDeConexao : IFabricaDeConexao
    {
        private readonly string _stringDeConexao;

        public FabricaDeConexao(string stringDeConexao) =>
            _stringDeConexao = stringDeConexao;

        public IDbConnection RetornarNovaConexao() =>
            new FbConnection(_stringDeConexao);
    }
}