using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ocelot.Admin.Entity.NameSpaces;

namespace Ocelot.Admin.EntityTypeConfigurations;

public class NameSpaceEntityTypeConfiguration : IEntityTypeConfiguration<NameSpace>
{
    public void Configure(EntityTypeBuilder<NameSpace> builder)
    {
        builder.ToTable($"{AdminServiceDbProperties.DbTablePrefix}{nameof(NameSpace)}");
        builder.HasKey(n => n.Id);
        builder.HasIndex(r => r.NId).IsUnique();
    }
}