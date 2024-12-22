using BISoft.Ejercicios.Aplicacion.Builder;
using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Builders;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Shared.Dtos;
using Moq;

namespace BISoft.Ejercicios.Test.InTest;

public class TestInTest
{

    [Fact]
    public void Test_1 ()
    {
        var producto = new ProductoPermitidoDto(1, 1,10, "Producto de prueba");

        var producto1 = new ProductoPermitidoDto(1, 1,10, "Producto de prueba");

        var iguales = producto == producto1;
        var info = producto.ToString();

        var linea1 = new LineaCompra(1, "Producto 1", 1, 100, 0);
        var linea2 = new LineaCompra(1, "Producto 1", 1, 100, 0);

        var igualesLineas = linea1 == linea2;
        var infoLinea = linea1.ToString();

        Assert.True(iguales);


    }




    [Fact]
    public void InnerJoin_Test()
    {
        var productos = new List<StaticProducto>
        {
            new StaticProducto { ProductoId = 1, Descripcion = "Producto 1", Status = true },
            new StaticProducto { ProductoId = 2, Descripcion = "Producto 2", Status = true },
            new StaticProducto { ProductoId = 3, Descripcion = "Producto 3", Status = false },
            new StaticProducto { ProductoId = 4, Descripcion = "Producto 4", Status = true },
            new StaticProducto { ProductoId = 5, Descripcion = "Producto 5", Status = false }
        };

        var productosMetadata = new List<ProductoMetadata>
        {
            new ProductoMetadata { ProductoId = 2, Fabricante = "Fabricante 2", Valor = "Valor 2" },
            new ProductoMetadata { ProductoId = 3, Fabricante = "Fabricante 3", Valor = "Valor 3" },
            new ProductoMetadata { ProductoId = 4, Fabricante = "Fabricante 4", Valor = "Valor 4" },
            new ProductoMetadata { ProductoId = 8, Fabricante = "Fabricante 5", Valor = "Valor 5" }
        };



        //Left Join Producto con ProductoMetadata
        var leftJoin = from p in productos
                       join pm in productosMetadata on p.ProductoId equals pm.ProductoId into pm
                       from pmj in pm.DefaultIfEmpty()
                       select new
                       {
                           p.ProductoId,
                           p.Descripcion,
                           pmj?.Fabricante,
                           pmj?.Valor
                       };


        //Assert
        Assert.Equal(5, leftJoin.Count());



    }

    [Fact]
    public async Task InnerJoin_IQueryable()
    {
        var productoRepo = new Mock<IComprasRepository>();
        productoRepo.Setup(p=>p.ProductosPermitidosCompras())
            .Returns(new List<ProductoPermitidoCompra>
            {
                new ProductoPermitidoCompra { ProductoId = 1, SucursalId = 1 },
                new ProductoPermitidoCompra { ProductoId = 2, SucursalId = 1 },
                new ProductoPermitidoCompra { ProductoId = 3, SucursalId = 1 },
            }.AsQueryable);

        var productosRepo = new Mock<IProductosRepository>();
        productosRepo.Setup(p => p.ObtenerProductos())
            .Returns(new List<Producto>
            {
                new ProductoBuilder().WithId(1).WithDescripcion("Producto 1").WithStatus(true).WithPrecio(100).WithCosto(10).WithCategoriaId(1).WithFabricanteId(1).Build(),
                new ProductoBuilder().WithId(2).WithDescripcion("Producto 2").WithStatus(true).WithPrecio(100).WithCosto(10).WithCategoriaId(1).WithFabricanteId(1).Build(),
                new ProductoBuilder().WithId(3).WithDescripcion("Producto 3").WithStatus(false).WithPrecio(100).WithCosto(10).WithCategoriaId(1).WithFabricanteId(1).Build(),
                new ProductoBuilder().WithId(4).WithDescripcion("Producto 4").WithStatus(true).WithPrecio(100).WithCosto(10).WithCategoriaId(1).WithFabricanteId(1).Build()
            }.AsQueryable);


        ////left join productos con productosPermitidos
        var productosPermitidos = from p in productosRepo.Object.ObtenerProductos()
                                  where p.Status == true
                                  join pp in productoRepo.Object.ProductosPermitidosCompras() on p.ProductoId equals pp.ProductoId
                                  into result
                                  from pd in result.Where (p => p.SucursalId == 1)
                                  .DefaultIfEmpty()
                                  select new { 
                                    p.ProductoId,
                                    p.Descripcion,
                                    pd.SucursalId
                                  };

        //var productos = 
        //    await productosPermitidos.ToListAsync();

        var servicio = new ComprasService(productoRepo.Object, productosRepo.Object);


        var compra = new Compra
        {
            CompraId = 1,
            SucursalId = 1,
            Proveedor = 1,
            Descripcion = "Compra 1",
            CompraDetalles = new List<CompraDetalle>
            {
                new CompraDetalle { ProductoId = 1, Cantidad = 1, Precio = 0 },
                new CompraDetalle { ProductoId = 2, Cantidad = 1, Precio = 0 },
                new CompraDetalle { ProductoId = 3, Cantidad = 1, Precio = 0 }
            }
        };

        var list = new List<ProductoPermitidoDto>
        {
            new ProductoPermitidoDtoBuilder().WithProductoId(1).WithSucursalId(1).WithDescripcion("Producto 1").Build(),
            new ProductoPermitidoDtoBuilder().WithProductoId(2).WithSucursalId(1).WithDescripcion("Producto 2").Build(),
            new ProductoPermitidoDtoBuilder().WithProductoId(3).WithSucursalId(1).WithDescripcion("Producto 3").Build()
        };

        await servicio.CrearCompra(compra,list);

        
    }

    [Fact]
    public void Class_Should_be_error_when_compare()
    {
        var clase = new Class { Id = 1, Nombre = "Clase A" };
        var claseB = new Class { Id = 1, Nombre = "Clase A" };

        Assert.True(clase == claseB);
    }

    [Fact]
    public void Record_Should_be_ok_when_compare()
    {
        var clase = new Record { Id = 1, Nombre = "Clase A" };
        var claseB = new Record { Id = 1, Nombre = "Clase A" };

        Assert.True(clase == claseB);
    }

    [Fact]
    public void CustomizedClass_Should_be_ok_when_compare()
    {
        var clase = new CustomizedClass { Id = 1, Nombre = "Clase A" };
        var claseB = new CustomizedClass { Id = 1, Nombre = "Clase A" };

        Assert.True(clase == claseB);
    }

}

public class StaticProducto
{
    public int ProductoId { get; set; }
    public string Descripcion { get; set; }
    public bool Status { get; set; }
}

public class ProductoMetadata
{
    public int ProductoId { get; set; }
    public string Fabricante { get; set; }
    public string Valor { get; set; }
}



//class FactAttribute : Attribute
//{
//    public FactAttribute() { }
//    public FactAttribute(string name) { }


//}




public class Class
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

public record Record
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}

public class CustomizedClass
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is CustomizedClass clase)
        {
            return clase.Id == this.Id && clase.Nombre == this.Nombre ;
        }

        return base.Equals(obj);
    }
}