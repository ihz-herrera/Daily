using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Dominio.Entidades
{
    public class CompraDetalle : Entity
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        //Propiedades de Navegacion
        public virtual Compra Compra { get; set; }

        
    }


}
