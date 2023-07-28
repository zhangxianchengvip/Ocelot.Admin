using System;
using Volo.Abp.Domain.Entities;

namespace Ocelot.Admin.Entity.Configurations.Routes;
public class FileCacheOptions : Entity<Guid>
{
    public int TtlSeconds { get; set; }
}
