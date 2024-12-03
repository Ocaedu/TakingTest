using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Domain.Entities;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Infra.Contexts;

namespace TakingTest.Infra.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(SaleContext context) : base(context) { }
    }
}
