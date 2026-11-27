using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlchemyCalculator.Models.Entidades
{
    public class Log 
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
    }
}

