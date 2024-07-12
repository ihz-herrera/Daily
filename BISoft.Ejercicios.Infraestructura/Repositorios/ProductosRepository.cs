using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProductosRepository: Repositorio<Producto>, IProductosRepository
    {

        public ProductosRepository(Context context):base(context)
        {
        }

     

        public void EliminarProducto(int id)
        {
            var producto = _context.Productos.FirstOrDefault(x => x.ProductoId == id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
        }

    }
}
