using AutoMapper;
using MenuDinamicoAPI.DTO;
using MenuDinamicoAPI.Models;
using MenuDinamicoAPI.Repository.Contratos;
using MenuDinamicoAPI.Repository.Implementacion;
using MenuDinamicoAPI.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuDinamicoAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
		{
			_mapper = mapper;
			_usuarioRepository = usuarioRepository;
		}

		[HttpGet]
		[Route("lista")]
		public async Task<IActionResult> Lista()
		{
			Response<List<UsuarioDTO>> _response = new Response<List<UsuarioDTO>>();

			try
			{
				List<UsuarioDTO> _listaRol = new List<UsuarioDTO>();

				_listaRol = _mapper.Map<List<UsuarioDTO>>(await _usuarioRepository.ListaUsuario());

				if (_listaRol.Count > 0)
				{
					_response = new Response<List<UsuarioDTO>> { status = true, msg = "OK", value = _listaRol };
				}
				else
					_response = new Response<List<UsuarioDTO>> { status = false, msg = "Sin Resultados", value = _listaRol };


				return StatusCode(StatusCodes.Status200OK, _response);
			}
			catch (Exception)
			{

				throw;
			}

		}

		[HttpPost]
		[Route("post")]
		public async Task<IActionResult> Guardar([FromBody] UsuarioDTO request)
		{
			try
			{
				Response<UsuarioDTO> _response = new Response<UsuarioDTO>();

				Usuario _usuario = _mapper.Map<Usuario>(request);

				Usuario _crearUsuario = await _usuarioRepository.Crear(_usuario);
				if (_crearUsuario.IdUsuario != 0)
					_response = new Response<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_crearUsuario) };
				else
					_response = new Response<UsuarioDTO>() { status = false, msg = "No se pudo crear el Usuario" };

				return StatusCode(StatusCodes.Status200OK, _response);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		[HttpPut]
		[Route("Editar")]
		public async Task<IActionResult> Editar([FromBody] UsuarioDTO request)
		{
			Response<UsuarioDTO> _response = new Response<UsuarioDTO>();
			try
			{
				Usuario _usuario = _mapper.Map<Usuario>(request);
				Usuario _usuarioParaEditar = await _usuarioRepository.ObtenerPorId(u => u.IdUsuario == _usuario.IdUsuario);

				if (_usuarioParaEditar != null)
				{

					_usuarioParaEditar.Usuario1 = _usuario.Usuario1;
					_usuarioParaEditar.Pass = _usuario.Pass;
					_usuarioParaEditar.Correo = _usuario.Correo;
					_usuarioParaEditar.IdRol = _usuario.IdRol;


					bool respuesta = await _usuarioRepository.Editar(_usuarioParaEditar);

					if (respuesta)
						_response = new Response<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_usuarioParaEditar) };
					else
						_response = new Response<UsuarioDTO>() { status = false, msg = "No se pudo editar el Usuario" };
				}
				else
				{
					_response = new Response<UsuarioDTO>() { status = false, msg = "No se encontró el Usuario" };
				}

				return StatusCode(StatusCodes.Status200OK, _response);
			}
			catch (Exception ex)
			{
				_response = new Response<UsuarioDTO>() { status = false, msg = ex.Message };
				return StatusCode(StatusCodes.Status500InternalServerError, _response);
			}
		}

		[HttpDelete]
		[Route("Eliminar")]
		public async Task<IActionResult> Eliminar(UsuarioDTO request)
		{
			Response<string> _response = new Response<string>();
			try
			{
				Usuario _usuarioEliminar = await _usuarioRepository.ObtenerPorId(u => u.IdUsuario == request.IdUsuario);

				if (_usuarioEliminar != null)
				{

					bool respuesta = await _usuarioRepository.Eliminar(_usuarioEliminar);

					if (respuesta)
						_response = new Response<string>() { status = true, msg = "ok", value = "" };
					else
						_response = new Response<string>() { status = false, msg = "No se pudo eliminar el Usuario", value = "" };
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
