using BISoft.Ejercicios.Infraestructura.Entidades;

namespace BISoft.Ejercicios.Infraestructura.Contratos
{
    public interface IProveedoresRepository
    {
        void ActualizarProveedor(Proveedor proveedor);
        void CrearProveedor(Proveedor proveedor);
        void EliminarProveedor(int id);
        List<Proveedor> ObtenerProveedores();
        Proveedor ObtenerProveedorPorId(int id);
    }
}