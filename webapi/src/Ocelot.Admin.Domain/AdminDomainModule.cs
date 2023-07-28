using Volo.Abp.Modularity;

namespace Ocelot.Admin;

[DependsOn(
    typeof(AdminDomainSharedModule)
)]
public class AdminDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
