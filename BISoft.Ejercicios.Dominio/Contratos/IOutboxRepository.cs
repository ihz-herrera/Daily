using BISoft.Ejercicios.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Dominio.Contratos
{
    public interface IOutboxRepository:IRepository<OutboxMessage>
    {

        Task Crear(IEnumerable<OutboxMessage> outboxMessages);
    }
}
