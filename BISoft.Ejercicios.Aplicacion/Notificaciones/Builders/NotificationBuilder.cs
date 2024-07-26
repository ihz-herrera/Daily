using BISoft.Ejercicios.Dominio.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Notificaciones.Builders
{
    public class NotificationBuilder : ISetEventType, ISetEmail
    {
        private List<OutboxMessage> _messages;
        private string _eventType;

        public NotificationBuilder()
        {
            _messages = new List<OutboxMessage>();
        }

        public static ISetEventType Create()
        {
            return new NotificationBuilder();
        }

        public ISetEmail AddEventType(string eventType)
        {
            _eventType = eventType;
            return this;
        }

        public NotificationBuilder AddEmail(string to, string subject, string data)
        {

            var emailMessage = new EmailMessage(to
                , subject
                , data);

            _messages.Add(new OutboxMessage
            {
                MessageType = "Email",
                EventType = _eventType,
                Payload = JsonConvert.SerializeObject(emailMessage),
                CreatedAt = DateTime.Now
            });
            return this;
        }

        public NotificationBuilder AddWhatsapp(Action<WhatsappMessage> actionBuilder)
        {

            var whatsappMessage = new WhatsappMessage();
            actionBuilder(whatsappMessage);

            _messages.Add(new OutboxMessage
            {
                MessageType = "WhatsApp",
                EventType = _eventType,
                Payload = JsonConvert.SerializeObject(whatsappMessage),
                CreatedAt = DateTime.Now
            });

            return this;
        }

        public NotificationBuilder AddHttpMessage(Action<HttpMessageBuilder> actionBuilder)
        {

            var httpMessageBuilder = new HttpMessageBuilder();
            actionBuilder(httpMessageBuilder);
            
            var httpMessage = httpMessageBuilder.Build();

            _messages.Add(new OutboxMessage
            {
                MessageType = "Http",
                EventType = _eventType,
                Payload = JsonConvert.SerializeObject(httpMessage),
                CreatedAt = DateTime.Now
            });

            return this;
        }

        public IEnumerable<OutboxMessage> Build()
        {
            return _messages;
        }
    }

    public interface ISetEventType
    {
        ISetEmail AddEventType(string eventType);
    }

    public interface ISetEmail
    {
        NotificationBuilder AddEmail(string to, string subject, string data);
    }
}
