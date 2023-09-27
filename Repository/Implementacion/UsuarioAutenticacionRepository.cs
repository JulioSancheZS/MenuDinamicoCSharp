using MenuDinamicoAPI.Models;
using MenuDinamicoAPI.Repository.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Implementacion
{
    public class UsuarioAutenticacionRepository : IUsuarioAutenticacion
    {
        public readonly MenuDbContext _menuDbContext;

        public UsuarioAutenticacionRepository(MenuDbContext menuDbContext)
        {
            _menuDbContext = menuDbContext;
        }
        public async Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null)
        {
            try
            {
                return await _menuDbContext.Usuarios.Where(filtro).FirstOrDefaultAsync();
            }
            catch 
            {

                throw;
            }
        }

        public Task<Usuario> RegistrarUsuario(Usuario entidad)
        {
            throw new NotImplementedException();
        }
    }
}
