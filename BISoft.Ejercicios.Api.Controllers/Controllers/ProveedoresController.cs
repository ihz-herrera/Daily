using BISoft.Ejercicios.Api.Controllers.Dto;
using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.SignalR;
using Serilog;

namespace BISoft.Ejercicios.Api.Controllers.Controllers
{
    [Route("api/proveedores")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {

        private readonly ProveedoresService _servicio;
        private readonly ILogger<ProveedoresController> _logger;


        public ProveedoresController(ProveedoresService servicio, ILogger<ProveedoresController> logger)
        {
            _servicio = servicio;
            _logger = logger;
        }

        [Authorize]
        [EnableRateLimiting("fixed-window")]
        [HttpGet]
        public async Task <ActionResult<IEnumerable<Proveedor>>> GetProveedores([FromQuery] ProveedoresParameters parameters)
        {
            //_logger.LogInformation("Obteniendo proveedores");
            try
            {
                var proveedores = await _servicio.ObtenerProveedores(parameters);

                _logger.LogDebug("Proveedores obtenidos {@proveedores}", proveedores);

                if (proveedores.Any())
                {
                    return Ok(proveedores);
                }

                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener proveedores");
                //responder con status code 500
                return StatusCode(500,$"Web App: Error Interno. Code {125}");
            }
           
            


        }

        //[Authorize]
        //[HttpGet("nombre/{nombre}/direccion/{direccion}")]
        //public async Task<IEnumerable<Proveedor>> GetProveedoresNombre(string nombre)
        //{
        //    //_logger.LogInformation("Obteniendo proveedores");

        //    var proveedores = await _servicio.ObtenerProveedores();

        //    _logger.LogDebug("Proveedores obtenidos {@proveedores}", proveedores);

        //    return proveedores;


        //}

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedorPorId([FromRoute] int id)
        {

            try
            {
                var proveedor = await _servicio
                .ObtenerProveedorPorId(id);

                return proveedor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener proveedores");
                //responder con status code 500
                return StatusCode(500, $"Web App: Error Interno. Code {125}");
            }
            
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CrearProveedor([FromBody] CrearProveedor proveedor)
        {
            try
            {
                var result = await _servicio.GuardarProveedor(proveedor);
                return Created($"api/proveedores/{result.Id}", proveedor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener proveedores");
                //responder con status code 500
                return StatusCode(500, $"Web App: Error Interno. Code {125}");
            }

        }

    }

   
}
