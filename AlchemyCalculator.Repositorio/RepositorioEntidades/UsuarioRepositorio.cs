using Dapper;
using AlchemyCalculator.Interfaces.Contexto;
using AlchemyCalculator.Interfaces.Repositorio;
using AlchemyCalculator.Models.Entidades;
using AlchemyCalculator.Models.InputModels;
using AlchemyCalculator.Repositorio.RepositoriosEntidades.Compartilhado;
using AlchemyCalculator.Repositorio.Contexto;

namespace AlchemyCalculator.Repositorio.RepositorioEntidades;

public class UsuarioRepositorio : EntidadeRepositorio<Usuario>, IUsuarioRepositorio
{
    public UsuarioRepositorio(IDapperContexto dapperContexto) : base(dapperContexto)
    {

    }

    public Usuario? ObterUsuarioPorLogin(InputLogin inputCadastroEntrar)
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            Usuario? usuario;
            string query = """
                SELECT u.* 
                FROM Usuario u 
                WHERE 
                    u.Email = @email AND 
                    u.Senha = @senha
            """;
            var parametros = new
            {
                email = inputCadastroEntrar.Email,
                senha = inputCadastroEntrar.Senha
            };
            conexaoBanco.AbrirConexao();
            usuario = conexaoBanco.QueryFirstOrDefault<Usuario>(query, parametros);
            conexaoBanco.FecharConexao();

            return usuario;
        }
    }

    public bool VerificarEmailDisponivel(string email)
    {
        using (var conexaoBanco = _dapperContexto._conectaBanco())
        {
            bool emailDisponivel;

            string query = """
                SELECT COUNT(*) 
                FROM Usuario u 
                WHERE 
                    u.Email = @email
            """;
            var parametros = new
            {
                email
            };
            conexaoBanco.AbrirConexao();
            emailDisponivel = conexaoBanco.QueryFirstOrDefault<int>(query, parametros) != 0 ? true : false;
            conexaoBanco.FecharConexao();

            return emailDisponivel;
        }
        
    }
}

