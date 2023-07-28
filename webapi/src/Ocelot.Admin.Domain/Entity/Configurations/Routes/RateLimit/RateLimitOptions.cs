using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.Entity.Configurations.Routes.RateLimit;
public class RateLimitOptions
{
    public ClientWhitelist ClientWhitelist { get; set; }
    public bool EnableRateLimiting { get; set; }
    public int Period { get; set; }
    public int PeriodTimespan { get; set; }
    public int Limit { get; set; }
}
