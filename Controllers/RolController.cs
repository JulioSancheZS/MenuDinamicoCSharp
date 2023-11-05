using AutoMapper;
using MenuDinamicoAPI.DTO;
using MenuDinamicoAPI.Models;
using MenuDinamicoAPI.Repository.Contratos;
using MenuDinamicoAPI.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuDinamicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRolRepository _rolRepository;

        public RolController(IRolRepository rolRepository, IMapper mapper)
        {
            _mapper = mapper;
            _rolRepository = rolRepository;
        }

        [HttpGet]
        [Route("lista")]
        public async  Task<IActionResult> Lista()
        {
            Response<List<RolDTO>> _response = new Response<List<RolDTO>>();

            try
            {
                List<RolDTO> _listaRol = new List<RolDTO>();

                _listaRol = _mapper.Map<List<RolDTO>>(await _rolRepository.ListaRol());

                if (_listaRol.Count > 0)
                {
                    _response = new Response<List<RolDTO>> { status = true, msg = "OK", value= _listaRol };
                }else
                    _response = new Response<List<RolDTO>> { status = false, msg = "Sin Resultados", value = _listaRol };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> Guardar([FromBody] RolDTO request)
        {
            try
            {
                Response<RolDTO> _response = new Response<RolDTO>();

                Rol _rol = _mapper.Map<Rol>(request);

                Rol _crearRol = await _rolRepository.Crear(_rol);
                if (_crearRol.IdRol != 0)
                    _response = new Response<RolDTO>() { status = true, msg = "ok", value = _mapper.Map<RolDTO>(_crearRol) };
                else
                    _response = new Response<RolDTO>() { status = false, msg = "No se pudo crear el Rol" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] RolDTO request)
        {
            Response<RolDTO> _response = new Response<RolDTO>();
            try
            {
                Rol _rol = _mapper.Map<Rol>(request);
                Rol _rolParaEditar = await _rolRepository.ObtenerPorId(u => u.IdRol == _rol.IdRol);

                if (_rolParaEditar != null)
                {

                    _rolParaEditar.NombreRol = _rol.NombreRol;

                    bool respuesta = await _rolRepository.Editar(_rolParaEditar);

                    if (respuesta)
                        _response = new Response<RolDTO>() { status = true, msg = "ok", value = _mapper.Map<RolDTO>(_rolParaEditar) };
                    else
                        _response = new Response<RolDTO>() { status = false, msg = "No se pudo editar el Rol" };
                }
                else
                {
                    _response = new Response<RolDTO>() { status = false, msg = "No se encontró el Rol" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<RolDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(RolDTO request)
        {
            Response<string> _response = new Response<string>();
            try
            {
                Rol _rolEliminar = await _rolRepository.ObtenerPorId(u => u.IdRol == request.IdRol);

                if (_rolEliminar != null)
                {

                    bool respuesta = await _rolRepository.Eliminar(_rolEliminar);

                    if (respuesta)
                        _response = new Response<string>() { status = true, msg = "ok", value = "" };
                    else
                        _response = new Response<string>() { status = false, msg = "No se pudo eliminar el producto", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
