using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public long Insert(TEntity entity)
        {
            return repository.Insert(entity);
        }

        public TEntity SelectById(long id)
        {
            return repository.SelectById(id);
        }

        public List<TEntity> SelectAll()
        {
            return repository.SelectAll();
        }
    }
}
