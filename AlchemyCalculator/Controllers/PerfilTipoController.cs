using AlchemyCalculator.Dominio.Servicos;
using AlchemyCalculator.Interfaces.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TemplateAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilTipoController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        public PerfilTipoController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [AllowAnonymous]
        [HttpPost("obterPermissao")]
        public IActionResult ObeterPermissao(int usuarioId)
        {
            // Passar usuarioId como parametro para busca no repositorio e retornar uma lista de permissoes Selecionadas como true;
            var retorno = _usuarioServico.ObeterPermissao(usuarioId);
            return Ok(retorno);
        }
    }
}

