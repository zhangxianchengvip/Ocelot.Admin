using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotAdmin.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace OcelotAdmin.EntityTypeConfigurations;
public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable($"{OcelotAdminConsts.DbTablePrefix}_UserRoles");
        builder.ConfigureByConvention();
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        builder.Property<Guid>("UserId").IsRequired();
        builder.Property(s => s.RoleId).IsRequired();
    }
}
