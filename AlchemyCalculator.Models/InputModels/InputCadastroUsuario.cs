using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Models.InputModels;

public class InputCadastroUsuario
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public char Sexo { get; set; } = '-';
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string ConfirmarSenha { get; set; } = string.Empty;

    public bool ValidaFormularioCadastroUsuario()
    {
        if (string.IsNullOrWhiteSpace(Email)) return false;
        if (string.IsNullOrWhiteSpace(Nome)) return false;
        if (string.IsNullOrWhiteSpace(Senha)) return false;
        if (string.IsNullOrWhiteSpace(ConfirmarSenha)) return false;

        if(Idade < 0) return false;
        if(Sexo == '-') return false;

        return true;
    }
}

