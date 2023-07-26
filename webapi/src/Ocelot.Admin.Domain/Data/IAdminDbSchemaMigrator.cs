using System.Threading.Tasks;

namespace Ocelot.Admin.Data;

public interface IAdminDbSchemaMigrator
{
    Task MigrateAsync();
}
