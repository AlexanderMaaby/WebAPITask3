using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }

        /// <summary>
        /// Many-to-Many relationship between Movie and Character table
        /// </summary>
        public ICollection<Character> Characters { get; set; }
        /// <summary>
        /// One-to-Many relationship between Franchise and Movie
        /// </summary>
        public Franchise Franchise { get; set; }
    }
}
