using AutoMapper;
using School.Data.Entities;
using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDto>()
                .ForMember(dst => dst.Student, map => map.MapFrom(src => src.Student == null ? null : src.Student));
            CreateMap<CardDto, Card>();
            
            CreateMap<Card, CardRequestDto>();
            CreateMap<CardRequestDto, Card>();
                
        }
    }
}
