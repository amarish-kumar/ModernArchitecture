namespace MA.ServiceInterfaces
{
    public interface ILoggerService
    {
        void LogFatal(string message);
        void LogError(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogDebug(string message);
    }
}
