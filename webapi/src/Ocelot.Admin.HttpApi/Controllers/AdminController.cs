﻿using Ocelot.Admin.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Ocelot.Admin.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AdminController : AbpControllerBase
{
    protected AdminController()
    {
        LocalizationResource = typeof(AdminResource);
    }
}
