using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Ocelot.Admin;

[DependsOn(
    typeof(AdminDomainModule),
    typeof(AbpAutoMapperModule),
    typeof(AdminApplicationContractsModule)

    )]
public class AdminApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AdminApplicationModule>();
        });
    }
}
