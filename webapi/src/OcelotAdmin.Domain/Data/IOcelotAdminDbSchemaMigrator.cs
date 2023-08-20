using System.Threading.Tasks;

namespace OcelotAdmin.Data;

public interface IOcelotAdminDbSchemaMigrator
{
    Task MigrateAsync();
}
