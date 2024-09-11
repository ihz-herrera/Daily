using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresRepository : Repositorio<Proveedor>, IProveedoresRepository
    {

        public ProveedoresRepository(Context contexto):base(contexto)
        {
        }

        public async Task<Proveedor> ObtenerProveedorPorId(int id)
        {
            
           return await ObtenerPorExpresion(x => x.Id == id);
        }

       
     
        public void EliminarProveedor(int id)
        {
            var proveedor = _context.Proveedores.FirstOrDefault(x => x.Id == id);
            _context.Proveedores.Remove(proveedor);
            _context.SaveChanges();
        }
    }
}
