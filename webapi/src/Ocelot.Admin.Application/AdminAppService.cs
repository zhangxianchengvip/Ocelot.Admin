using Ocelot.Admin.Localization;
using Volo.Abp.Application.Services;

namespace Ocelot.Admin;

/* Inherit your application services from this class.
 */
public abstract class AdminAppService : ApplicationService
{
    protected AdminAppService()
    {
        LocalizationResource = typeof(AdminResource);
    }
}
