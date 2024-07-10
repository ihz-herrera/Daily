using Dawn;
using System;
using System.Collections.Generic;

namespace BISoft.Ejercicios.Infraestructura.Entidades
{
    public partial class Producto
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
            Precio = Guard.Argument(precio, nameof(precio)).Positive().NotZero();
            Costo = Guard.Argument(costo,"Costo").Positive();
            Status = status;
        }
    }
}
