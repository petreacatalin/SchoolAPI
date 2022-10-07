using System;

namespace School.Data.Entities.Abstraction
{
    public interface IEntityId
    {
        Guid? Id { get; set; }
        
    }
}