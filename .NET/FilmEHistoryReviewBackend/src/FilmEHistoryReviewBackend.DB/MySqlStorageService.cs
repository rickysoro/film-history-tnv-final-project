using FilmEHistoryReviewBackend.Core.Models;
using FilmEHistoryReviewBackend.Core.Service;
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
            throw new NotImplementedException();
        }

        public List<Review> GetAllReviews()
        {
            throw new NotImplementedException();
        }

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
