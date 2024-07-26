using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Notificaciones.Builders
{
    public class HttpMessageBuilder
    {
        private string _url;
        private string _data;
        private string _apikey;

        public static HttpMessageBuilder Create()
        {
            return new HttpMessageBuilder();
        }

        public HttpMessageBuilder AddUrl(string url)
        {
            _url = url;
            return this;
        }

        public HttpMessageBuilder AddData(string data)
        {
            _data = data;
            return this;
        }

        public HttpMessageBuilder AddApiKey(string apikey)
        {
            _apikey = apikey;
            return this;
        }

        public HttpRequestMessage Build()
        {
            return new HttpRequestMessage(_url, _data, _apikey);
        }
    }
}
