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
    public class LogRepository : BaseRepository<LogEntity>, ILogRepository
    {
        public LogRepository(SaleContext context) : base(context) { }
    }
}
