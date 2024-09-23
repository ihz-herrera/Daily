using BISoft.Ejercicios.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Builder
{
    public class ProductoPermitidoDtoBuilder
    {
        private int _productoId;
        private int _sucursalId;
        private string _descripcion;

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

        public ProductoPermitidoDto Build()
        {
            return new ProductoPermitidoDto(_productoId, _sucursalId, _descripcion, false);
        }
    }
}
