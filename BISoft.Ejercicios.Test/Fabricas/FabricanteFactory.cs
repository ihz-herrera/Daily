using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Test.Fabricas
{
    public static class FabricanteFactory
    {
        public static Fabricante CrearFabricanteValidoActivo() => new Fabricante
            {
                FabricanteId = 1,
                Descripcion = "Fabricante 1",
                Nombre = "Fabricante 1",
                Activo = true
            };
        
    }
}
