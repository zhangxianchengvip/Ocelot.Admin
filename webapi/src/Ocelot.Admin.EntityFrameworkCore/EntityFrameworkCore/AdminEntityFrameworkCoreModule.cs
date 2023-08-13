using Microsoft.Extensions.DependencyInjection;
using Ocelot.Admin.Repositorys;
using Ocelot.Admin.Users;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace Ocelot.Admin.EntityFrameworkCore;

[DependsOn(
    typeof(AdminDomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
    )]
public class AdminEntityFrameworkCoreModule : AbpModule
{

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AdminDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });

        context.Services.AddScoped<IUserRepository, UserRepository>();
    }
}
