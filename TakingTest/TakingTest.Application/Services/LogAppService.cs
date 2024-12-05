using Serilog;
using TakingTest.Application.Interfaces;
using TakingTest.Domain.Entities;
using TakingTest.Application.DTO;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Application.Services
{
    public class LogAppService : ILogApp
    {
        protected readonly ILogService logService;

        public LogAppService(ILogService logService)
        {
            this.logService = logService;
        }

        public long Insert(LogEntity entity)
        {
            return logService.Insert(entity);
        }

        public LogEntity SelectById(long id)
        {
            return logService.SelectById(id);
        }
        public List<LogEntity> SelectAll()
        {
            return logService.SelectAll();
        }




    }
}
