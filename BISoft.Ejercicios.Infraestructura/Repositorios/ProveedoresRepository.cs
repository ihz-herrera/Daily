using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresRepository : Repositorio<Proveedor>, IProveedoresRepository
    {

        public ProveedoresRepository(Context contexto):base(contexto)
        {
        }

        public Proveedor ObtenerProveedorPorId(int id)
        {
            
           return ObtenerPorExpresion(x => x.Id == id);
        }

       
     
        public void EliminarProveedor(int id)
        {
            var proveedor = _context.Proveedores.FirstOrDefault(x => x.Id == id);
            _context.Proveedores.Remove(proveedor);
            _context.SaveChanges();
        }
    }
}
