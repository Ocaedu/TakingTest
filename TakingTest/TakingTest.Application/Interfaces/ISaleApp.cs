using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Application.DTO;
using TakingTest.Domain.Entities;

namespace TakingTest.Application.Interfaces
{
    public interface ISaleApp : IBaseApp<Sale, SaleDTO>
    {
    }
}
