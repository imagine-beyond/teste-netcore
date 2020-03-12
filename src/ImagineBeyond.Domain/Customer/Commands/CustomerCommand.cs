using ImagineBeyond.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Customer.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Email { get; protected set; }

        public DateTime DateCreate { get; protected set; }
    }
}
