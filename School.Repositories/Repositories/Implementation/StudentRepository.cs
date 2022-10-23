using School.Repositories;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Repositories.Implementation;
using School.Repositories.Contracts;

namespace School.Repositories.Implementation
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolDbContext context) : base(context)
        {

        }
    }
}
