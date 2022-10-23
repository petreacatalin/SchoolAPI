using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using School.Data.Entities.Abstraction;
using School.Data.Entities.Base;
using School.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Repositories.Implementation
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class, IBaseEntity, new()
    {
        protected readonly SchoolDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(SchoolDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll(int? skip = null, int? take = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null) query = include(query);

            if (filter != null) query = query.Where(filter);

            if (orderBy != null) query = orderBy(query);

            if (skip.HasValue) query = query.Skip(skip.Value);

            if (take.HasValue) query = query.Take(take.Value);
            if (!enableTracking) query = query.AsNoTracking();

            return query;
        }
        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!enableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (filter != null) query = query.Where(filter);

            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

            return orderBy != null ? await orderBy(query).SingleOrDefaultAsync() : await query.SingleOrDefaultAsync();
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task InsertAsync(params TEntity[] entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }       
        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(params TEntity[] entities)
        {
            _dbSet.UpdateRange(entities);
        }
      
        public virtual void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);            
        }       
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
