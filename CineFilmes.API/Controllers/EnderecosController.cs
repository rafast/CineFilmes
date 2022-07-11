using AutoMapper;
using CineFilmes.API.Data;
using CineFilmes.API.Data.Dtos.Endereco;
using CineFilmes.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CineFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly CineFilmesContext context;
        private readonly IMapper mapper;

        public EnderecosController(CineFilmesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromBody] CreateEnderecoDto createEnderecoDto)
        {
            Endereco endereco = mapper.Map<Endereco>(createEnderecoDto);
            context.Enderecos.Add(endereco);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetEnderecoById), new { id = endereco.Id }, endereco);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnderecoById(int id)
        {
            Endereco existingEndereco = context.Enderecos.SingleOrDefault(endereco => endereco.Id == id);

            if (existingEndereco is null)
            {
                return NotFound();
            }

            ReadEnderecoDto readEnderecoDto = mapper.Map<ReadEnderecoDto>(existingEndereco);

            return Ok(readEnderecoDto);
        }

        [HttpGet]
        public IActionResult GetEndereco()
        {
            List<Endereco> enderecos = context.Enderecos.ToList();

            if (enderecos is null)
            {
                return NotFound();
            }

            List<ReadEnderecoDto> enderecosDto = mapper.Map<List<ReadEnderecoDto>>(enderecos);
            return Ok(enderecosDto);
        }
    }
}
