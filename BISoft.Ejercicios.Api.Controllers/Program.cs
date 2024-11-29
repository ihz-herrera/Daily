using BISoft.Ejercicios.Api.Controllers.HealthChecks;
using BISoft.Ejercicios.Api.Controllers.Middlewares;
using BISoft.Ejercicios.Aplicacion.Servicios;
using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Repositorios;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Text;
using System.Threading.RateLimiting;

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
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(connectionString: connectionString,
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true, SchemaName = "dbo" })
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();

            //obtner version del ensamblado
            var version = typeof(Program).Assembly.GetName().Version.ToString();

            builder.Services.AddHealthChecks()
                .AddCheck("APIEjercicios", () => HealthCheckResult.Healthy($"API Ejercicios is working. v{version}"))
                .AddSqlServer(connectionString, failureStatus: HealthStatus.Unhealthy)
                .AddUrlGroup(
                    new Uri("https://google.com"),
                    name: "OnLine",
                    failureStatus: HealthStatus.Degraded
                )
                .AddCheck<CustomHealthCheck>("Licenciamiento", HealthStatus.Degraded)
                .AddCheck("Almacenamiento", new MSSQLServerHealthCheck(connectionString)
                            , failureStatus: HealthStatus.Degraded)
                ;


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Configurar Rate Limiter
            builder.Services.AddRateLimiter(options => {

                options.OnRejected = (context, rateLimitRule) =>
            {
                context.HttpContext.Response.StatusCode = 429;
                context.HttpContext.Response.WriteAsync("To Many Request");
                return new ValueTask();
            };

            options.AddFixedWindowLimiter("fixed-window", options =>
                {
                    options.PermitLimit = 60;
                    options.Window = TimeSpan.FromSeconds(15);
                    options.QueueLimit = 0;
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });
            }
            );
           

            builder.Services.AddDbContext<Context>(o =>
            {
                o.UseSqlServer(connectionString);
            });


            builder.Services.AddScoped<IProveedoresRepository, ProveedoresCacheRepository>();
            builder.Services.AddScoped<ProveedoresRepository>();
            builder.Services.AddScoped<ProveedoresService>();
            builder.Services.AddScoped<SeguridadService>();

            builder.Services.AddScoped<IProductosRepository, ProductosRepository>();
            builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
            builder.Services.AddScoped<IFabricantesRepository, FabricantesRepository>();
            builder.Services.AddScoped<IOutboxRepository, OutboxRepository>();
            builder.Services.AddScoped<ProductosService>();
            builder.Services.AddScoped<GlobalErrorMiddleware>();
            builder.Services.AddScoped<TraceIdentifierMiddleware>();


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

            app.UseRateLimiter();

            app.UseSerilogRequestLogging();

            app.UseMiddleware<GlobalErrorMiddleware>();
            
            app.UseMiddleware<TraceIdentifierMiddleware>();

            app.MapHealthChecks("/health-check");//.RequireAuthorization();
            app.MapHealthChecks("/health-details", new HealthCheckOptions()
            {
                //Predicate = (check) => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }).RequireRateLimiting("fixed-window");//.RequireAuthorization();

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
