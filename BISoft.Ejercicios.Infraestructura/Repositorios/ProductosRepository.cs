using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProductosRepository: Repositorio<Producto>, IProductosRepository
    {

        public ProductosRepository(Context context):base(context)
        {
        }

     
        public IQueryable<Producto> ObtenerProductos()
        {
            return _context.Productos;
        }

        public void EliminarProducto(int id)
        {
            var producto = _context.Productos.FirstOrDefault(x => x.ProductoId == id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
        }

    }
}
