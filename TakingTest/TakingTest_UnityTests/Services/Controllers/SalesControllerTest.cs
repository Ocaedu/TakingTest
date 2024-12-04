
using TakingTest.Controllers;
using Moq;
using TakingTest.Application.Interfaces;
using TakingTest.Domain.Entities;
using TakingTest.Application.DTO;

namespace TakingTest_UnityTests.Services.Controllers
{
    public class SalesControllerTest
    {
        private SalesController controller;
        private Mock<ISaleApp> _ISaleApp;


        public SalesControllerTest()
        {
            _ISaleApp = new Mock<ISaleApp>();
            controller = new SalesController(_ISaleApp.Object);
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
