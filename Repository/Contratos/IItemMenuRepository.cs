using MenuDinamicoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuDinamicoAPI.Repository.Contratos
{
    public interface IItemMenuRepository
    {


        Task<List<ItemMenu>> ListaMenu();
        Task<List<ItemMenu>> GetMenuItems(int? parentId);

    }
}
