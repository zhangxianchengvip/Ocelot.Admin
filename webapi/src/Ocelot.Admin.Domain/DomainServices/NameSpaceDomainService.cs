using System;
using System.Threading.Tasks;
using Ocelot.Admin.Entity.NameSpaces;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Ocelot.Admin.DomainServices;

public class NameSpaceDomainService : DomainService
{
    private readonly IRepository<NameSpace, Guid> _repository;

    public NameSpaceDomainService(IRepository<NameSpace, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<NameSpace> Create(string nId, string name, string desc, Guid creator)
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