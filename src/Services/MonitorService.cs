
using Hangfire;
using HangfirePlayground.Workers;

namespace HangfirePlayground.Services
{
    public class MonitorService : IHostedService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public MonitorService(IRecurringJobManager recurringJobManager, IBackgroundJobClient backgroundJobClient)
        {
            _recurringJobManager = recurringJobManager;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
           await AddJobs();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task AddJobs()
        {
            _recurringJobManager.AddOrUpdate<ConsolidacaoDadosRecurringJob>(
               ConsolidacaoDadosRecurringJob.Id,
               (x) => x.Iniciar(),
               Cron.Daily
           );

        }
    }
}
