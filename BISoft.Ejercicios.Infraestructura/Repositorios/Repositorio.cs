using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public abstract class Repositorio<TEntity>:IRepository<TEntity>  where TEntity : Entity 
    {
        protected readonly Context _context;

        public Repositorio(Context context)
        {
            _context = context;

        }

        public virtual List<TEntity> ObtenerTodos()
        {
            return _context.Set<TEntity>()
                .AsNoTracking().ToList();
        }

        public TEntity ObtenerPorExpresion(Expression<Func<TEntity,bool>> exp)
        {
            Task.Delay(4000).Wait();

            return _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(exp);
        }

        public virtual void Crear(TEntity entidad)
        {
            _context.Set<TEntity>().Add(entidad);
            _context.SaveChanges();
        }

        public void Actualizar(TEntity entidad)
        {
            _context.Set<TEntity>().Update(entidad);
            _context.SaveChanges();
        }

        //public void EliminarProducto(int id)
        //{
        //    var producto = _context.Productos.FirstOrDefault(x => x.ProductoId == id);
        //    _context.Productos.Remove(producto);
        //    _context.SaveChanges();
        //}
    }
}
