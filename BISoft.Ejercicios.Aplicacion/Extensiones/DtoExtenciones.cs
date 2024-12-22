using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Dominio.Builders;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Extensiones
{
    public static class DtoExtensiones
    {

        public static Producto ToEntity(this CrearProducto producto)
        {
            return ProductoBuilder.Empty
                .WithDescripcion(producto.Descripcion)
                .WithPrecio(producto.Precio)
                .WithCosto(producto.Costo)
                .WithStatus(true)
                .WithCategoriaId(producto.CategoriaId)
                .WithFabricanteId(producto.FabricanteId)
                .Build();
        }
    }
}
