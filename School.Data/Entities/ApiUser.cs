using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class ApiUser : IdentityUser
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? StudentId { get; set; }
        public Student Student { get; set; }
        public Guid? ProfessorId { get; set; }
        public Professor Professor { get; set; }

    }
}
