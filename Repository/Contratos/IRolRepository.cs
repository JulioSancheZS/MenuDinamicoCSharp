using MenuDinamicoAPI.Models;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Contratos
{
    public interface IRolRepository
    {
        Task<List<Rol>> ListaRol();
        Task<Rol> ObtenerPorId(Expression<Func<Rol, bool>> filtro = null);

        Task<Rol> Crear(Rol rol);
        Task<bool> Editar(Rol rol);
        Task<bool> Eliminar(Rol rol);
        Task<IQueryable<Rol>>Consultar (Expression<Func<Rol, bool>> filtro = null);
    }
}
