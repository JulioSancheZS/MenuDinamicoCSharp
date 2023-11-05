using MenuDinamicoAPI.Models;
using MenuDinamicoAPI.Repository.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Implementacion
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly MenuDbContext _dbContext;

		public UsuarioRepository(MenuDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null)
		{
			IQueryable<Usuario> query = filtro == null ? _dbContext.Usuarios : _dbContext.Usuarios.Where(filtro);
			return query;
		}

		public async Task<Usuario> Crear(Usuario entidad)
		{
			try
			{
				Usuario oUsuario = new Usuario();

				oUsuario.IdRol = entidad.IdRol;
				oUsuario.Usuario1 = entidad.Usuario1;
				oUsuario.Pass = entidad.Pass;
				oUsuario.Correo = entidad.Correo;
				
				_dbContext.Set<Usuario>().Add(oUsuario);
				await _dbContext.SaveChangesAsync();
				return oUsuario;
			}
			catch
			{

				throw;
			}
		}

		public async Task<bool> Editar(Usuario entidad)
		{
			try
			{
				_dbContext.Update(entidad);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch
			{

				throw;
			}
		}

		public async Task<bool> Eliminar(Usuario entidad)
		{
			try
			{
				_dbContext.Remove(entidad);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch
			{

				throw;
			}
		}

		public async Task<List<Usuario>> ListaUsuario()
		{
			try
			{
				return await _dbContext.Usuarios.ToListAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<Usuario> ObtenerPorId(Expression<Func<Usuario, bool>> filtro = null)
		{
			try
			{
				return await _dbContext.Usuarios.Where(filtro).FirstOrDefaultAsync();

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
