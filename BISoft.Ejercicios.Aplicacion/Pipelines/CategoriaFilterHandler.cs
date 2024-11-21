using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Pipelines
{
    internal class CategoriaFilterHandler : IFilterHandler<Producto,ProductoParameters>
    {
        public IQueryable<Producto> Handle(IQueryable<Producto> source, ProductoParameters parameters)
        {
            if (parameters.CategoriaId > 0)
            {
                source = source.Where(p => p.CategoriaId == parameters.CategoriaId);
            }

            return source;
        }
    }
}
