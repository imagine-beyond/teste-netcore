using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagineBeyond.Repository.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly InfraContext InfraContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(InfraContext infraContext)
        {
            InfraContext = infraContext;
            DbSet = InfraContext.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            Action create = () =>
            {
                DbSet.Add(entity);                
            };

            await Task.Run(create);
        }

        public async Task Delete(TEntity entity)
        {
            Action delete = () =>
            {
                DbSet.Remove(entity);
            };

            await Task.Run(delete);
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            IQueryable<TEntity> objs = null;
            Action get = () =>
            {
                objs = DbSet;
            };

            await Task.Run(get);

            return objs;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            TEntity entity = null;

            Action getById = () =>
            {
                entity = DbSet.Find(id);
            };

            await Task.Run(getById);

            return entity;
        }

        public async Task Update(TEntity entity)
        {
            Action update = () =>
            {
                DbSet.Update(entity);                
            };

            await Task.Run(update);
        }

        public int SaveChanges()
        {
            return InfraContext.SaveChanges();
        }
    }
}
