using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
   

    public class ProveedoresService 
    {
        private readonly IProveedoresRepository _repo;
        private readonly ILogger<ProveedoresService> _logger;

        public ProveedoresService(IProveedoresRepository repo, ILogger<ProveedoresService> logger)
        {
            _repo = repo;
            _logger = logger;
        }


        public async Task<Proveedor> GuardarProveedor(CrearProveedor proveedorDto)
        {

            // Consultar si el proveedor ya existe
            var proveedor = await _repo.ObtenerPorExpresion(p => p.Nombre == proveedorDto.Nombre);
            //_repo.ObtenerProveedorPorId(proveedorDto);
            if (proveedor != null)
            {
                //si existe, actualizar
                _logger.LogInformation("Actualizando proveedor {@proveedor}", proveedor);
                proveedor = new Proveedor
                {
                    Id = proveedor.Id,
                    Nombre = proveedorDto.Nombre,
                    Direccion = proveedorDto.Direccion
                };

                await _repo.Actualizar(proveedor);
            }
            else
            {


                //si no existe, crear
                proveedor = new Proveedor
                {
                    Nombre = proveedorDto.Nombre,
                    Direccion = proveedorDto.Direccion
                };

                _logger.LogInformation("Creando Proveedor {@proveedor}", proveedor);

                await _repo.Crear(proveedor);
            }

            return proveedor;


        }

        public async Task<IEnumerable<Proveedor>> ObtenerProveedores(ProveedoresParameters parametros)
        {
            var proveedores = _repo.GetCollection();  // await _repo.ObtenerTodos();

            if (parametros != null)
            {
                if (parametros.Nombre != null)
                    proveedores = proveedores.Where(x => x.Nombre.ToLower().Contains(parametros.Nombre.ToLower()));

                if (parametros.Direccion != null)
                    proveedores = proveedores.Where(x => x.Direccion.ToLower().Contains(parametros.Direccion.ToLower()));
            }


            return await proveedores.ToListAsync();
        }

        public async Task<Proveedor> ObtenerProveedorPorId(int id)
        {
            return await _repo.ObtenerProveedorPorId(id);
        }
    }
}
