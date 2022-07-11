using AutoMapper;
using CineFilmes.API.Data.Dtos.Filme;
using CineFilmes.API.Models;

namespace CineFilmes.API.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
