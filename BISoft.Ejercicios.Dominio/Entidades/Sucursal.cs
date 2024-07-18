using BISoft.Ejercicios.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Dominio.Entidades
{
    public class Sucursal:Entity
    {

        public short Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
