namespace HangfirePlayground.Configurations
{
    public class HangfireSettings
    {
        public string ConnectionStrings { get; set; }
        public IList<HangfireServerSettings> Servers { get; set; }
    }

    public class HangfireServerSettings
    {
        public string[] Queues { get; set; }
        public string ServerName { get; set; }
        public int WorkerCount { get; set; }
    }
}