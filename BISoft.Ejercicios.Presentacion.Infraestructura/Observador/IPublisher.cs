namespace BISoft.Ejercicios.Presentacion.Infraestructura.Observador
{
    public interface IPublisher<T>
    {
        void AddSubscriber(  ISubscriber<T> subscriber,params string[] eventType);
        void RemoveSubscriber(string eventType, ISubscriber<T> subscriber);
        Task Notify(T element,params string[] eventType);
    }
}
