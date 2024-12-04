using AutoMapper;
using TakingTest.Application.Interfaces;
using TakingTest.Domain.Entities;
using TakingTest.Application.DTO;
using TakingTest.Domain.Interfaces.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


        private long VerifyDiscount(List<SalesProductDTO> entity)
        {
            var result = entity.GroupBy(c => c.IdProduct)
                        .Select(gp => new
                        {
                            IdProduct = gp.Key,
                            Quantity = gp.Sum(c => c.Quantity)
                        });

            //foreach (var item in entity.OrderBy()
            //{

            //}
                return 1;
        }

        private Sale getSale(SaleDTO entity)
        {
            decimal salesFinalPrice = 0;
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
                    Id = item.Id,
                    Discount = VerifyDiscount(entity.SaleProducts),
                    Product = productService.SelectById(item.IdProduct),
                    Quantity = item.Quantity,
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
