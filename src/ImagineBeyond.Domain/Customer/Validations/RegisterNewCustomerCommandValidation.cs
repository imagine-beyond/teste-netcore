using ImagineBeyond.Domain.Customer.Commands;

namespace ImagineBeyond.Domain.Customer.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidateEmail();
        }
    }
}
