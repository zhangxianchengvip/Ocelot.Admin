using OcelotAdmin.Properties.Enums;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OcelotAdmin.Roles;
public class Role : BasicAggregateRoot<Guid>
{
    public string Name { get; init; }
    public string Desc { get; private set; }
    public bool IsCanBeDeleted { get; init; }
    public ICollection<RoleNameSpace> RoleNameSpaces { get; private set; }
    private Role() { }
    public Role(Guid id, string name, string desc) : base(id)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        Desc = desc;
        IsCanBeDeleted = true;
        RoleNameSpaces = new Collection<RoleNameSpace>();
    }

    internal Role AddRoleNamespace(Guid nameSpaceId, Operation operation)
    {
        if (!RoleNameSpaces.Any(s => s.NameSpaceId.Equals(nameSpaceId)))
        {
            RoleNameSpaces.Add(new RoleNameSpace(Id, nameSpaceId, operation));
        }
        return this;
    }
}
