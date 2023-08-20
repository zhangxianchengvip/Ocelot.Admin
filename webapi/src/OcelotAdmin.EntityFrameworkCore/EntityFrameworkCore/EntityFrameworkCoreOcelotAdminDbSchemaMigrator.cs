using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcelotAdmin.Data;
using Volo.Abp.DependencyInjection;

namespace OcelotAdmin.EntityFrameworkCore;

public class EntityFrameworkCoreOcelotAdminDbSchemaMigrator
    : IOcelotAdminDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOcelotAdminDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the OcelotAdminDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<OcelotAdminDbContext>()
            .Database
            .MigrateAsync();
    }
}
