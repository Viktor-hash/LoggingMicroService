using System.ComponentModel.DataAnnotations;

namespace LoggingMicroService.Requests
{
    public class LogMessage
    {
        [Required]
        public DateOnly? Date { get; set; }
        [Required]
        public int? Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Text { get; set; } = string.Empty;
    }
}
