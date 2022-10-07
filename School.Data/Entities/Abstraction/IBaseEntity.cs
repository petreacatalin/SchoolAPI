namespace School.Data.Entities.Abstraction
{
    public interface IBaseEntity
    {
        bool IsDeleted { get; set; }
    }
}