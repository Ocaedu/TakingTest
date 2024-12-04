
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Domain.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        public ClientService(IClientRepository repository) : base(repository) { }


    }
}
