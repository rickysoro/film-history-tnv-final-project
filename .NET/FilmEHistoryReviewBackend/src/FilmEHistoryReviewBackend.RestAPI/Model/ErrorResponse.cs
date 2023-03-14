using System.ComponentModel;

namespace FilmEHistoryReviewBackend.RestAPI.Model
{
    // Definisco una classe che mi consente di identificare gli errori
    public class ErrorResponse
    {
        [DisplayName("error_message")]
        public string Message { get; set; }

        [DisplayName("timestamp")]
        public DateTime Timestamp { get; set; }
        
        public ErrorResponse(string message)
        {
            this.Message = message;
            this.Timestamp = DateTime.Now;
        }
    }
}
