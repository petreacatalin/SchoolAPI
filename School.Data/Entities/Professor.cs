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
    public class Professor : EntityId, IUserInfo
    {
        public Professor()
        {            
            Grades = new HashSet<Grade>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Birthdate { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset HireDate { get; set; }
        public Guid OfficeId { get; set; }       
        public Guid ClassId { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }
        public Office Office { get; set; }       
        public Class Class { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }


    }
}
