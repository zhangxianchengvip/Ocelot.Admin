using OcelotAdmin.Properties.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OcelotAdmin.Ocelots.Routes;

public class Upstream : Entity<Guid>
{
    public string PathTemplate { get; private set; }
    public ICollection<UpstreamHttpMethod> UpstreamHttpMethod { get; private set; }
    private Upstream() { }
    public Upstream(Guid id, string pathTemplate, List<HttpMethod> methods) : base(id)
    {
        SetUpstream(pathTemplate, methods);
    }

    public Upstream SetUpstream(string pathTemplate, List<HttpMethod> methods)
    {
        PathTemplate = Check.NotNullOrEmpty(pathTemplate, nameof(pathTemplate));
        UpstreamHttpMethod = methods.Select(m => new UpstreamHttpMethod(Id, m)).ToList();
        return this;
    }
}