using AutoMapper;
using Ocelot.Admin.NameSpaces;
using Ocelot.Admin.Roles;

namespace Ocelot.Admin;

public class AdminApplicationAutoMapperProfile : Profile
{
    public AdminApplicationAutoMapperProfile()
    {
        CreateMap<Role, RoleViewModel>();
        CreateMap<NameSpace, NameSpaceViewModel>();
    }
}
