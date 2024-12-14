using System.ComponentModel.DataAnnotations;

namespace Aplicacion.Dtos
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El numero de telefono es requerido")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
        public string NumeroTelefono { get; set; } = string.Empty;
    }
}
