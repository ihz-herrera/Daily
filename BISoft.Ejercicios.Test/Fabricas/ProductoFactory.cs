using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Builders;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Test.Fabricas
{
    public static class ProductoFactory
    {
        public static Producto CrearProductoValidoActivo=> ProductoBuilder.Empty
                .WithId(1)
                .WithDescripcion("Producto 1")
                .WithPrecio(100)
                .WithCosto(50)
                .WithStatus(true)
                .WithCategoriaId(1)
                .WithFabricanteId(1)
                .Build();

        public static Producto CreaProductoInvalidoActivo => ProductoBuilder.Empty
                .WithId(30004)
                .WithDescripcion("Producto Test 1")
                .WithPrecio(100)
                .WithCosto(500)
                .WithStatus(true)
                .WithCategoriaId(1)
                .WithFabricanteId(1)
                .Build();

    }
}
