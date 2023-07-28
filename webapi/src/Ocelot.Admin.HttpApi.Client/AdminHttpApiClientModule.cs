using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Ocelot.Admin;

[DependsOn(
    typeof(AdminApplicationContractsModule)
)]
public class AdminHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<AdminHttpApiClientModule>(); });
    }
}