
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Ocelot.Admin.Ocelots.Routes;
public class LoadBalancerOptions : Entity<Guid>
{
    public string Type { get; set; }
    public string Key { get; set; }
    public int Expiry { get; set; }

    internal LoadBalancerOptions SetType(string type)
    {
        Type = Check.NotNullOrEmpty(type, nameof(type));
        return this;
    }
}
