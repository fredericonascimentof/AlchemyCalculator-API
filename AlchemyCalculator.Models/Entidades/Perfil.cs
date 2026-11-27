using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Models.Entidades
{
    [Table("Perfil")]
    public class Perfil
    {
        public int Id {  get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool ADM { get; set; }
        public List<string> Permissoes { get; set; }
    }
}

