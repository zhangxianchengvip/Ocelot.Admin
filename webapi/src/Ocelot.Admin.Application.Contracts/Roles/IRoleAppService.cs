using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Ocelot.Admin.Roles;
public interface IRoleAppService : IApplicationService
{
    public Task<RoleViewModel> Create(RoleInput input, CancellationToken token);
    public Task<bool> Delete(Guid id, CancellationToken token);

    public Task<List<RoleViewModel>> GetList(CancellationToken token);
}
