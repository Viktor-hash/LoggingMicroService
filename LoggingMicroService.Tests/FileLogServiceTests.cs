// File: LoggingMicroService.Tests/Services/FileLogServiceTests.cs
using LoggingMicroService.Requests;
using LoggingMicroService.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Serilog.Context;

namespace LoggingMicroService.Tests.Services
{
    [TestFixture]
    public class FileLogServiceTests
    {
        private Mock<ILogger<FileLogService>> _mockLogger;
        private FileLogService _fileLogService;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<FileLogService>>();
            _fileLogService = new FileLogService(_mockLogger.Object);
        }

        [Test]
        public void LogMessage_NullLogMessage_ThrowsArgumentNullException()
        {
            // Arrange
            LogMessage? logMessage = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _fileLogService.LogMessage(logMessage!));
        }

        [Test]
        public void LogMessage_ValidLogMessage_LogsInformation()
        {
            // Arrange
            var logMessage = new LogMessage
            {
                Id = 1,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Text = "Test log message"
            };

            // Act
            _fileLogService.LogMessage(logMessage);

            // Assert
            _mockLogger.Verify(x => x.Log(LogLevel.Information,
               It.IsAny<EventId>(),
               It.Is<It.IsAnyType>((v, t) => v != null && v.ToString()!.Contains($"id: {logMessage.Id} | date: {logMessage.Date} | text: {logMessage.Text}")),
               It.IsAny<Exception?>(),
               (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
               Times.Once);
        }
    }
}

