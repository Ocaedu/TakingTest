using AutoMapper;
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



            //CreateMap<SaleDTO, Sale>()
            // .ForMember(o => o.Id, b => b.MapFrom(z => z.Id))
            // .ForMember(o => o.Date, b => b.MapFrom(z => z.Date))
            // .ForMember(o => o.Client, b => b.MapFrom(z => z.Client))
            // .ForMember(o => o.SaleProducts, b => b.MapFrom(z => z.SaleProducts))
            // .ForMember(o => o.SalesFinalPrice, b => b.MapFrom(z => z.SalesFinalPrice))
            // .ForMember(o => o.Branch, b => b.MapFrom(z => z.Branch))
            // .ForMember(o => o.Canceled, b => b.MapFrom(z => z.Canceled));


            //.ForMember(o => o.UserName, b => b.MapFrom(user => (user.UserName != null) ? user.UserName : "User" + user.ID.ToString));

            //CreateMap<SaleDTO, Sale>()
            //.ForMember(vm => vm.Id, m => m.MapFrom(u => (u.Id != null)
            //                                   ? u.Id
            //                                   : "User" + u.ID.ToString()));

        }
    }
}
