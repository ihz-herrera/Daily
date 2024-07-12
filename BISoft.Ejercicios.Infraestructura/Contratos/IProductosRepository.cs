using BISoft.Ejercicios.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Contratos
{
    public interface IProductosRepository : IRepository<Producto>
    {

        void EliminarProducto(int id);
    }
}
