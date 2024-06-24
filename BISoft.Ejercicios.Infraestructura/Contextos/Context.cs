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
        }

    }
}
