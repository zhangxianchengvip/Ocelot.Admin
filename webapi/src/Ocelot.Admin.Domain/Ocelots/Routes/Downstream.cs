using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Ocelot.Admin.Ocelots.Routes;
public class Downstream : Entity<Guid>
{
    public string PathTemplate { get; private set; }
    public string Scheme { get; private set; }
    public ICollection<DownstreamHostAndPort> HostAndPorts { get; set; }
    private Downstream()
    {
    }

    internal Downstream(Guid id, string pathTemplate, string scheme, List<(string, int)> hostAndPort) : base(id)
    {
        SetDownstream(pathTemplate, scheme, hostAndPort);
    }

    internal Downstream SetDownstream(string pathTemplate, string scheme, List<(string, int)> HostAndPort)
    {
        PathTemplate = Check.NotNullOrEmpty(pathTemplate, nameof(pathTemplate));
        Scheme = Check.NotNullOrEmpty(scheme, nameof(scheme));
        HostAndPorts = HostAndPort.Select(hp => new DownstreamHostAndPort(hp.Item1, hp.Item2)).ToList();
        return this;
    }

}
