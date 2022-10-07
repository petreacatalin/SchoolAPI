using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities.Abstraction
{
     public interface IUserInfo
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        DateTimeOffset Birthdate { get; set; }
    }
}
