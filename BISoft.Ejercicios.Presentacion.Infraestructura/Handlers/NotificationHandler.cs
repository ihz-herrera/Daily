﻿using BISoft.Ejercicios.Presentacion.Infraestructura.Observador;

namespace BISoft.Ejercicios.Presentacion.Infraestructura.Haddlers
{
    public class NotificationHandler <TEntity> : IPublisher<TEntity>
    {
        private Dictionary<string, List<ISubscriber<TEntity>>> _subscribers = 
            new();
            
        public void AddSubscriber( ISubscriber<TEntity> subscriber, params string[] eventType)
        {
           foreach (var item in eventType)
            {
                if (!_subscribers.ContainsKey(item))
                {
                    _subscribers.Add(item, new List<ISubscriber<TEntity>>());
                }
                _subscribers[item].Add(subscriber);
            }
        }

        public Task Notify( TEntity element, params string[] eventType)
        {
            foreach (var item in eventType)
            {

                if (_subscribers.ContainsKey(item) || _subscribers.ContainsKey("Todos"))
                {
                    foreach (var subscriber in _subscribers[item])
                    {
                        subscriber.Update(element);
                    }
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
