using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Shared.Dtos
{
    public class SucursalDto
    {
        public short Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;

        public SucursalDto(short id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override bool Equals(object obj)
        {
            //sobreescribir equal para comparar objetos como record
            return obj is SucursalDto dto &&
                   Id == dto.Id &&
                   Nombre == dto.Nombre;
        }

        //sobrescribir operador == para comparar objetos como record
        public static bool operator ==(SucursalDto left, SucursalDto right)
        {
            return EqualityComparer<SucursalDto>.Default.Equals(left, right);
        }

        public static bool operator !=(SucursalDto left, SucursalDto right)
        {
            return !(left == right);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id, Nombre);
        }
    }


  
}
