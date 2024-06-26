using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresStoredRepository:ProveedoresRepository
    {

        private readonly Context _context;

        public ProveedoresStoredRepository(Context context):base(context)
        {
            _context = context;
        }

        public override List<Proveedor> ObtenerProveedores()
        {
            var result= _context.Proveedores
                .FromSqlRaw("SELECT * FROM Proveedores")
                .ToList();
            return result;
        }

       

        public override void CrearProveedor(Proveedor proveedor)
        {
            _context.Database.ExecuteSqlRaw("EXEC CrearProveedor @Id={0}, @Nombre={1}, @Direccion={2}"
                , proveedor.Id, proveedor.Nombre, proveedor.Direccion);
        }

      
    }
}
