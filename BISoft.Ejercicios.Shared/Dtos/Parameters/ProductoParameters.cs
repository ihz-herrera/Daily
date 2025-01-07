using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Dtos.Parametros
{
    public class ProductoParameters : PaginationParameters
    {
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public int CategoriaId { get; set; }
        public int FabricanteId { get; set; }
    }
}
