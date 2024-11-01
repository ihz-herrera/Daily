using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BISoft.Ejercicios.Api.Controllers.HealthChecks
{
    public class MSSQLServerHealthCheck : IHealthCheck
    {

        private string _connectionString;

        public MSSQLServerHealthCheck(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync(cancellationToken);

                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT 1";
                    await command.ExecuteScalarAsync(cancellationToken);
                    
                }
                catch (SqlException)
                {
                    return new HealthCheckResult(context.Registration.FailureStatus, description: "Servicio de almacenamiento no disponible.");
                }
            }

            return new HealthCheckResult(HealthStatus.Healthy, description: "Servicio de almacenamiento disponible.");



        }
    }
}
