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

        public ProductosController(ProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            return Ok( _productosService.ObtenerProductos());
        }


        


    }
}
