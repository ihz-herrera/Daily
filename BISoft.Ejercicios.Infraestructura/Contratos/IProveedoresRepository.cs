using BISoft.Ejercicios.Infraestructura.Entidades;

namespace BISoft.Ejercicios.Infraestructura.Contratos
{
    public interface IProveedoresRepository : IRepository<Proveedor>
    {
       
        void EliminarProveedor(int id);
        Proveedor ObtenerProveedorPorId(int id);
    }
}