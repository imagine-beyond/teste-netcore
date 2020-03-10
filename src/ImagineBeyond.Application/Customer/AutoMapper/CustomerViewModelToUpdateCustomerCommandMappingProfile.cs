using AutoMapper;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Customer.Commands;

namespace ImagineBeyond.Application.Customer.AutoMapper
{
    public class CustomerViewModelToUpdateCustomerCommandMappingProfile : Profile
    {
        public CustomerViewModelToUpdateCustomerCommandMappingProfile()
        {
            CreateMap<CustomerViewModel, UpdateCustomerCommand> ();
        }
    }
}
