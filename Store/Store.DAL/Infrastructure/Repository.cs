﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MarketDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MarketDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Insert(TEntity entity) => _dbSet.Add(entity);

        public async Task InsertRange(IEnumerable<TEntity> entities) => await _dbSet.AddRangeAsync(entities);

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AttachRange(entities);
            _dbSet.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            //TODO add States
            _context.Entry(entity).State = EntityState.Deleted;
            _dbSet.Attach(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AttachRange(entities);
            _dbSet.RemoveRange(entities);
        }

        public TEntity GetById(object id) => _dbSet.Find(id);

        public IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int skip = 0, int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            orderBy?.Invoke(query);

            if (skip != 0)
                query = query
                    .Skip(skip);

            if (take.HasValue)
                query.Take(take.Value);

            return query.AsNoTracking();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }
    }
}
