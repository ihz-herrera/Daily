using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using BISoft.Ejercicios.Infraestructura.Contextos;
using Dapper;
using System.Linq.Expressions;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresDapperRepository : IProveedoresRepository
    {


        public async Task<List<Proveedor>> ObtenerTodos()
        {
            var query = "SELECT * FROM Proveedores";

            using (var connection = DapperContext.CrearContexto())
            {
                return connection.Query<Proveedor>(query).ToList();
            }
        }

        public async Task Crear(Proveedor proveedor)
        {
            var query = "INSERT INTO Proveedores (Id, Nombre, Direccion) VALUES (@Id, @Nombre, @Direccion)";

            using (var connection = DapperContext.CrearContexto())
            {
                await connection.ExecuteAsync(query, proveedor);
            }
        }

        public async Task Actualizar(Proveedor proveedor)
        {
            var query = "UPDATE Proveedores SET Nombre = @Nombre, Direccion = @Direccion WHERE Id = @Id";

            using (var connection = DapperContext.CrearContexto())
            {
                await connection.ExecuteAsync(query, proveedor);
            }
        }

        public void EliminarProveedor(int id)
        {
            var query = "DELETE FROM Proveedores WHERE Id = @Id";

            using (var connection = DapperContext.CrearContexto())
            {
                connection.Execute(query, new { Id = id });
            }
        }

        public async Task<Proveedor> ObtenerProveedorPorId(int id)
        {
            var query = "SELECT * FROM Proveedores WHERE Id = @Id";

            using (var connection = DapperContext.CrearContexto())
            {
                return await connection.QueryFirstOrDefaultAsync<Proveedor>(query, new { Id = id });
            }
        }

        public async Task<Proveedor> ObtenerPorExpresion(Expression<Func<Proveedor, bool>> expresion)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Proveedor> GetCollectionByExp(Expression<Func<Proveedor, bool>> expresion)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Proveedor> GetCollection()
        {
            throw new NotImplementedException();
        }
    }
}
