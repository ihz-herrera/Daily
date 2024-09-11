using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Test.Fabricas
{
    public class ComprasFactory
    {
      


        public static IComprasRepository CrearComprasRepository()
        {


            return new ComprasRepository(new Context());
        }

        public static ComprasService CrearComprasService()
        {
            var context = new Context();
            var repo = new ComprasRepository(context);
            var repoProducto = new ProductosRepository  (context);

            return new ComprasService(repo, repoProducto);
        }
    }
}
