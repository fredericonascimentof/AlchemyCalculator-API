using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Models.Entidades;

[Table("Usuario")]
public class Usuario
{
    public int UsuarioID { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public char Sexo { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public int TipoPerfilId { get; set; }

}

