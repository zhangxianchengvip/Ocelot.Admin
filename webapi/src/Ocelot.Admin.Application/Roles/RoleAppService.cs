using Ocelot.Admin.Entity.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Ocelot.Admin.Roles;
public class RoleAppService : ApplicationService, IRoleAppService
{
    private readonly RoleManager _domainService;
    private readonly IRepository<Role, Guid> _repository;
    public RoleAppService(RoleManager domainService, IRepository<Role, Guid> repository)
    {
        _domainService = domainService;
        _repository = repository;
    }

    public async Task<RoleViewModel> Create(RoleInput input, CancellationToken token)
    {
        var role = await _domainService.Create
        (
                name: input.Name,
                desc: input.Desc,
                token: token
        );

        return ObjectMapper.Map<Role, RoleViewModel>(role);
    }

    public async Task<bool> Delete(Guid id, CancellationToken token)
    {
        await _repository.DeleteAsync(s => s.Id.Equals(id) && s.IsCanBeDeleted.Equals(true));
        return true;
    }

    public async Task<List<RoleViewModel>> GetList(CancellationToken token)
    {
        var roles = await _repository.GetListAsync(false, token);

        return ObjectMapper.Map<List<Role>, List<RoleViewModel>>(roles);
    }
}
