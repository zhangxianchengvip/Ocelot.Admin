using OcelotAdmin.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling;
using Volo.Abp.AspNetCore.Mvc;

namespace OcelotAdmin.Controllers;

/* Inherit your controllers from this class.
 */
[ApiController]
[Route("api/v1/[Controller]")]
public class OcelotAdminController : AbpControllerBase
{
    public OcelotAdminController()
    {
        LocalizationResource = typeof(OcelotAdminResource);
    }

    [HttpGet]
    public IActionResult GetCounts()
    {

        return Ok(true);
    }
}
