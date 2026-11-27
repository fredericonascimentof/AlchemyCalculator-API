using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Interfaces.Repositorio;

public interface IEntidadeRepositorio<TEntidade> where TEntidade : class
{
    IDbTransaction IniciarTransacao();
    bool Atualizar(TEntidade entidade, IDbTransaction? transacao = null);
    TEntidade Cadastrar(TEntidade entidade, IDbTransaction? transacao = null);
    List<TEntidade> CadastrarLista(List<TEntidade> listaEntidadeS, IDbTransaction? transacao = null);
    bool ExcluirPorId(int idEntidade, IDbTransaction? transacao = null);
    TEntidade ObterPorId(int idEntidade, IDbTransaction? transacao = null);
    List<TEntidade> ObterTodos(IDbTransaction? transacao = null);
}

