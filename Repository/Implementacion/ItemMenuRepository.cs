using MenuDinamicoAPI.DTO;
using MenuDinamicoAPI.Models;
using MenuDinamicoAPI.Repository.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Implementacion
{
    public class ItemMenuRepository : IItemMenuRepository
    {
        private readonly MenuDbContext _dbContext;

        public ItemMenuRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<ItemMenu>> Consultar(Expression<Func<ItemMenu, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }

        public Task<ItemMenu> Crear(ItemMenu itemMenu)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(ItemMenu itemMenu)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(ItemMenu itemMenu)
        {
            throw new NotImplementedException();
        }
        public Task<List<ItemMenu>> ListaRol()
        {
            throw new NotImplementedException();
        }

        public Task<ItemMenu> ObtenerPorId(Expression<Func<ItemMenu, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }
        //Nuevo Menu Item
        public async Task<List<MenuItemDTO>> GetMenu(int? parentId = null)
        {
            var items = await _dbContext.ItemMenus
        .Where(item => item.Visible == true && item.IdItemMenuPadre == parentId)
        .ToListAsync();

            var menu = new List<MenuItemDTO>();

            foreach (var item in items)
            {
                var menuItem = new MenuItemDTO
                {
                    IdItemMenu = item.IdItemMenu,
                    IdItemMenuPadre = item.IdItemMenuPadre,
                    Ruta = item.Ruta,
                    Texto = item.Texto,
                    Visible = item.Visible ?? false,
                    EsActivo = item.EsActivo ?? false
                };

                menuItem.Submenu = await GetMenu(item.IdItemMenu); // Llamada recursiva
                menu.Add(menuItem);
            }

            return menu;
        }

        public async Task<List<MenuItemDTO>> ListaMenuNew()
        {
            try
            {
                var menuItems = await GetMenu();
                return menuItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
