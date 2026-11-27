using System.Data;

namespace AlchemyCalculator.Interfaces.Contexto;

public interface IDapperContexto
{
    IDbTransaction? transacao { get; set; }
    IDbConnection _conectaBanco();
}

