using AlchemyCalculator.Models.Entidades;
using AlchemyCalculator.Models.Entidades;
using AlchemyCalculator.Models.InputModels;
using AlchemyCalculator.Models.ViewModels;

namespace AlchemyCalculator.Interfaces.Repositorio;

public interface IUsuarioRepositorio : IEntidadeRepositorio<Usuario>
{
    Usuario? ObterUsuarioPorLogin(InputLogin inputCadastroEntrar);
    bool VerificarEmailDisponivel(string email);
}

