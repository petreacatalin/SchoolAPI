using School.DTOs.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.AuthManager
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserModel loginUserModel);
        Task<string> CreateToken();
    }
}
