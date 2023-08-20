using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace OcelotAdmin.Ocelots.Routes;

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