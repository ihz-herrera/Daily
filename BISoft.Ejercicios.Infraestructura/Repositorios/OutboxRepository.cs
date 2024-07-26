using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class OutboxRepository:Repositorio<OutboxMessage>, IOutboxRepository
    {
        public OutboxRepository(Context context):base(context)
        {

        }

        public async Task Crear(IEnumerable<OutboxMessage> outboxMessages)
        {
            await _context.AddRangeAsync(outboxMessages);
            await _context.SaveChangesAsync();
        }
    }
}
