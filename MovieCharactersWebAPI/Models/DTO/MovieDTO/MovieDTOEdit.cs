using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Models.DTO
{
    public class MovieDTOEdit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }
    }
}
