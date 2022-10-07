﻿using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Dtos
{
    public class UserModelDto : LoginUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }        
        public Guid? StudentId { get; set; }
        public Guid? ProfessorId { get; set; }

    }
    public class LoginUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Password is limited to {2} to {1} characters.", MinimumLength = 5)]
        public string Password { get; set; }
    }

}
