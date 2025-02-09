using LoggingMicroService.Requests;

namespace LoggingMicroService.Services
{
    public interface IFileLogService
    {
        void LogMessage(LogMessage logMessage);
    }
}
