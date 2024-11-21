using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Pipelines
{
    internal interface IFilterHandler <TSource,TParameters>
    {
        IQueryable<TSource> Handle(IQueryable<TSource> source, TParameters filter);
    }
}
