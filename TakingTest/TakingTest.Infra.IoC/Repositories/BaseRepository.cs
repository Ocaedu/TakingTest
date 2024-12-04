using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Infra.Contexts;

namespace TakingTest.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        protected readonly SaleContext context;

        public BaseRepository(SaleContext context) : base()
        {
            this.context = context;
        }

        public void Update(TEntity entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = SelectById(id);
            if (entity != null)
            {
                context.Remove(entity);
                context.SaveChanges();
            }
            Log.Information("Sale id - " + id + "created");
        }

        public long Insert(TEntity entity)
        {
            var newEntity = context.Set<TEntity>().Add(entity).Entity;
            context.SaveChanges();
            var id = newEntity.Id;
   
            return id;
        }

        public TEntity SelectById(long id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> SelectAll()
        {
            return context.Set<TEntity>().ToList();
        }

    }
}
