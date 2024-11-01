using BISoft.Ejercicios.Api.Controllers.HealthChecks;
using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Text;

namespace BISoft.Ejercicios.Api.Controllers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("AppConnectionString");

            var sqlitePath = builder.Configuration.GetValue<string>("LogSqlitePath");

            // Add services to the container.

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                //.MinimumLevel.Information()
                //.WriteTo.Console()
                //.WriteTo.SQLite(sqlitePath)
                .WriteTo.MSSqlServer(connectionString: connectionString,
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true, SchemaName = "dbo" })
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();

            //obtner version del ensamblado
            var version = typeof(Program).Assembly.GetName().Version.ToString();

            builder.Services.AddHealthChecks()
                .AddCheck("APIEjercicios", () => HealthCheckResult.Healthy($"API Ejercicios is working. v{version}"))
                .AddSqlServer(connectionString,failureStatus:HealthStatus.Unhealthy)
                .AddUrlGroup(
                    new Uri("https://google.com"),
                    name: "OnLine",
                    failureStatus: HealthStatus.Degraded
                )
                .AddCheck<CustomHealthCheck>("Licenciamiento",HealthStatus.Degraded)
                .AddCheck("MSSQLServer", new MSSQLServerHealthCheck(connectionString)
                            ,failureStatus:HealthStatus.Degraded)   
                ;


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
         

            
           

            builder.Services.AddDbContext<Context>(o =>
            {
                o.UseSqlServer(connectionString);
            });


            builder.Services.AddScoped<IProveedoresRepository, ProveedoresCacheRepository>();
            builder.Services.AddScoped<ProveedoresRepository>();
            builder.Services.AddScoped<ProveedoresService>();
            builder.Services.AddScoped<SeguridadService>();

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "Bearer";
                opt.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "http://localhost:5000",
                    ValidAudience = "api.ejercicios",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345"))
                };
            } );


            builder.Host.UseSerilog();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSerilogRequestLogging();
            

            app.MapHealthChecks("/health-check").RequireAuthorization();
            app.MapHealthChecks("/health-details", new HealthCheckOptions()
            {
                //Predicate = (check) => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }).RequireAuthorization();

            app.MapControllers( );


            //configurar serilog




            try
            {
                Log.Information("Iniciando la aplicacion");

                app.Run();

                Log.Information("Finalizando la aplicacion");
            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex, "Error en la aplicacion");
            }
            
        }
    }
}
