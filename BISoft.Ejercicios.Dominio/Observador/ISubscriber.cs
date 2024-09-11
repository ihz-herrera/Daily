using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Dominio.Observador
{
    public interface ISubscriber<T>
    {
        Task Update(T element);
    }
}
