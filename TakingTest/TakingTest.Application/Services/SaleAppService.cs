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

        public SaleAppService(ISaleService saleService, IBranchService branchService, IClientService clientService, IProductService productService)
        {
            this.saleService = saleService;
            this.branchService = branchService;
            this.clientService = clientService;
            this.productService = productService;
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
                    Product = productService.SelectById(item.IdProduct),
                    Sale = saleService.SelectById(item.IdSale),
                    Canceled = false
                };
                salesFinalPrice = salesFinalPrice + salesProduct.Value;
                salesProductList.Add(salesProduct);
            }
            sale.SaleProducts = salesProductList;
            sale.SalesFinalPrice = salesFinalPrice;

            return sale;
        }

        public void Update(SaleDTO entity)
        {

        }

        public void Delete(SaleDTO entity)
        {
            saleService.Delete(getSale(entity));
        }

        public void Delete(long id)
        {
            saleService.Delete(id);
        }

        public long Insert(SaleDTO entity)
        {

            return saleService.Insert(getSale(entity));
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
