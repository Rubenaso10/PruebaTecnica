using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParteDos.Config;
using ParteDos.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ParteDos.Config;
using ParteDos.Models;

namespace TuProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>();
        private readonly JwtConfig _jwtConfig;

        public AuthController(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        // Registro de usuario
        [HttpPost("registro")]
        public IActionResult Registro([FromBody] Usuario usuario)
        {
            if (usuarios.Any(u => u.NombreUsuario == usuario.NombreUsuario))
                return BadRequest("El usuario ya existe.");

            usuario.Id = usuarios.Count + 1;
            usuarios.Add(usuario);
            return Ok("Usuario registrado con éxito.");
        }

        // Inicio de sesión
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            var user = usuarios.FirstOrDefault(u => u.NombreUsuario == usuario.NombreUsuario && u.Contrasena == usuario.Contrasena);
            if (user == null)
                return Unauthorized();

            var token = GenerarToken(user);
            return Ok(new { token });
        }

        // Generar JWT
        private string GenerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.token);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
