using MenuDinamicoAPI.Models;
using MenuDinamicoAPI.Repository.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Implementacion
{
    public class RolRepository : IRolRepository
    {

        private readonly MenuDbContext _dbContext;

        public RolRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public async Task<List<Rol>> ListaRol()
        {
            try
            {
                return await _dbContext.Rols.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Rol> ObtenerPorId(Expression<Func<Rol, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Rols.Where(filtro).FirstOrDefaultAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
