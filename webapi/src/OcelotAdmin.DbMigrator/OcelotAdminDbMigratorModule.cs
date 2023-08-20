using OcelotAdmin.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace OcelotAdmin.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OcelotAdminEntityFrameworkCoreModule),
    typeof(OcelotAdminApplicationContractsModule)
    )]
public class OcelotAdminDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
