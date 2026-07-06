using Microsoft.EntityFrameworkCore;
using GestorDeApartamentos.Model;

namespace GestorDeApartamentos.DA
{
    public class ExamenDbContext : DbContext
    {
        public ExamenDbContext(DbContextOptions<ExamenDbContext> options)
            : base(options)
        {
        }

        public DbSet<Apartamento> Apartamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartamento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Descripcion).IsRequired();
                entity.Property(e => e.NumeroDePiso).IsRequired();
                entity.Property(e => e.PrecioPorMes).HasColumnType("money");
            });
        }
    }
}
