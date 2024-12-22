using System;

namespace BISoft.Ejercicios.Shared.Dtos
{

public class LineaCompra
{
    public int ProductoId { get; private set; }
    public string Descripcion { get; } = string.Empty;
    public int Cantidad { get; private set; }
    public decimal Precio { get; private set; }
    public decimal Descuento { get; private set; }

    public LineaCompra(int productoId, string Descripcion, int cantidad, decimal precio, decimal descuento)
    {
        ProductoId = productoId;
        Descripcion = Descripcion;
        Cantidad = cantidad;
        Precio = precio;
        Descuento = descuento;
    }

        
    }



}
