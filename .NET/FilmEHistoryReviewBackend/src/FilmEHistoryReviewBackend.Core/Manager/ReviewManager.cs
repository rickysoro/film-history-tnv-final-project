using FilmEHistoryReviewBackend.Core.Exceptions;
using FilmEHistoryReviewBackend.Core.Models;
using FilmEHistoryReviewBackend.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.Core.Manager
{
    public class ReviewManager
    {
        IStorageService _iStorageService;

        public ReviewManager(IStorageService iStorageService)
        {
            _iStorageService = iStorageService;
        }

        public List<Review> GetAllReviews() => _iStorageService.GetAllReviews();

        public Review GetReviewById(int id) => _iStorageService.GetReviewById(id);

        public Review InsertReview(int userId, int movieId, string comment)
        {
            if (comment.Length < 10) throw new TextTooShortException();
            return _iStorageService.InsertReview(userId, movieId, comment);
        }

        public Review UpdateReview(int id, string comment) => _iStorageService.UpdateReview(id, comment);

        public void DeleteReview(int id) => _iStorageService.DeleteReview(id);
    }
}
