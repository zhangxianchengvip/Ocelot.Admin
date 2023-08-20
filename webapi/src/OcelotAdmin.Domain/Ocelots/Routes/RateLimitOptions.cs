using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace OcelotAdmin.Ocelots.Routes;
public class RateLimitOptions : Entity<Guid>
{
    public ClientWhitelist ClientWhitelist { get; set; }
    public bool EnableRateLimiting { get; set; }
    public int Period { get; set; }
    public int PeriodTimespan { get; set; }
    public int Limit { get; set; }
}
