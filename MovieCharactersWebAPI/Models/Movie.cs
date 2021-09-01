using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Models
{
    [Table("Movie")]
    public class Movie
    {
        //PK
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Genre { get; set; }
        
        public int ReleaseYear { get; set; }
        [MaxLength(100)]
        public string PictureUrl { get; set; }
        [MaxLength(100)]
        public string TrailerUrl { get; set; }

        /// <summary>
        /// Many-to-Many relationship between Movie and Character table
        /// </summary>
        public ICollection<Character> Characters { get; set; }
        /// <summary>
        /// One-to-Many relationship between Franchise and Movie
        /// </summary>
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
    }
}
