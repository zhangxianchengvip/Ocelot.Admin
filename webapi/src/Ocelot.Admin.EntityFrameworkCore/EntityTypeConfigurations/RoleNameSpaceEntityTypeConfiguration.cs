using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocelot.Admin.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.EntityTypeConfigurations;
internal class RoleNameSpaceEntityTypeConfiguration : IEntityTypeConfiguration<RoleNameSpace>
{
    public void Configure(EntityTypeBuilder<RoleNameSpace> builder)
    {
        builder.HasKey(n => new { n.RoleId, n.NameSpaceId });
    }
}
