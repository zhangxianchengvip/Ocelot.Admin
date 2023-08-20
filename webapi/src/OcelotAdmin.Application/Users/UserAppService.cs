using OcelotAdmin.Users;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Ocelot.Admin.Users;
public class UserAppService : ApplicationService, IUserAppService
{
    private readonly UserManager _manager;

    public UserAppService(UserManager manager)
    {
        _manager = manager;
    }

    public async Task<UserViewModel> Create(UserInput input, CancellationToken token)
    {
        var user = await _manager.Create
        (
                loginName: input.LoginName,
                password: input.Password,
                roleId: input.RoleId,
                creatorId: CurrentUser.Id,
                token: token
        );

        return ObjectMapper.Map<User, UserViewModel>(user);
    }
}
