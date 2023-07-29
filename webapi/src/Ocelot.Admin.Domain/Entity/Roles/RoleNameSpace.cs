using Ocelot.Admin.Entity.Users;
using Ocelot.Admin.Properties.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Ocelot.Admin.Entity.Roles;
public class RoleNameSpace : ValueObject
{
    public Guid RoleId { get; init; }
    public Guid NameSpaceId { get; init; }
    public int OperationId { get; init; }

    public RoleNameSpace(Guid roleId, Guid nameSpaceId, Operation operationId)
    {
        RoleId = roleId;
        NameSpaceId = nameSpaceId;
        OperationId = operationId;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return new object[] { RoleId, NameSpaceId };
    }
}
