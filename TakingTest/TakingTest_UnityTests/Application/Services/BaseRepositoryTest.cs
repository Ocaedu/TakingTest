using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Domain.Entities;
using TakingTest.Infra.Repositories;
using TakingTest.Infra.Contexts;
using NSubstitute;

namespace TakingTest_UnityTests.Application.Services
{

    public class BaseRepositoryTest
    {
        private BaseRepository<Sale> service;
        private SaleContext _context;

        public BaseRepositoryTest()
        {
            _context = Substitute.For<SaleContext>();
            service = new BaseRepository<Sale>(_context);
        }

        [Fact]
        public void UpdateTest()
        {
            //Arrange
            Sale sale = new Sale();

            //Act
             service.Update(sale);

            //Assert
        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            Sale sale = new Sale();

            //Act
            service.Delete(sale);

            //Assert
        }

        [Fact]
        public void DeleteIdTest()
        {
            //Arrange
            Sale sale = new Sale();

            //Act
            service.Delete(1);

            //Assert
        }


    }
}
