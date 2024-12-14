using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Persistencia.Contexto
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.NumeroTelefono)
                      .IsRequired()
                      .HasMaxLength(15);
            });
        }
    }
}
