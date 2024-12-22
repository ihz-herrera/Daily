using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Shared.Dtos
{
    public class CategoriaDto
    {
        public int CategoriaId { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public bool Activo { get; private set; }

        public CategoriaDto(int categoriaId, string nombre, string descripcion, bool activo)
        {
            CategoriaId = categoriaId;
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
        }
    }
}
