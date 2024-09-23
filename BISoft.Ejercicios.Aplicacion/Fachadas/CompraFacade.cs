using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Fachadas
{
    public class CompraFacade:IObservable<CompraFacade>
    {

        public IReadOnlyCollection<LineaCompra> Lineas => InternalLineas.AsReadOnly();
        private List<LineaCompra> InternalLineas { get; set; } = new();

        public int Articulos => InternalLineas.Count;
        public decimal SubTotal => InternalLineas.Sum(x => x.Cantidad * x.Precio);


        public void AgregarLinea(ProductoDto producto)
        {

            var productoBuscado = InternalLineas.FirstOrDefault(x => x.ProductoId == producto.ProductoId);
            if (productoBuscado != null)
            {
                productoBuscado = productoBuscado with { Cantidad= productoBuscado.Cantidad+1} ;
                return;
            }
            else
            {
                var lineaCompra = new LineaCompra(producto.ProductoId, producto.Descripcion,1,producto.Precio,0 );
                InternalLineas.Add(lineaCompra);
            }
           // Lineas.Add(linea);

        }

        public IDisposable Subscribe(IObserver<CompraFacade> observer)
        {
            throw new NotImplementedException();
        }
    }

   
}
