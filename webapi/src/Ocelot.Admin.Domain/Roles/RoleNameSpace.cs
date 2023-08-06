using Ocelot.Admin.Properties.Enums;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;
using Volo.Abp.Uow;

namespace Ocelot.Admin.Roles;
public class RoleNameSpace : Entity
{
    public Guid RoleId { get; init; }
    public Guid NameSpaceId { get; init; }
    public int OperationId { get; init; }
    private RoleNameSpace() { }
    public RoleNameSpace(Guid roleId, Guid nameSpaceId, Operation operationId)
    {
        RoleId = roleId;
        NameSpaceId = nameSpaceId;
        OperationId = operationId;
    }

    public override object[] GetKeys()
    {
        return new object[] { new { RoleId, NameSpaceId } };
    }
}
