using Doacao.Dominio;
using Doacao.Dominio.Repositorios;
using Doacao.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        //Injeção de dependencia
        private readonly DoacaoContext _context;

        public UsuarioRepositorio(DoacaoContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorID(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            return _context.Usuarios
                .AsNoTracking()
                .Include(x => x.Doacoes)
                .OrderBy(x => x.DataCriacao)
                .ToList();
        }
    }
}
