using Dominio.Entidades;

namespace Persistencia.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> RegistrarUsuario(Usuario usuario);
        Task<List<Usuario>> ObtenerUsuarios();
        bool ExisteNumeroTelefono(string numeroTelefono);
    }
}
