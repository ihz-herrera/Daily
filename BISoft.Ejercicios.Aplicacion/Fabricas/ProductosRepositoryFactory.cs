using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;

namespace BISoft.Ejercicios.Aplicacion.Fabricas
{
    public class ProductosRepositoryFactory
    {
        public static IProductosRepository CrearProductosRepository(string repoType)
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
