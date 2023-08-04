using System;
using Volo.Abp.Domain.Entities;

namespace Ocelot.Admin.Ocelots.Routes;
public class FileCacheOptions : Entity<Guid>
{
    public int TtlSeconds { get; set; }
}
