using AutoMapper;
using FIlmesAPI.Data;
using FIlmesAPI.Data.DTOs.Endereco;
using FIlmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIlmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;


        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDTO enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult RecuperarEndereco()
        {
            return Ok(_context.Enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null)
            {
                ReadEnderecoDTO enderecoDto = _mapper.Map<ReadEnderecoDTO>(endereco);
                return Ok(enderecoDto);
            }
            else
            {
                return NotFound();
            }
            
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if(endereco == null)
            {
                return NotFound();
            }

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        public IActionResult DeletarEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if(endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return Ok();
        }
    }
}
