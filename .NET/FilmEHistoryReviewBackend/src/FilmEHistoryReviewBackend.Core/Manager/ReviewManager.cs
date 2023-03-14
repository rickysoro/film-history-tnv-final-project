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
    /*** Definisco la classe che mi consente di gestire la logica di business separandola dalle funzioni di storing, attraverso la dependency injection dell'interfaccia 
     * di storing nel costruttore ***/
    public class ReviewManager
    {
        // Dichiaro l'interfaccia di storing
        IStorageService _iStorageService;

        // Definisco il costruttore della classe. Il costruttore sfrutterà la dependency injection, venendogli passata come argomento l'interfaccia di storing 
        public ReviewManager(IStorageService iStorageService)
        {
            _iStorageService = iStorageService;
        }

        // Implemento il metodo per la visualizzazione a schermo di tutte le review
        public List<Review> GetAllReviews() => _iStorageService.GetAllReviews();

        // Implemento il metodo per la visualizzazione a schermo di una review dato il suo id
        public Review GetReviewById(int id) => _iStorageService.GetReviewById(id);

        /*** Implemento il metodo per l'inserimento della review. Il metodo lancia un'eccezione e chiama la InsertReview dell'InMemoryStorageService attraverso
        * l'IStorageService ***/
        public Review InsertReview(int userId, int movieId, string comment)
        {
            if (comment.Length < 10) throw new TextTooShortException();
            return _iStorageService.InsertReview(userId, movieId, comment);
        }

        /*** Implemento il metodo per l'aggiornamento di una review. Il metodo lancia un'eccezione e chiama la UpdateReview dell'InMemoryStorageService attraverso
         * l'IStorageService ***/
        public Review UpdateReview(int id, string comment)
        {
            if (comment.Length < 10) throw new TextTooShortException();
            return _iStorageService.UpdateReview(id, comment);
        }

        // Implemento il metodo per la cancellazione della review
        public void DeleteReview(int id) => _iStorageService.DeleteReview(id);
    }
}
