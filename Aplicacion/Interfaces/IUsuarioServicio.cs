using Aplicacion.Dtos;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioServicio
    {
        Task RegistrarUsuario(UsuarioDto usuarioDto);
        Task<List<UsuarioDto>> ObtenerUsuarios();
    }
}
