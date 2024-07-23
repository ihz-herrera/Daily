using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class EmailService
    {


        public async Task SendEmail(string emailTo, string subject, string message)
        {
            // Aquí iría la lógica para enviar el email
            await Task.Delay(2000);

            //Enviar Email
            // Configuración del servidor SMTP
            string smtpAddress = "127.0.0.1"; // Ejemplo: smtp.gmail.com
            int portNumber = 27; // Puerto del servidor SMTP
            bool enableSSL = false;

            // Credenciales de la cuenta de correo
            string emailFrom = "tuemail@dominio.com";
            string password = "tucontraseña";
            string body = "Cuerpo del correo";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true; // Si el cuerpo del correo es HTML

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;

                    try
                    {
                        smtp.Send(mail);
                        Console.WriteLine("Correo enviado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al enviar el correo: " + ex.Message);
                    }
                }
            }
        }
    }
}
