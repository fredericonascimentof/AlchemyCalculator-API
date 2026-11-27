using AlchemyCalculator.Interfaces.Repositorio;
using AlchemyCalculator.Interfaces.Servico;

namespace AlchemyCalculator.Dominio.Servicos;

public class EntidadeServico<TEntidade> : IEntidadeServico<TEntidade> where TEntidade : class
{
    private IEntidadeRepositorio<TEntidade> _repositorio;

    public EntidadeServico(IEntidadeRepositorio<TEntidade> repositorio)
    {
        _repositorio = repositorio;
    }

    public bool Atualizar(TEntidade entidade)
    {
        return _repositorio.Atualizar(entidade);
    }

    public TEntidade Cadastrar(TEntidade entidade)
    {
        return _repositorio.Cadastrar(entidade);
    }

    public bool ExcluirPorId(int idEntidade)
    {
        return _repositorio.ExcluirPorId(idEntidade);
    }

    public TEntidade ObterPorId(int idEntidade)
    {
        return _repositorio.ObterPorId(idEntidade);
    }

    public List<TEntidade> ObterTodos()
    {
        return _repositorio.ObterTodos();
    }
}

