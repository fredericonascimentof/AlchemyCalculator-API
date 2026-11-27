using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Models.Entidades
{
    [Table("PerfilTipo")]
    public class PerfilTipoService
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}

