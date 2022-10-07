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
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            CreateMap<Student, StudentRequestDto>();
            CreateMap<StudentRequestDto, Student>()      
                .ForMember(dst => dst.StudentClasses, map => map.MapFrom(src => src.StudentClasses));
        }
    }
}
