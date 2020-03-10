using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Repository.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImagineBeyond.Repository.Repository
{
    public class CustomerRepository : Repository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(InfraContext infraContext) : base(infraContext)
        {

        }        
    }
}
