using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Dtos
{
    public class ProductoDto
    {

        //Dto con propiedades de solo lectura de la entidad producto
        public int ProductoId { get; private set; }
        public string Descripcion { get; private set; } = null!;
        public decimal Precio { get; private set; }
        public decimal Costo { get; private set; }
        public bool Status { get; private set; } = true;


        public string Catetoria { get; private set; }
        public string Fabricante { get; private set; }

  
        //constructor
        public ProductoDto(int productoId, string descripcion, decimal precio, decimal costo, bool status, string categoria, string fabricante)
        {
            ProductoId = productoId;
            Descripcion = descripcion;
            Precio = precio;
            Costo = costo;
            Status = status;
            Catetoria = categoria;
            Fabricante = fabricante;
        }
    }
}
