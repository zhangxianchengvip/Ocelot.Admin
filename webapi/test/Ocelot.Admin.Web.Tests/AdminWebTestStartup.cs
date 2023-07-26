using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Ocelot.Admin;

public class AdminWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<AdminWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
