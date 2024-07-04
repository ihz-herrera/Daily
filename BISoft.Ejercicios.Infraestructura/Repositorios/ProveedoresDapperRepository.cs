using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresDapperRepository : IProveedoresRepository
    {


        public List<Proveedor> ObtenerProveedores()
        {
            var query = "SELECT * FROM Proveedores";

            using (var connection = DapperContext.CrearContexto())
            {
                return connection.Query<Proveedor>(query).ToList();
            }
        }

        public void CrearProveedor(Proveedor proveedor)
        {
            var query = "INSERT INTO Proveedores (Id, Nombre, Direccion) VALUES (@Id, @Nombre, @Direccion)";

            using (var connection = DapperContext.CrearContexto())
            {
                connection.Execute(query, proveedor);
            }
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            var query = "UPDATE Proveedores SET Nombre = @Nombre, Direccion = @Direccion WHERE Id = @Id";

            using (var connection = DapperContext.CrearContexto())
            {
                connection.Execute(query, proveedor);
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

        public Proveedor ObtenerProveedorPorId(int id)
        {
            var query = "SELECT * FROM Proveedores WHERE Id = @Id";

            using (var connection = DapperContext.CrearContexto())
            {
                return connection.QueryFirstOrDefault<Proveedor>(query, new { Id = id });
            }
        }

    }
}
