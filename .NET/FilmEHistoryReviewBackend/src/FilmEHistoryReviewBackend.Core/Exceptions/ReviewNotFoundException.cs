using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.Core.Exceptions
{
    public class ReviewNotFoundException : Exception
    {
        public ReviewNotFoundException(int id) : base($"No review with id {id} was found")
        {
        }
    }
}
