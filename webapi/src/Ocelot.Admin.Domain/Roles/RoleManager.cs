using Ocelot.Admin.Properties.Enums;
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

namespace Ocelot.Admin.Roles;
public class RoleManager : DomainService
{
    private readonly IRepository<Role, Guid> _repository;

    public RoleManager(IRepository<Role, Guid> repository)
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

    public async Task<Role> AddRoleNameSpace(Guid id, Guid nameSpaceId, Operation operationId)
    {
        var role = await GetRoleIfNotHasThrowException(id);
        role.AddRoleNameSpace(nameSpaceId, operationId);
        return role;
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

    private async Task<Role> GetRoleIfNotHasThrowException(Guid id)
    {
        return await _repository.GetAsync(id);
    }
}
