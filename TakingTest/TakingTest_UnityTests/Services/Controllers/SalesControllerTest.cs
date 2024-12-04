
using TakingTest.Controllers;
using NSubstitute;
using TakingTest.Application.Interfaces;
using TakingTest.Domain.Entities;
using TakingTest.Application.DTO;

namespace TakingTest_UnityTests.Services.Controllers
{
    public class SalesControllerTest
    {
        private readonly SalesController controller;
        private readonly ISaleApp _ISaleApp;


        public SalesControllerTest()
        {
            _ISaleApp = Substitute.For<ISaleApp>();
            controller = new SalesController(_ISaleApp);
        }

        [Fact]
        public void InsertTest()
        {
            //Arrange
            SaleDTO SaleDTO = new SaleDTO();

            //Act
            var result = controller.Insert(SaleDTO);

            //Assert
            Assert.Equal(0, result);
        }

    }
}
