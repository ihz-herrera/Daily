using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class HttpService
    {

        public async Task SendRequest(string url)
        {
            // Aquí iría la lógica para enviar el email
            await Task.Delay(2000);
        }
    }
}
