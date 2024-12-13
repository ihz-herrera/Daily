using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Shared.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        //public string Password { get; set; }
        public int EmpresaId { get; set; }
    }
}
