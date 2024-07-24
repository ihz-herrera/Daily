using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;

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

                var messages = await outboxRepository.ObtenerTodos();
                var mensajesSinProcesar = messages
                        .Where(x => x.IsProcessed == false)
                        .ToList();    

                foreach (var message in mensajesSinProcesar)
                {
                    //Enviar mensaje
                    switch (message.MessageType)
                    {
                        case "Email":
                            //Enviar por email
                            //var emailService = new EmailService();
                            //emailService.SendEmail(message.Payload);
                          

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
