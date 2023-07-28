using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace Ocelot.Admin;

[DependsOn(
    typeof(AdminDomainSharedModule),
    typeof(AbpObjectExtendingModule)
)]
public class AdminApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AdminDtoExtensions.Configure();
    }
}
