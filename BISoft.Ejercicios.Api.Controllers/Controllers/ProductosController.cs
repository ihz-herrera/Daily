using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace BISoft.Ejercicios.Api.Controllers.Controllers
{
    [ApiController]
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
            try
            {
                _logger.LogDebug("Obteniendo productos");
                var productos = await _productosService.ObtenerProductoPaginados(parameters);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al obtener productos Error:{}",ex.Message);
                return StatusCode(500, "Error al obtener productos");
            }

            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            return Ok(_productosService.ObtenerProductoPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(CrearProducto producto)
        {
            try
            {
                var result = await _productosService.CrearProducto(producto);
                _logger.LogInformation("Producto creado {@producto}",result );

                return Ok(result);

            }
            catch (InvalidOperationException ex)
            {
                _logger.LogDebug(ex, "Error al crear producto");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
               _logger.LogError("Error al crear producto Error:{error}",ex.Message);
                return StatusCode(500, "Error al crear producto");
            }
        }
        


    }
}
