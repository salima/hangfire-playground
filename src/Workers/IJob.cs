namespace HangfirePlayground.Workers
{
    public interface IJob
    {
        public static string Id { get; }
    }
}