using FilmEHistoryReviewBackend.Core.Models;
using FilmEHistoryReviewBackend.RestAPI.Model;

namespace FilmEHistoryReviewBackend.RestAPI.Mapper
{
    public class ReviewDtoMapper
    {
        public static ReviewDto From(Review review) => new ReviewDto
        {
            Id = review.Id,
            UserId = review.UserId,
            MovieId = review.MovieId,
            Comment = review.Comment,
        };
    }
}
