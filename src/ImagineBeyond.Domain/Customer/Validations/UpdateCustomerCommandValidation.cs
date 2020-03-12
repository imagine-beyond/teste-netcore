using ImagineBeyond.Domain.Customer.Commands;

namespace ImagineBeyond.Domain.Customer.Validations
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidateEmail();
        }
    }
}
