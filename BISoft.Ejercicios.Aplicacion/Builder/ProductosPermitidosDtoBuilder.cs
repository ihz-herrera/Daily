using BISoft.Ejercicios.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Builder
{
    public class ProductosPermitidosDtoBuilder
    {
        private int _productoId;
        private int _sucursalId;
        private string _descripcion;

        public static ProductosPermitidosDtoBuilder Empty()
        {
            return new ProductosPermitidosDtoBuilder();
        }

        public ProductosPermitidosDtoBuilder WithProductoId(int productoId)
        {
            _productoId = productoId;
            return this;
        }

        public ProductosPermitidosDtoBuilder WithSucursalId(int sucursalId)
        {
            _sucursalId = sucursalId;
            return this;
        }

        public ProductosPermitidosDtoBuilder WithDescripcion(string descripcion)
        {
            _descripcion = descripcion;
            return this;
        }

        public ProductoPermitidoDto Build()
        {
            return new ProductoPermitidoDto(_productoId, _sucursalId, _descripcion, false);
        }
    }
}
