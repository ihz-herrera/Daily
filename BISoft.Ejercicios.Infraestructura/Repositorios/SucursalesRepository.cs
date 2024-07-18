using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class SucursalesRepository:Repositorio<Sucursal>, ISucursalesRepository
    {
        public SucursalesRepository(Context context):base(context)
        {
        }
    }
}
