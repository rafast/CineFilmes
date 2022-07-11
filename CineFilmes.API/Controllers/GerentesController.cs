using AutoMapper;
using CineFilmes.API.Data;
using CineFilmes.API.Data.Dtos.Gerente;
using CineFilmes.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerentesController : ControllerBase
    {
        private readonly CineFilmesContext context;
        private readonly IMapper mapper;

        public GerentesController(CineFilmesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/<GerentesController>
        [HttpGet]
        public IActionResult GetGerente()
        {
            List<Gerente> gerente = context.Gerentes.ToList();

            if (gerente is null)
            {
                return NotFound();
            }

            List<ReadGerenteDto> readGerenteDto = mapper.Map<List<ReadGerenteDto>>(gerente);
            return Ok(readGerenteDto);
        }

        // GET api/<GerentesController>/5
        [HttpGet("{id}")]
        public IActionResult GetGerenteById(int id)
        {
            Gerente gerente = context.Gerentes.SingleOrDefault(gerente => gerente.Id == id);

            if (gerente is null)
            {
                return NotFound();
            }

            ReadGerenteDto readGerenteDto = mapper.Map<ReadGerenteDto>(gerente);

            return Ok(readGerenteDto);
        }

        // POST api/<GerentesController>
        [HttpPost]
        public IActionResult CreateGerente([FromBody] CreateGerenteDto createGerenteDto)
        {
            Gerente gerente = mapper.Map<Gerente>(createGerenteDto);
            context.Gerentes.Add(gerente);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetGerenteById), new { id = gerente.Id }, gerente);
        }

        // PUT api/<GerentesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GerentesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
