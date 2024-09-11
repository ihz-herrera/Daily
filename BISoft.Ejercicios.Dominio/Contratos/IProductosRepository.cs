using BISoft.Ejercicios.Dominio.Entidades;
using System.Linq;

namespace BISoft.Ejercicios.Dominio.Contratos
{
    public interface IProductosRepository : IRepository<Producto>
    {

        void EliminarProducto(int id);

        IQueryable<Producto> ObtenerProductos();
    }
}
