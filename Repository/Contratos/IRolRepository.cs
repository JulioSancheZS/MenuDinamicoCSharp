using MenuDinamicoAPI.Models;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Contratos
{
    public interface IRolRepository
    {
        Task<List<Rol>> ListaRol();
        Task<Rol> ObtenerPorId(Expression<Func<Rol, bool>> filtro = null);

    }
}
