﻿using Hangfire;
using HangfirePlayground.Workers.Interface;

namespace HangfirePlayground.Workers
{
    public class NotificacaoEmailJob : IJob
    {
        private readonly ILogger<NotificacaoEmailJob> _logger;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public NotificacaoEmailJob(ILogger<NotificacaoEmailJob> logger, IBackgroundJobClient backgroundJobClient)
        {
            _logger = logger;
            _backgroundJobClient = backgroundJobClient;
        }
        public static string Id => "notificacao-email";

        public void Iniciar()
        {
            try
            {
                _logger.LogInformation("Job de notificação de e-mail iniciado");

                // Lógica do job diário
                Console.WriteLine("Job Diário executado");

                _logger.LogInformation("Job de notificação de e-mail finalizado");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Job de notificação de e-mail finalizado");

                // Lógica do job diário
                Console.WriteLine("Erro na execução do Job notificação de e-mail");
            }
        }
    }
}
