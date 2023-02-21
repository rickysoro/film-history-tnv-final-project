using FilmEHistoryReviewBackend.Core.Exceptions;
using FilmEHistoryReviewBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.Core.Service
{
    /*** Definisco la classe adibita inizialmente allo storing delle informazioni e alla logica di business. La classe dovrà estendere lo storage service per poter
     * implementare i metodi CRUD ***/
    public class InMemoryStorageService : IStorageService
    {
        // Dichiaro una lista che dovrà contenere le review
        public List<Review> _reviews;

        // Definisco il costruttore della classe
        public InMemoryStorageService()
        {
            _reviews = new List<Review>();
        }

        /*** Implemento il metodo per la cancellazione di una review. Il metodo chiama a sua volta FindReviewByIdOrFail che in caso di successo individua l'elemento
         * per id. Infine la review viene rimosso dalla lista ***/
        public void DeleteReview(int id)
        {
            var reviewToDelete = FindReviewByIdOrFail(id);
            _reviews.Remove(reviewToDelete);
        }

        /*** Implemento il metodo per l'individuazione di un elemento della lista per id. Se l'elemento nella lista è presente, l'individuazione ha successo e il metodo
         * restituisce l'elemento richiesto. Se l'elemento non è presente nella lista, il metodo lancia un'eccezione ***/
        private Review FindReviewByIdOrFail(int id) 
        {
            var reviewToFind = _reviews.FirstOrDefault(review => review.Id == id);
            if (reviewToFind == null) throw new ReviewNotFoundException(id);
            return reviewToFind;
        }

        // Implemento il metodo per la visualizzazione a schermo di tutti gli elementi della lista
        public List<Review> GetAllReviews() => _reviews;

        /*** Implemento il metodo per la visualizzazione a schermo di un elemento per id. Il metodo chiama FindReviewByIdOrFail che in caso di successo restituisce 
         * l'elemento richiesto ***/
        public Review GetReviewById(int id) => FindReviewByIdOrFail(id);

        /*** Implemento il metodo per l'inserimento di una nuova review. Il metodo chiama a sua volta il metodo per la generazione dell'id, crea una nuova review
         * con l'id appena generato, lo userId, il movieId e il testo del commento, assegnandolo a una variabile. La variabile appena creata viene aggiunta alla lista.
         * Infine il metodo restituisce la variabile ***/
        public Review InsertReview(int userId, int movieId, string comment)
        {
            var id = GenerateId();
            var reviewToInsert = new Review(id, userId, movieId, comment);
            _reviews.Add(reviewToInsert);
            return reviewToInsert;
        }

        /*** Implemento il metodo per la generazione dell'id. Se la lista è vuota il metodo rende 1, altrimenti crea una nuova review
         * individuando l'elemento con id massimo e aggiungendo 1 ***/
        private int GenerateId()
        {
            if (_reviews.Count == 0) return 1;
            return _reviews.Select(_review => _review.Id).Max() + 1;
        }

        /*** Implemento il metodo per l'aggiornamento della review. Il metodo chiama FindReviewByIdOrFail, assegna il valore a una variabile, cambia l'attributo
         * relativo al testo del commento (comment) della variabile e la restituisce aggiornata ***/
        public Review UpdateReview(int id, string comment)
        {
            var reviewToUpdate = FindReviewByIdOrFail(id);
            reviewToUpdate.Comment = comment;  
            return reviewToUpdate;
        }
    }
}
