using OcelotAdmin.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace OcelotAdmin;

[DependsOn(
    typeof(OcelotAdminEntityFrameworkCoreTestModule)
    )]
public class OcelotAdminDomainTestModule : AbpModule
{

}
