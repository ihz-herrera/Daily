using BISoft.Ejercicios.Api.Controllers.Dto;
using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<IEnumerable<Proveedor>> GetProveedores([FromQuery] ProveedoresParameters parameters)
        {
            //_logger.LogInformation("Obteniendo proveedores");

            var proveedores = await _servicio.ObtenerProveedores(parameters);

            _logger.LogDebug("Proveedores obtenidos {@proveedores}", proveedores);

            if (proveedores.Any())
            {
                return proveedores;
            }

            return NoContent();
            


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
        public async Task<Proveedor> GetProveedorPorId([FromRoute] int id)
        {
            var proveedor = await _servicio
                .ObtenerProveedorPorId(id)
                ;

            return proveedor;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CrearProveedor([FromBody] CrearProveedor proveedor)
        {
            var result = await _servicio.GuardarProveedor(proveedor);


            return Created($"api/proveedores/{result.Id}",proveedor);
        }

    }

   
}
