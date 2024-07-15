using BISoft.Ejercicios.Aplicacion.Fabricas;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class ProveedoresService
    {
        private readonly ProveedoresRepository _repo;

        public ProveedoresService(ProveedoresRepository repo)
        {
            _repo = repo;
        }


        public async Task GuardarProveedor(short id, string nombre, string direccion)
        {
          
            // Consultar si el proveedor ya existe
            var proveedor = await _repo.ObtenerProveedorPorId(id);
            if (proveedor != null)
            {
                proveedor = new Proveedor
                {
                    Id = id,
                    Nombre = nombre,
                    Direccion = direccion
                };

                await _repo.Actualizar(proveedor);
            }
            else
            {
                proveedor = new Proveedor
                {
                    Id = id,
                    Nombre = nombre,
                    Direccion = direccion
                };

                await _repo.Crear(proveedor);
            }
        }
    }
}
