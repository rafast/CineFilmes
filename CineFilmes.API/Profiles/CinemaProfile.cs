using AutoMapper;
using CineFilmes.API.Data.Dtos.Cinema;
using CineFilmes.API.Models;

namespace CineFilmes.API.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            //source --> targe
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
        }
    }
}
