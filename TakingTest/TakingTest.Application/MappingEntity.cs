using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Application.DTO;
using TakingTest.Domain.Entities;

namespace TakingTest.Application
{
    public class MappingEntity : Profile
    {
        public MappingEntity() 
        {
            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleDTO, Sale>();
        }
    }
}
