using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Dominio.Observador
{
    public interface IPublisher<T>
    {
        void AddSubscriber(  ISubscriber<T> subscriber,params string[] eventType);
        void RemoveSubscriber(string eventType, ISubscriber<T> subscriber);
        Task Notify(T element,params string[] eventType);
    }
}
