using Ocelot.Admin.Entity.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Ocelot.Admin.DomainServices;
public class RoleDomainService : DomainService
{
    private readonly IRepository<Role, Guid> _repository;

    public RoleDomainService(IRepository<Role, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<Role> Create(string name, string desc, CancellationToken token)
    {
        await CheckRoleIfAnyThrowException(name);

        var role = new Role
        (
              id: GuidGenerator.Create(),
              name: name,
              desc: desc
        );
        return await _repository.InsertAsync(role, true, token);
    }

    private async Task CheckRoleIfAnyThrowException(string name)
    {

        if (await _repository.AnyAsync(s => s.Name.Equals(name)))
        {
            throw new BusinessException(AdminDomainErrorCodes.RoleExist)
            {
                Data = { { "name", name } }
            };
        }
    }
}
