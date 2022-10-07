using School.Data.Entities.Base;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Data.Entities.Abstraction;

namespace School.Data.Entities
{
    public class StudentClass : BaseEntity
    {
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid ClassId { get; set; }
        public virtual Class Class { get; set; }        
       
    }
}
