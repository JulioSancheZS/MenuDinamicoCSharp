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

        public async Task<IQueryable<Rol>> Consultar(Expression<Func<Rol, bool>> filtro = null)
        {
            IQueryable<Rol> query = filtro == null? _dbContext.Rols : _dbContext.Rols.Where(filtro);
            return query;
        }

        public async Task<Rol> Crear(Rol rol)
        {
            try
            {
                Rol oRol = new Rol();

                oRol.NombreRol = rol.NombreRol;

                _dbContext.Set<Rol>().Add(oRol);
                await _dbContext.SaveChangesAsync();
                return oRol;
            }   
            catch
            {

                throw;
            }
        }

        public async Task<bool> Editar(Rol rol)
        {
            try
            {
                _dbContext.Update(rol);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> Eliminar(Rol rol)
        {
            try
            {
                _dbContext.Remove(rol);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch 
            {

                throw;
            }
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
