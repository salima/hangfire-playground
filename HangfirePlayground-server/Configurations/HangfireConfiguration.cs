using Hangfire;

namespace HangfirePlayground_server.Configurations
{
    public static class HangfireConfiguration
    {
        public static void AddHangfireConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var hangfireSettings = new HangfireSettings();
            configuration.GetSection("Hangfire").Bind(hangfireSettings);

            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(hangfireSettings.ConnectionStrings));

            foreach (var server in hangfireSettings.Servers)
            {
                services.AddHangfireServer(options =>
                {
                    options.ServerName = server.ServerName;
                    options.Queues = server.Queues;
                    options.WorkerCount = server.WorkerCount;
                });
            }
        }
    }
}