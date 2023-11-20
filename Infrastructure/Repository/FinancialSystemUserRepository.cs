using Domain.Interfaces.IFinancialSystemUser;
using Entities.Entities;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class FinancialSystemUserRepository : GenericsRepository<FinancialSystemUser>, InterfaceFinancialSystemUser
    {
        public Task<IList<FinancialSystemUser>> FinancialSystemUsersList(int systemId)
        {
            throw new NotImplementedException();
        }

        public Task<FinancialSystemUser> GetUsersByEmail(string emailUser)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUsers(List<FinancialSystemUser> users)
        {
            throw new NotImplementedException();
        }
    }
}
