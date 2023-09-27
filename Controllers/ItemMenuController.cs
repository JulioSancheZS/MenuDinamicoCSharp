using AutoMapper;
using MenuDinamicoAPI.DTO;
using MenuDinamicoAPI.Repository.Contratos;
using MenuDinamicoAPI.Repository.Implementacion;
using MenuDinamicoAPI.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuDinamicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMenuController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemMenuRepository _itemMenuRepository;


        public ItemMenuController(IItemMenuRepository itemMenuRepository, IMapper mapper)
        {
            _mapper = mapper;
            _itemMenuRepository = itemMenuRepository;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<ItemMenuDTO>> _response = new Response<List<ItemMenuDTO>>();

            try
            {
                List<ItemMenuDTO> _listaItemMenu = new List<ItemMenuDTO>();

                _listaItemMenu = _mapper.Map<List<ItemMenuDTO>>(await _itemMenuRepository.ListaMenu());

                if (_listaItemMenu.Count > 0)
                {
                    _response = new Response<List<ItemMenuDTO>> { status = true, msg = "OK", value = _listaItemMenu };
                }
                else
                    _response = new Response<List<ItemMenuDTO>> { status = false, msg = "Sin Resultados", value = _listaItemMenu };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
