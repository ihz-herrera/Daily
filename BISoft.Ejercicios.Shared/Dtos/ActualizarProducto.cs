using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Shared.Dtos
{
    public class ActualizarProducto
    {
        public string Descripcion { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Costo { get; private set; }

        public ActualizarProducto(string descripcion, decimal precio, decimal costo)
        {
            Descripcion = descripcion;
            Precio = precio;
            Costo = costo;
        }
    }
}
