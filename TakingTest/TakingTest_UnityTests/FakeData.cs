using Bogus;

using TakingTest.Application.DTO;
using TakingTest.Domain.Entities;

namespace TakingTest_UnityTests
{
    public static class FakeData
    {

        public static Sale salesFake()
        {
            var entityFake = new Faker<Sale>("pt_BR")
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Branch, branchFake)
                .RuleFor(c => c.Client, clientFake)
                .RuleFor(c => c.Date, f => f.Date.Recent(100))
                .RuleFor(c => c.SalesFinalPrice, f => f.Random.Double(1, 500))
                .RuleFor(c => c.SaleProducts, salesProductFake);

            return entityFake;
        }


        public static SaleDTO salesDTOFake()
        {
            var entityFake = new Faker<SaleDTO>("pt_BR")
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Branch, 1)
                .RuleFor(c => c.Client, 1)
                .RuleFor(c => c.Date, f => f.Date.Recent(100))
                .RuleFor(c => c.SalesFinalPrice, f => f.Random.Double(1, 500))
                .RuleFor(c => c.SaleProducts, salesProductDTOFake);

            return entityFake;
        }

        public static List<SalesProductDTO> salesProductDTOFake()
        {
            var entityFake = new Faker<SalesProductDTO>("pt_BR")
                .RuleFor(c => c.Canceled, false)
                .RuleFor(c => c.IdProduct, 1)
                .RuleFor(c => c.IdSale, 1)
                .RuleFor(c => c.Quantity, f => f.Random.Int(1, 20));


            var result = entityFake.Generate(5);

            return result;
        }

        public static List<SalesProduct> salesProductFake()
        {
            var entityFake = new Faker<SalesProduct>("pt_BR")
                .RuleFor(c => c.Canceled, false)
                .RuleFor(c => c.ProductId, 1)
                .RuleFor(c => c.Product, productFake)
                .RuleFor(c => c.SaleId, 1)
                .RuleFor(c => c.Sale, new Sale())
                .RuleFor(c => c.Quantity, f => f.Random.Int(1, 20));

            var result = entityFake.Generate(5);

            return result;
        }

        public static Branch branchFake()
        {
            var entityFake = new Faker<Branch>("pt_BR")
                .RuleFor(c => c.Id, f => 1)
                .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female));
            return entityFake;
        }

        public static Client clientFake()
        {
            var entityFake = new Faker<Client>("pt_BR")
                .RuleFor(c => c.Id, f => 1)
                .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male));
            return entityFake;
        }

        public static Product productFake()
        {
            var entityFake = new Faker<Product>("pt_BR")
                .RuleFor(c => c.Id, f => 1)
                .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(c => c.Price, f => f.Random.Double(1, 500));

            return entityFake;
        }
    }
}
