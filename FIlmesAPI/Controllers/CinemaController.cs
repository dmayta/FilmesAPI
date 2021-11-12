using AutoMapper;
using FIlmesAPI.Data;
using FIlmesAPI.Data.DTOs.Cinema;
using FIlmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FIlmesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction("RecuperaCinemaPorId", new { Id = cinema.Id }, cinema);
        }


        [HttpGet]
        public IActionResult RecuperaCinema()
        {
            return Ok(_context.Cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema != null)
            {
                ReadCinemaDTO cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);
                return Ok(cinemaDto);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if(cinema == null)
            {
                return NotFound();
            }

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverFilme(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if(cinema == null)
            {
                return NotFound();
            }

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
