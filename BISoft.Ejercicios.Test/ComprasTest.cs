using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace BISoft.Ejercicios.Test
{
    public class ComprasTest
    {
        [Fact]
        public async Task CreateCompras_Should_be_Ok()
        {

            // Arrange

            var _comprasRepository = new ComprasRepository(new Context());

            var compra = new Compra
            {
                
                Proveedor = 1,
                Descripcion = "Compra de prueba"
            };

            // Act
            await _comprasRepository.Crear(compra);


            var compraConsultar= await _comprasRepository
                .ObtenerPorExpresion(x => x.CompraId == compra.CompraId);

            // Assert
            Assert.NotNull(compraConsultar);


        }

        [Fact]
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