using Microsoft.Data.SqlClient;
using System.Data;

namespace BISoft.Ejercicios.Infraestructura.Contextos
{
    internal class DapperContext
    {


        private static readonly string _connectionString = "Server=.\\MSSQLServer01;Initial Catalog=DailyBD;Trusted_connection=true" ;

      
        internal static IDbConnection CrearContexto()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
