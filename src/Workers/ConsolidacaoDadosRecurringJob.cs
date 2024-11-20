using Hangfire;
using HangfirePlayground.Workers.Interface;

namespace HangfirePlayground.Workers
{
    public class ConsolidacaoDadosRecurringJob : IJob
    {
        private readonly ILogger<ConsolidacaoDadosRecurringJob> _logger;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public ConsolidacaoDadosRecurringJob(ILogger<ConsolidacaoDadosRecurringJob> logger, IBackgroundJobClient backgroundJobClient)
        {
            _logger = logger;
            _backgroundJobClient = backgroundJobClient;
        }

        public static string Id => "consolidacao-dados";

        public void Iniciar(string queue)
        {
            try
            {
                _logger.LogInformation("Job de consolidação diário iniciado");

                // Lógica do job diário
                Console.WriteLine("Job Diário executado");


                 //Inicia a notificação de email, depois de 2 minutos
                _backgroundJobClient.Schedule<NotificacaoEmailJob>(queue, (x) => x.Iniciar(), TimeSpan.FromMinutes(2));
            }
            catch (Exception ex)
            {
                // Lógica do job diário
                Console.WriteLine("Erro na execução do Job Diário executado");
            }
            finally
            {
                _logger.LogInformation("Job de consolidação diário finalizado");
            }
        }
    }
}
