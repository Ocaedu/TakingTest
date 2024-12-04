
using TakingTest.Domain.Interfaces.Repositories;
using NSubstitute;
using Moq;
using TakingTest.Domain.Entities;
using TakingTest.Domain.Services;

namespace TakingTest_UnityTests.Application.Services
{

    public class BaseServiceTest
    {
        private BaseService<Sale> service;
        private IBaseRepository<Sale> _IBaseRepository;

        public BaseServiceTest()
        {
            _IBaseRepository = Substitute.For<IBaseRepository<Sale>>();
            service = new BaseService<Sale>(_IBaseRepository);
            
        }

        [Fact]
        public void UpdateTest()
        {
            //Arrange
            var sale = FakeData.salesFake();

            //Act
            var result = service.Update(sale);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            var sale = FakeData.salesFake();

            //Act
            var result = service.Delete(sale);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteIdTest()
        {
            //Arrange
            var sale = FakeData.salesFake();

            //Act
            var result = service.Delete(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void InsertTest()
        {
            //Arrange
            var sale = FakeData.salesFake();

            //Act
            var result = service.Insert(sale);

            //Assert
            Assert.Equal(0, result);
        }

    }
}
