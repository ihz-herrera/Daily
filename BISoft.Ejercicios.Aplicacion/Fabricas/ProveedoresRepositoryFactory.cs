using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;

namespace BISoft.Ejercicios.Aplicacion.Fabricas
{
    public class ProveedoresRepositoryFactory
    {

        public static IProveedoresRepository CrearProveedoresRepository(string repoType)
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
