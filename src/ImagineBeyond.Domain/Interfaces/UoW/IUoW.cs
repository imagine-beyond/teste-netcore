using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Domain.Interfaces.UoW
{
    public interface IUoW : IDisposable
    {
        bool Commit();
    }
}
