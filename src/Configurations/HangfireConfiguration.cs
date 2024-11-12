using Hangfire;

namespace HangfirePlayground.Configurations
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
        }
    }
}