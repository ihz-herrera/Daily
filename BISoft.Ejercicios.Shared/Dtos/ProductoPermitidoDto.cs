using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Shared.Dtos
{
    public class ProductoPermitidoDto
    {
        public int ProductoId { get; private set; }
        public int SucursalId { get; private set; }
        public string Descripcion { get; private set; }
        public decimal Precio { get; private set; }

        public bool Validado { get; private set; }

        internal ProductoPermitidoDto(int productoId, int sucursalId, string descripcion,decimal precio, bool validado)
        {
            ProductoId = productoId;
            SucursalId = sucursalId;
            Descripcion = descripcion;
            Precio = precio;
            Validado = validado;
        }

        public ProductoPermitidoDto(int productoId, int sucursalId, decimal precio, string descripcion)
        {
            ProductoId = productoId;
            SucursalId = sucursalId;
            Descripcion = descripcion;
            Validado = false;
            Precio = precio;
        }
    }
}
