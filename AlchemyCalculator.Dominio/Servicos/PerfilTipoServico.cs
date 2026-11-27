using AlchemyCalculator.Interfaces.Repositorio;
using AlchemyCalculator.Interfaces.Servico;
using AlchemyCalculator.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AlchemyCalculator.Dominio.Servicos
{
    public class TipoPerfilServico : IUsuarioServico
    {
        private readonly IPerfilTipoRepositorio _perfilTipoRepositorio;
        public TipoPerfilServico(IPerfilTipoRepositorio perfilTipoRepositorio)
        {
            _perfilTipoRepositorio = perfilTipoRepositorio;
        }

        public List<PermissaoPerfil> ObeterPermissao(int usuarioId)
        {
            OpcaoPermissaoPerfil permissao = new OpcaoPermissaoPerfil();

            var usuario = _perfilTipoRepositorio.ObterUsuarioId(usuarioId);
            var tipoPerfil = _perfilTipoRepositorio.ObterTipoPerfil(usuario.TipoPerfilId);
            var listaPermissoesUsuario = _perfilTipoRepositorio.ObterPermissoes(usuario.TipoPerfilId);
            var listaPermissoes = permissao.RetornaPermissoesPerfil();
            if (tipoPerfil.ADM == true)
            {
                foreach (var item in listaPermissoes)
                {
                    item.Selecionado = true;
                }
            }
            else
            {
                foreach (var item in listaPermissoes)
                {
                    item.Selecionado = listaPermissoesUsuario.FirstOrDefault(l => l == item.Descricao) is not null;
                }
            }
            
            return listaPermissoes;
        }
    }
}

