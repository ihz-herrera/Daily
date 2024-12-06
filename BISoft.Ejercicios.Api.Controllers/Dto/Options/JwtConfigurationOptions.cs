namespace BISoft.Ejercicios.Api.Controllers.Dto.Options
{
    public class JwtConfigurationOptions
    {
        public string? ValidIssuer { get; set; }
        public string? ValidAudience {get;set;}
        public string? IssuerSigningKey {get;set;}

    }
}
