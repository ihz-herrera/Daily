using BISoft.Ejercicios.Shared.Dtos;

namespace BISoft.Ejercicios.Presentacion.Infraestructura.Contratos
{
    public interface IProveedoresService
    {
        Task<ProveedorDto> GuardarProveedor(string id, string nombre, string direccion);
        Task<IEnumerable<ProveedorDto>> ObtenerProveedores();
        Task<ProveedorDto> ObtenerProveedorPorId(int id);
        Task<ProveedorDto> GuardarProveedor(CrearProveedor proveedor);
    }
}
