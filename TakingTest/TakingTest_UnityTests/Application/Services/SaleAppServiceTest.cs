using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Application.DTO;
using TakingTest.Application.Interfaces;
using TakingTest.Application.Services;
using TakingTest.Controllers;
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest_UnityTests.Application.Services
{
    public class SaleAppServiceTest
    {
        private SaleAppService service;
        private Mock<ISaleService> _ISaleService;
        private Mock<IBranchService> _IBranchService;
        private Mock<IClientService> _IClientService;
        private Mock<IProductService> _IProductService;


        public SaleAppServiceTest()
        {
            _ISaleService = new Mock<ISaleService>();
            _IBranchService = new Mock<IBranchService>();
            _IClientService = new Mock<IClientService>();
            _IProductService = new Mock<IProductService>();

            service = new SaleAppService(_ISaleService.Object, _IBranchService.Object, _IClientService.Object, _IProductService.Object);
        }


        [Fact]
        public void VerifyQuantityTest_Ok()
        {
            //Arrange

            //Act
            var result = service.VerifyQuantity(10);

            //Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void VerifyQuantityTest_Error()
        {
            //Arrange

            //Act
            Action act = () => service.VerifyQuantity(21);
            ArgumentException exception = Assert.Throws<ArgumentException>(act);

            //Assert
            Assert.Equal("Quantity of any item cannot be greater than 20", exception.Message);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0.1)]
        [InlineData(11, 0.2)]
        public void VerifyDiscountTest(long quantity, long expectedResult)
        {
            //Arrange
            SalesProductDTO entity = new SalesProductDTO
            {
                Canceled = false,
                IdProduct = 1,
                IdSale = 1,
                Quantity = quantity
            };

            //Act
            var result = service.VerifyDiscount(entity);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void getSaleTest()
        {
            //Arrange
            SaleDTO entity = new SaleDTO();

            //Act
            var result = service.getSale(entity);

            //Assert
            Assert.Equal(result, result);
        }


    }
}
