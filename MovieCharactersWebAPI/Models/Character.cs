using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string Alias{ get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }

        /// <summary>
        /// Many-to-Many relationship between Movie and Character
        /// </summary>
        public ICollection<Movie> Movies { get; set; }

    }
}
