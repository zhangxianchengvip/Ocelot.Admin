using Volo.Abp.Modularity;

namespace Ocelot.Admin;

[DependsOn(
    typeof(AdminApplicationModule),
    typeof(AdminDomainTestModule)
    )]
public class AdminApplicationTestModule : AbpModule
{

}
