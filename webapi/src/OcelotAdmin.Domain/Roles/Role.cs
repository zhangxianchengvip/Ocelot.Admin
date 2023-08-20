using OcelotAdmin.Properties.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OcelotAdmin.Roles;
public class Role : BasicAggregateRoot<Guid>
{
    public string Name { get; init; }
    public string Desc { get; private set; }
    public bool IsCanBeDeleted { get; init; }
    private Role() { }
    public Role(Guid id, string name, string desc) : base(id)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        Desc = desc;
        IsCanBeDeleted = true;
    }
}
