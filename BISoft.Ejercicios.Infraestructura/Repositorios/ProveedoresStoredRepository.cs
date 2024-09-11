using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresStoredRepository:ProveedoresRepository 
    {

        private readonly Context _context;

        public ProveedoresStoredRepository(Context context):base(context)
        {
            _context = context;
        }

        public async override Task<List<Proveedor>> ObtenerTodos()
        {
            var result= await _context.Proveedores
                .FromSqlRaw("SELECT * FROM Proveedores")
                .ToListAsync();
            return result;
        }

       

        public async override Task Crear(Proveedor proveedor)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC CrearProveedor @Id={0}, @Nombre={1}, @Direccion={2}"
                , proveedor.Id, proveedor.Nombre, proveedor.Direccion);
        }

      
    }
}
