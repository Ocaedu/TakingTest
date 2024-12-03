
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Domain.Services
{
    public class SaleService : BaseService<Sale>, ISaleService
    {
        public SaleService(ISaleRepository repository) : base(repository) { }


    }
}
