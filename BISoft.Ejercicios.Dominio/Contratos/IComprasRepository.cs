using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Dominio.Contratos
{
    public interface IComprasRepository : IRepository<Compra>
    {
        Task<List<Compra>> ObtenerComprasConDetalle();

        Task<Compra> ObtenerCompraConDetalle(int id);

        IQueryable<ProductoPermitidoCompra> ProductosPermitidosCompras();

    }

}
