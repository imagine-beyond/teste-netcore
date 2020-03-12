using ImagineBeyond.Customer.Entity;
using ImagineBeyond.Domain.Customer.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Customer.Commands
{    
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(string firstName, string lastName, string email)
        {            
            FirstName = firstName;
            LastName = lastName;
            Email = email;            
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public CustomerEntity CreateCustommer()
        {
            return new CustomerEntity(FirstName, LastName, Email);
        }
    }   
}
