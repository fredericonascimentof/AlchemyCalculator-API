using System.ComponentModel.DataAnnotations;

namespace AlchemyCalculator.Models.DTO;

public class CriacaoUsuario
{
    [Required]
    public string NomeUsuario { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string Senha { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string SenhaConfirmacao { get; set; } = string.Empty;

    public bool ValidaConfirmacaoSenha() => Senha == SenhaConfirmacao;

}

