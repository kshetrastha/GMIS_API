namespace gmis.API.Configuration
{
    public static class Startup
    {
        internal static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, config) =>
            {
                const string configurationsDirectory = "Configuration";
                var env = context.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/database.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/security.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/swagger.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/serilogConfig.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
            });
            return host;
        }
    }
}
