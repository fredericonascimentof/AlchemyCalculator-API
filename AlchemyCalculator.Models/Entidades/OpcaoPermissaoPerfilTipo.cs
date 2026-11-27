using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Models.Entidades
{
    public class OpcaoPermissaoPerfil
    {
        public List<PermissaoPerfil> RetornaPermissoesPerfil()
        {
            List<PermissaoPerfil> lista = new List<PermissaoPerfil>();

            foreach (var permissao in Enum.GetValues(typeof(PermissoesAcesso)))
            {
                var usuarioPermissao = new PermissaoPerfil
                {
                    Descricao = permissao.ToString(),
                    Selecionado = false
                };
                lista.Add(usuarioPermissao);
            }
            return lista;
        }
    }
    public class PermissaoPerfil
    {
        public string Descricao { get; set; }
        public bool Selecionado { get; set; } 
    }
    public enum PermissoesAcesso
    {
        Listar,
        Criar,
        Excluir
    }
}

