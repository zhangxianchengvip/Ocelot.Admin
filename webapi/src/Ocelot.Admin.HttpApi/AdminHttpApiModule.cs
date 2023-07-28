using Ocelot.Admin.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Ocelot.Admin;

[DependsOn(
    typeof(AdminApplicationContractsModule)

    )]
public class AdminHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }


}
