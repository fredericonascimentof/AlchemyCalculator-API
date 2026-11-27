using AlchemyCalculator.Interfaces.Servico;
using Microsoft.AspNetCore.Http;
using AlchemyCalculator.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Dominio.Servicos
{
    public class LogServico : ILogServico
    {
        public void GerarLog(string observacao, int? usuarioId = null)
        {

            try
            {
                var log = new Log
                {
                    UsuarioId = (int)usuarioId,
                    Data = DateTime.Now,
                    Observacao = observacao.ToUpper(),
                };
                // Chamada do método para o banco onde será salvo
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}

