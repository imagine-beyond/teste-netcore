using AutoMapper;
using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.ViewModel;
using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Customer.Commands;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagineBeyond.Application.Customer.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUoW _uoW;
        public CustomerAppService(IMapper mapper, IUoW uOw, ICustomerRepository customerRepository)
        {
            _uoW = uOw;
            _customerRepository = customerRepository;            
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerViewModel>> Get()
        {            
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            foreach (var customer in await _customerRepository.Get())
            {
                customers.Add(_mapper.Map<CustomerViewModel>(customer));
            }
            return customers;
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {                        
            var actual = await _customerRepository.GetById(id);
            var customer = _mapper.Map<CustomerViewModel>(actual);                        

            return customer;
        }

        public async Task CreateCostumer(CustomerViewModel costumerViewModel)
        {
            var costumer = _mapper.Map<RegisterNewCustomerCommand>(costumerViewModel);
            if (costumer.IsValid())
            {
                var customer = costumer.CreateCustommer();
                costumerViewModel.Id = customer.Id;
                await _customerRepository.Create(customer);
                _uoW.Commit();
            }
            else
            {
                throw new Exception("ValidationException. Mensagem de erro de validação");
            }                        
        }

        public async Task UpdateCostumer(CustomerViewModel costumerViewModel)
        {
            var customer = await _customerRepository.GetById(costumerViewModel.Id);
            var costumer = _mapper.Map<UpdateCustomerCommand>(costumerViewModel);

            if (customer != null && customer.Id == costumerViewModel.Id)
            {
                if (costumer.IsValid())
                {
                    await _customerRepository.Update(costumer.UpdateCustommer(customer));
                    _uoW.Commit();
                }
                else
                {
                    throw new Exception("ValidationException. Mensagem de erro de validação");
                }
            }
        }

        public async Task DeleteCostumer(Guid id)
        {
            var customer = await _customerRepository.GetById(id);
            await _customerRepository.Delete(customer);
            _uoW.Commit();
        }
    }
}