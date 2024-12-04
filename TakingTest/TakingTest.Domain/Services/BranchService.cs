
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Domain.Services
{
    public class BranchService : BaseService<Branch>, IBranchService
    {
        public BranchService(IBranchRepository repository) : base(repository) { }


    }
}
