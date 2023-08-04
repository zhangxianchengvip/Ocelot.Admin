using System;
using System.Threading;
using System.Threading.Tasks;
using Ocelot.Admin.Entity.Configurations.Routes;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Ocelot.Admin.Entity.NameSpaces;

public class NameSpaceManager : DomainService
{
    private readonly IRepository<NameSpace, Guid> _repository;
    private readonly IRepository<Route, Guid> _routeRepository;

    public NameSpaceManager(IRepository<NameSpace, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<NameSpace> Create(string nId, string name, string desc, Guid? creator)
    {
        await CheckNameSpaceIfAnyException(nId);

        NameSpace nameSpace = new
        (
            id: GuidGenerator.Create(),
            nId: nId,
            name: name,
            desc: desc,
            creator: creator
        );

        return await _repository.InsertAsync(nameSpace);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
    {
        var any = await _routeRepository.AnyAsync(s => s.NamespaceId.Equals(id), token);

        if (!any)
        {
            await _repository.DeleteAsync(s => s.Id.Equals(id), true, token);
        }

        return true;
    }
    private async Task CheckNameSpaceIfAnyException(string nId)
    {
        var any = await _repository.AnyAsync(n => n.NId.Equals(nId));
        if (any)
        {
            throw new BusinessException(AdminDomainErrorCodes.NameSpaceExist)
            {
                Data =
                {
                    { "name", nId }
                }
            };
        }
    }
}