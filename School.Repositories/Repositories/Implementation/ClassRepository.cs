using School.Data.Entities;
using School.Repositories.Contracts;
using School.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repositories.Implementation
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(SchoolDbContext context) : base(context)
        {

        }
    }
}
