using MenuDinamicoAPI.Models;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Contratos
{
    public interface IUsuarioAutenticacion
    {
        Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null);
        Task<Usuario> RegistrarUsuario(Usuario entidad);
    }
}
