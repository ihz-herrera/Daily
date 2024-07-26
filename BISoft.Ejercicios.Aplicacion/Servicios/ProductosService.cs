using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Aplicacion.Notificaciones;
using BISoft.Ejercicios.Aplicacion.Notificaciones.Builders;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class ProductosService
    {
        private readonly IProductosRepository _repo;
        private readonly IOutboxRepository _outboxRepository;

        public ProductosService(IProductosRepository repo)
        {
            _outboxRepository = new OutboxRepository(new Context());
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


            var messages = NotificationBuilder
                .Create()
                .AddEventType("ProductoCreado")
                .AddEmail("ivanh@techsoft.com.mx"
                    , "Producto Creado"
                    , $"Se ha creado el producto {producto.ProductoId}")
                .AddWhatsapp(w =>
                    {
                        w.PhoneNumber = "1234567890";
                        w.Data = $"Se ha creado el producto {producto.ProductoId}";
                    }
                )
                .AddHttpMessage(h => h
                    .AddUrl("http://localhost:5000/api/Producto")
                    .AddData($"Se ha creado el producto {producto.ProductoId}"))
                .Build();

            await _outboxRepository.Crear(messages);

            //retornar el producto creado o actualizado
            return producto;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _repo.ObtenerTodos();

        }

        public async Task<List<Producto>> ObtenerProductoPaginados(PaginationParameters parameters)
        {
            return await _repo.GetCollection()
                .AsNoTracking()
                .OrderBy(p => p.ProductoId)
                .Skip((parameters.PageNumber-1)*parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }
    }
}
