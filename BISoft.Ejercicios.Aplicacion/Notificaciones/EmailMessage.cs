using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Notificaciones
{
    public class EmailMessage
    {
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Data { get; private set; }

        //public List<string> Documenents { get; private set; }

        //Constructor   
        public EmailMessage(string to, string subject, string data)
        {
            To = to;
            Subject = subject;
            Data = data;
        }




    }

   
}
