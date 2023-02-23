﻿using System.ComponentModel;

namespace FilmEHistoryReviewBackend.RestAPI.Model
{
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
