using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Dtos
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }        
        public Guid StudentId { get; set; }
        public StudentDto Student { get; set; }


    }
}
