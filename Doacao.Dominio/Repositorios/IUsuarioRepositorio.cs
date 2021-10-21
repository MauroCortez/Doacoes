using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        void AlterarSenha(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorID(Guid id);
        ICollection<Usuario> Listar(bool? ativo = null);
    }
}
