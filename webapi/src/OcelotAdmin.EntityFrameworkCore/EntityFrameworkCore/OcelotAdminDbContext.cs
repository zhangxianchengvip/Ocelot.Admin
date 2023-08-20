using OcelotAdmin.Tests;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using OcelotAdmin.Roles;
using OcelotAdmin.Users;
using OcelotAdmin.EntityTypeConfigurations;

namespace OcelotAdmin.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class OcelotAdminDbContext : AbpDbContext<OcelotAdminDbContext>
{

    #region Entities from the modules

    public virtual DbSet<Test> Tests { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    #endregion

    public OcelotAdminDbContext(DbContextOptions<OcelotAdminDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Test>().ToTable($"{OcelotAdminConsts.DbTablePrefix}_Tests");
        builder.ApplyConfiguration(new RoleEntityTypeConfiguration());
        builder.ApplyConfiguration(new UserEntityTypeConfiguration());
        builder.ApplyConfiguration(new UserRoleEntityTypeConfiguration());
    }
}
