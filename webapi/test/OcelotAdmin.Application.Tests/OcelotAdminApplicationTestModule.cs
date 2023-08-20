using Volo.Abp.Modularity;

namespace OcelotAdmin;

[DependsOn(
    typeof(OcelotAdminApplicationModule),
    typeof(OcelotAdminDomainTestModule)
    )]
public class OcelotAdminApplicationTestModule : AbpModule
{

}
