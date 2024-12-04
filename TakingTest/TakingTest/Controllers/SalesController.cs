using Microsoft.AspNetCore.Mvc;
using TakingTest.Application.DTO;
using TakingTest.Application.Interfaces;
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleApp _service;
        private readonly ILogger<SalesController> _logger;

        public SalesController(ILogger<SalesController> logger, ISaleApp service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public long Insert([FromBody] SaleDTO request)
        {
            try
            {
                return _service.Insert(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
