using AutoMapper;
using MenuDinamicoAPI.DTO;
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
    }
}
