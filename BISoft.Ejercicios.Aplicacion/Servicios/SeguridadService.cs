using BISoft.Ejercicios.Aplicacion.Dtos;
using BISoft.Ejercicios.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class SeguridadService
    {

        public async Task<UsuarioDto> ObtenerUsuario(string usuario, string password)
        {
            //Buscar en la base de datos usuario

            //Encripto el password

            //Comparo el password encriptado con el de la base de datos

            if(usuario == "admin" && password == "admin")
            {
                return new UsuarioDto
                {
                    Id = 1,
                    Usuario = "admin",
                    EmpresaId = 1
                };

            }
            else
            {
                return null;
            }


        }
    }
}
