using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrdenCompra.Models
{
    public partial class ejercicioContext : DbContext
    {
        public ejercicioContext()
        {
        }

        public ejercicioContext(DbContextOptions<ejercicioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenArticulo> OrdenArticulo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ejercicio;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.CodigoArticulo);

                entity.ToTable("articulo");

                entity.Property(e => e.CodigoArticulo)
                    .HasColumnName("codigo_articulo")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreArticulo)
                    .HasColumnName("nombre_articulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioArticulo)
                    .HasColumnName("precio_articulo")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.StockArticulo).HasColumnName("stock_articulo");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.ApellidoCliente)
                    .HasColumnName("apellido_cliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .HasColumnName("nombre_cliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.IdOrden);

                entity.ToTable("orden");

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.FechaOrden)
                    .HasColumnName("fecha_orden")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_ejercicio_cliente");
            });

            modelBuilder.Entity<OrdenArticulo>(entity =>
            {
                entity.HasKey(e => new { e.CodigoArticulo, e.IdOrden });

                entity.ToTable("orden_articulo");

                entity.Property(e => e.CodigoArticulo)
                    .HasColumnName("codigo_articulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdOrden).HasColumnName("id_orden");

                entity.Property(e => e.CantidadArticulo).HasColumnName("cantidad_articulo");

                entity.HasOne(d => d.CodigoArticuloNavigation)
                    .WithMany(p => p.OrdenArticulo)
                    .HasForeignKey(d => d.CodigoArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orden_articulo_articulo");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.OrdenArticulo)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orden_articulo_orden");
            });
        }
    }
}
