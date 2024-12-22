using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Shared.Dtos
{
    public class CompraDto
    {
        [Obsolete("Propiedad Obsoleta, se eliminará en versiones posteriores",false)]
        public int ProductoId { get; private set; }
        public int SucursalId { get; private set; }
         
        public List<ProductoPermitidoDto> productoPermitidoDtos { get; set; }

        [Obsolete("Parametro Producto Id obsoleto, utilizar constructor CompraDto(productoId, int sucursalId)", false)]
        public CompraDto(int productoId, int sucursalId)
        {
            ProductoId = productoId;
            SucursalId = sucursalId;
            productoPermitidoDtos= new List<ProductoPermitidoDto>();
        
        }

        public CompraDto(int sucursalId)
        {
            SucursalId = sucursalId;
            productoPermitidoDtos = new List<ProductoPermitidoDto>();

        }
    }
}
