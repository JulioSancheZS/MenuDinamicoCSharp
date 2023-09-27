using AutoMapper;
using MenuDinamicoAPI.DTO;
using MenuDinamicoAPI.Models;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuDinamicoAPI.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Rol, RolDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino => destino.NombreRol, opt => opt.MapFrom(origen => origen.IdRolNavigation.NombreRol));

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino => destino.IdRolNavigation, opt => opt.Ignore());

            CreateMap<ItemMenu, ItemMenuDTO>().ReverseMap();

            CreateMap<ItemRol, ItemRolDTO>()
                .ForMember(destino => destino.NombreItemMenu, opt => opt.MapFrom(origen => origen.IdItemMenuNavigation.Texto))
                .ForMember(destino => destino.NombreRol, opt => opt.MapFrom(origen => origen.IdRolNavigation.NombreRol));

            CreateMap<ItemRolDTO, ItemRol>()
                .ForMember(destino => destino.IdItemMenuNavigation, opt => opt.Ignore())
                .ForMember(destino => destino.IdRolNavigation, opt => opt.Ignore());
        }
    }
}
