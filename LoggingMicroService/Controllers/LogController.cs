using LoggingMicroService.Requests;
using LoggingMicroService.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LoggingMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {

        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Logs a message to the file log service.
        /// </summary>
        /// <param name="logMessage">The log message to be logged.</param>
        /// <param name="fileLogService">The file log service to log the message.</param>
        /// <returns>Returns Ok if the message is logged successfully, otherwise returns an error status code.</returns>
        /// <response code="200">If the message is logged successfully.</response>
        /// <response code="500">If there is an internal server error.</response>
        [HttpPost(Name = "PostLogMessage")]
        public IActionResult PostLogMessage([FromBody][Required] LogMessage logMessage, [FromServices] IFileLogService fileLogService)
        {
            try
            {
                fileLogService.LogMessage(logMessage);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging message");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
