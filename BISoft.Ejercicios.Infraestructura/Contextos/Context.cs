using BISoft.Ejercicios.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Contextos
{
    public class Context:DbContext
    {
        public DbSet<Proveedor> Proveedores  { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\MSSQLServer01;Database=DailyBD;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Proveedor>()
            //    .ToTable("Proveedores");

            modelBuilder.Entity<Proveedor>().HasKey(p => p.Id);
            modelBuilder.Entity<Proveedor>().Property(p => p.Nombre)
                .HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.Direccion)
                .HasMaxLength(50).IsRequired();


            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e=>  e.ProductoId);

                entity.ToTable("genProductosCat");

                entity.Property(e => e.ProductoId)
                .HasColumnName("codigoProducto");

                entity.Property(e => e.Costo)
                    .HasColumnType("money")
                    .HasColumnName("costo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("nombreProducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("precio");

                entity.Property(e => e.Status)
                .HasColumnName("status");
            });


            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.ComprasId);

                entity.Property(e => e.ComprasId).HasColumnName("comprasId");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Proveedor).HasColumnName("proveedor");
            });
        }

    }
}
