using Microsoft.EntityFrameworkCore.Storage;
using School.Repositories.Contracts;
using School.Repositories.Implementation;
using School.Repositories.Repositories.Contracts;
using School.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Repositories.Repositories.Implementation;

namespace School.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly SchoolDbContext _context;
        public ICardRepository CardRepository { get; private set; }
        public IClassRepository ClassRepository { get; private set; }       
        public IGradeRepository GradeRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }
        public IOfficeRepository OfficeRepository { get; private set; }
        public IProfessorRepository ProfessorRepository { get; private set; }       
        public IStudentClassRepository StudentClassRepository { get; private set; }       

        IDbContextTransaction _transaction;

        public UnitOfWork(SchoolDbContext context)
        {
            _context = context;
            CardRepository = new CardRepository(context);
            ClassRepository = new ClassRepository(context);           
            GradeRepository = new GradeRepository(context);
            StudentRepository = new StudentRepository(context);
            OfficeRepository = new OfficeRepository(context);
            ProfessorRepository = new ProfessorRepository(context);
            StudentClassRepository = new StudentClassRepository(context);
            
        }
        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
            else
            {
                throw new Exception("A transaction is already in progress");
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new Exception("There is no transaction to commit");
            }

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }

        public async Task RollBackTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new Exception("There is no transaction to rollback");
            }

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            CardRepository?.Dispose();
            ClassRepository?.Dispose();           
            GradeRepository?.Dispose();
            StudentRepository?.Dispose();
            OfficeRepository?.Dispose();
            ProfessorRepository?.Dispose();
            StudentClassRepository?.Dispose();
            
        }
    }
}
