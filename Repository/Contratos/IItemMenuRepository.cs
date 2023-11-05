using MenuDinamicoAPI.DTO;
using MenuDinamicoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MenuDinamicoAPI.Repository.Contratos
{
    public interface IItemMenuRepository
    {

        //Listado para el menu dinamico
        Task<List<MenuItemDTO>> GetMenu(int? parentId);
        Task<List<MenuItemDTO>> ListaMenuNew();

        //CRUD
        Task<List<ItemMenu>> ListaRol();
        Task<ItemMenu> ObtenerPorId(Expression<Func<ItemMenu, bool>> filtro = null);

        Task<ItemMenu> Crear(ItemMenu itemMenu);
        Task<bool> Editar(ItemMenu itemMenu);
        Task<bool> Eliminar(ItemMenu itemMenu);
        Task<IQueryable<ItemMenu>> Consultar(Expression<Func<ItemMenu, bool>> filtro = null);

    }
}
