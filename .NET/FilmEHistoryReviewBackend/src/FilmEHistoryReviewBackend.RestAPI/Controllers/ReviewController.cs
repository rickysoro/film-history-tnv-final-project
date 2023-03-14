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
    [ApiController]
    [Route("reviews")]
    public class ReviewController : ControllerBase
    {
        private ReviewManager _reviewManager;

        public ReviewController(ReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        [HttpGet]
        public ActionResult<List<ReviewDto>> GetAllReviews() =>
            Ok(_reviewManager.GetAllReviews().Select(review => ReviewDtoMapper.From(review)).ToList());

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
