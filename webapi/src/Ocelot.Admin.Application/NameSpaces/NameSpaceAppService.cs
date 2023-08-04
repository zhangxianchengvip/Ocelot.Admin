using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Ocelot.Admin.NameSpaces;
public class NamespaceAppService : ApplicationService, INamespacesAppService
{
    private readonly NameSpaceManager _domainService;
    private readonly IRepository<NameSpace, Guid> _repository;
    public NamespaceAppService(NameSpaceManager domainService, IRepository<NameSpace, Guid> repository)
    {
        _domainService = domainService;
        _repository = repository;
    }

    public async Task<NameSpaceViewModel> Create(NameSpaceInput input, CancellationToken token)
    {
        var nameSpace = await _domainService.Create
        (
            nId: input.NId,
            name: input.Name,
            desc: input.Desc,
            CurrentUser.Id
         );

        return ObjectMapper.Map<NameSpace, NameSpaceViewModel>(nameSpace);
    }

    public async Task<bool> Delete(Guid id, CancellationToken token)
    {
        return await _domainService.DeleteAsync(id, token);
    }

    public async Task<List<NameSpaceViewModel>> GetList(CancellationToken token)
    {
        var nameSpaces = await _repository.GetListAsync(false, token);

        return ObjectMapper.Map<List<NameSpace>, List<NameSpaceViewModel>>(nameSpaces);
    }
}
