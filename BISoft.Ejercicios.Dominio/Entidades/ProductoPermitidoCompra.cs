using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Dominio.Entidades
{
    public class ProductoPermitidoCompra:Entity
    {
        public int SucursalId { get; set; }
        public int ProductoId { get; set; }

        public ProductoPermitidoCompra()
        {
            
        }
    }
}
