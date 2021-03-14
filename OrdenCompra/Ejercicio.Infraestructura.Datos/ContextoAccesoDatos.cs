using Ejercicio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Infraestructura.Datos
{
    public class ContextoAccesoDatos : DbContext
    {
        public ContextoAccesoDatos(DbContextOptions<ContextoAccesoDatos> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrdenArticulo> OrdenArticulo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cliente
            modelBuilder.Entity<Cliente>()
                .Property(c => c.NombreCliente)
                .IsRequired(true);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.ApellidoCliente)
                .IsRequired(true);

            //Articulo
            modelBuilder.Entity<Articulo>()
                .Property(a => a.NombreArticulo)
                .IsRequired(true);

            modelBuilder.Entity<Articulo>()
                .Property(a => a.PrecioArticulo)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Articulo>()
                .Property(a => a.StockArticulo)
                .IsRequired(true);

            //Orden
            modelBuilder.Entity<Orden>()
                .Property(o => o.FechaOrden)
                .IsRequired(true);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Cliente)
                .WithMany()
                .HasForeignKey(o => o.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orden>()
                .HasMany(o => o.OrdenArticulos)
                .WithOne();

            //OrdenArticulo
            modelBuilder.Entity<OrdenArticulo>()
                .HasKey(oa => new { oa.CodigoArticulo, oa.IdOrden });

            modelBuilder.Entity<OrdenArticulo>()
                .Property(oa => oa.CantidadArticulo)
                .IsRequired(true);

            modelBuilder.Entity<OrdenArticulo>()
                .HasOne(oa => oa.Articulo)
                .WithMany()
                .HasForeignKey(oa => oa.CodigoArticulo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
