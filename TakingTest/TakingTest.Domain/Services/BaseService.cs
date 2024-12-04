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

        public bool Update(TEntity entity)
        {
            try
            {
                repository.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                repository.Delete(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try 
            {
                repository.Delete(id);
                return true;
            }
            catch 
            { 
                return false; 
            }
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
