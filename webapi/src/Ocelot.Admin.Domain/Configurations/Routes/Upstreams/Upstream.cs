using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.Configurations.Routes.Upstreams;
public class Upstream
{
    public string UpstreamPathTemplate { get; set; }
    public ICollection<UpstreamHttpMethod> UpstreamHttpMethod { get; set; }
}
