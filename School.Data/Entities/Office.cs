using School.Data.Entities.Base;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
    public class Office : EntityId
    {
        public Office()
        {
            Professors = new HashSet<Professor>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalMembers { get ; set; }
        public virtual ICollection<Professor> Professors { get; set; }
    }
}
