using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.Configurations.Routes.Downstreams;
public class Downstream
{
    public string DownstreamPathTemplate { get; set; }
    public string DownstreamScheme { get; set; }
    public ICollection<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
}
