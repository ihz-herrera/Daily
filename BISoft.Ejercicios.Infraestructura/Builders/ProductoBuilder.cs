using BISoft.Ejercicios.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Builders
{
    public class ProductoBuilder
    {
        private int _productoId;
        private string _descripcion;
        private decimal _precio;
        private decimal _costo;
        private bool _status;

        public ProductoBuilder ConId(int productoId)
        {
            _productoId = productoId;
            return this;
        }

        public ProductoBuilder ConDescripcion(string descripcion)
        {
            _descripcion = descripcion;
            return this;
        }

        public ProductoBuilder ConPrecio(decimal precio)
        {
            _precio = precio;
            return this;
        }

        public ProductoBuilder ConCosto(decimal costo)
        {
            _costo = costo;
            return this;
        }

        public ProductoBuilder ConStatus(bool status)
        {
            _status = status;
            return this;
        }

        public Producto Build()
        {
            return new Producto(_productoId, _descripcion, _precio, _costo, _status);
        }
    }
}
