using TakingTest.Application.DTO;
using TakingTest.Domain.Entities;

namespace TakingTest.Application.Interfaces
{
    public interface IBaseApp<TEntity, TEntityDTO>
        where TEntity : BaseEntity
        where TEntityDTO : BaseDTO
    {
        long Insert(TEntityDTO entity);
        void Delete(long id);
        void Delete(TEntityDTO entity);
        void Update(TEntityDTO entity);
        TEntityDTO SelectById(long id);
        List<TEntityDTO> SelectAll();
    }
}
