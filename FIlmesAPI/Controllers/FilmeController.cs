using AutoMapper;
using FIlmesAPI.Data;
using FIlmesAPI.Data.DTOs;
using FIlmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FIlmesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes(int id)
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDTO filmeDto = _mapper.Map<ReadFilmeDTO>(filme);

                return Ok(filme);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO filmeDto) //FromBody - significa que vem do corpo da requisição
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme recuperarFilme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(recuperarFilme == null)
            {
                return NotFound();
            }
            _context.Remove(recuperarFilme);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
