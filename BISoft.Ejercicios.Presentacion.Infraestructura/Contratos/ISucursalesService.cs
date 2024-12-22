using BISoft.Ejercicios.Shared.Dtos;

namespace BISoft.Ejercicios.Presentacion.Infraestructura.Contratos
{
    public interface ISucursalesService
    {
        Task<IEnumerable<SucursalDto>> ObtenerSucursales();
    }
}
