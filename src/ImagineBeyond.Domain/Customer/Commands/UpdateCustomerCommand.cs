using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Customer.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Customer.Commands
{    
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(Guid id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;            
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public CustomerEntity UpdateCustommer(CustomerEntity customerEntity)
        {            
            return customerEntity.Update(FirstName, LastName, Email);
        }
    }   
}
