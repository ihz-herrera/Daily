using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Dominio.Observador
{
    public interface IPublisher<T>
    {
        void AddSubscriber( string eventType, ISubscriber<T> subscriber);
        void RemoveSubscriber(string eventType, ISubscriber<T> subscriber);
        Task Notify(string eventType, T element);
    }
}
