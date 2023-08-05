using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ocelot.Admin.EntityTypeConfigurations;
using Ocelot.Admin.NameSpaces;
using Ocelot.Admin.Roles;
using Ocelot.Admin.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Ocelot.Admin.EntityFrameworkCore;

[ConnectionStringName(AdminConsts.ConnectionStringName)]
public class AdminDbContext : AbpDbContext<AdminDbContext>
{
    public DbSet<NameSpace> NameSpaces { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new NameSpaceEntityTypeConfiguration());

        // 从当前程序集加载所有IEntityTypeConfiguration
        builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        // 统一添加前缀
        foreach (IMutableEntityType entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName($"{AdminConsts.DbTablePrefix}{entity.GetTableName()}");
        }
    }
}