using AlchemyCalculator.Models.Entidades;
using AlchemyCalculator.Models.Seguranca.JWT;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Models.Seguranca;

public class AccessManager
{
    private SigningConfigurations _signingConfigurations;
    private TokenConfigurations _tokenConfigurations;

    public AccessManager(
        SigningConfigurations signingConfigurations,
        TokenConfigurations tokenConfigurations)
    {
        _signingConfigurations = signingConfigurations;
        _tokenConfigurations = tokenConfigurations;
    }

    public bool ValidateCredentials(Usuario user)
    {
        //TODO: Criar validação de credenciais
        return true;
    }

    public Token GenerateToken(Usuario usuario)
    {
        ClaimsIdentity identity = new(
            new GenericIdentity(usuario?.Email?.ToString() ?? "", "Login"),
            new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario!.Email ?? "SemEmail"),
                new Claim("UsuarioID", usuario!.UsuarioID.ToString()),
                new Claim("NomeUsuario", usuario!.Nome ?? usuario!.Email ?? "Usuário")
            }
        );

        DateTime dataCriacao = DateTime.Now;
        DateTime dataExpiracao = dataCriacao +
        TimeSpan.FromSeconds(usuario.UsuarioID == -10 ? 300 : _tokenConfigurations.Seconds);

        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _tokenConfigurations.Issuer,
            Audience = _tokenConfigurations.Audience,
            SigningCredentials = _signingConfigurations.SigningCredentials,
            Subject = identity,
            NotBefore = dataCriacao,
            Expires = dataExpiracao
        });
        var token = handler.WriteToken(securityToken);

        return new()
        {
            Authenticated = true,
            Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
            Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
            AccessToken = token,
            Message = "OK"
        };
    }
}

