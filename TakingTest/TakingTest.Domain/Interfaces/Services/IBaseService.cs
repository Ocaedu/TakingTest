using TakingTest.Domain.Entities;

namespace TakingTest.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        long Insert(TEntity entity);
        void Delete(long id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity SelectById(long id);
        List<TEntity> SelectAll();
    }
}
