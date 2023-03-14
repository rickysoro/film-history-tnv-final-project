using FilmEHistoryReviewBackend.Core.Exceptions;
using FilmEHistoryReviewBackend.Core.Models;
using FilmEHistoryReviewBackend.Core.Service;
using FilmEHistoryReviewBackend.DB.Mapper;
using FilmEHistoryReviewBackend.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.DB
{
    public class MySqlStorageService : IStorageService
    {
        ApplicationContext _context;

        public MySqlStorageService()
        {
            _context = new ApplicationContext();
            _context.Database.EnsureCreated();
        }

        public void DeleteReview(int id)
        {
            var reviewToDelete = GetReviewOrFail(id);
            _context.Reviews.Remove(reviewToDelete);
            _context.SaveChanges();
        }

        public List<Review> GetAllReviews()
        {
            return _context.Reviews.Select(reviewEntry => ReviewEntityMapper.From(reviewEntry)).ToList();
        }

        public Review GetReviewById(int id)
        {
            var reviewToGet = GetReviewOrFail(id);
            return ReviewEntityMapper.From(reviewToGet);
        }

        public Review InsertReview(int userId, int movieId, string comment)
        {
            var reviewToInsert = new ReviewEntity
            {
                UserId = userId,
                MovieId = movieId,
                Comment = comment
            };

            _context.Reviews.Add(reviewToInsert);
            _context.SaveChanges();
            return ReviewEntityMapper.From(reviewToInsert);
        }

        public Review UpdateReview(int id, string comment)
        {
            throw new NotImplementedException();
        }

        private ReviewEntity GetReviewOrFail(int reviewId)
        {
            var reviewToFind = _context.Reviews.Find(reviewId);

            if (reviewToFind == null) throw new ReviewNotFoundException(reviewId);
            return reviewToFind;
        }
    }
}
