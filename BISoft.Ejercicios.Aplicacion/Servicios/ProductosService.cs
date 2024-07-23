using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;

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

            //Enviar email de notificación
            var emailService = new EmailService();
            await emailService.SendEmail("","Nuevo producto creado", $"Se ha creado el producto {producto.ProductoId}");
            
            //Enviar mensaje de whatsapp
            var whatsappService = new WhatsappService();
            await whatsappService.SendMessage("1234567890", $"Se ha creado el producto {producto.ProductoId}");

            //Enviar notificación por http
            var httpService = new HttpService();
            await httpService.SendRequest("http://miservicio.com/notificar");

            //retornar el producto creado o actualizado
            return producto;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _repo.ObtenerTodos();

        }
    }
}
