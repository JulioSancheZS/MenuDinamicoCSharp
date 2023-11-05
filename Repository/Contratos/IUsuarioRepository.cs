using MenuDinamicoAPI.Models;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Contratos
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ListaUsuario();
        Task<Usuario> ObtenerPorId(Expression<Func<Usuario, bool>> filtro = null);
        Task<Usuario> Crear(Usuario entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(Usuario entidad);
        Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null);
    }
}
