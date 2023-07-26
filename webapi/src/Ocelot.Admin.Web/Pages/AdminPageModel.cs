using Ocelot.Admin.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ocelot.Admin.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AdminPageModel : AbpPageModel
{
    protected AdminPageModel()
    {
        LocalizationResourceType = typeof(AdminResource);
    }
}
