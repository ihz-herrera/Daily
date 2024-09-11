using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Dominio.Observador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Haddlers
{
    public class NotificationHandler <TEntity> : IPublisher<TEntity>
    {
        private Dictionary<string, List<ISubscriber<TEntity>>> _subscribers = 
            new();
            
        public void AddSubscriber(string eventType, ISubscriber<TEntity> subscriber)
        {
            if (!_subscribers.ContainsKey(eventType))
            {
                _subscribers.Add(eventType, new List<ISubscriber<TEntity>>());

            }

            _subscribers[eventType].Add(subscriber);
        }

        public Task Notify(string eventType, TEntity element)
        {
            if (_subscribers.ContainsKey(eventType) || _subscribers.ContainsKey("Todos"))
            {
                foreach (var subscriber in _subscribers[eventType])
                {
                    subscriber.Update(element);
                }
            }
            return Task.CompletedTask;
        }

        public void RemoveSubscriber(string eventType, ISubscriber<TEntity> subscriber)
        {
            if (_subscribers.ContainsKey(eventType))
            {
                _subscribers[eventType].Remove(subscriber);
            }
        }
    }
}
