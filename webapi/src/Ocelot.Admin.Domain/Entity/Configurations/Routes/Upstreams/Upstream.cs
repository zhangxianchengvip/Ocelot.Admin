using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Ocelot.Admin.Entity.Configurations.Routes.Upstreams;

public class Upstream : Entity<Guid>
{
    public string PathTemplate { get; private set; }
    public ICollection<UpstreamHttpMethod> UpstreamHttpMethod { get; private set; }

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