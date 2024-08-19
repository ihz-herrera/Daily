using BISoft.Ejercicios.Dominio.Entidades;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Dominio.Contratos
{
    public interface IProveedoresRepository : IRepository<Proveedor>
    {
       
        void EliminarProveedor(int id);
        Task<Proveedor> ObtenerProveedorPorId(int id);
    }
}