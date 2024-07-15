﻿using BISoft.Ejercicios.Infraestructura.Contextos;
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

        public async virtual Task<List<TEntity>> ObtenerTodos()
        {
            await Task.Delay(8000);

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

        //public void EliminarProducto(int id)
        //{
        //    var producto = _context.Productos.FirstOrDefault(x => x.ProductoId == id);
        //    _context.Productos.Remove(producto);
        //    _context.SaveChanges();
        //}
    }
}
