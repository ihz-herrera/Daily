using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Fabricas
{
    public class ProductosRepositoryFactory
    {
        public static IProductosRepository GetProductosRepository(string repoType)
        {

            ProductosRepository repository;

            switch (repoType)
            {
                //case "SP":
                //    var contexto = new Context();
                //    repository = new ProductosStoredRepository(contexto);
                //    break;
                //case "Dapper":
                //    repository = new ProductosDapperRepository();
                //    break;
                default:
                    repository = new ProductosRepository(new Context());
                    break;
            }

            return repository; // new ProductosCacheRepository( repository);
        }
    }
}
