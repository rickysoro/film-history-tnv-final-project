using FilmEHistoryReviewBackend.Core.Exceptions;
using FilmEHistoryReviewBackend.Core.Manager;
using FilmEHistoryReviewBackend.Core.Models;
using FilmEHistoryReviewBackend.Core.Service;
using FilmEHistoryReviewBackend.RestAPI.Mapper;
using FilmEHistoryReviewBackend.RestAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FilmEHistoryReviewBackend.RestAPI.Controllers
{
    // Implemento la classe che mi permette di esporre le chiamate Api della mia applicazione. La classe dovrà estendere la classe ControllerBase
    [ApiController]
    [Route("reviews")]
    public class ReviewController : ControllerBase
    {
        // Dichiaro una variabile di tipi ReviewsManage
        private ReviewManager _reviewManager;

        // Definisco il costruttore nel quale inietto il manager
        public ReviewController(ReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        // Implemento il metodo che visualizza a schermo tutte le review. Il metodo rende codice 200
        [HttpGet]
        public ActionResult<List<ReviewDto>> GetAllReviews() =>
            Ok(_reviewManager.GetAllReviews().Select(review => ReviewDtoMapper.From(review)).ToList());

        // Implemento il metodo che visualizza a schermo una review per id. Il metodo gestisce un'eccezione e restituisce un ReviewDto con codice 200
        [HttpGet]
        [Route("/{review-id}")]
        public ActionResult<ReviewDto> GetReviewById([FromRoute(Name = "review-id")] int id)
        {
            try
            {
                var reviewToGet = _reviewManager.GetReviewById(id);
                return Ok(ReviewDtoMapper.From(reviewToGet));
            }
            catch (ReviewNotFoundException exception)
            {
                return NotFound(new ErrorResponse(exception.Message));
            }
        }

        /*** Implemento il metodo per l'inserimento di una nuova review. Il metodo gestisce un'eccezione, chiama il metodo InsertReview, crea un nuovo uri
         * e lo restituisce insieme a un oggetto ReviewDto con codice 201 ***/
        [HttpPost]
        public ActionResult<ReviewDto> InsertReview([FromBody] ReviewRequest body)
        {
            try
            {
                var reviewToInsert = _reviewManager.InsertReview(body.UserId, body.MovieId, body.Comment);
                var uri = $"/reviews/{reviewToInsert.Id}";
                return Created(uri, ReviewDtoMapper.From(reviewToInsert));
            }
            catch (TextTooShortException exception)
            {
                return BadRequest(new ErrorResponse(exception.Message));
            }
        }

        /*** Implemento il metodo per l'aggiornamento di una review. Il metodo gestisce due eccezioni (commento non trovato e testo troppo corto), 
         * chiama la UpdateReview e restituisce un oggetto ReviewDto con codice 200 ***/
        [HttpPut]
        [Route("/{review-id}")]
        public ActionResult<ReviewDto> UpdateReview([FromRoute(Name = "review-id")] int id, string comment)
        {
            try
            {
                var reviewToUpdate = _reviewManager.UpdateReview(id, comment);
                return Ok(ReviewDtoMapper.From(reviewToUpdate));
            }
            catch (ReviewNotFoundException notFoundException)
            {
                return NotFound(new ErrorResponse(notFoundException.Message));
            }
            catch (TextTooShortException tooShortException)
            {
                return BadRequest(new ErrorResponse(tooShortException.Message));
            }
        }

        /*** Implemento il metodo per la cancellazione di una review. Il metodo chiama la DeleteReview e gestice l'eccezione relativa al commento
        * non trovato. Restituisce true se la cancellazione va a buon fine ***/
        [HttpDelete]
        [Route("/{review-id}")]
        public ActionResult<bool> DeleteReview([FromRoute(Name = "review-id")] int id)
        {
            try 
            {
                _reviewManager.DeleteReview(id);
                return Ok(true);
            }
            catch (ReviewNotFoundException exception)
            {
                return NotFound(new ErrorResponse(exception.Message));
            }
        }
    }
}
