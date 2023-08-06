using Ocelot.Admin.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Ocelot.Admin.Users;
public class UserManager : DomainService
{
    private readonly IRepository<User, Guid> _user;
    private readonly IRepository<Role, Guid> _role;
    public UserManager(IRepository<User, Guid> user, RoleManager roleManager, IRepository<Role, Guid> role)
    {
        _user = user;
        _role = role;
    }

    public async Task<User> Create(string loginName, string password, Guid roleId, Guid? creatorId, CancellationToken token)
    {
        await CheckUserIfAnyException(loginName);

        await CheckRoleIfNotAnyException(roleId);

        User user = new
        (
            id: GuidGenerator.Create(),
            loginName: loginName,
            password: password
        );

        user.AddRole(roleId);

        return await _user.InsertAsync(user, true, token);
    }

    private async Task CheckUserIfAnyException(string loginName)
    {
        var any = await _user.AnyAsync(s => s.LoginName.Equals(loginName));
        if (any)
        {
            throw new BusinessException(AdminDomainErrorCodes.NameSpaceExist)
            {
                Data =
                {
                    { "loginName", loginName }
                }
            };
        }
    }

    private async Task CheckRoleIfNotAnyException(Guid roleId)
    {
        var any = await _role.AnyAsync(s => s.Id.Equals(roleId));
        if (!any)
        {

            throw new BusinessException(AdminDomainErrorCodes.NameSpaceExist)
            {
                Data =
                {
                    { "loginName", roleId }
                }
            };

        }
    }
}
