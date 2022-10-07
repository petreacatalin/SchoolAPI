using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTOs.Dtos
{
    public class GradeDto
    {
        public Guid Id { get; set; }
        public double Score { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Comment { get; set; }
        public Guid StudentId { get; set; }
        public Guid ProfessorId { get; set; }
        
    }
}
