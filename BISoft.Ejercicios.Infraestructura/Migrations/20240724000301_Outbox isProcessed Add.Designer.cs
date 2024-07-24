﻿// <auto-generated />
using System;
using BISoft.Ejercicios.Infraestructura.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BISoft.Ejercicios.Infraestructura.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240724000301_Outbox isProcessed Add")]
    partial class OutboxisProcessedAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BISoft.Ejercicios.Dominio.Entidades.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FailureReason")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("failureReason");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("bit");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("messageType");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("payload");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("processedAt");

                    b.Property<int>("RetryCount")
                        .HasColumnType("int")
                        .HasColumnName("retryCount");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", "outbox");
                });

            modelBuilder.Entity("BISoft.Ejercicios.Dominio.Entidades.Sucursal", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("sucursalId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("BISoft.Ejercicios.Infraestructura.Entidades.Compra", b =>
                {
                    b.Property<int>("ComprasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("comprasId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComprasId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("descripcion");

                    b.Property<int>("Proveedor")
                        .HasColumnType("int")
                        .HasColumnName("proveedor");

                    b.HasKey("ComprasId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("BISoft.Ejercicios.Infraestructura.Entidades.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codigoProducto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"), 1L, 1);

                    b.Property<decimal>("Costo")
                        .HasColumnType("money")
                        .HasColumnName("costo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombreProducto");

                    b.Property<decimal>("Precio")
                        .HasColumnType("money")
                        .HasColumnName("precio");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("ProductoId");

                    b.ToTable("genProductosCat", "dbo");
                });

            modelBuilder.Entity("BISoft.Ejercicios.Infraestructura.Entidades.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });
#pragma warning restore 612, 618
        }
    }
}