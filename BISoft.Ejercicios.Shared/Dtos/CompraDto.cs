using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Shared.Dtos
{
    public class CompraDto
    {
        public int ProductoId { get; private set; }
        public int SucursalId { get; private set; }
         
        public List<ProductoPermitidoDto> productoPermitidoDtos { get; set; }

        public CompraDto(int productoId, int sucursalId)
        {
            ProductoId = productoId;
            SucursalId = sucursalId;
            productoPermitidoDtos= new List<ProductoPermitidoDto>();
        
        }
    }
}
