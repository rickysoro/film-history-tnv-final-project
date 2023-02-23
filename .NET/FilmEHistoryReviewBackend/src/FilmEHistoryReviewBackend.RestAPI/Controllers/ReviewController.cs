using FilmEHistoryReviewBackend.Core.Exceptions;
using FilmEHistoryReviewBackend.Core.Manager;
using FilmEHistoryReviewBackend.Core.Models;
using FilmEHistoryReviewBackend.Core.Service;
using FilmEHistoryReviewBackend.RestAPI.Mapper;
using FilmEHistoryReviewBackend.RestAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilmEHistoryReviewBackend.RestAPI.Controllers
{
    [ApiController]
    [Route("reviews")]
    public class ReviewController : ControllerBase
    {
        private IStorageService _iStorageService;
        private ReviewManager _reviewManager;

        public ReviewController()
        {
            _iStorageService = new InMemoryStorageService();
            _reviewManager = new ReviewManager(_iStorageService);
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
    }
}
