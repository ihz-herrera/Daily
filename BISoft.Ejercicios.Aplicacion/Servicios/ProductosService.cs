using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using BISoft.Ejercicios.Infraestructura.Repositorios;

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


            //Crear mensaje en outbox
            var outboxMessage = new OutboxMessage
            {
                MessageType = "Email",
                EventType = "ProductoCreado",
                Payload = $"Se ha creado el producto {producto.ProductoId}",
                CreatedAt = DateTime.Now
            };

            await _outboxRepository.Crear(outboxMessage);

            //Enviar por WhatsApp
            var whatsAppOutboxMessage = new OutboxMessage
            {
                MessageType = "WhatsApp",
                EventType = "ProductoCreado",
                Payload = $"Se ha creado el producto {producto.ProductoId}",
                CreatedAt = DateTime.Now
            };

            await _outboxRepository.Crear(whatsAppOutboxMessage);

            //Enviar por Http
            var httpOutboxMessage = new OutboxMessage
            {
                MessageType = "Http",
                EventType = "ProductoCreado",
                Payload = $"Se ha creado el producto {producto.ProductoId}",
                CreatedAt = DateTime.Now
            };

            await _outboxRepository.Crear(httpOutboxMessage);

            //retornar el producto creado o actualizado
            return producto;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _repo.ObtenerTodos();

        }
    }
}
