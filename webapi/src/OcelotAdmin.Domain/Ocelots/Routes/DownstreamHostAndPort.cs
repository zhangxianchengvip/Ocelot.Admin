using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace OcelotAdmin.Ocelots.Routes;
public class DownstreamHostAndPort : ValueObject
{
    public string Host { get; set; }
    public int Port { get; set; }
    public DownstreamHostAndPort(string host, int port)
    {
        Host = Check.NotNullOrEmpty(host, nameof(host));
        Port = Check.NotDefaultOrNull<int>(port, nameof(port));
    }



    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return new object[] { Host, Port };
    }
}
