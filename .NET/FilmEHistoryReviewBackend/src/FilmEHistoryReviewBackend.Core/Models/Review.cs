using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FilmEHistoryReviewBackend.Core.Models
{
    public class Review
    {
        private int _id;
        private int _user_id;
        private int _movie_id;
        private string _comment;

        // Definisco il costruttore di Review   
        public Review(int id, int user_id, int movie_id, string comment) 
        {
            _id = id;
            _user_id = user_id;
            _movie_id = movie_id;
            _comment = comment;
        }

        // Definisco le properties di Review per tutti i suoi attributi
        public int Id 
        { 
            get { return _id; } 
        }

        public int UserId
        { 
            get { return _user_id; } 
            set { _user_id = value; }
        }

        public int MovieId
        { 
            get { return _movie_id; } 
            set { _movie_id = value; } 
        }

        public string Comment
        {
            get { return _comment; } 
            set { _comment = value; } 
        }
    }
}
