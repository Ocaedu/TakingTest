using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Application.DTO;
using TakingTest.Domain.Entities;

namespace TakingTest.Application.Interfaces
{
    public interface ISaleApp
    {
        long Insert(SaleDTO entity);
        void Delete(long id);
        void Delete(SaleDTO entity);
        void Update(SaleDTO entity);
        Sale SelectById(long id);
        List<Sale> SelectAll();

    }
}
