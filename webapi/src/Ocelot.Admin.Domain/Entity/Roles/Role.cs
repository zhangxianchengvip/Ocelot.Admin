using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Ocelot.Admin.Entity.Roles;
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
