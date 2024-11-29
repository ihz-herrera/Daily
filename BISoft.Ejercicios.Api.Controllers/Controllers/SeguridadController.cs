using BISoft.Ejercicios.Api.Controllers.Dto;
using BISoft.Ejercicios.Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BISoft.Ejercicios.Api.Controllers.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {

        private readonly SeguridadService _servicio;

        public SeguridadController(SeguridadService servicio)
        {
            _servicio = servicio;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {

          if(login == null)
          {
              return BadRequest("No se ha enviado la información de login.");
          }


          var usuario =  await _servicio.ObtenerUsuario(login.Usuario, login.Password);

          if(usuario == null)
          {
              return Unauthorized("El usuario o contraseña son incorrectos.");
          }

          var sesionId = Guid.NewGuid().ToString();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Usuario),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("EmpresaId",usuario.EmpresaId.ToString()),
                new Claim("SesionId", sesionId)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "api.ejercicios",
                expires: DateTime.Now.AddMinutes(5),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345")), SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { Token = tokenString });

        }


    }
}
