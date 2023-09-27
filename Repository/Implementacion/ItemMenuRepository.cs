using MenuDinamicoAPI.Models;
using MenuDinamicoAPI.Repository.Contratos;
using Microsoft.EntityFrameworkCore;

namespace MenuDinamicoAPI.Repository.Implementacion
{
    public class ItemMenuRepository : IItemMenuRepository
    {
        private readonly MenuDbContext _dbContext;

        public ItemMenuRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ItemMenu>> GetMenuItems(int? parentId = null)
        {

            var items = await _dbContext.ItemMenus
         .Where(item => item.Visible == true && item.IdItemMenuPadre == parentId)
         .ToListAsync();

            var menu = new List<ItemMenu>();

            foreach (var item in items)
            {
                var menuItem = new ItemMenu
                {
                    IdItemMenu = item.IdItemMenu,
                    IdItemMenuPadre = item.IdItemMenuPadre,
                    Ruta = item.Ruta,
                    Texto = item.Texto,
                    Visible = item.Visible,
                    FechaRegistro = item.FechaRegistro,
                    EsActivo = item.EsActivo
                };

                menuItem.InverseIdItemMenuPadreNavigation = await GetMenuItems(item.IdItemMenu); // Llamada recursiva
                menu.Add(menuItem);
                menu.AddRange(menuItem.InverseIdItemMenuPadreNavigation);
            }

            return menu;
        }

        public async Task<List<ItemMenu>> ListaMenu()
        {
            try
            {
                var menuItems = await GetMenuItems();
                return menuItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
