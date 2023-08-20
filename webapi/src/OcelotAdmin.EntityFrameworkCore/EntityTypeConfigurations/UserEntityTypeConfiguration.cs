using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OcelotAdmin.Roles;
using OcelotAdmin.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace OcelotAdmin.EntityTypeConfigurations;
public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable($"{OcelotAdminConsts.DbTablePrefix}_Users");
        builder.ConfigureByConvention();
        builder.HasIndex(s => s.Id);
        builder.Property("_password").HasColumnName("Password");
        builder.Navigation(q => q.UserRoles).UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}
