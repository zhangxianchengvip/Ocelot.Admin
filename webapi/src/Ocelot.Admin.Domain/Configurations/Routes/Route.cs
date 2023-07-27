using Ocelot.Admin.Configurations.Routes.Downstreams;
using Ocelot.Admin.Configurations.Routes.RateLimit;
using Ocelot.Admin.Configurations.Routes.Upstreams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Ocelot.Admin.Configurations.Routes;
public class Route : BasicAggregateRoot<Guid>
{
    private Route() { }
    public Route(Guid id) : base(id)
    {
    }
    public string Name { get; set; }
    public string ServiceName { get; set; }
    public Downstream Downstream { get; set; }
    public Upstream Upstream { get; set; }
    public LoadBalancerOptions LoadBalancerOptions { get; set; }
    public RateLimitOptions RateLimitOptions { get; set; }
    public QoSOptions QoSOptions { get; set; }
    public FileCacheOptions FileCacheOptions { get; set; }

}
