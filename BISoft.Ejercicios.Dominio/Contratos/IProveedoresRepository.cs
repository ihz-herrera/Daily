using BISoft.Ejercicios.Infraestructura.Entidades;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Contratos
{
    public interface IProveedoresRepository : IRepository<Proveedor>
    {
       
        void EliminarProveedor(int id);
        Task<Proveedor> ObtenerProveedorPorId(int id);
    }
}