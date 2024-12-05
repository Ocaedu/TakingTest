
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
            var saleDTO = FakeData.salesDTOFake();

            //Act
            var result = controller.Insert(saleDTO);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void UpdateTest()
        {
            //Arrange
            var saleDTO = FakeData.salesDTOFake();

            //Act
            var result = controller.Update(saleDTO);

            //Assert
        }

    }
}
