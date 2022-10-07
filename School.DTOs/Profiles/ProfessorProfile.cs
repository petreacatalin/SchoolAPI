using AutoMapper;
using School.Data.Entities;
using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<Professor, ProfessorDto>();
            CreateMap<ProfessorDto, Professor>();  

            CreateMap<Professor, ProfessorRequestDto>();
            CreateMap<ProfessorRequestDto, Professor>();              
                    
        }
    }
}
