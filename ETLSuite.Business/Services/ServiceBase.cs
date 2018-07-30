using ETLSuite.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETLSuite.Business.Services
{
    public abstract class ServiceBase
    {
        protected IUnitOfWork uow;

        public ServiceBase(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
