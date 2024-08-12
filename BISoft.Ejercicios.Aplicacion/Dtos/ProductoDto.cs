using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Dtos
{
    public class ProductoDto
    {
        public Producto Producto { get; set; }
        public Categoria Categoria { get; set; }

        public Fabricante Fabricante { get; set; }
    }
}
