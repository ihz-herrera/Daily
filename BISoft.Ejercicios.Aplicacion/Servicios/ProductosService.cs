using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class ProductosService
    {
        private readonly IProductosRepository _repo;

        public ProductosService(IProductosRepository repo)
        {
            _repo = repo;
        }

      
        public async Task<Producto> CrearProducto(Producto producto)
        {
            //Consultar si el producto ya existe
            var productoExiste= await _repo.ObtenerPorExpresion(
                p=> p.ProductoId == producto.ProductoId );

            if (productoExiste != null)
                {
                //si existe, actualizar
                productoExiste = producto;
                await _repo.Actualizar(productoExiste);
            }
            else
            {
                //si no existe, crear
                await _repo.Crear(producto);
            }

            
            //retornar el producto creado o actualizado
            return producto;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _repo.ObtenerTodos();

        }
    }
}
