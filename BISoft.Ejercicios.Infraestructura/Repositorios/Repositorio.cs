using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public abstract class Repositorio<TEntity>:IRepository<TEntity>  where TEntity : Entity 
    {
        protected readonly Context _context;

        public Repositorio(Context context)
        {
            _context = context;

        }

        [Obsolete ("Función descontinuada, usar GetCollectionByExp en su lugar")]
        public async virtual Task<List<TEntity>> ObtenerTodos()
        {
            //await Task.Delay(8000);

            return await _context.Set<TEntity>()
                .AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> ObtenerPorExpresion(Expression<Func<TEntity,bool>> exp)
        {
            await Task.Delay(4000);

            var resultado = await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(exp);

            return resultado!;
        }

        public async virtual Task Crear(TEntity entidad)
        {
            await _context.Set<TEntity>().AddAsync(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(TEntity entidad)
        {
            _context.Set<TEntity>().Update(entidad);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetCollectionByExp(Expression<Func<TEntity, bool>> expresion)
        {
            return _context.Set<TEntity>().Where(expresion);
        }

        public IQueryable<TEntity> GetCollection()
        {
            return _context.Set<TEntity>();
        }

        //public void EliminarProducto(int id)
        //{
        //    var producto = _context.Productos.FirstOrDefault(x => x.ProductoId == id);
        //    _context.Productos.Remove(producto);
        //    _context.SaveChanges();
        //}
    }
}
