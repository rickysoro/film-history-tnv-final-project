using System.ComponentModel;

namespace FilmEHistoryReviewBackend.RestAPI.Model
{
    // Implemento una classe in grado di filtrare le informazioni dell'oggetto che voglio mostrare all'esterno
    public class ReviewDto
    {
        [DisplayName("id")]
        public int Id { get; set; }

        [DisplayName("user_id")]
        public int UserId { get; set; }

        [DisplayName("movie_id")]
        public int MovieId { get; set; }

        [DisplayName("comment")]
        public string Comment { get; set; }
    }
}