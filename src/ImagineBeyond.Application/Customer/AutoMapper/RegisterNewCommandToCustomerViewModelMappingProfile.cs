using AutoMapper;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Customer.Commands;

namespace ImagineBeyond.Application.Customer.AutoMapper
{
    public class RegisterNewCommandToCustomerViewModelMappingProfile : Profile
    {
        public RegisterNewCommandToCustomerViewModelMappingProfile()
        {
            CreateMap<RegisterNewCustomerCommand, CustomerViewModel>();
        }
    }
}
