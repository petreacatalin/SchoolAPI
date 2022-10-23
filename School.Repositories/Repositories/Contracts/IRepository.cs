using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace School.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        void Delete(TEntity entity);
        void Dispose();
        IQueryable<TEntity> GetAll(int? skip = null, int? take = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true);

        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true, bool ignoreQueryFilters = false);

        void Update(TEntity entity);
    }
}