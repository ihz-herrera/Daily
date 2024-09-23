using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Dtos
{
    public class ProductoPermitidoDto
    {
        public int ProductoId { get; private set; }
        public int SucursalId { get; private set; }
        public string Descripcion { get; private set; }
        public bool Validado { get; private set; }

        internal ProductoPermitidoDto(int productoId, int sucursalId, string descripcion, bool validado)
        {
            ProductoId = productoId;
            SucursalId = sucursalId;
            Descripcion = descripcion;
            Validado = validado;
        }

        public ProductoPermitidoDto(int productoId, int sucursalId, string descripcion)
        {
            ProductoId = productoId;
            SucursalId = sucursalId;
            Descripcion = descripcion;
            Validado = false;
        }
    }
}
