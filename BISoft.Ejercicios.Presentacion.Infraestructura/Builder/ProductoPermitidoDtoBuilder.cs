using BISoft.Ejercicios.Shared.Dtos;

namespace BISoft.Ejercicios.Presentacion.Infraestructura.Builder
{
    public class ProductoPermitidoDtoBuilder
    {
        private int _productoId;
        private int _sucursalId;
        private string _descripcion;
        private decimal _precio;

        public static ProductoPermitidoDtoBuilder Empty()
        {
            return new ProductoPermitidoDtoBuilder();
        }

        public ProductoPermitidoDtoBuilder WithProductoId(int productoId)
        {
            _productoId = productoId;
            return this;
        }

        public ProductoPermitidoDtoBuilder WithSucursalId(int sucursalId)
        {
            _sucursalId = sucursalId;
            return this;
        }

        public ProductoPermitidoDtoBuilder WithDescripcion(string descripcion)
        {
            _descripcion = descripcion;
            return this;
        }

        public ProductoPermitidoDtoBuilder WithPrecio(decimal precio)
        {
            _precio = precio;
            return this;
        }

        public ProductoPermitidoDto Build()
        {
            return new ProductoPermitidoDto(_productoId, _sucursalId, _descripcion,_precio);
        }
    }
}
