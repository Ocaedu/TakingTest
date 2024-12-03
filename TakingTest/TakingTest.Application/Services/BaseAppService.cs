using AutoMapper;
using TakingTest.Application.Interfaces;
using TakingTest.Domain.Entities;
using TakingTest.Application.DTO;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Application.Services
{
    public class BaseAppService<TEntity, TEntityDTO> : IBaseApp<TEntity, TEntityDTO>
        where TEntity : BaseEntity
        where TEntityDTO : BaseDTO
    {
        protected readonly IBaseService<TEntity> service;
        protected readonly IMapper iMapper;

        public BaseAppService(IBaseService<TEntity> service, IMapper iMapper)
        {
            this.service = service;
            this.iMapper = iMapper;
        }

        public void Update(TEntityDTO entity)
        {
            service.Update(iMapper.Map<TEntity>(entity));
        }

        public void Delete(TEntityDTO entity)
        {
            service.Delete(iMapper.Map<TEntity>(entity));
        }

        public void Delete(long id)
        {
            service.Delete(id);
        }

        public long Insert(TEntityDTO entity)
        {
            return service.Insert(iMapper.Map<TEntity>(entity));
        }

        public TEntityDTO SelectById(long id)
        {
            return iMapper.Map <TEntityDTO> (service.SelectById(id));
        }
        public List<TEntityDTO> SelectAll()
        {
            return iMapper.Map<List<TEntityDTO>>(service.SelectAll());
        }




    }
}
