using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotAdmin.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace OcelotAdmin.EntityTypeConfigurations;
public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable($"{OcelotAdminConsts.DbTablePrefix}_Roles");
        builder.ConfigureByConvention();
        builder.HasIndex(s => s.Id);
    }
}
