using AutoMapper;
using MovieCharactersWebAPI.Models;
using MovieCharactersWebAPI.Models.DTO;
using MovieCharactersWebAPI.Models.DTO.MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<Movie, MovieDTOEdit>();
            CreateMap<Movie, MovieDTOCreate>();
            
        }
    }
}
