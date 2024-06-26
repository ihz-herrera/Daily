using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
