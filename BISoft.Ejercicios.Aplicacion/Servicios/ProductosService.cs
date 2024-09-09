using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Aplicacion.Helpers;
using BISoft.Ejercicios.Aplicacion.Notificaciones.Builders;
using BISoft.Ejercicios.Dominio.Builders;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
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

        public ProductosService(IProductosRepository repo,ICategoriasRepository repoCategorias,
            IFabricantesRepository fabricantesRepository, IOutboxRepository outboxRepository)
        {
            _outboxRepository = outboxRepository; // new OutboxRepository(new Context());
            _repo = repo;
            _repoCategorias = repoCategorias;
            _repoFabricantes = fabricantesRepository;
        }

      
        public async Task<Producto> CrearProducto(Producto producto)
        {
            //Consultar si el producto ya existe
            var productoExiste= await _repo.ObtenerPorExpresion(
                p=> p.ProductoId == producto.ProductoId );

            var categoria = await _repoCategorias.ObtenerPorExpresion(
                c=> c.CategoriaId == producto.CategoriaId);


            if (categoria == null)
                throw new InvalidOperationException("La categoria no existe");

            var fabricante = await _repoFabricantes.ObtenerPorExpresion(fabricante => fabricante.FabricanteId == producto.FabricanteId);

            if (fabricante == null)
                throw new InvalidOperationException("El fabricante no existe");

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

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            return await _repo.ObtenerPorExpresion( p=> p.ProductoId == id);
        }

        public async Task<IEnumerable<ProductoDto>> ObtenerProductos()
        {
            var products = _repo.GetCollection()
                .Include(p=> p.CodigosRelacionados);

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

        public async Task<PagerList<Producto>> ObtenerProductoPaginados(PaginationParameters parameters,Expression<Func<Producto,bool>> where = null )
        {
            var source = _repo.GetCollection();
                 
            if (where != null)
            {
                source = source.Where(where);
            }

            source = source.AsNoTracking()
                 .OrderBy(p => p.ProductoId);

            return await PagerList<Producto>
                .Create(source, parameters.PageNumber, parameters.PageSize);
                
        }
    }
}
