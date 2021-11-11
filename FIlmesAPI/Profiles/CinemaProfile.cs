using AutoMapper;
using FIlmesAPI.Data.DTOs.Cinema;
using FIlmesAPI.Models;

namespace FIlmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>();
            CreateMap<UpdateCinemaDTO, Cinema>();
        }
    }
}
