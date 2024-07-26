using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class FacturacionService
    {

        private readonly EmailService _emailService;

        public FacturacionService(EmailService emailService)
        {
            _emailService = emailService;
        }

        public Task EnviarFactura(string email, string factura)
        {
            // Aquí se enviaría la factura por email
            _emailService.SendEmail (email, "Factura", factura);
            return Task.CompletedTask;
        }
    }
}
