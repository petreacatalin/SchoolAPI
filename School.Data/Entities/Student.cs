using School.Data.Entities;
using School.Data.Entities.Abstraction;
using School.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class Student : EntityId, IUserInfo
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            StudentClasses = new HashSet<StudentClass>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Birthdate { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset EnrollmentDate { get; set; }        
        public Card Card { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
