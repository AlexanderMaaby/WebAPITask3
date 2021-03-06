using AutoMapper;
using MovieCharactersWebAPI.Models;
using MovieCharactersWebAPI.Models.DTO;
using MovieCharactersWebAPI.Models.DTO.CharacterDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDTO>().ReverseMap();
            CreateMap<Character, CharacterDTOCreate>().ReverseMap();
        }
    }
}
