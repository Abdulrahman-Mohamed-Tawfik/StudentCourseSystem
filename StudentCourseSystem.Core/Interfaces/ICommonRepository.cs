using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Core.Interfaces
{
    public interface ICommonRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task CreateRangeAsync(IEnumerable<TEntity> tutorialSteps);
        Task<TEntity> CreateAsync(TEntity entity);
        IQueryable<TEntity> OrderBy(IQueryable<TEntity> entities, string? orderBy, bool isAccending = true);
        Task<bool> DeletePhysicallyAsync(int id);
        Task<int> SaveChangesAsync();

        //**
        List<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> GetAllIQuarable(Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> GetAllQueryableInclude(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes);
        List<TEntity> GetAll();
    }
}
