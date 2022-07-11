using AutoMapper;
using CineFilmes.API.Data;
using CineFilmes.API.Data.Dtos.Filme;
using CineFilmes.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly CineFilmesContext context;
        private readonly IMapper mapper;

        // GET: api/<FilmesController>
        [HttpGet]
        public IActionResult GetFilme()
        {
            List<Filme> filmes = context.Filmes.ToList();

            if (filmes is null)
            {
                return NotFound();
            }

            List<ReadFilmeDto> readFilmeDto = mapper.Map<List<ReadFilmeDto>>(filmes);

            return Ok(readFilmeDto);
        }

        // GET api/<FilmesController>/5
        [HttpGet("{id}")]
        public IActionResult GetFilmeById(int id)
        {
            Filme filme = context.Filmes.SingleOrDefault(filme => filme.Id == id);

            if (filme is null)
            {
                return NotFound();
            }

            ReadFilmeDto readFilmeDto = mapper.Map<ReadFilmeDto>(filme);

            return Ok(readFilmeDto);
        }

        // POST api/<FilmesController>
        [HttpPost]
        public IActionResult CreateFilme([FromBody] CreateFilmeDto createFilmeDto)
        {
            Filme filme = mapper.Map<Filme>(createFilmeDto);
            context.Filmes.Add(filme);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        }

        // PUT api/<FilmesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
