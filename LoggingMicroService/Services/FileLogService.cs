using LoggingMicroService.Requests;
using Serilog.Context;

namespace LoggingMicroService.Services
{
    public class FileLogService : IFileLogService
    {
        private readonly ILogger<FileLogService> _logger;
        public FileLogService(ILogger<FileLogService> logger) => _logger = logger;
        public void LogMessage(LogMessage logMessage)
        {
            if (logMessage == null) 
                throw new ArgumentNullException(nameof(logMessage));

            using (LogContext.PushProperty("ExternalServiceLog", true))
                _logger.LogInformation($"id: {logMessage?.Id} | date: {logMessage?.Date} | text: {logMessage?.Text}");
        }
    }
}
