using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Ocelot.Admin.Auths;
public interface IAuthAppService : IApplicationService
{
    public Task<AuthViewModel> Login(AuthInput input, CancellationToken token);
}
