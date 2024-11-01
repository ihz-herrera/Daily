using BISoft.Ejercicios.Aplicacion.Dtos;

namespace BISoft.Ejercicios.Aplicacion.Fachadas
{
    public class CompraFacade:IObservable<CompraFacade>,IDisposable
    {

        private readonly List<IObserver<CompraFacade>> _observers = 
            new List<IObserver<CompraFacade>>();


        public IReadOnlyCollection<LineaCompra> Lineas => InternalLineas.AsReadOnly();
        private List<LineaCompra> InternalLineas { get; set; } = new();

        public int Articulos => InternalLineas.Sum(_ => _.Cantidad);
        public decimal SubTotal => InternalLineas.Sum(x => x.Cantidad * x.Precio);


        public void AgregarLinea(ProductoPermitidoDto producto)
        {


            if(producto.SucursalId != 2)
            {
                OnError(new Exception ("No de pueden agregar productos de diferente sucursal. La sucursal deberia ser 1"));
                return;
            }

            var productoBuscado = InternalLineas.FirstOrDefault(x => x.ProductoId == producto.ProductoId);
            if (productoBuscado != null)
            {
                InternalLineas.Remove(productoBuscado); 
                InternalLineas.Add( productoBuscado with { Cantidad= productoBuscado.Cantidad+1} );
        
            }
            else
            {
                var lineaCompra = new LineaCompra(producto.ProductoId, producto.Descripcion,1,producto.Precio,0 );
                InternalLineas.Add(lineaCompra);
            }
           // Lineas.Add(linea);

            Notify();

            

        }

        private void OnError(Exception exception)
        {
            foreach (var observer in _observers)
            {
                observer.OnError(exception);
            }
        }

        /// <summary>
        /// Notificar cambios a los observadores
        /// </summary>
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(this);
            }
        }

        public IDisposable Subscribe(IObserver<CompraFacade> observer)
        {
            _observers.Add(observer);
            return new Unsubscriber<CompraFacade>(_observers, observer);
        }

        public void EliminarLinea(ProductoPermitidoDto producto)
        {
            var productoBuscado = InternalLineas.FirstOrDefault(x => x.ProductoId == producto.ProductoId);

            if (productoBuscado != null)
            {
                if (productoBuscado.Cantidad > 1)
                {
                    InternalLineas.Remove(productoBuscado);
                    InternalLineas.Add(productoBuscado with { Cantidad = productoBuscado.Cantidad - 1 });
                }
                else
                {
                    InternalLineas.Remove(productoBuscado);
                }

                Notify();
            }
        }

        public void Dispose()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
        }

        private class Unsubscriber<CompraFacade> : IDisposable
        {
            private List<IObserver<CompraFacade>> _observers;
            private IObserver<CompraFacade> _observer;

            public Unsubscriber(List<IObserver<CompraFacade>> observers, IObserver<CompraFacade> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }




    }

   
}
