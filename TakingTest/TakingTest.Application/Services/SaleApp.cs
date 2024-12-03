using TakingTest.Application.Interfaces;
using TakingTest.Domain.Entities;
using TakingTest.Application.DTO;
using AutoMapper;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Application.Services
{
    public class SaleApp : BaseAppService<Sale, SaleDTO>, ISaleApp
    {
        public SaleApp(IMapper iMapper, ISaleService service) 
            : base(service, iMapper )
        {

        }
    }
}
