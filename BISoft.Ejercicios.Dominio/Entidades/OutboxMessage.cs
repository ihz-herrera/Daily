using BISoft.Ejercicios.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Dominio.Entidades
{
    public class OutboxMessage:Entity
    {
        public Guid Id { get; set; }
        public string EventType { get; set; }
        public string MessageType { get; set; }
        public string Payload { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public bool IsProcessed { get; set; }
        public int RetryCount { get; set; }
        public string? FailureReason { get; set; }
    }
}
