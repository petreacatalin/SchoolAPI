using School.Repositories.Contracts;
using School.Repositories.Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace School.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository CardRepository { get; }
        IClassRepository ClassRepository { get; }        
        IGradeRepository GradeRepository { get; }
        IOfficeRepository OfficeRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        IStudentRepository StudentRepository { get; }
        IStudentClassRepository StudentClassRepository { get; }

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();        
        Task RollBackTransactionAsync();
        Task SaveAsync();
    }
}