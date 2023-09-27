using AutoMapper;
using MenuDinamicoAPI.DTO;
using MenuDinamicoAPI.Models;
using MenuDinamicoAPI.Repository.Contratos;
using MenuDinamicoAPI.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MenuDinamicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioAutenticacion _usuarioAutenticacion;
        private readonly IRolRepository _rolRepository;
        public IConfiguration _configuration;

        public AuthenticationController(IMapper mapper, IUsuarioAutenticacion usuarioAutenticacion, IRolRepository rolRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _usuarioAutenticacion = usuarioAutenticacion;
            _rolRepository = rolRepository;
            _configuration = configuration; 
        }

        [HttpPost]
        [Route("authentication")]
        public async Task<IActionResult> Authentication([FromBody] Login login)
        {
            Response<UsuarioDTO> _response = new Response<UsuarioDTO>();

            try
            {
                string usuario = login.usuario;
                string clave = login.pass;

                Usuario _usuario = await _usuarioAutenticacion.Obtener(u => u.Usuario1 == usuario && u.Pass == clave);

                if (_usuario == null)
                {
                    _response = new Response<UsuarioDTO>() { status = false, msg = "No se encontro el usuario, Por favor, inténtalo nuevamente" };
                    return StatusCode(StatusCodes.Status200OK, _response);
                }


                if (_usuario != null)
                {
                    if (_usuario.EsActivo == false)
                    {
                        _response = new Response<UsuarioDTO>() { status = false, msg = $"El usuario {_usuario.Usuario1} está inactivo, por lo tanto no tiene acceso al sistema.", value = null };
                        return StatusCode(StatusCodes.Status200OK, _response);
                    }

                    Rol _rol = await _rolRepository.ObtenerPorId(x => x.IdRol == _usuario.IdRol);


                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("IdUsuario", _usuario.IdUsuario.ToString()),
                        new Claim("Usuario", _usuario.Usuario1.ToString()),
                        new Claim("Rol",_rol.NombreRol)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);

                    _response = new Response<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_usuario), token = new JwtSecurityTokenHandler().WriteToken(token) };

                }

                return StatusCode(StatusCodes.Status200OK, _response);

            }
            catch (Exception ex)
            {

                _response = new Response<UsuarioDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
