using AlchemyCalculator.Interfaces.Servico;
using Microsoft.AspNetCore.Mvc;

namespace TemplateAPI.Controllers
{

    public class BaseController : ControllerBase
    {
        private int usuarioId;
        public int UsuarioLogadoId
        {
            get
            {
                if (usuarioId == 0)
                {
                    try
                    {
                        usuarioId = int.Parse(User.Claims
                            .First(i => i.Type == "UsuarioID").Value
                        );
                    }
                    catch (Exception)
                    {
                        usuarioId = 0;
                    }
                }
                return usuarioId;
            }
            set { usuarioId = value; }
        }
    }
}
