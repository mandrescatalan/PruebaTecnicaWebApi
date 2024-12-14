using Aplicacion.Dtos;
using Aplicacion.Interfaces;
using Dominio.Entidades;
using Microsoft.Extensions.Logging;
using Persistencia.Interfaces;

namespace Aplicacion.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<UsuarioServicio> _logger;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio, ILogger<UsuarioServicio> logger)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
        }

        public async Task RegistrarUsuario(UsuarioDto usuarioDto)
        {
            if (_usuarioRepositorio.ExisteNumeroTelefono(usuarioDto.NumeroTelefono))
            {
                throw new InvalidDataException("El número de teléfono ya está registrado.");
            }

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nombre = usuarioDto.Nombre,
                NumeroTelefono = usuarioDto.NumeroTelefono
            };
            var usuarioGuardado = await _usuarioRepositorio.RegistrarUsuario(usuario);
            SimularEnvioDeMensaje(usuarioGuardado.Nombre, usuarioGuardado.NumeroTelefono);
        }

        public async Task<List<UsuarioDto>> ObtenerUsuarios()
        {
            var usuarios = await _usuarioRepositorio.ObtenerUsuarios();
            return usuarios.Select(u => new UsuarioDto { Nombre = u.Nombre, NumeroTelefono = u.NumeroTelefono }).ToList();
        }

        private void SimularEnvioDeMensaje(string nombre, string numeroTelefono)
        {
            string mensaje = $"Mensaje de bienvenida enviado a {nombre} al número {numeroTelefono}";
            _logger.LogInformation(mensaje);
        }
    }
}
