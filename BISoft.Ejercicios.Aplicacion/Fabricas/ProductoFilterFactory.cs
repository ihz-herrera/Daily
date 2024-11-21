using BISoft.Ejercicios.Aplicacion.Dtos.Parametros;
using BISoft.Ejercicios.Aplicacion.Pipelines;
using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Fabricas
{
    internal static class ProductoFilterFactory
    {

        public static List<IFilterHandler<Producto, ProductoParameters>> CrearFiltros()
        {
            return new List<IFilterHandler<Producto, ProductoParameters>>
            {
                new DescripcionFilterHandler(),
                new PrecioFilterHandler(),
                new CostoFilterHandler(),
                new CategoriaFilterHandler()
            };
        }

        public static List<IFilterHandler<Producto, ProductoParameters>> CrearFiltrosCategoriaProducto()
        {
            return new List<IFilterHandler<Producto, ProductoParameters>>
            {
                new DescripcionFilterHandler(),
                new PrecioFilterHandler(),
                new CostoMenor25000FilterHandler(2500)
            };
        }

    }
}
