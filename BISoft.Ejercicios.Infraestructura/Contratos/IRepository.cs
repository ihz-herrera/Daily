using BISoft.Ejercicios.Infraestructura.Entidades;
using System.Linq.Expressions;

namespace BISoft.Ejercicios.Infraestructura.Contratos
{
    public interface IRepository <T> where T : Entity
    {
        void Actualizar(T entidad);
        void Crear(T entidad);
        List<T> ObtenerTodos();

        T ObtenerPorExpresion(Expression<Func<T, bool>> expresion);
    }
}
