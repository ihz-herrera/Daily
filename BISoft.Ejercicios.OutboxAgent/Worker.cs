using BISoft.Ejercicios.Aplicacion.Notificaciones;
using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BISoft.Ejercicios.OutboxAgent
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var outboxRepository = new OutboxRepository(new Context());

                var exp = outboxRepository
                    .GetCollectionByExp(x => x.IsProcessed == false);

                var messages = await exp
                     .ToListAsync();


                foreach (var message in messages)
                {
                    //Enviar mensaje
                    switch (message.MessageType)
                    {
                        case "Email":
                            //Enviar por email
                            var emailService = new EmailService();

                            var emailMessage = JsonConvert.DeserializeObject<EmailMessage>(message.Payload);

                            await emailService.SendEmail(emailMessage.To
                                ,emailMessage.Subject
                                ,emailMessage.Data);
                          

                            break;
                        case "WhatsApp":
                            //Enviar por WhatsApp
                            break;
                        default:
                            break;

                        
                    }

                    message.IsProcessed = true;
                    await outboxRepository.Actualizar(message);
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10, stoppingToken);
            }
        }
    }
}
