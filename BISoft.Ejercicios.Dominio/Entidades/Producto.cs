using Dawn;
using System;
using System.Collections.Generic;

namespace BISoft.Ejercicios.Dominio.Entidades
{
    public partial class Producto:Entity
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal Costo { get;  private set ; }
        public bool Status { get; set; } = true;


        public int FabricanteId { get; set; }
        public int CategoriaId { get; set; }

       
        //Propiedades de navegacion
        public virtual List<CodigoRelacionado> CodigosRelacionados { get; set; } 
            = new List<CodigoRelacionado>();


        //crear constructor
        internal Producto(int productoId, string descripcion, decimal precio, decimal costo, bool status,int categoriaId, int fabricanteId)
        {
            ProductoId = productoId;

            Descripcion = Guard.Argument(descripcion, "Descripción")
                .NotEmpty().MaxLength(50);

            Precio = Guard.Argument(precio, nameof(precio))
                .Positive(m=> "El valor debe ser mayor a cero");

            Costo = Guard.Argument(costo,"Costo")
                .Positive(m => "El valor debe ser mayor a cero");

            Status = status;

            CategoriaId =  Guard.Argument( categoriaId,"ID Categoría").Positive();
            FabricanteId = Guard.Argument(fabricanteId, "ID Fabricante").Positive(); ;
        }

        public void SetCosto(decimal costo)
        {
            Costo = Guard.Argument(costo, "Costo")
                .Positive(m => "El valor debe ser mayor a cero");

            if (Costo > Precio)
                throw new ArgumentException("El costo no puede ser mayor al precio");
        }
    }
}
