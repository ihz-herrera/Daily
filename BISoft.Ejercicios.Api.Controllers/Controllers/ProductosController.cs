using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BISoft.Ejercicios.Api.Controllers.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {

        private readonly ProductosService _productosService;
        private readonly ILogger<ProductosController> _logger;

        public ProductosController(ProductosService productosService, ILogger<ProductosController> logger)
        {
            _productosService = productosService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos([FromQuery]ProductoParameters parameters)
        {
          
            _logger.LogDebug("Obteniendo productos");
            var productos = await _productosService.ObtenerProductoPaginados(parameters);
               
            var header = HttpContext.Response.Headers;

            var pagination = new
            {
                productos.TotalCount,
                productos.PageSize,
                parameters.PageNumber,
                productos.TotalPages,
                productos.HasNextPage,
                productos.HasPreviousPage
            };
                
            header.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
            return Ok(productos);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            return Ok(_productosService.ObtenerProductoPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> CrearProducto(CrearProducto producto)
        {
     
            var result = await _productosService.CrearProducto(producto);
            _logger.LogInformation("Producto creado {@producto}",result );

            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> ActualizarProducto(int id, ActualizarProducto producto)
        {

            var result = await _productosService.ActualizarProducto(id, producto);
            _logger.LogInformation("Producto actualizado {@producto}", result);

            return Ok(result);

        }

    }
}
