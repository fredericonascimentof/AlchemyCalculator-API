using AlchemyCalculator.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Interfaces.Servico
{
    public interface ILogServico 
    {
        public void GerarLog(string observacao, int? usuarioId = null );
    }
}

