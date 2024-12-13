using BISoft.Ejercicios.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Presentacion.Infraestructura.Contratos
{
    public interface IProductosService
    {
        Task<ProductoDto> ActualizarProducto(int id, ActualizarProducto producto);
        Task<ProductoDto> CrearProducto(CrearProducto producto);
        Task<List<CategoriaDto>> ObtenerCategorias();
        Task<List<FabricanteDto>> ObtenerFabricantes();
        Task<PagerList<ProductoDto>> ObtenerProductoPaginados(ProductoParameters parameters, Expression<Func<Producto, bool>> where = null);
        Task<ProductoDto> ObtenerProductoPorId(int id);
        Task<IEnumerable<ProductoDto>> ObtenerProductos();
    }
}
