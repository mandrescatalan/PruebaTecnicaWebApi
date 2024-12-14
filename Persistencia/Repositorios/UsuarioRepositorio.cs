using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Persistencia.Contexto;
using Persistencia.Interfaces;

namespace Persistencia.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> RegistrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public bool ExisteNumeroTelefono(string numeroTelefono)
        {
            return _context.Usuarios.Any(u => u.NumeroTelefono == numeroTelefono);
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }


    }
}
