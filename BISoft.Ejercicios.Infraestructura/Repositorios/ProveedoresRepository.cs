using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresRepository : IProveedoresRepository
    {

         private readonly Context _contexto;


        public ProveedoresRepository(Context contexto)
        {
            _contexto = contexto;

        }

        public virtual List<Proveedor> ObtenerProveedores()
        {
            return _contexto.Proveedores.AsNoTracking().ToList();
        }

        public Proveedor ObtenerProveedorPorId(int id)
        {
            
           Task.Delay(4000).Wait();

            return _contexto.Proveedores
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public virtual void CrearProveedor(Proveedor proveedor)
        {
            _contexto.Proveedores.Add(proveedor);
            _contexto.SaveChanges();
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            _contexto.Proveedores.Update(proveedor);
            _contexto.SaveChanges();
        }

        public void EliminarProveedor(int id)
        {
            var proveedor = _contexto.Proveedores.FirstOrDefault(x => x.Id == id);
            _contexto.Proveedores.Remove(proveedor);
            _contexto.SaveChanges();
        }
    }
}
