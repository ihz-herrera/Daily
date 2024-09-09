using BISoft.Ejercicios.Dominio.Builders;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Test.Builders;
using BISoft.Ejercicios.Test.Fabricas;
using Moq;

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


        #region Servicios

        [Fact]
        [Trait("Categoria", "Servicio")]
        public async Task CrearProducto_DebeGuardarProducto_CuandoLosDatosSonValidos()
        {
            var (fakeService, repo) = MockProductoServiceBuilder.Empty()
                .WithProductoIsNull()
                .WithCategoria()
                .WithFabricante()
                .WithOutbox()
                .Build();

            var producto = ProductoFactory.CrearProductoValidoActivo;


            // Act
            await fakeService.CrearProducto(producto);

            // Assert
            //Assert.NotNull(productoConsultar);

            repo.Verify(x => x.Crear(producto), Times.Once);
            repo.Verify(x => x.Actualizar(producto), Times.Never);
        }


        [Fact]
        [Trait("Categoria", "Servicio")]
        public async Task CrearProducto_DebeActualizarProducto_CuandoLosDatosSonValidosYExiste()
        {
            var (fakeService, repo) = 
                MockProductoServiceBuilder.Default().Build();

            var producto = ProductoFactory.CrearProductoValidoActivo;

            // Act
            await fakeService.CrearProducto(producto);

            // Assert

            repo.Verify(x => x.Crear(producto), Times.Never);
            repo.Verify(x => x.Actualizar(producto), Times.Once);
        }



        [Fact]
        [Trait("Categoria", "Servicio")]
        public async Task CrearProducto_DebeLanzarExcepcion_CuandoNoExisteLaCategoria()
        {
            // Arrange

            var (fakeService,repo)  = MockProductoServiceBuilder.Empty()
                .WithProductoIsNull()
                .WithCategoriaIsNull()
                .WithFabricante()
                .WithOutbox()
                .Build();

            var producto = ProductoFactory.CrearProductoValidoActivo;
            // Act

            // Assert

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(  async ()=>await fakeService.CrearProducto(producto));

            Assert.Equal("La categoria no existe", exception.Message);

            repo.Verify(x => x.Crear(producto), Times.Never);

        }

        [Fact]
        [Trait("Categoria", "Servicio")]
        public async Task CrearProducto_DebeLanzarExcepcion_CuandoNoExisteElFabricante()
        {
            // Arrange

            var (fakeService, repo) = MockProductoServiceBuilder.Empty()
                .WithProductoIsNull()
                .WithCategoria()
                .WithFabricanteIsNull()
                .WithOutbox()
                .Build();

            var producto = ProductoFactory.CrearProductoValidoActivo;
            // Act

            // Assert

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () => await fakeService.CrearProducto(producto));

            Assert.Equal("El fabricante no existe", exception.Message);

            repo.Verify(x => x.Crear(producto), Times.Never);

        }

        [Fact]
        [Trait("Categoria", "Servicio")]
        public async Task CrearProducto_DebeLanzarExcepcion_CuandoLosDatosNoSonValidos()
        {
            // Arrange
           
            
            // Act


            // Assert
            var message = Assert.Throws<ArgumentException>(() =>
            ProductoFactory.CreaProductoInvalidoActivo);

            Assert.Equal("El costo no puede ser mayor al precio", message.Message);

        }

        #endregion

    }


}

