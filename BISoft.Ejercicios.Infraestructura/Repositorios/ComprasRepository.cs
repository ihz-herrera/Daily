using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ComprasRepository:Repositorio<Compra>, IComprasRepository
    {
        public ComprasRepository(Context context):base(context)
        {
        }

        public async Task<List<Compra>> ObtenerComprasConDetalle()
        {
            return await _context.Compras
                .Include(x => x.CompraDetalles)
                .ToListAsync();
        }

        public async Task<Compra> ObtenerCompraConDetalle(int id)
        {
            return await _context.Compras
                .Include(x => x.CompraDetalles)
                .FirstOrDefaultAsync(x => x.CompraId == id);
        }

        public IQueryable<ProductoPermitidoCompra> ProductosPermitidosCompras()
        {
             return _context.ProductosPermitidosCompras;
        }
    }
}
