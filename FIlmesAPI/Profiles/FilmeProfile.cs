using AutoMapper;
using FIlmesAPI.Data.DTOs;
using FIlmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIlmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<UpdateFilmeDTO, Filme>();
        }
    }
}
