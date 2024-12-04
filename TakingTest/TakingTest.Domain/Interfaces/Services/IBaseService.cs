using TakingTest.Domain.Entities;

namespace TakingTest.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        long Insert(TEntity entity);
        bool Delete(long id);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        TEntity SelectById(long id);
        List<TEntity> SelectAll();
    }
}
