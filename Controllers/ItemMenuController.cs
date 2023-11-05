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
        [Route("menu")]
        public async Task<IActionResult> getMenu()
        {
            Response<List<MenuItemDTO>> _response = new Response<List<MenuItemDTO>>();

            try
            {
                List<MenuItemDTO> _listaItemMenu = new List<MenuItemDTO>();

                _listaItemMenu = _mapper.Map<List<MenuItemDTO>>(await _itemMenuRepository.ListaMenuNew());
                if (_listaItemMenu.Count > 0)
                {
                    _response = new Response<List<MenuItemDTO>> { status = true, msg = "OK", value = _listaItemMenu };
                }
                else
                    _response = new Response<List<MenuItemDTO>> { status = false, msg = "Sin Resultados", value = _listaItemMenu };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {

                _response = new Response<List<MenuItemDTO>> { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }
    }
}
