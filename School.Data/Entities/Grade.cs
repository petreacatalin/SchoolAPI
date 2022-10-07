using School.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class Grade : EntityId
    {        
        public double Score { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Comment { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        

    }
}
