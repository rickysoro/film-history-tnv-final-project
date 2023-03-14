using FilmEHistoryReviewBackend.Core.Models;
using FilmEHistoryReviewBackend.RestAPI.Model;

namespace FilmEHistoryReviewBackend.RestAPI.Mapper
{
    // Implemento una classe che ha il compito di convertire il mio oggetto, in modo da slegarlo dall'implementazione che ne faccio nel progetto Core
    public class ReviewDtoMapper
    {
        // Definisco il costruttore che traduce l'oggetto di tipo Review e i suoi attributi in ReviewDto
        public static ReviewDto From(Review review) => new ReviewDto
        {
            Id = review.Id,
            UserId = review.UserId,
            MovieId = review.MovieId,
            Comment = review.Comment,
        };
    }
}
