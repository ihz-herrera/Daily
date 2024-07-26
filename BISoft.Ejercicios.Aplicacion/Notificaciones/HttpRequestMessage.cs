using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Notificaciones
{
    public class HttpRequestMessage
    {
        public string Url { get; private set; }
        public string ApiKey { get; private set; }
        public string Data { get; private set; }

        //Constructor
        public HttpRequestMessage(string url, string data, string apiKey)
        {
            Url = url;
            Data = data;
            ApiKey = apiKey;
        }
    }
}
