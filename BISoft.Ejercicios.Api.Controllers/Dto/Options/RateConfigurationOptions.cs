namespace BISoft.Ejercicios.Api.Controllers.Dto.Options
{
    public class RateConfigurationOptions
    {
        public int? PermitLimit { get; set; }= 10;
        public int WindowInSeconds {get;set;} = 60;
        public int QueueLimit {get;set;} = 0;

    }
}
