using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Entidades
{
    public class Proveedor: Entity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
   
    }
}
