using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Dtos
{
    public class ClassDto
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public int Credits { get; set; }
        
    }
}
