using Ocelot.Admin.Properties.Enums;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Ocelot.Admin.Ocelots.Routes;

public class Route : BasicAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Desc { get; private set; }
    public Guid NamespaceId { get; set; }
    public Guid Creator { get; init; }
    public DateTime CreeteTime { get; init; }
    public Guid Updater { get; set; }
    public DateTime UpdateTime { get; set; }
    public string ServiceName { get; private set; }
    public Upstream Upstream { get; private set; }
    public Downstream Downstream { get; private set; }
    public LoadBalancerOptions LoadBalancerOptions { get; private set; }
    public RateLimitOptions RateLimitOptions { get; private set; }
    public QoSOptions QoSOptions { get; private set; }
    public FileCacheOptions FileCacheOptions { get; private set; }
    private Route()
    {
    }

    internal Route(Guid id, Guid nameSpaceId, string name, string desc, Upstream upstream, Downstream downstream, Guid creator) : base(id)
    {
        Upstream = upstream;
        Downstream = downstream;
        Name = Check.NotNullOrEmpty(name, nameof(name));
        Desc = desc;
        Creator = creator;
        CreeteTime = DateTime.Now;
        SetUpdater(creator);
        NamespaceId = Check.NotDefaultOrNull<Guid>(nameSpaceId, nameof(nameSpaceId));
    }



    internal Route SetUpstream(string pathTemplate, List<HttpMethod> methods)
    {
        Upstream.SetUpstream(pathTemplate, methods);
        return this;
    }

    internal Route SetDownstream(string pathTemplate, string scheme, List<(string, int)> HostPort)
    {
        Downstream.SetDownstream(pathTemplate, scheme, HostPort);
        return this;
    }

    internal void SetUpdater(Guid updater)
    {
        Updater = updater;
        UpdateTime = DateTime.Now;
    }

    internal void SetServiceName(string serviceName)
    {
        ServiceName = Check.NotNullOrEmpty(serviceName, nameof(serviceName));
    }
}