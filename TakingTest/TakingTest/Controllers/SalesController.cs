using Microsoft.AspNetCore.Mvc;
using TakingTest.Application.DTO;
using TakingTest.Application.Interfaces;
using Serilog;
using TakingTest.Domain.Entities;


namespace TakingTest.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleApp _service;

        public SalesController( ISaleApp service)
        {
            _service = service;
        }

        [HttpPost(Name = "Insert")]
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

        [HttpPost(Name = "Update")]
        public bool Update([FromBody] SaleDTO request)
        {
            try
            {
                var result = _service.Update(request);
                Log.Information("Sale id - " + request.Id + " edited");
                return result;
            }
            catch (Exception ex)
            {
                Log.Error("Error updating the sale - " + request.Id + "" + ex.Message);
                throw ex;
            }
        }



    }
}
