using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Fabricas
{
    public class SucursalesRepositoryFactory
    {

        public static ISucursalesRepository CrearSucursalesRepository()
        {
            return new SucursalesRepository(new Context());
        }
    }
}
