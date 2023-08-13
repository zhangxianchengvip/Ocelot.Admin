using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocelot.Admin.Roles;
using Ocelot.Admin.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Admin.EntityTypeConfigurations;
internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property("_password").HasColumnName("Password");
        builder.HasMany(s => s.UserRoles).WithOne().HasForeignKey(s => s.UserId);
    }
}
