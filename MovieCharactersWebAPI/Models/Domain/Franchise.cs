using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Models
{
    
    public class Franchise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        /// <summary>
        /// One-to-Many relationship between Franchise and Movie (many Movie can be apart of one Franchise)
        /// </summary>
        public ICollection<Movie> Movies { get; set; }
    }
}
