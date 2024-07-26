using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Notificaciones
{
    public class WhatsappMessage
    {
        public string PhoneNumber { get;  set; }
        public string Data { get;  set; }

        public WhatsappMessage()
        {
            
        }

        //Constructor
        public WhatsappMessage(string phoneNumber, string data)
        {
            PhoneNumber = phoneNumber;
            Data = data;
        }
    }
}
