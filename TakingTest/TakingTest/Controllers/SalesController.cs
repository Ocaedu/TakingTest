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
                return idSale;
            }
            catch (Exception ex)
            {
                Log.Error("Error creating new sale - " + ex.Message);
                throw ex;
            }
        }

        [HttpDelete]
        public bool Delete(long idSale)
        {
            try
            {
                bool result = _service.Delete(idSale);
                Log.Information("Sale id - " + idSale + " deleted");
                return result;
            }
            catch (Exception ex)
            {
                Log.Error("Error deleting the sale - " + ex.Message);
                throw ex;
            }
        }



    }
}
