using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Dominio.Contratos
{
    public interface IOutboxRepository:IRepository<OutboxMessage>
    {

        Task Crear(IEnumerable<OutboxMessage> outboxMessages);
    }
}
