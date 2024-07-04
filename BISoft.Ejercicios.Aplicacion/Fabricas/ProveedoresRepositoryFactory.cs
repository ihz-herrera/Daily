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
    public class ProveedoresRepositoryFactory
    {

        public static IProveedoresRepository GetProveedoresRepository(string repoType)
        {

            IProveedoresRepository repository ;

            switch (repoType)
            {
                case "SP":
                    var contexto = new Context();
                    repository = new ProveedoresStoredRepository(contexto);
                    break;
                case "Dapper":
                    repository = new ProveedoresDapperRepository();
                    break;
                default:
                    repository = new ProveedoresRepository(new Context());
                    break;
            }

            return new ProveedoresCacheRepository( repository);


        }

    }
}
