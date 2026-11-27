using AlchemyCalculator.Interfaces.Contexto;
using AlchemyCalculator.Interfaces.Repositorio;
using AlchemyCalculator.Repositorio.Contexto;
using System.Data;

namespace AlchemyCalculator.Repositorio.RepositoriosEntidades.Compartilhado;

public class EntidadeRepositorio<TEntidade> : IEntidadeRepositorio<TEntidade> where TEntidade : class
{
    protected readonly IDapperContexto _dapperContexto;

    public EntidadeRepositorio(IDapperContexto dapperContexto)
    {
        _dapperContexto = dapperContexto;
    }

    public TEntidade ObterPorId(int idEntidade, IDbTransaction? transacao = null)
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            TEntidade entidadeObtida;
            conexaoBanco.AbrirConexao();
            entidadeObtida = conexaoBanco.ObterPorId<TEntidade>(idEntidade, transacao);
            conexaoBanco.FecharConexao();

            return entidadeObtida;
        }
    }

    public List<TEntidade> ObterTodos(IDbTransaction? transacao = null)
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            List<TEntidade> listaEntidades;
            conexaoBanco.AbrirConexao();
            listaEntidades = conexaoBanco.ObterTodosSemFiltro<TEntidade>();
            conexaoBanco.FecharConexao();

            return listaEntidades;
        }
    }

    public TEntidade Cadastrar(TEntidade entidade, IDbTransaction? transacao = null)
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            TEntidade entidadeCadastrada;
            conexaoBanco.AbrirConexao();
            entidadeCadastrada = conexaoBanco.Cadastrar<TEntidade>(entidade, transacao);
            conexaoBanco.FecharConexao();

            return entidadeCadastrada;
        }
    }

    public List<TEntidade> CadastrarLista(List<TEntidade> listaEntidades, IDbTransaction? transacao = null)
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            List<TEntidade> entidadeCadastrada;
            conexaoBanco.AbrirConexao();
            entidadeCadastrada = conexaoBanco.CadastrarLista<TEntidade>(listaEntidades, transacao);
            conexaoBanco.FecharConexao();

            return entidadeCadastrada;
        }
    }

    public bool Atualizar(TEntidade entidade, IDbTransaction? transacao = null)
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            bool atualizacaoSucesso;
            conexaoBanco.AbrirConexao();
            atualizacaoSucesso = conexaoBanco.Atualizar<TEntidade>(entidade, transacao);
            conexaoBanco.FecharConexao();

            return atualizacaoSucesso;
        }
    }

    public bool ExcluirPorId(int idEntidade, IDbTransaction? transacao = null)
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            bool exclusaoSucesso;
            conexaoBanco.AbrirConexao();
            exclusaoSucesso = conexaoBanco.ExcluirPorId<TEntidade>(idEntidade, transacao);
            conexaoBanco.FecharConexao();

            return exclusaoSucesso;
        }
    }

    public IDbTransaction IniciarTransacao()
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            conexaoBanco.AbrirConexao();
            return conexaoBanco.IniciarTransacao();
        }
    }

}

