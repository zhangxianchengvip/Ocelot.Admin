using OcelotAdmin.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace OcelotAdmin;

[DependsOn(
    typeof(OcelotAdminApplicationContractsModule)
    )]
public class OcelotAdminHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<OcelotAdminResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
