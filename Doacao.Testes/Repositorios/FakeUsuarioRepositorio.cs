using Doacao.Dominio;
using Doacao.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Testes.Repositorios
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        public void Adicionar(Usuario usuario)
        {
            
        }

        public void Alterar(Usuario usuario)
        {
            
        }

        public void AlterarSenha(Usuario usuario)
        {
            
        }

        public Usuario BuscarPorEmail(string email)
        {
            return null;
        }

        public Usuario BuscarPorID(Guid id)
        {
            return new Usuario("Mauro", "mauro@gmail.com", "123456789", Comum.EnTipoUsuario.Doador, "Rua Arroz", "1145678312");
        }

        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            return new List<Usuario>()
            {
                new Usuario("Mauro", "mauro@gmail.com", "123456789", Comum.EnTipoUsuario.Doador, "Rua Arroz", "1145678312"),
                new Usuario("Cortez", "cortez@gmail.com", "789456123", Comum.EnTipoUsuario.Solicitante, "Rua Feijao", "1165826471")
        };
        }
    }
}
