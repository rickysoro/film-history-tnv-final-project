using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.Core.Exceptions
{
    public class TextTooShortException : Exception
    {
        public TextTooShortException() : base("Text is too short. Insert a 10 carachter-long review at least") 
        { 
        }
    }
}
