using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFinancialSystemUser
{
    public interface InterfaceFinancialSystemUser : InterfaceGeneric<FinancialSystemUser>
    {
        Task<IList<FinancialSystemUser>> ListFinancialSystemsUsers(int systemId);
        Task RemoveUsers (List<FinancialSystemUser> users);
        Task<FinancialSystemUser> GetUsersByEmail(string emailUser);
    }
}
