using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcelotAdmin.Users;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace OcelotAdmin.EntityFrameworkCore;

[DependsOn(
    typeof(OcelotAdminDomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
    )]
public class OcelotAdminEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        OcelotAdminEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<OcelotAdminDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also OcelotAdminMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });

        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<User>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query.Include(o => o.UserRoles);
            });
        });
    }
}
