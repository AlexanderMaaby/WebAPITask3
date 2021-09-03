using AutoMapper;
using MovieCharactersWebAPI.Models;
using MovieCharactersWebAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersWebAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseDTO>().ReverseMap();
            CreateMap<Franchise, FranchiseDTOEdit>().ReverseMap();
            CreateMap<Franchise, FranchiseDTOCreate>().ReverseMap();
        }
    }
}
