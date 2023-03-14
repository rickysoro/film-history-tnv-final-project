using FilmEHistoryReviewBackend.Core.Models;
using FilmEHistoryReviewBackend.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.DB.Mapper
{
    // Implemento una classe che mi permetta di tradurre le righe della mia tabella in attributi del mio oggetto
    public class ReviewEntityMapper
    {
        public static Review From(ReviewEntity entity)
        {
            return new Review(entity.Id, entity.UserId, entity.MovieId, entity.Comment);
        }
    }
}
