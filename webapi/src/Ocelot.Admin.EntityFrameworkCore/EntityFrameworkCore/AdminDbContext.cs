using Microsoft.EntityFrameworkCore;
using Ocelot.Admin.Entity.Configurations.Routes;
using Ocelot.Admin.Entity.NameSpaces;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace Ocelot.Admin.EntityFrameworkCore;

[ConnectionStringName(AdminConsts.ConnectionStringName)]
public class AdminDbContext : AbpDbContext<AdminDbContext>
{
    public DbSet<NameSpace> NameSpaces { get; set; }

    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}