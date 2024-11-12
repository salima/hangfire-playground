using Hangfire;

namespace HangfirePlayground.Workers
{
    public class JobConfigurations
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public JobConfigurations(IRecurringJobManager recurringJobManager, IBackgroundJobClient backgroundJobClient)
        {
            _recurringJobManager = recurringJobManager;
            _backgroundJobClient = backgroundJobClient;
        }

        // Método que configura todos os jobs
        public void ConfigureJobs()
        {
            _recurringJobManager.AddOrUpdate<ConsolidacaoDadosRecurringJob>(
                ConsolidacaoDadosRecurringJob.Id,
                (x) => x.Iniciar(),
                Cron.Daily
            );
          
            // Configurando um job com atraso de 2 minutos
            _backgroundJobClient.Schedule<NotificacaoEmailJob>((x) => x.Iniciar(), TimeSpan.FromMinutes(2));
        }
    }
}
