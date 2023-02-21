using FilmEHistoryReviewBackend.Core.Exceptions;
using FilmEHistoryReviewBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.Core.Service
{
    public class InMemoryStorageService : IStorageService
    {
        public List<Review> _reviews;

        public InMemoryStorageService()
        {
            _reviews = new List<Review>();
        }

        public void DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        private Review FindReviewByIdOrFail(int id) 
        {
            var reviewToFind = _reviews.FirstOrDefault(review => review.Id == id);
            if (reviewToFind == null) throw new ReviewNotFoundException(id);
            return reviewToFind;
        }

        public List<Review> GetAllReviews() => _reviews;

        public Review GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public Review InsertReview(int userId, int movieId, string comment)
        {
            throw new NotImplementedException();
        }

        public Review UpdateReview(int id, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
