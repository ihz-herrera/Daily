using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BISoft.Ejercicios.Dominio.Builders
{
    public class ProductoBuilder
    {

        private int id;
        private string descripcion;
        private decimal precio;
        private decimal costo;
        private bool status;
        private int categoriaId;
        private int fabricanteId;

        public static ProductoBuilder Empty => new ProductoBuilder();

        public ProductoBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }

        public ProductoBuilder WithDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
            return this;
        }

        public ProductoBuilder WithPrecio(decimal precio)
        {
            this.precio = precio;
            return this;
        }

        public ProductoBuilder WithCosto(decimal costo)
        {
            this.costo = costo;
            return this;
        }

        public ProductoBuilder WithStatus(bool status)
        {
            this.status = status;
            return this;
        }

        public ProductoBuilder WithCategoriaId(int categoriaId)
        {
            this.categoriaId = categoriaId;
            return this;
        }


        public ProductoBuilder WithFabricanteId(int fabricanteId)
        {
            this.fabricanteId = fabricanteId; 
            return this;
        }



        public Producto Build()
        {
            if (costo > precio)
                throw new ArgumentException("El costo no puede ser mayor al precio");

            return new Producto(id, descripcion, precio, costo, status);
        }

    }
}
