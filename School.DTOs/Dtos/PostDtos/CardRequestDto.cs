using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Dtos.PostDtos
{
    public class CardRequestDto
    {        
        public int Code { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public Guid StudentId { get; set; }
        
    }
}
