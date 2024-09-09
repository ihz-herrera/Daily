using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Migrations;
using BISoft.Ejercicios.Test.Fabricas;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Test.Builders
{
    public class MockProductoServiceBuilder : SetProducto,SetCategoria,SetFabricante,SetOutbox
    {
        private Mock<IProductosRepository> fakeProductosRepository;
        private Mock<ICategoriasRepository> fakeCategoriasRepository;
        private Mock<IFabricantesRepository> fakeFabricantesRepository;
        private Mock<IOutboxRepository> fakeOutboxRepository;

        private MockProductoServiceBuilder()
        {
            fakeProductosRepository = new Mock<IProductosRepository>();
            fakeCategoriasRepository = new Mock<ICategoriasRepository>();
            fakeFabricantesRepository = new Mock<IFabricantesRepository>();
            fakeOutboxRepository = new Mock<IOutboxRepository>();
        }

       
        private MockProductoServiceBuilder(Mock<IProductosRepository> productosRepository, Mock<ICategoriasRepository> categoriasRepository, Mock<IFabricantesRepository> fabricantesRepository, Mock<IOutboxRepository> outboxRepository)
        {
            fakeProductosRepository = productosRepository;
            fakeCategoriasRepository = categoriasRepository;
            fakeFabricantesRepository = fabricantesRepository;
            fakeOutboxRepository = outboxRepository;
        }

        public static SetProducto Empty() => new MockProductoServiceBuilder();
        public static MockProductoServiceBuilder Default()
        {

            var productoRepo = new Mock<IProductosRepository>();
            productoRepo.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<Producto, bool>>>()))
                .ReturnsAsync(ProductoFactory.CrearProductoValidoActivo);

            var fabricanteRepo = new Mock<IFabricantesRepository>();
            fabricanteRepo.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<Fabricante, bool>>>()))
                .ReturnsAsync(FabricanteFactory.CrearFabricanteValidoActivo);


            var outboxRepo = new Mock<IOutboxRepository>();
            outboxRepo.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<OutboxMessage, bool>>>()))
                .ReturnsAsync(() => null);

            var categoriaRepo = new Mock<ICategoriasRepository>();
            categoriaRepo.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<Categoria, bool>>>()))
                .ReturnsAsync(CategoriaFactory.CategoriaValidaActiva);


            var builder = new MockProductoServiceBuilder(productoRepo,categoriaRepo,fabricanteRepo, outboxRepo);

            return builder;

           
        }

        public SetCategoria WithProducto()
        {
            fakeProductosRepository.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<Producto,bool>>>()))
                .ReturnsAsync(ProductoFactory.CrearProductoValidoActivo);
            return this;
        }

        public SetCategoria WithProductoIsNull()
        {
            fakeProductosRepository.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<Producto, bool>>>()))
                .ReturnsAsync(()=>null);
            return this;
        }

        public SetFabricante WithCategoria()
        {
            fakeCategoriasRepository.Setup(repo =>
                repo.ObtenerPorExpresion(It.Is<Expression<Func<Categoria, bool>>>(exp=>
                    exp.Compile()(CategoriaFactory.CategoriaValidaActiva)
                )))
                .ReturnsAsync(CategoriaFactory.CategoriaValidaActiva);
            return this;
        }

        public SetFabricante WithCategoriaIsNull()
        {
            fakeCategoriasRepository.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<Categoria, bool>>>()))
                .ReturnsAsync(() => null);
            return this;
        }

        public MockProductoServiceBuilder WithFabricante()
        {
            fakeFabricantesRepository.Setup(repo =>
                repo.ObtenerPorExpresion(It.Is<Expression<Func<Fabricante, bool>>>(exp=>
                exp.Compile()(FabricanteFactory.CrearFabricanteValidoActivo()))))
                .ReturnsAsync(FabricanteFactory.CrearFabricanteValidoActivo);
            return this;
        }

        public MockProductoServiceBuilder WithFabricanteIsNull()
        {
            fakeFabricantesRepository.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<Fabricante, bool>>>()))
                .ReturnsAsync(() => null);
            return this;
        }

        public MockProductoServiceBuilder WithOutbox()
        {
            fakeOutboxRepository.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<OutboxMessage, bool>>>()))
                .ReturnsAsync(()=>null);
            return this;
        }

        public MockProductoServiceBuilder WithOutboxIsNull()
        {
            fakeOutboxRepository.Setup(repo =>
                repo.ObtenerPorExpresion(It.IsAny<Expression<Func<OutboxMessage, bool>>>()))
                .ReturnsAsync(() => null);
            return this;
        }



        public (ProductosService service,Mock<IProductosRepository> repo) Build()
        {
            return (new ProductosService(fakeProductosRepository.Object, fakeCategoriasRepository.Object,
                fakeFabricantesRepository.Object, fakeOutboxRepository.Object),
                fakeProductosRepository);
        }


    }


    public interface SetProducto
    {
        SetCategoria WithProducto();
        SetCategoria WithProductoIsNull();
    }

    public interface SetCategoria
    {
        SetFabricante WithCategoria();
        SetFabricante WithCategoriaIsNull();
    }

    public interface SetFabricante
    {
        MockProductoServiceBuilder WithFabricante();
        MockProductoServiceBuilder WithFabricanteIsNull();

    }

    public interface SetOutbox
    {
        MockProductoServiceBuilder WithOutbox();
        MockProductoServiceBuilder WithOutboxIsNull();
    }


}
