using Ocelot.Admin.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Ocelot.Admin;

[DependsOn(
    typeof(AdminEntityFrameworkCoreTestModule)
    )]
public class AdminDomainTestModule : AbpModule
{

}
