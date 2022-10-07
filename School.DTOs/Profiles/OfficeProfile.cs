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
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeDto>();
            CreateMap<OfficeDto, Office>()                
                .ForMember(dst => dst.Professors, map => map.Ignore());
            
            CreateMap<Office, OfficeRequestDto>();
            CreateMap<OfficeRequestDto, Office>();
        }
    }
}
