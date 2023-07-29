using Ocelot.Admin.Entity.Configurations.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocelot.Admin.Entity.Configurations.Routes.Downstreams;
using Ocelot.Admin.Entity.Configurations.Routes.Upstreams;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using Volo.Abp.Users;
using Ocelot.Admin.Properties.Enums;

namespace Ocelot.Admin.DomainServices;

public class RouteDomainService : DomainService
{
    private readonly IRepository<Route, Guid> _repository;

    public RouteDomainService(IRepository<Route, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<Route> Create
    (
        Guid nameSpaceId, string name, string desc, Guid creator,
        string upstreamPathTemplate, List<HttpMethod> methods,
        string downstreamPathTemplate, string downatreamScheme, List<(string, int)> downatreamHostAndPort
    )
    {
        await CheckRouteIfHasException(name);

        Route route = new
        (
            id: GuidGenerator.Create(),
            nameSpaceId: nameSpaceId,
            name: name,
            desc: desc,
            upstream: new Upstream
            (
                id: GuidGenerator.Create(),
                pathTemplate: upstreamPathTemplate,
                methods: methods
            ),
            downstream: new Downstream
            (
                id: GuidGenerator.Create(),
                pathTemplate: downstreamPathTemplate,
                scheme: downatreamScheme,
                hostAndPort: downatreamHostAndPort
            ),
            creator: creator
        );

        return await _repository.InsertAsync(route);
    }

    private async Task CheckRouteIfHasException(string name)
    {
        var any = await _repository.AnyAsync(r => r.Name.Equals(name));
        if (any)
        {
            throw new BusinessException(AdminDomainErrorCodes.RouteExist)
            {
                Data =
                {
                    { "name", name }
                }
            };
        }
    }
}