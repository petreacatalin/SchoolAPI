
using Microsoft.AspNetCore.Mvc;
using School.Data.Entities;
using School.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace School.Data.Entities
{
    public class Class : EntityId
    {
        public Class()
        {
            StudentClasses = new HashSet<StudentClass>();
            Professors = new HashSet<Professor>();
        }
        
        public int Code { get; set; }        
        public string Title { get; set; }
        public string Location { get; set; }
        public int Duration { get; set; }
        public int Credits { get; set; }        
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }


    }
}
