using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Interfaces.Servico;

public interface IEntidadeServico<TEntidade> where TEntidade : class
{
    bool Atualizar(TEntidade entidade);
    TEntidade Cadastrar(TEntidade entidade);
    bool ExcluirPorId(int idEntidade);
    TEntidade ObterPorId(int idEntidade);
    List<TEntidade> ObterTodos();
}

