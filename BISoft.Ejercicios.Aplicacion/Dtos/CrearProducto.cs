namespace BISoft.Ejercicios.Aplicacion.Dtos
{
    public record CrearProducto(string Descripcion, decimal Precio, decimal Costo, 
        int FabricanteId, int CategoriaId);
}
