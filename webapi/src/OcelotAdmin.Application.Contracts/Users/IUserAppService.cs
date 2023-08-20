using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Ocelot.Admin.Users;
public interface IUserAppService : IApplicationService
{
    Task<UserViewModel> Create(UserInput input, CancellationToken token);
}
