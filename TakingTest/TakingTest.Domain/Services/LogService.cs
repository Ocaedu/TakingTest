
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Domain.Services
{
    public class LogService : BaseService<LogEntity>, ILogService
    {
        public LogService(ILogRepository repository) : base(repository) { }
    }
}
