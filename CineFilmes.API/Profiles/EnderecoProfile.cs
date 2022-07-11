using AutoMapper;
using CineFilmes.API.Data.Dtos.Endereco;
using CineFilmes.API.Models;

namespace CineFilmes.API.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
