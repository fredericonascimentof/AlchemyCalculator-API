using System.Text.RegularExpressions;
using AlchemyCalculator.Interfaces.Repositorio;
using AlchemyCalculator.Interfaces.Servico;
using AlchemyCalculator.Models.Entidades;
using AlchemyCalculator.Models.InputModels;
using AlchemyCalculator.Models.Seguranca;
using AlchemyCalculator.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AlchemyCalculator.Dominio.Servicos;

public class LoginServico : ControllerBase, ILoginServico
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly ILogServico _logService;
    public LoginServico(
        IUsuarioRepositorio usuarioRepositorio, 
        ILogServico logService

    )
    {
        _usuarioRepositorio = usuarioRepositorio;
        _logService = logService;
    }

    private bool ValidaFormularioCadastroUsuario(InputCadastroUsuario formulario)
    {
        if (formulario.Senha != formulario.ConfirmarSenha) return false;
        if (ValidacaoFormatoEmail(formulario.Email) is false) return false;

        return true;
    }

    private bool ValidacaoFormatoEmail(string email)
    {
        // Expressão regular para validação de e-mail
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(email);
    }

    public Usuario? ObterUsuarioPorLogin(InputLogin inputLogin)
    {
        return _usuarioRepositorio.ObterUsuarioPorLogin(inputLogin);
    }

    public ViewModelToken Cadastrar(InputCadastroUsuario inputCadastro, AccessManager accessManager)
    {
        try
        {
            if (!ValidaFormularioCadastroUsuario(inputCadastro))
            {
                throw new Exception(message: "Formulário inválido!");
            }

            if (_usuarioRepositorio.VerificarEmailDisponivel(inputCadastro.Email))
            {
                throw new Exception(message: "Email já utilizado!");
            }

            Usuario novoUsuario = new Usuario();
            novoUsuario.Nome = inputCadastro.Nome;
            novoUsuario.Idade = inputCadastro.Idade;
            novoUsuario.Sexo = inputCadastro.Sexo;
            novoUsuario.Email = inputCadastro.Email;
            novoUsuario.Senha = inputCadastro.Senha;

            novoUsuario = _usuarioRepositorio.Cadastrar(novoUsuario);

            ViewModelToken cadastroRetorno = new();
            InputLogin inputLogin = new();
            inputLogin.Email = inputCadastro.Email.Trim();
            inputLogin.Senha = inputCadastro.Senha.Trim();
            try
            {
                Usuario? usuarioCadastrado = ObterUsuarioPorLogin(inputLogin);
                if (usuarioCadastrado is null)
                {
                    throw new Exception(message: "Erro ao obter usuário para login.");
                }

                cadastroRetorno.AuthToken = accessManager
                    .GenerateToken(usuarioCadastrado)
                    .AccessToken;

                if (cadastroRetorno.AuthToken is null)
                {
                    throw new Exception(
                        message: "Erro na tentativa de login."
                    );
                }

                cadastroRetorno.IdUsuario = usuarioCadastrado.UsuarioID.ToString();
                return cadastroRetorno;
            }
            catch (Exception)
            {
                throw;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public ViewModelToken GerarToken(InputLogin inputEntrar, AccessManager _accessManager)
    {
        ViewModelToken token = new ViewModelToken();

        Usuario? usuario = ObterUsuarioPorLogin(inputEntrar!);

        if (usuario is null)
        {
            return null;
        }

        var authToken = _accessManager.GenerateToken(usuario).AccessToken;
        token.IdUsuario = usuario.ToString();
        token.AuthToken = authToken;

        return token;
    }
}

