using Dawn;
using System;
using System.Collections.Generic;

namespace BISoft.Ejercicios.Infraestructura.Entidades
{
    public partial class Producto:Entity
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public bool Status { get; set; }

       

        //crear constructor
        public Producto(int productoId, string descripcion, decimal precio, decimal costo, bool status)
        {
            ProductoId = productoId;

            Descripcion = Guard.Argument(descripcion, "Descripción")
                .NotEmpty().MaxLength(50).MinLength(8);

            Precio = Guard.Argument(precio, nameof(precio))
                .Positive(m=> "El valor debe ser mayor a cero");

            Costo = Guard.Argument(costo,"Costo")
                .Positive(m => "El valor debe ser mayor a cero");

            Status = status;
        }
    }
}
