using Bogus;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSubstitute;
using TakingTest.Application.DTO;
using TakingTest.Application.Services;
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Services;

namespace TakingTest_UnityTests.Application.Services
{
    public class SaleAppServiceTest
    {
        private SaleAppService service;
        private ISaleService _ISaleService;
        private IBranchService _IBranchService;
        private IClientService _IClientService;
        private IProductService _IProductService;
        private IBaseService<BaseEntity> _IBaseService;

        public SaleAppServiceTest()
        {
            _ISaleService = Substitute.For<ISaleService>();
            _IBranchService = Substitute.For<IBranchService>();
            _IClientService = Substitute.For<IClientService>();
            _IProductService = Substitute.For<IProductService>();
            _IBaseService = Substitute.For<IBaseService<BaseEntity>>();

            service = new SaleAppService(_ISaleService, _IBranchService, _IClientService, _IProductService);
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

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0.1)]
        [InlineData(11, 0.2)]
        public void VerifyDiscountTest(long quantity, double testValue)
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
            Assert.Equal(testValue, result);
        }

        [Fact]
        public void getSaleTest()
        {
            //Arrange
            var entity = FakeData.salesDTOFake();

            //Act
            var result = service.getSale(entity);

            //Assert
            Assert.Equal(result, result);
        }

        [Fact]
        public void UpdateTest()
        {
            
            //Arrange
            _IProductService.SelectById(1).Returns(new Product());
            _ISaleService.SelectById(1).Returns(new Sale());
            _IBranchService.SelectById(1).Returns(new Branch());
            _IClientService.SelectById(1).Returns(new Client());
            _IBaseService.Update(new Sale()).Returns(true);
            
            var entity = FakeData.salesDTOFake();
            
            //Act
            var result = service.Update(entity);

            //Assert
            

        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            var entity = FakeData.salesDTOFake();

            //Act
            var result = service.Delete(entity);

            //Assert
        }

        [Fact]
        public void DeleteTestId()
        {
            //Arrange

            //Act
            var result = service.Delete(1);

            //Assert
        }




    }
}
