using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImagineBeyond.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(Guid id);

        int SaveChanges();
    }
}
