using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlchemyCalculator.Models.DTO;
using AlchemyCalculator.Models.Seguranca;
using AlchemyCalculator.Models.ViewModels;
using AlchemyCalculator.Models.InputModels;
using AlchemyCalculator.Models.Entidades;
using AlchemyCalculator.Interfaces.Servico;
using System.Net;
using AlchemyCalculator.Dominio.Servicos;
using TemplateAPI.Controllers;

namespace AlchemyCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        private readonly ILoginServico _cadastroServico;
        private readonly ILogServico _logServico;
        public LoginController(ILoginServico cadastroServico, ILogServico logService) 
        {
            _cadastroServico = cadastroServico;
            _logServico = logService;
        }

        [AllowAnonymous]
        [HttpPost("Cadastro")]
        public IActionResult Cadastro([FromBody] InputCadastroUsuario inputCadastroUsuario, [FromServices] AccessManager _accessManager)
        {
            try
            {
                if (inputCadastroUsuario == null || inputCadastroUsuario.ValidaFormularioCadastroUsuario() is false) return BadRequest();
                ViewModelToken usuarioCadastrado = _cadastroServico.Cadastrar(inputCadastroUsuario, _accessManager);
                _logServico.GerarLog("NOVO USUARIO CADASTRADO: " + UsuarioLogadoId);
                return Ok(usuarioCadastrado);
            }
            catch (Exception ex)
            {

                return Problem(
                    detail: ex.Message,
                    statusCode: ex.Message == "Email já utilizado!" ? (int)HttpStatusCode.Forbidden : (int)HttpStatusCode.InternalServerError
                );
            }
        }

        [AllowAnonymous]
        [HttpPost("Entrar")]
        public ActionResult Entrar(
        [FromBody] InputLogin inputEntrar,
        [FromServices] ILogger<LoginController> _logger,
        [FromServices] AccessManager _accessManager
    )
        {

            if (inputEntrar is null)
            {
                return Problem("Inválido", statusCode: 400);
            }

            _logger.LogInformation($"Recebida solicitação para o usuário: {inputEntrar?.Email}");

            var tokenAcesso = _cadastroServico.GerarToken(inputEntrar, _accessManager);
            
            if (tokenAcesso.IdUsuario is null)
            {
                return Problem("Credenciais inválidas", statusCode: (int)HttpStatusCode.Unauthorized);
            }

            _logServico.GerarLog("USUARIO LOGADO: " + UsuarioLogadoId);
           return Ok(tokenAcesso);
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            return NoContent();
        }
    }
}

