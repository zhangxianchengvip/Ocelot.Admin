using System;
using Volo.Abp.Domain.Entities;

namespace OcelotAdmin.Ocelots.Routes;
public class FileCacheOptions : Entity<Guid>
{
    public int TtlSeconds { get; set; }
}
