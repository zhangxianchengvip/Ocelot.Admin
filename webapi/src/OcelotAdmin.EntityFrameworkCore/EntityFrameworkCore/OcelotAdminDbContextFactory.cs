using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OcelotAdmin.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OcelotAdminDbContextFactory : IDesignTimeDbContextFactory<OcelotAdminDbContext>
{
    public OcelotAdminDbContext CreateDbContext(string[] args)
    {
        OcelotAdminEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<OcelotAdminDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new OcelotAdminDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OcelotAdmin.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
