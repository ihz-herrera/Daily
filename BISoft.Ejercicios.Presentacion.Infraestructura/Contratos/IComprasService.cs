using BISoft.Ejercicios.Shared.Dtos;

namespace BISoft.Ejercicios.Presentacion.Infraestructura.Contratos
{
    public interface IComprasService
    {
        Task ActualizarCompra(CompraDto compra);
        Task Cancelar(int id);
        Task<CompraDto> CrearCompra(CompraDto compra, List<ProductoPermitidoDto> permitidos);
        Task<CompraDto> CrearCompra(CompraDto compra);
        Task<CompraDto> ObtenerCompraPorId(int id);
        Task<List<CompraDto>> ObtenerCompras();
        Task<List<ProductoPermitidoDto>> ProductosPermitidos(int sucursalId);
    }
}
