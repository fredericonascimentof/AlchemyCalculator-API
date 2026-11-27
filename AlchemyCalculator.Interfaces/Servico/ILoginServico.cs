using AlchemyCalculator.Models.ViewModels;
using AlchemyCalculator.Models.InputModels;
using AlchemyCalculator.Models.Seguranca;
using AlchemyCalculator.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlchemyCalculator.Interfaces.Servico;

public interface ILoginServico
{
    ViewModelToken Cadastrar(InputCadastroUsuario inputCadastroUsuario, AccessManager accessManager);
    Usuario? ObterUsuarioPorLogin(InputLogin inputLogin);
    ViewModelToken GerarToken(InputLogin inputEntrar, AccessManager _accessManager);
}

