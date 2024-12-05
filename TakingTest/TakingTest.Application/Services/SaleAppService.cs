using Serilog;
using TakingTest.Application.Interfaces;
using TakingTest.Domain.Entities;
using TakingTest.Application.DTO;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest.Application.Services
{
    public class SaleAppService : ISaleApp
    {
        protected readonly ISaleService saleService;
        protected readonly IBranchService branchService;
        protected readonly IClientService clientService;
        protected readonly IProductService productService;
        protected readonly ILogService logService;

        public SaleAppService(ISaleService saleService, IBranchService branchService, IClientService clientService, IProductService productService, ILogService logService)
        {
            this.saleService = saleService;
            this.branchService = branchService;
            this.clientService = clientService;
            this.productService = productService;
            this.logService = logService;
        }

        //Verify if an item was cancelled or the entire sale
        public void VerifyCanceled(List<SalesProduct> entity)
        {
            long idSale = 0;
            foreach (var item in entity)
            {
                if (item.Canceled == true)
                {
                    idSale = item.SaleId;
                    LogEntity logEntity = new LogEntity();
                    logEntity.Date = DateTime.Now;
                    logEntity.Event = "Item cancelled: sale - " + item.SaleId + "product - " + item.ProductId;
                    logService.Insert(logEntity);
                }
            }

            var saleStatus = entity.Count(a => a.Canceled==false);

            if(saleStatus == 0)
            {
                LogEntity logEntity = new LogEntity();
                logEntity.Date = DateTime.Now;
                logEntity.Event = "The sale - " + idSale + " was cancelled";
                logService.Insert(logEntity);
            }
            else
            {
                LogEntity logEntity = new LogEntity();
                logEntity.Date = DateTime.Now;
                logEntity.Event = "The sale - " + idSale + " was edited";
                logService.Insert(logEntity);
            }

        }

        public long VerifyQuantity(long quantity)
        {
            if (quantity > 20)
            {
                Log.Error("Quantity of any item cannot be greater than 20");
                throw new Exception("Quantity of any item cannot be greater than 20");
            }
            else
            {
                return quantity;
            }
        }

        public double VerifyDiscount(SalesProductDTO entity)
        {
            double returnValue = 0;

            if (entity.Quantity >= 10)
            {
                returnValue = 0.2;
            }
            else
            {
                returnValue = entity.Quantity >= 4 ? 0.1 : 0;
            }
            return returnValue;
        }

        public Sale getSale(SaleDTO entity)
        {
            double salesFinalPrice = 0;
            List<SalesProduct> salesProductList = new List<SalesProduct>();
            Sale sale = new Sale();

            sale.Id = entity.Id;
            sale.Branch = branchService.SelectById(entity.Branch);
            sale.Client = clientService.SelectById(entity.Client);
            sale.Date = entity.Date;

            foreach (var item in entity.SaleProducts)
            {
                SalesProduct salesProduct = new SalesProduct
                {
                    Quantity = VerifyQuantity(item.Quantity),
                    Discount = VerifyDiscount(item),
                    ProductId = item.IdProduct,
                    Product = productService.SelectById(item.IdProduct),
                    SaleId = entity.Id,
                    //Sale = saleService.SelectById(entity.Id),
                    Canceled = item.Canceled
                };
                salesFinalPrice = salesFinalPrice + salesProduct.Value;
                salesProductList.Add(salesProduct);
            }
            sale.SaleProducts = salesProductList;
            sale.SalesFinalPrice = salesFinalPrice;

            return sale;
        }

        public bool Update(SaleDTO entity)
        {
            var sale = getSale(entity);
            var result =  saleService.Update(sale);
            
            //Verifica se houve cancelamento de produto ou venda inteira
            if (result==true)
            {
                VerifyCanceled(sale.SaleProducts);
            }

            return result;
        }

        public bool Delete(SaleDTO entity)
        {
            return saleService.Delete(getSale(entity));
        }

        public bool Delete(long id)
        {
            return saleService.Delete(id);
        }

        public long Insert(SaleDTO entity)
        {
            var sale = getSale(entity);
            foreach (var item in sale.SaleProducts)
            {
                item.Canceled = false;
            }
            return saleService.Insert(sale);
        }

        public Sale SelectById(long id)
        {
            return saleService.SelectById(id);
        }
        public List<Sale> SelectAll()
        {
            return saleService.SelectAll();
        }




    }
}
