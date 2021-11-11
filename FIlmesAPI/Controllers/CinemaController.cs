using AutoMapper;
using FIlmesAPI.Data;
using FIlmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIlmesAPI.Controllers
{
    [Route("controller")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] Cinema cinema)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinema);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction("RecuperaCinemaPorId", new { Id = cinema.Id }, cinema);
        }



    }
}
