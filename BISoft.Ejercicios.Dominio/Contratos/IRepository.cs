using BISoft.Ejercicios.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Contratos
{
    public interface IRepository <T> where T : Entity
    {
        Task Actualizar(T entidad);
        Task Crear(T entidad);
        Task<List<T>> ObtenerTodos();


        Task<T> ObtenerPorExpresion(Expression<Func<T, bool>> expresion);

        IQueryable<T> GetCollectionByExp (Expression<Func<T, bool>> expresion);

        IQueryable<T> GetCollection ();
    }
}
