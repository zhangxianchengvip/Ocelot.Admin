using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Ocelot.Admin.NameSpaces;
public interface INamespacesAppService : IApplicationService
{
    public Task<NameSpaceViewModel> Create(NameSpaceInput input, CancellationToken token);
    public Task<List<NameSpaceViewModel>> GetList(CancellationToken token);

    public Task<bool> Delete(Guid id, CancellationToken token);
}
