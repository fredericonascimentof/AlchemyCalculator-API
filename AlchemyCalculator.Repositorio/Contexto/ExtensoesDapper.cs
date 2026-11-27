using Dapper.Contrib.Extensions;
using System.Data;

namespace AlchemyCalculator.Repositorio.Contexto;

public static class ExtensoesDapper
{
    private static int? _timeout = null;

    public static void AbrirConexao(this IDbConnection conexao)
    {
        if (conexao != null && conexao.State != ConnectionState.Open)
            conexao.Open();
    }

    public static void FecharConexao(this IDbConnection conexao)
    {
        if (conexao != null && conexao.State != ConnectionState.Executing)
            conexao.Close();
    }

    public static IDbTransaction IniciarTransacao(this IDbConnection conexao) => conexao.BeginTransaction();


    public static T ObterPorId<T>(this IDbConnection conexao, int entidadeId, IDbTransaction? transacaoEscopada = null) where T : class => conexao.Get<T>(entidadeId, transacaoEscopada, _timeout);

    public static List<T> ObterTodosSemFiltro<T>(this IDbConnection conexao, IDbTransaction? transacaoEscopada = null) where T : class
    {
        return conexao.GetAll<T>(transacaoEscopada, _timeout).ToList();
    }

    public static T Cadastrar<T>(this IDbConnection conexao, T entidadeCadastro, IDbTransaction? transacaoEscopada = null) where T : class
    {
        conexao.Insert<T>(entidadeCadastro, transacaoEscopada, _timeout);
        return entidadeCadastro;
    }

    public static List<T> CadastrarLista<T>(this IDbConnection conexao, List<T> entidadeCadastro, IDbTransaction? transacaoEscopada = null) where T : class
    {
        conexao.Insert<List<T>>(entidadeCadastro, transacaoEscopada, _timeout);
        return entidadeCadastro;
    }

    public static bool Atualizar<T>(this IDbConnection conexao, T entidadeAtualizada, IDbTransaction? transacaoEscopada = null) where T : class => conexao.Update<T>(entidadeAtualizada, transacaoEscopada, _timeout);

    public static bool Excluir<T>(this IDbConnection conexao, T entidade, IDbTransaction? transacaoEscopada = null) where T : class => conexao.Delete(entidade, transacaoEscopada, _timeout);

    public static bool ExcluirPorId<T>(this IDbConnection conexao, int entidadeId, IDbTransaction? transacaoEscopada = null) where T : class
    {
        T entidade = conexao.ObterPorId<T>(entidadeId, transacaoEscopada);
        return conexao.Excluir<T>(entidade, transacaoEscopada);
    }
}

