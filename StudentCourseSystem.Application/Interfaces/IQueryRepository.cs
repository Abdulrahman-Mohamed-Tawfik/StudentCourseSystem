using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces
{
    public interface IQueryRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<IQueryable<TEntity>> GetAllAsync();
        List<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> GetAllQueryableInclude(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> OrderBy(IQueryable<TEntity> entities, string? orderBy, bool isAccending = true);
    }
}
