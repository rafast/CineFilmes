using AutoMapper;
using CineFilmes.API.Data.Dtos.Gerente;
using CineFilmes.API.Models;

namespace CineFilmes.API.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas
                .Select(cine => new { cine.Id, cine.Nome, cine.Endereco, cine.EnderecoId })));
        }
    }
}
