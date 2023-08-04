using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Ocelot.Admin.Users;
public class UserRole : ValueObject
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return new object[] { UserId, RoleId };
    }
}
