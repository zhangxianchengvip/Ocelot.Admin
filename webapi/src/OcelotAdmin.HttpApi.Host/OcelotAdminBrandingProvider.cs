using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace OcelotAdmin;

[Dependency(ReplaceServices = true)]
public class OcelotAdminBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "OcelotAdmin";
}
