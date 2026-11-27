namespace AlchemyCalculator.Models.DTO;

public class LoginUsuario
{
    public string Usuario { get; set; } = string.Empty; //Aqui será aceito tanto email quanto o nome de usuário
    public string Senha { get; set; } = string.Empty;
}

