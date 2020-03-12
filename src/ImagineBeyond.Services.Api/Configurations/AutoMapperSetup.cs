using System;
using AutoMapper;
using ImagineBeyond.Application.Customer.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ImagineBeyond.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {            
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile),
                typeof(RegisterNewCommandToCustomerViewModelMappingProfile), typeof(CustomerViewModelToRegisterNewCommandMappingProfile),
                typeof(UpdateCustomerCommandToCustomerViewModelMappingProfile), typeof(CustomerViewModelToUpdateCustomerCommandMappingProfile));            
        }
    }
}
