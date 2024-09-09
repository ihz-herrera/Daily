using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Test.Fabricas
{
    public static class CategoriaFactory
    {
        public static Categoria CategoriaValidaActiva=> new() 
        {
            CategoriaId = 1,
            Descripcion = "Categoria 1",
            Nombre = "Categoria 1",
            Activo = true
        };

    }
}
