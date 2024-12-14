using Aplicacion.Dtos;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }


        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                await _usuarioServicio.RegistrarUsuario(usuarioDto);
                return Ok(new { message = "Datos recibidos correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuariosDto = await _usuarioServicio.ObtenerUsuarios();
            return Ok(usuariosDto);
        }

    }
}
