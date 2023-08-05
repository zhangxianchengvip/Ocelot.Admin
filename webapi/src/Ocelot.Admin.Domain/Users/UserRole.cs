using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace Ocelot.Admin.Users;
public class UserRole : Entity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
    public override object[] GetKeys()
    {
        return new object[] { UserId, RoleId };
    }
}
