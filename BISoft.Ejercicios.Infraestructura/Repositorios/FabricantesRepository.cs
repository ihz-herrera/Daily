using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class FabricantesRepository : Repositorio<Fabricante>, IFabricantesRepository
    {
        public FabricantesRepository(Context context) : base(context)
        {
        }
    }
}
