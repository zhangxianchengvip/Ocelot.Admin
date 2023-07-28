using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Ocelot.Admin.Entity.Configurations.Routes.Upstreams;

public class UpstreamHttpMethod : ValueObject
{
    public UpstreamHttpMethod(Guid id, int httpMethodId)
    {
        Id = id;
        HttpMethodId = httpMethodId;
    }

    public Guid Id { get; set; }
    public int HttpMethodId { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Id;
        yield return HttpMethodId;
    }
}