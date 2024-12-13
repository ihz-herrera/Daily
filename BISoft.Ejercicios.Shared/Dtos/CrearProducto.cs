namespace BISoft.Ejercicios.Shared.Dtos
{
    public class CrearProducto
    {
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public int FabricanteId { get; set; }
        public int CategoriaId { get; set; }

        public CrearProducto(string descripcion, decimal precio, decimal costo, int fabricanteId, int categoriaId)
        {
            Descripcion = descripcion;
            Precio = precio;
            Costo = costo;
            FabricanteId = fabricanteId;
            CategoriaId = categoriaId;
        }
    }
}
