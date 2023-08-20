using System;
using System.Collections.Generic;
using System.Text;
using OcelotAdmin.Localization;
using Volo.Abp.Application.Services;

namespace OcelotAdmin;

/* Inherit your application services from this class.
 */
public class OcelotAdminAppService : ApplicationService
{
    protected OcelotAdminAppService()
    {
        LocalizationResource = typeof(OcelotAdminResource);
    }
}
