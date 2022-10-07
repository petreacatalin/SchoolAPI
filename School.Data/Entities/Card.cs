using School.Data.Entities.Base;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class Card : EntityId
    {
        public int Code { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }        

    }
}
