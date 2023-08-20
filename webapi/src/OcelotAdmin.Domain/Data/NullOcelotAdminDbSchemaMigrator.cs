using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OcelotAdmin.Data;

/* This is used if database provider does't define
 * IOcelotAdminDbSchemaMigrator implementation.
 */
public class NullOcelotAdminDbSchemaMigrator : IOcelotAdminDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
