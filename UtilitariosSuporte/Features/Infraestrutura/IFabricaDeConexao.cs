using System.Data;

namespace UtilitariosSuporte.Features.Infraestrutura
{
    public interface IFabricaDeConexao
    {
        IDbConnection RetornarNovaConexao();
    }
}