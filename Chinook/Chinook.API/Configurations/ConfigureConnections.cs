using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

//using Chinook.Data;
using Chinook.DataCmpldQry;
using Chinook.DataPostgres;

namespace Chinook.API.Configurations;

public static class ConfigureConnections
{
    public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connection = String.Empty;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            connection = configuration.GetConnectionString("ChinookDbWindows");
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            connection = configuration.GetConnectionString("ChinookDbDocker");

        services.AddDbContextPool<ChinookContext>(options => options.UseSqlServer(connection));
        services.AddSingleton(new SqlConnection(connection));
        
        var connectionPostgres = configuration.GetConnectionString("ChinookPostgres");
        services.AddDbContextPool<ChinookPostgresContext>(options => options.UseSqlServer(connectionPostgres));

        return services;
    }
}