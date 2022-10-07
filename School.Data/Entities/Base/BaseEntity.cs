using School.Data.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public bool IsDeleted { get; set; }
    }
}
