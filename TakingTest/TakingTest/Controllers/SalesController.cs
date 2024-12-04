using Microsoft.AspNetCore.Mvc;
using TakingTest.Application.DTO;
using TakingTest.Application.Interfaces;
using Serilog;


namespace TakingTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleApp _service;

        public SalesController( ISaleApp service)
        {
            _service = service;
        }

        [HttpPost]
        public long Insert([FromBody] SaleDTO request)
        {
            try
            {
                long idSale = _service.Insert(request);
                Log.Information("Sale id - " + idSale + " created");
                return _service.Insert(request);
            }
            catch (Exception ex)
            {
                Log.Error("Error creating new sale - " + ex.Message);
                throw ex;
            }
        }



    }
}
