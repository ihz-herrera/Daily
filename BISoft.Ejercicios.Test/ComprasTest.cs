using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using BISoft.Ejercicios.Test.Fabricas;
using Microsoft.EntityFrameworkCore;

namespace BISoft.Ejercicios.Test
{
    public class ComprasTest
    {
        [Fact]
        [Trait("Categoria", "Integral")]

        public async Task CreateCompras_Should_be_Ok()
        {

            // Arrange

            var servicio = ComprasFactory.CrearComprasService();

            var compra = new Compra
            {
                
                Proveedor = 1,
                Descripcion = "Compra de prueba"
            };

            compra.CompraDetalles.Add(new CompraDetalle
            {
                ProductoId = 1,
                Cantidad = 10,
                Precio = 100
            });

            // Act
            await servicio.CrearCompra(compra);


            var resultado = await servicio.ObtenerCompraPorId(compra.CompraId);

            // Assert
            Assert.NotNull(resultado);


        }

        [Fact]
        public async Task ProductosPermitidos_ShouldReturnProductos_WhenProductoEsPermitido()
        {

            var servicio = ComprasFactory.CrearComprasService();

            var productos = await servicio.ProductosPermitidos(2);

            Assert.NotNull(productos);

        }

        [Fact(DisplayName ="Consulta Compras desde BD",Skip = "Dependiente de Base de Datos"
            ,Timeout = 10000)]
        [Trait("Categoria", "Integral")]

        public async Task QueryCompras_Should_be_Ok()
        {

            // Arrange

            var _comprasRepository = new ComprasRepository(new Context());

            var compraConsultar = await _comprasRepository
                .ObtenerPorExpresion(x => x.CompraId == 1);

            // Assert
            Assert.NotNull(compraConsultar);


        }

      


    }

  
}