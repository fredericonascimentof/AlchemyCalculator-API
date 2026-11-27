using AlchemyCalculator.Interfaces.Contexto;
using AlchemyCalculator.Interfaces.Repositorio;
using AlchemyCalculator.Models.Entidades;
using AlchemyCalculator.Repositorio.RepositoriosEntidades.Compartilhado;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyCalculator.Repositorio.RepositorioEntidades
{
    public class PerfilTipoPermissaoRepositorio : EntidadeRepositorio<Perfil>, IPerfilTipoRepositorio
    {
        public PerfilTipoPermissaoRepositorio(IDapperContexto context) : base(context)
        {

        }
        public Perfil ObterTipoPerfil(int tipoPerfilId)
        {
            var listaPerfis = new List<Perfil>
           {
               new Perfil
               {
                  Id = 1,
                  Descricao = "Administrador",
                  Ativo = true,
                  ADM = true,
               },
               new Perfil
               {
                   Id = 2,
                   Descricao = "Estagiario",
                   ADM = false,
                   Ativo = true,
                   Permissoes = ["Listar", "Criar"]
               },
               new Perfil
               {
                   Id = 3,
                   Descricao = "Usuario Comum",
                   ADM = false,
                   Ativo = true,
                   Permissoes = ["Listar"]
               }
           };
            return listaPerfis.FirstOrDefault(p => p.Id == tipoPerfilId);

            //return Db.Query<PerfilTipo>("SELECT * FROM PerfilTipoPermissao WHERE PerfilTipoId = @perfilTipoId", new { Id }, transaction);
        }
        public Usuario ObterUsuarioId(int usuarioId)
        {
            var Usuario = new Usuario
            {
                UsuarioID = 1,
                TipoPerfilId = 3,
                Nome = "Teste",
                Idade = 25,
                Sexo = 'M',
                Email = "teste@teste.com",
                Senha = "123456",
            }; 
            return Usuario;
        }

        public List<string> ObterPermissoes(int tipoPerfilId)
        {
            var listaPerfis = new List<Perfil>
           {
               new Perfil
               {
                  Id = 1,
                  Descricao = "Administrador",
                  Ativo = true,
                  ADM = true,
               },
               new Perfil
               {
                   Id = 2,
                   Descricao = "Estagiario",
                   ADM = false,
                   Ativo = true,
                   Permissoes = ["Listar", "Criar"]
               },
               new Perfil
               {
                   Id = 3,
                   Descricao = "Usuario Comum",
                   ADM = false,
                   Ativo = true,
                   Permissoes = ["Listar"]
               }
           };
            return listaPerfis.FirstOrDefault(p => p.Id == tipoPerfilId)?.Permissoes;
        }

    }
}

