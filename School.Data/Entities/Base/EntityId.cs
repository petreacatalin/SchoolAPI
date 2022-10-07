using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Data.Entities.Abstraction;

namespace School.Data.Entities.Base
{
    public class EntityId : BaseEntity,IEntityId
    {
        public Guid? Id { get; set; }
        
    }
}
