using FilmEHistoryReviewBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.Core.Service
{
    // Definisco l'interfaccia IStorageService che dichiarerà i metodi per le funzionalità CRUD dell'applicazione
    public interface IStorageService
    {
        public Review InsertReview(int userId, int movieId, string comment);

        public void DeleteReview(int id);

        public List<Review> GetAllReviews();

        public Review GetReviewById(int id);

        public Review UpdateReview(int id, string comment); 
    }
}
