using AutoMapper;
using Ocelot.Admin.NameSpaces;
using Ocelot.Admin.Roles;
using Ocelot.Admin.Users;

namespace Ocelot.Admin;

public class AdminApplicationAutoMapperProfile : Profile
{
    public AdminApplicationAutoMapperProfile()
    {
        CreateMap<Role, RoleViewModel>();
        CreateMap<NameSpace, NameSpaceViewModel>();
        CreateMap<User, UserViewModel>();
    }
}
