namespace BISoft.Ejercicios.Presentacion.Infraestructura.Observador

{
    public interface ISubscriber<T>
    {
        Task Update(T element);
    }
}
