using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Builders;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Test
{
    public class ProductosTest
    {
        [Fact]
        [Trait("Categoria", "Producto")]
        public void CrearProductoNuevo_DebeCrearProducto_CuandoEsValido()
        {
            //Act
            var producto = ProductoBuilder.Empty
                .WithDescripcion("Producto 1")
                .WithPrecio(100)
                .WithCosto(50)
                .WithStatus(true)
                .WithCategoriaId(1)
                .WithFabricanteId(1)
                .Build();

            // Assert
            Assert.NotNull(producto);
        }

        [Theory]
        [InlineData(100,100)]
        [InlineData(100, 110)]
        [Trait("Categoria", "Excepciones")]
        public void CrearProductoNuevo_DebeLanzarExcepcion_CuandoNoEsValido(decimal precio, decimal costo )
        {
            //Act
            

            // Assert
            Assert.Throws<ArgumentException>(()=> ProductoBuilder.Empty
                .WithDescripcion("Producto 1")
                .WithPrecio(precio)
                .WithCosto(costo)
                .WithStatus(true)
                .WithCategoriaId(1)
                .WithFabricanteId(1)
                .Build());
        }

        [Fact]
        [Trait("Categoria", "Servicio")]
        public async Task CrearProducto_DebeGuardarProducto_CuandoLosDatosSonValidos()
        {


            // Arrange
            var context = new Context();
            var _productosRepository = new ProductosRepository(context);
            var _categoriasRepository = new CategoriasRepository(context);
            var _fabricantesRepository = new FabricantesRepository(context);
            var _outBoxRepository = new OutboxRepository(context);
            var _productosService = new ProductosService(_productosRepository,_categoriasRepository,
                _fabricantesRepository,_outBoxRepository);

            var producto = ProductoBuilder.Empty
                .WithId(30004)
                .WithDescripcion("Producto Test 1")
                .WithPrecio(100)
                .WithCosto(50)
                .WithStatus(true)
                .WithCategoriaId(1)
                .WithFabricanteId(1)
                .Build();

            // Act
            await _productosService.CrearProducto (producto);

            var productoConsultar = await _productosRepository
                .ObtenerPorExpresion(x => x.ProductoId == producto.ProductoId);

            // Assert
            Assert.NotNull(productoConsultar);
        }
    }


}

