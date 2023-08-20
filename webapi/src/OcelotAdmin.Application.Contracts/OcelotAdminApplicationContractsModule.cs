using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace OcelotAdmin;

[DependsOn(
    typeof(OcelotAdminDomainSharedModule),
    typeof(AbpObjectExtendingModule)
)]
public class OcelotAdminApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        OcelotAdminDtoExtensions.Configure();
    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<OcelotAdminApplicationContractsModule>());
        context.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        context.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    }
}
