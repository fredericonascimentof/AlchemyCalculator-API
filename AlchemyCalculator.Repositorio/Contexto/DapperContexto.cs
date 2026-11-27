using Microsoft.Data.SqlClient;
using System.Data;
using AlchemyCalculator.Interfaces.Contexto;

namespace AlchemyCalculator.Repositorio.Contexto;

public class DapperContexto : IDapperContexto
{
    private readonly string _stringConexao;

    public IDbTransaction? transacao { get; set; }

    public DapperContexto()
    {
        _stringConexao = $"Server=.\\SQLEXPRESS; Integrated Security=SSPI; Database=template; TrustServerCertificate=True";
    }

    public IDbConnection _conectaBanco()
    {
        try
        {
            return new SqlConnection(_stringConexao);
        }
        catch (Exception)
        {
            throw;
        }
    }
}

