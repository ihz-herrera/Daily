using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Contextos
{
    class Context
    {
        public Context(DbContextOptions<Context> options):base(options)
		{
		}
        public Context()
        {
            
        }

    }
}
