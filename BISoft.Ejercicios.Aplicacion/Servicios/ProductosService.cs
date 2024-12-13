using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Aplicacion.Extensiones;
using BISoft.Ejercicios.Aplicacion.Fabricas;
using BISoft.Ejercicios.Aplicacion.Helpers;
using BISoft.Ejercicios.Aplicacion.Notificaciones.Builders;
using BISoft.Ejercicios.Aplicacion.Pipelines;
using BISoft.Ejercicios.Dominio.Builders;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Dominio.Excepciones;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using BISoft.Ejercicios.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
  

    public class ProductosService 
    {
        private readonly IProductosRepository _repo;
        private readonly ICategoriasRepository _repoCategorias;
        private readonly IFabricantesRepository _repoFabricantes;
        private readonly IOutboxRepository _outboxRepository;

        public ProductosService(IProductosRepository repo, ICategoriasRepository repoCategorias,
            IFabricantesRepository fabricantesRepository, IOutboxRepository outboxRepository)
        {
            _outboxRepository = outboxRepository; // new OutboxRepository(new Context());
            _repo = repo;
            _repoCategorias = repoCategorias;
            _repoFabricantes = fabricantesRepository;
        }


        public async Task<Producto> CrearProducto(CrearProducto producto)
        {
            ////Consultar si el producto ya existe
            //var productoExiste= await _repo.ObtenerPorExpresion(
            //    p=> p.ProductoId == producto.ProductoId );

            var productoExiste = await _repo.ObtenerPorExpresion(
                p => p.Descripcion == producto.Descripcion);

            //Clausula de guarda
            if (productoExiste is not null)
                throw new ProcessException("El producto ya existe");

            var categoria = await _repoCategorias.ObtenerPorExpresion(
                c => c.CategoriaId == producto.CategoriaId);


            if (categoria == null)
                throw new ProcessException("La categoria no existe",
                    new List<string> { $"CategoriaId: {producto.CategoriaId.ToString()}", $"Producto: {producto.Descripcion}" });

            var fabricante = await _repoFabricantes.ObtenerPorExpresion(fabricante => fabricante.FabricanteId == producto.FabricanteId);

            if (fabricante == null)
                throw new ProcessException("El fabricante no existe");


            var productoEntidad = producto.ToEntity();
            await _repo.Crear(productoEntidad);



            var messages = NotificationBuilder
                .Create()
                .AddEventType("ProductoCreado")
                .AddEmail("ivanh@techsoft.com.mx"
                    , "Producto Creado"
                    , $"Se ha creado el producto {productoEntidad.ProductoId}")
                .AddWhatsapp(w =>
                    {
                        w.PhoneNumber = "1234567890";
                        w.Data = $"Se ha creado el producto {productoEntidad.ProductoId}";
                    }
                )
                .AddHttpMessage(h => h
                    .AddUrl("http://localhost:5000/api/Producto")
                    .AddData($"Se ha creado el producto {productoEntidad.ProductoId}"))
                .Build();

            await _outboxRepository.Crear(messages);

            //Enviar por WhatsApp
            var whatsAppOutboxMessage = new OutboxMessage
            {
                MessageType = "WhatsApp",
                EventType = "ProductoCreado",
                Payload = $"Se ha creado el producto {productoEntidad.ProductoId}",
                CreatedAt = DateTime.Now
            };

            await _outboxRepository.Crear(whatsAppOutboxMessage);

            //Enviar por Http
            var httpOutboxMessage = new OutboxMessage
            {
                MessageType = "Http",
                EventType = "ProductoCreado",
                Payload = $"Se ha creado el producto {productoEntidad.ProductoId}",
                CreatedAt = DateTime.Now
            };

            await _outboxRepository.Crear(httpOutboxMessage);

            //retornar el producto creado o actualizado
            return productoEntidad;
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return await _repo.ObtenerPorExpresion(p => p.ProductoId == id);
        }

        public async Task<IEnumerable<ProductoDto>> ObtenerProductos()
        {
            var products = _repo.GetCollection()
                .Include(p => p.CodigosRelacionados);

            var categorias = _repoCategorias.GetCollection();

            var productos = from p in products
                            join c in categorias on p.CategoriaId equals c.CategoriaId
                            join f in _repoFabricantes.GetCollection() on p.FabricanteId equals f.FabricanteId
                            select new ProductoDto(
                                p.ProductoId,
                                p.Descripcion,
                                p.Precio,
                                p.Costo,
                                p.Status,
                                c.Nombre,
                                f.Nombre
                                )
            ;

            //var fabricantes = _repoFabricantes.GetCollection();

            //var result2 = 
            //    productos.Join(fabricantes,
            //    p => p.FabricanteId,
            //    f => f.FabricanteId,
            //    (p, f) =>
            //    new ProductoDto
            //    {
            //        Producto = p,
            //        Fabricante = f,

            //    });

            return await productos.ToListAsync();

        }

        public async Task<PagerList<Producto>> ObtenerProductoPaginados(ProductoParameters parameters, Expression<Func<Producto, bool>> where = null)
        {
            var source = _repo.GetCollection();

            if (where != null)
            {
                source = source.Where(where);
            }

            var handlers = ProductoFilterFactory.CrearFiltros();

            foreach (var handler in handlers)
            {
                source = handler.Handle(source, parameters);
            }

            //if (parameters.FabricanteId > 0)
            //{
            //    source = source.Where(p => p.FabricanteId == parameters.FabricanteId);
            //}

            if (parameters.PageSize > 100)
                parameters.PageSize = 100;



            source = source.AsNoTracking()
                 .OrderBy(p => p.ProductoId);

            return await PagerList<Producto>
                .Create(source, parameters.PageNumber, parameters.PageSize);

        }


        public async Task<List<Categoria>> ObtenerCategorias()
        {

            return await _repoCategorias.ObtenerTodos();
        }

        public async Task<List<Fabricante>> ObtenerFabricantes()
        {
            return await _repoFabricantes.ObtenerTodos();
        }

        public async Task<ProductoDto> ActualizarProducto(int id, ActualizarProducto producto)
        {

            //Buscar el producto
            var productoEntidad = await _repo.ObtenerPorExpresion(p => p.ProductoId == id)
                ?? throw new KeyNotFoundException("El producto no existe");


            //Actualizar las propiedades del producto
            productoEntidad.Descripcion = producto.Descripcion;
            productoEntidad.Precio = producto.Precio;
            productoEntidad.SetCosto(producto.Costo);
            //Guardar el producto
            await _repo.Actualizar(productoEntidad);

            //Regresar el producto actualizado

            var categoria = await _repoCategorias.ObtenerPorExpresion(
                c => c.CategoriaId == productoEntidad.CategoriaId);

            var fabricante = await _repoFabricantes.ObtenerPorExpresion(
                f => f.FabricanteId == productoEntidad.FabricanteId);

            return new ProductoDto(
                productoEntidad.ProductoId,
                productoEntidad.Descripcion,
                productoEntidad.Precio,
                productoEntidad.Costo,
                productoEntidad.Status,
                categoria.Nombre,
                fabricante.Nombre

                );

        }
    }
}
