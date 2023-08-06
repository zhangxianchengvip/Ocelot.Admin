using Ocelot.Admin.Properties.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Ocelot.Admin.Roles;
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
        //RoleNameSpaces = new Collection<RoleNameSpace>();
    }

    public Role AddRoleNameSpace(Guid nameSpaceId, Operation operationId)
    {
        //if (!RoleNameSpaces.Any(s => s.NameSpaceId.Equals(nameSpaceId)))
        //{
        //    RoleNameSpaces.Add(new RoleNameSpace(Id, nameSpaceId, operationId));
        //}
        return this;
    }
}
