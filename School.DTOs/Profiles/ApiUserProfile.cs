using AutoMapper;
using School.Data.Entities;
using School.DTOs.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Profiles
{
    public class ApiUserProfile : Profile
    {
        public ApiUserProfile()
        {
            CreateMap<ApiUser, UserModelDto>();
            CreateMap<UserModelDto, ApiUser>();           
            
        }
        
    }
}
