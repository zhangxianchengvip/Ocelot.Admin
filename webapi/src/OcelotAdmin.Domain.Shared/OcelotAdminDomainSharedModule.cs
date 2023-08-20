using Auto.Options;
using Microsoft.Extensions.DependencyInjection;
using OcelotAdmin.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace OcelotAdmin;

[DependsOn(
    typeof(AbpValidationModule)
    )]
public class OcelotAdminDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        OcelotAdminGlobalFeatureConfigurator.Configure();
        OcelotAdminModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoOptions(context.Services.GetConfiguration());

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OcelotAdminDomainSharedModule>(baseNamespace: "OcelotAdmin");
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<OcelotAdminResource>("zh-Hans")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/OcelotAdmin");

            options.DefaultResourceType = typeof(OcelotAdminResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("OcelotAdmin.Exception", typeof(OcelotAdminResource));
        });
    }
}
