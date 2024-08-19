using System;
using System.Collections.Generic;

namespace BISoft.Ejercicios.Dominio.Entidades
{
    public partial class Compra
    {
        public int ComprasId { get; set; }
        public int Proveedor { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
