using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Shared.Dtos
{
    public class FabricanteDto
    {
        public int FabricanteId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public FabricanteDto(int fabricanteId, string nombre, string descripcion, bool activo)
        {
            FabricanteId = fabricanteId;
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
        }
    }
}
