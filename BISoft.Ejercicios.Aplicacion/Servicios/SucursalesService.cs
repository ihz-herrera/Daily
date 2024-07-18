using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class SucursalesService
    {

        public readonly SucursalesRepository _repo;

        public SucursalesService(SucursalesRepository repo)
        {
            _repo = repo;
        }
  

        public async Task<IEnumerable<Sucursal>> ObtenerSucursales()
        {
            return await _repo.ObtenerTodos();

        }


    }
}
