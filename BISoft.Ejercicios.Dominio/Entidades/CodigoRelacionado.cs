using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Dominio.Entidades
{
    public class CodigoRelacionado
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Status { get; set; }


        //Propiedades de navegacion
        public int ProductoId { get; set; } 
        public virtual Producto Producto { get; set; }
    }
}
