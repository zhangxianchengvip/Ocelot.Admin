using OcelotAdmin.Tests;
using AutoMapper;
using OcelotAdmin.Roles;
using Ocelot.Admin.Roles;
using OcelotAdmin.Users;
using Ocelot.Admin.Users;

namespace OcelotAdmin;

public class OcelotAdminApplicationAutoMapperProfile : Profile
{
    public OcelotAdminApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Test, TestViewModel>();
        CreateMap<Role, RoleViewModel>();
        CreateMap<User, UserViewModel>();
    }
}
