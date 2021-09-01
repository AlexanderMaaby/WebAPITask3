using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Alias{ get; set; }
        [MaxLength(50)]
        public string Gender { get; set; }
        [MaxLength(100)]
        public string PictureUrl { get; set; }

        /// <summary>
        /// Many-to-Many relationship between Movie and Character
        /// </summary>
        public ICollection<Movie> Movies { get; set; }

    }
}
