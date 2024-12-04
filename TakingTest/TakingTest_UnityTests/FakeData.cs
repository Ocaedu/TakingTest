﻿using Bogus;

using TakingTest.Application.DTO;
using TakingTest.Domain.Entities;

namespace TakingTest_UnityTests
{
    public static class FakeData
    {
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
    }
}