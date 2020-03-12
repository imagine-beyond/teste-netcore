using AutoMapper;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Customer.Entity;

namespace ImagineBeyond.Application.Customer.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, CustomerEntity>();
        }
    }
}
