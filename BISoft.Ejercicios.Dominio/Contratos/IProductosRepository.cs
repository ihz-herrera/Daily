using BISoft.Ejercicios.Dominio.Entidades;

namespace BISoft.Ejercicios.Dominio.Contratos
{
    public interface IProductosRepository : IRepository<Producto>
    {

        void EliminarProducto(int id);
    }
}
