﻿using OcelotAdmin.Ocelots.Routes;
using OcelotAdmin.Properties.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace OcelotAdmin.Ocelots;

public class RouteManager : DomainService
{
    private readonly IRepository<Route, Guid> _repository;

    public RouteManager(IRepository<Route, Guid> repository)
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
            throw new BusinessException(OcelotAdminDomainErrorCodes.RouteExist)
            {
                Data =
                {
                    { "name", name }
                }
            };
        }
    }
}