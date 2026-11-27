using AlchemyCalculator.Interfaces.Repositorio;
using AlchemyCalculator.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Interfaces.Servico
{
    public interface IUsuarioServico 
    {
        List<PermissaoPerfil> ObeterPermissao(int usuarioId);
    }
}

