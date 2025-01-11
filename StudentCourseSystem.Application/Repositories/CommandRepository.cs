using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Repositories
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public CommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePhysicallyAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
