namespace Dominio.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = string.Empty;
        public string NumeroTelefono { get; set; } = string.Empty;
    }
}
