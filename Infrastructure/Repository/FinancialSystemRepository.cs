using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class FinancialSystemRepository : GenericsRepository<FinancialSystem>, InterfaceFinancialSystem
    {
        public Task<IList<FinancialSystem>> FinancialSystemUserList(string emailUser)
        {
            throw new NotImplementedException();
        }
    }
}
