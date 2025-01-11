using Microsoft.EntityFrameworkCore;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Repositories
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public QueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_context.Set<TEntity>());

        }

        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (filter != null) query = query.Where(filter);

            return await Task.FromResult(query);
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (filter != null) query = query.Where(filter);

            return query.ToList();
        }

        public IQueryable<TEntity> GetAllQueryableInclude(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var include in includes) query = query.Include(include);

            if (filter != null) query = query.Where(filter);
            return query;
        }

        public IQueryable<TEntity> OrderBy(IQueryable<TEntity> entities, string? orderBy, bool isAccending = true)
        {
            return entities;
        }

        
    }
}
