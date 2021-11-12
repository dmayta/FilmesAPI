using AutoMapper;
using FIlmesAPI.Data.DTOs.Endereco;
using FIlmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIlmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<ReadEnderecoDTO, Endereco>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
        }
    }
}
