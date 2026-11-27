using AlchemyCalculator.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Interfaces.Repositorio
{
    public interface IRepositorio<TEntity> : IEntidadeRepositorio<PerfilTipoService>
    {
        IDbTransaction IniciarTransacao();
    }
}

