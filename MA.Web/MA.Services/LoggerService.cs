using MA.ServiceInterfaces;
using Serilog;
using Serilog.Events;

namespace MA.Services
{
    public class LoggerService : ILoggerService
    {
        readonly ILogger _logger;
        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogFatal(string message)
        {
            _logger.Write(LogEventLevel.Fatal, message);
        }

        public void LogError(string message)
        {
            _logger.Write(LogEventLevel.Error, message);
        }

        public void LogInfo(string message)
        {
            _logger.Write(LogEventLevel.Information, message);
        }

        public void LogWarning(string message)
        {
            _logger.Write(LogEventLevel.Warning, message);
        }

        public void LogDebug(string message)
        {
            _logger.Write(LogEventLevel.Debug, message);
        }
    }
}
