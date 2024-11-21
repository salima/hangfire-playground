using Hangfire;
using HangfirePlayground_client.Workers;

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
            await AddJob("server01_critical");
            await AddJob("server02_critical");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task AddJob(string queue)
        {
            _recurringJobManager.AddOrUpdate<ConsolidacaoDadosRecurringJob>(
               $"{queue}-{ConsolidacaoDadosRecurringJob.Id}",
               queue,
               (x) => x.Iniciar(queue),
               Cron.Daily
           );
        }
    }
}
