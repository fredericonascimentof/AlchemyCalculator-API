using Microsoft.Extensions.DependencyInjection;
using AlchemyCalculator.Models.Entidades;
using AlchemyCalculator.Dominio.Servicos;
using AlchemyCalculator.Interfaces.Servico;
using AlchemyCalculator.Interfaces.Repositorio;
using AlchemyCalculator.Repositorio.RepositoriosEntidades.Compartilhado;
using AlchemyCalculator.Repositorio.RepositorioEntidades;
using AlchemyCalculator.Interfaces.Contexto;
using AlchemyCalculator.Repositorio.Contexto;
using AlchemyCalculator.Models.Seguranca;

namespace IoC;

public static class InjetorGeral 
{
    public static void RegistrarServicos(this IServiceCollection colecaoServicos)
    {
        colecaoServicos._Seguranca();
        colecaoServicos._Contexto();

        colecaoServicos._CamadaRepositorioGenericos();
        colecaoServicos._CamadaRepositorio();

        colecaoServicos._CamadaDominioGenericos();
        colecaoServicos._CamadaDominio();
    }

    private static void _CamadaDominioGenericos(this IServiceCollection colecaoServicos) 
    {
        colecaoServicos.AddScoped<IEntidadeServico<Usuario>, EntidadeServico<Usuario>>();
    }

    private static void _CamadaDominio(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.AddScoped<ILoginServico, LoginServico>();
        colecaoServicos.AddScoped<IUsuarioServico, TipoPerfilServico>();
        colecaoServicos.AddScoped<ILogServico, LogServico>();
    }

    private static void _CamadaRepositorioGenericos(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.AddScoped<IEntidadeRepositorio<Usuario>, EntidadeRepositorio<Usuario>>();
    }

    private static void _CamadaRepositorio(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        colecaoServicos.AddScoped<IPerfilTipoRepositorio, PerfilTipoPermissaoRepositorio>();

    }

    private static void _Contexto(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.AddScoped<IDapperContexto, DapperContexto>();
    }

    private static void _Seguranca(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.AddScoped<AccessManager>();
    }
}

