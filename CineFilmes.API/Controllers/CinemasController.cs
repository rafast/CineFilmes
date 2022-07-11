using AutoMapper;
using CineFilmes.API.Data;
using CineFilmes.API.Data.Dtos.Cinema;
using CineFilmes.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CineFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly CineFilmesContext context;
        private readonly IMapper mapper;

        public CinemasController(CineFilmesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCinema([FromBody] CreateCinemaDto createCinemaDto)
        {
            Cinema novoCinema = mapper.Map<Cinema>(createCinemaDto);
            context.Cinemas.Add(novoCinema);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetCinemaById), new { id = novoCinema.Id }, novoCinema);
        }

        [HttpGet("{id}")]
        public IActionResult GetCinemaById(int id)
        {
            Cinema existingCinema = context.Cinemas.SingleOrDefault(cinema => cinema.Id == id);
            
            if (existingCinema is null)
            {
                return NotFound();
            }

            ReadCinemaDto readCinemaDto = mapper.Map<ReadCinemaDto>(existingCinema);

            return Ok(readCinemaDto);
        }

        [HttpGet]
        public IActionResult GetCinema()
        {
            List<Cinema> cinemas = context.Cinemas.ToList();

            if(cinemas is null)
            {
                return NotFound();
            }

            List<ReadCinemaDto> cinemaDtos = mapper.Map<List<ReadCinemaDto>>(cinemas);
            return Ok(cinemaDtos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            Cinema existingCinema = context.Cinemas.SingleOrDefault(cinema => cinema.Id == id);

            if (existingCinema is null)
            {
                return NotFound();
            }

            context.Cinemas.Remove(existingCinema);
            context.SaveChanges();

            return NoContent();
        }
        
    }
}
