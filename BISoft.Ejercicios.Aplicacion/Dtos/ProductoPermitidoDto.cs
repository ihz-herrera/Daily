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
        public string Descripcion { get; set; }
        public bool Status { get; set; }

        internal ProductoPermitidoDto(int productoId, int sucursalId, string descripcion, bool status)
        {
            ProductoId = productoId;
            SucursalId = sucursalId;
            Descripcion = descripcion;
            Status = status;
        }
    }
}
