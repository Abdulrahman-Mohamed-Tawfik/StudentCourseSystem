using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces
{
    public interface ICommandRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> DeletePhysicallyAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
