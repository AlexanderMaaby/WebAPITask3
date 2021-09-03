using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Models.DTO.CharacterDTO
{
    public class CharacterDTOCreate
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }

    }
}
