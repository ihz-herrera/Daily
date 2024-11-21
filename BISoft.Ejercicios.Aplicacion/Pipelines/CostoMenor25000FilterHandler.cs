using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Pipelines
{
    internal class CostoMenor25000FilterHandler:IFilterHandler<Producto, ProductoParameters>
    {
        private readonly decimal costo;
        public CostoMenor25000FilterHandler(decimal costo)
        {
            this.costo = costo;
        }

        public IQueryable<Producto> Handle(IQueryable<Producto> source, ProductoParameters filter)
        {
            if (filter.Costo > 0 && filter.Costo<costo)
            {
                source = source.Where(p => p.Costo == filter.Costo);
            }

            return source;
        }
    }

}
