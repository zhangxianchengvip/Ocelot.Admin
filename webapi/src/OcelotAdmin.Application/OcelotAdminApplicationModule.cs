using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace OcelotAdmin;

[DependsOn(
    typeof(OcelotAdminDomainModule),
    typeof(AbpDddApplicationModule),
    typeof(OcelotAdminApplicationContractsModule),
    typeof(AbpAutoMapperModule)
    )]
public class OcelotAdminApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<OcelotAdminApplicationModule>();
        });
    }
}
