using School.Data.Entities;
using School.Repositories.Contracts;
using School.Repositories.Implementation;
using School.Repositories.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repositories.Repositories.Implementation
{
    public class StudentClassRepository : Repository<StudentClass>, IStudentClassRepository
    {
        public StudentClassRepository(SchoolDbContext context) : base(context)
        {

        }
    }
}
