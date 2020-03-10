using ImagineBeyond.Repository.Context;
using ImagineBeyond.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineBeyond.Repository.UnitOfWork
{
    public class UnitOfWork : IUoW
    {
        private readonly InfraContext _infraContext;

        public UnitOfWork(InfraContext infraContext)
        {
            _infraContext = infraContext;
        }

        public bool Commit()
        {
            return _infraContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _infraContext.Dispose();
        }
    }
}
