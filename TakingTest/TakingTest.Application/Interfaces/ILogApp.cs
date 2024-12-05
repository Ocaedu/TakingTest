using TakingTest.Domain.Entities;

namespace TakingTest.Application.Interfaces
{
    public interface ILogApp
    {
        long Insert(LogEntity entity);
        LogEntity SelectById(long id);
        List<LogEntity> SelectAll();
    }
}
