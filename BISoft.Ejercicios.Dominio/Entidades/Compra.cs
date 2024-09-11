using System;
using System.Collections.Generic;

namespace BISoft.Ejercicios.Dominio.Entidades
{
    public partial class Compra : Entity
    {
        public int CompraId { get; set; }
        public int Proveedor { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<CompraDetalle> CompraDetalles { get; set; } = new HashSet<CompraDetalle>();
    }
}
