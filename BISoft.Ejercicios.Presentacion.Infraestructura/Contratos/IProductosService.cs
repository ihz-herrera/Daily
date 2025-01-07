using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Shared.Dtos;
using BISoft.Ejercicios.Shared.Helpers;
using System.Linq.Expressions;

namespace BISoft.Ejercicios.Presentacion.Infraestructura.Contratos
{
    public interface IProductosService
    {
        Task<ProductoDto> ActualizarProducto(int id, ActualizarProducto producto);
        Task<ProductoDto> CrearProducto(CrearProducto producto);
        Task<List<CategoriaDto>> ObtenerCategorias();
        Task<List<FabricanteDto>> ObtenerFabricantes();
        Task<PagerList<ProductoDto>> ObtenerProductoPaginados(ProductoParameters parameters, Expression<Func<ProductoDto, bool>> where = null);
        Task<ProductoDto> ObtenerProductoPorId(int id);
        Task<IEnumerable<ProductoDto>> ObtenerProductos();
    }
}
