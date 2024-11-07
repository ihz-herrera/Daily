using BISoft.Ejercicios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace BISoft.Ejercicios.Infraestructura.Contextos
{
    public class Context:DbContext
    {

        public DbSet<Proveedor> Proveedores  { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraDetalle> CompraDetalles { get; set; }

        public DbSet<ProductoPermitidoCompra> ProductosPermitidosCompras { get; set; }

        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        public DbSet<CodigoRelacionado> CodigosRelacionados { get; set; }

        public Context(DbContextOptions<Context> options):base(options)
        {
        }

        public Context()
        {
            
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}

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

                entity.ToTable("genProductosCat","dbo");
                

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

                ////Ignorar la propiedad categoria Id
                //entity.Ignore(e => e.CategoriaId);

                ////Ignorar la propiedad fabricante Id
                //entity.Ignore(e => e.FabricanteId);
            });


            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.CompraId);

                entity.Property(e => e.CompraId).HasColumnName("comprasId");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                //entity.HasMany(e => e.CompraDetalles)
                //    .WithOne(e => e.Compra)
                //    .HasForeignKey(e => e.CompraId)
                //    .HasConstraintName("FK_Compra_CompraDetalle");

                entity.Property(e => e.Proveedor).HasColumnName("proveedor");
            });


            modelBuilder.Entity<ProductoPermitidoCompra>(entity =>
            {
                entity.ToTable("productosPermitidosCompra");
                entity.HasKey(entity => new { entity.SucursalId, entity.ProductoId });

            });


            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(p => p.Id)
                .ValueGeneratedOnAdd();
                

                entity.Property(e => e.Id)
                .HasColumnName("sucursalId");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });


            modelBuilder.Entity<OutboxMessage>(entity =>
            {
                entity.ToTable("OutboxMessages","outbox");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("id");

                entity.Property(e => e.MessageType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("messageType");

                entity.Property(e => e.Payload)
                    .IsUnicode(false)
                    .HasColumnName("payload");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt");

                entity.Property(e => e.ProcessedAt)
                    .HasColumnName("processedAt");

                entity.Property(e => e.RetryCount)
                    .HasColumnName("retryCount");

                entity.Property(e => e.FailureReason)
                    .IsUnicode(false)
                    .HasColumnName("failureReason");
            });


            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.Property(e => e.CategoriaId)
                .UseIdentityColumn();
            }
            );

            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.HasKey(e => e.FabricanteId);

                entity.Property(e => e.FabricanteId)
                .UseIdentityColumn();
            }
            );

            modelBuilder.Entity<CodigoRelacionado>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn()
                ;

                entity.HasOne(d=> d.Producto)
                    .WithMany(p => p.CodigosRelacionados)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_CodigoRelacionado_Producto");
            }
            );


            modelBuilder.Entity<CompraDetalle>(e => 
            {  
                e.ToTable("cmpCompraDet");
                e.HasKey(e => new { e.CompraId, e.ProductoId });
                e.HasOne(e => e.Compra)
                .WithMany(e => e.CompraDetalles)
                .HasForeignKey(e => e.CompraId)
                .HasConstraintName("FK_CompraDetalle_Compra");
            }
            );
        }

    }

    public class SequenceResult
    {
        public long Sequense { get; set; }
    }
}
