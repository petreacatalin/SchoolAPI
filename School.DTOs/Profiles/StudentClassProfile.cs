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
    public class StudentClassProfile : Profile
    {
        public StudentClassProfile()
        {
            CreateMap<StudentClass, StudentClassDto>();
            CreateMap<StudentClassDto, StudentClass>();                
            
        }
    }
}
